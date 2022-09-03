using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SemetricyWebAppDevelopment
{
    public class HTMLEditor
    {
        public static void editHTMLTemplateForEmptyProject(string path)
        {
            string html = "<!DOCTYPE html>\n";
            html += "<html>\n";
            html += "<head>\n";
            //making head
            html += "<meta charset=\"utf - 8\">\n <meta name=\"viewport\" content=\"width=device-width\">\n<title>Semetricy</title>\n<link href=\"style.css\" rel=\"stylesheet\" type=\"text/css\" />\n</head>";
            //attaching script
            html += "<body>\nWelcome to Semetricy\n<script src=\"script.js\"></script>\n";
            html += "<script src=\"" + (path + "\\" + "script.js") + "\" theme=\"blue\" defer></script>\n";

            html += "</body>\n";
            html += "</html>\n";

            File.WriteAllText(path + "\\" + "index.html", html);

            editCSSTemplateForEmptyProject(path);
        }

        private static void editCSSTemplateForEmptyProject(string path)
        {
            string css = "html, body {\n";
            css += "height: 100%;\n";
            css += "width: 100%;\n";
            css += "}";
            File.WriteAllText(path + "//" + "style.css", css);
        }

        public static void addLineToWebPageCode(string content)
        {
            string allHtml = File.ReadAllText(Container.pathToProject + "\\" + "index.html");
            allHtml = allHtml.Insert((allHtml.Count() - 16), content + "\n");
            File.WriteAllText(Container.pathToProject + "\\" + "index.html", allHtml);
        }
    }
}
