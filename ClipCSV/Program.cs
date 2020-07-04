using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipCSV
{

    static class ClipboardHelpers
    {
        public static void CopyHtml(string html)
        {
            var startHtml = 0;
            var endHtml = 0;
            var startFragment = 0;
            var endFragment = 0;

            var l1 = new Func<string>(()=> $"Version:0.9\r\nStartHTML: {startHtml:D10}\r\nEndHTML: {endHtml:D10}\r\nStartFragment: {startFragment:D10}\r\nEndFragment: {endFragment:D10}\r\n");
            var header = l1.Invoke();
            startHtml = header.Length;
            endHtml = header.Length + html.Length;
            var startMarker = "<--Start Fragment-->";
            var pos = html.IndexOf(startMarker);
            startFragment = pos == -1 ? startHtml : startHtml + pos + startMarker.Length;
            pos = html.IndexOf("<--End Fragment-->");
            endFragment = pos == -1 ? endHtml : startHtml + pos - 1;
            header = l1.Invoke();
            var sb = new StringBuilder(header);
            sb.Append(html);
            var obj = new DataObject();

            obj.SetData(DataFormats.Html, sb.ToString());
            obj.SetData(DataFormats.Text, sb.ToString());
            Clipboard.SetDataObject(obj, true);
        }
    }
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                var html = HExample.Get1();
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
