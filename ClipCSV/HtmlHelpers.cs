using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClipCSV
{
    class HtmlRowAttribute : System.Attribute
    {
        public int Order { get; private set; }
        public string Name { get; private set; }
        public HtmlRowAttribute(int order, string name = "")
        {
            Order = order;
            Name = name;
        }
    }

    class HtmlHelper<T>
    {
        static List<HtmlProperty> htmlPropertyList = new List<HtmlProperty>();
        static HtmlHelper()
        {
            var htmlPropertyList = (from property in typeof(T).GetProperties()
                                    let htmlRowAttribute = Attribute.GetCustomAttribute(property, typeof(HtmlRowAttribute)) as HtmlRowAttribute
                                    where htmlRowAttribute != null
                                    select new HtmlProperty { Property = property, Name = htmlRowAttribute.Name, Order = htmlRowAttribute.Order }).
                                    OrderBy(x => x.Order);


        }

        string GetHeader()
        {
            return $"<tr><th>{string.Join("</th><td>", htmlPropertyList.Select(x => x.Name))}</th></tr>"; 
        }

        string GetRow(T instance)
        {
            return $"<tr><th>{string.Join("</th><td>", htmlPropertyList.Select(x => x.Property.GetMethod.Invoke(instance, null)))}</th></tr>";
        }
    }

    class HtmlProperty
    {
        public PropertyInfo Property { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
