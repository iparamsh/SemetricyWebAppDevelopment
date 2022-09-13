using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;

namespace SemetricyWebAppDevelopment
{
    public class CSSEditor
    {
        public static void addCommandToCSSFile(string command)
        {
            if (command == "" || command == null)
                return;

            string allCSS = File.ReadAllText(Container.pathToProject + "\\" + "style.css");
            allCSS = allCSS.Insert((allCSS.Count() - 1), command + "\n");
            File.WriteAllText(Container.pathToProject + "\\" + "style.css", allCSS);
        }
    }
}
