using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ClipCSV
{
    public static class HtmlStaticHelper
    {
        public static string SimpleHeader(string cls = "t1")
        {
            return $"<head><style>{SimpleTableStyle(cls)}</style></head>";
        }

        public static string SimpleTableStyle(string cls = "t1")
        {
            var style = new[]
            {
                $".{cls} table, .{cls} td, .{cls} th {{",
                "    border:solid 1px black;",
                "    border-collapse:collapse;",
                "}"
            };

            var builder = new StringBuilder();
            foreach (var line in style)
            {
                builder.AppendLine(line);
            }
            return builder.ToString();
        }
    }

    internal class HtmlHelper<T> where T : class
    {
        private static List<HtmlProperty> htmlPropertyList = new List<HtmlProperty>();

        static HtmlHelper()
        {
            htmlPropertyList = (from property in typeof(T).GetProperties()
                                let htmlRowAttribute = Attribute.GetCustomAttribute(property, typeof(HtmlRowAttribute)) as HtmlRowAttribute
                                where htmlRowAttribute != null
                                let getter = MakeDelegate<T>(property.GetMethod)
                                select new HtmlProperty { Getter = getter, Name = htmlRowAttribute.Name, Order = htmlRowAttribute.Order }).
                                OrderBy(x => x.Order).ToList();
            Console.WriteLine();
        }

        public string GetHeader()
        {
            return $"<tr><th>{string.Join("</th><th>", htmlPropertyList.Select(x => x.Name))}</th></tr>";
        }

        public string GetRow(T instance)
        {
            return $"<tr><td>{string.Join("</td><td>", htmlPropertyList.Select(x => x.Getter(instance)))}</td></tr>";
        }

        private static Func<T2, object> MakeDelegate<T2>(MethodInfo method) where T2 : class
        {
            // First fetch the generic form
            MethodInfo genericHelper = typeof(HtmlHelper<T>).GetMethod("MakeDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod(typeof(T), method.ReturnType);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Func<T2, object>)ret;
        }

        private static Func<TTarget, object> MakeDelegateHelper<TTarget, TReturn>(MethodInfo method)
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Func<TTarget, TReturn> func = (Func<TTarget, TReturn>)
                Delegate.CreateDelegate(typeof(Func<TTarget, TReturn>), method);
            // Now create a more weakly typed delegate which will call the strongly typed one
            Func<TTarget, object> ret = (TTarget target) => func(target);
            return ret;
        }
        private class HtmlProperty
        {
            public Func<T, object> Getter { get; set; }
            public string Name { get; set; }
            public int Order { get; set; }
        }
    }

    internal class HtmlRowAttribute : System.Attribute
    {
        public HtmlRowAttribute(int order, string name = "")
        {
            Order = order;
            Name = name;
        }

        public string Name { get; private set; }
        public int Order { get; private set; }
    }
}