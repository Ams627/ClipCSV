using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ClipCSV
{
    class Person
    {
        [HtmlRow(10, "Hello")]
        public int Id { get; set; }
        [HtmlRow(15, "World")]
        public string Name { get; set; }
        [HtmlRow(15, "Frank")]
        public string Address { get; set; }
    }
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                //var html = HExample.Get1();


                var hHelper = new HtmlHelper<Person>();
                var people = new[]
                {
                    new Person {Name = "John Smith", Address = "44 Acacia Avenue", Id = 100},
                    new Person {Name = "John Anderson", Address = "10 Wasle Way", Id = 101},
                    new Person {Name = "John Smith", Address = "44 Tanananan Way", Id = 102},
                    new Person {Name = "John Smith", Address = "44 Bigory Road", Id = 103}
                };

                var sb = new StringBuilder();
                sb.AppendLine("<html>");
                sb.AppendLine(HtmlStaticHelper.SimpleHeader("t1"));
                sb.AppendLine("<body><table class=\"t1\">");
                sb.Append(hHelper.GetHeader());
                people.ToList().ForEach(x => sb.AppendLine(hHelper.GetRow(x)));
                sb.Append("</table></body></html>");
                var html = sb.ToString();
                ClipboardHelpers.CopyHtml(html);
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
