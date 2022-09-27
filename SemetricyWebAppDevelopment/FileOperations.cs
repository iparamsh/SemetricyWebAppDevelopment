using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace SemetricyWebAppDevelopment
{
    public class FileOperations
    {
        public void createFolder(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public string choosePathToTheFolder()
        {
            string path = "";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }

            return path;
        }

        public static string browseImageFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                string destination = Globals.pathToProject + "\\img\\" + Path.GetFileName(filename);

                try
                {
                    File.Copy(filename, destination, true);
                }
                catch (IOException iox)
                {
                    MessageBox.Show(iox.Message);
                }

                return destination;
            }
            return "";
        }

        public void createNewProject(string path, string name)
        {
            if (Directory.Exists(path))
            {
                path = path + "\\" + name;
                Directory.CreateDirectory(path);

                var htmlFile = File.CreateText(path + "\\" + "index.html");
                htmlFile.Close();
                var cssFile = File.CreateText(path + "\\" + "style.css");
                cssFile.Close();
                var jsFile = File.CreateText(path + "\\" + "script.js");
                jsFile.Close();

                var subsubfolder = new DirectoryInfo(path).CreateSubdirectory("img").FullName;

                HTMLEditor.editHTMLTemplateForEmptyProject(path);
            }
            else
                MessageBox.Show("Folder does not exist");

        }

        public bool checkIfCorrectPathForOpenFile(string path)
        {
            if (Directory.Exists(path))
                return true;

            return false;
        }
    }
}
