using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

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
           // dlg.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV;*.jpeg;*.png;*.jpg;*.gif";
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

                createDataFile();
            }
            else
                MessageBox.Show("Folder does not exist");

        }

        private void createDataFile()
        {
            using (StreamWriter sw = File.CreateText(Globals.pathToProject + "\\SavedData.txt"));
        }

        public static void saveCounterData()
        {
            string[] lines =
            {
                "textElementCtr = " + Globals.textElementCtr,
                "buttonElementCtr = " + Globals.buttonElementCtr,
                "imageElementCtr = " + Globals.imageElementCtr,
                "videoElementCtr = " + Globals.videoElementCtr
            };

            File.WriteAllLinesAsync(Globals.pathToProject + "\\SavedData.txt", lines);
        }

        public void readSavedData()
        {
            string[] lines = File.ReadAllLines(Globals.pathToProject + "\\SavedData.txt");

            Globals.textElementCtr = Convert.ToInt32(lines[0].Substring(lines[0].IndexOf('=') + 1));
            Globals.buttonElementCtr = Convert.ToInt32(lines[1].Substring(lines[1].IndexOf('=') + 1));
            Globals.imageElementCtr = Convert.ToInt32(lines[2].Substring(lines[2].IndexOf('=') + 1));
            Globals.videoElementCtr = Convert.ToInt32(lines[3].Substring(lines[3].IndexOf('=') + 1));
        }

        public bool checkIfCorrectPathForOpenFile(string path)
        {
            if (Directory.Exists(path))
                return true;

            return false;
        }
    }
}
