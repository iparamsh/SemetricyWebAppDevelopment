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
                System.IO.Directory.CreateDirectory(filePath);
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

        public void createNewProject(string path, string name)
        {
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path + "\\" + name);
            }
            else
                System.Windows.Forms.MessageBox.Show("Folder does not exist");
        }

        public bool checkIfCorrectPathForOpenFile(string path)
        {
            if (Directory.Exists(path))
                return true;

            return false;
        }
    }
}
