using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Workspace workspace = new Workspace();
        private FileOperations fileOperation = new FileOperations();
        private string pathToDir = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Semetricy");

        //private string sFileName = "";

        public MainWindow()
        {
            InitializeComponent();
            fileOperation.createFolder(pathToDir);
            pathToProject.Text = pathToDir;
            pathToOpenProject.Text = pathToDir;
        }

        private void Hyperlink_RequestNavigate(object sender, RoutedEventArgs e)
        {
           string url = @"https://discord.gg/sCtYruVkCC";
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }

        }

        private void browsePathToNewProject(object sender, RoutedEventArgs e)
        {
            pathToProject.Text = fileOperation.choosePathToTheFolder();
        }

        private void BrowsePathToTheExistantProj_click(object sender, RoutedEventArgs e)
        {
            pathToOpenProject.Text = fileOperation.choosePathToTheFolder();
        }

        private void createProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameOfTheProject.Text != "" && pathToProject.Text != "")
            {
                Globals.pathToProject = pathToProject.Text + "\\" + nameOfTheProject.Text;

                fileOperation.createNewProject(pathToProject.Text, nameOfTheProject.Text);
                jumpToNewWindow();
            }
            else
            {
                if (nameOfTheProject.Text == "")
                    MessageBox.Show("You cant leave name of the project empty!!!");
                else
                    MessageBox.Show("You cant leave path to the project empty!!!");
            }
        }

        private void openProjectBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (pathToOpenProject.Text != "" && fileOperation.checkIfCorrectPathForOpenFile(pathToOpenProject.Text))
            {
                Globals.pathToProject = pathToOpenProject.Text;
                fileOperation.readSavedData();
                jumpToNewWindow();

            }
            else
            {
                if (pathToOpenProject.Text == "")
                {
                    MessageBox.Show("Can't leave the path root empty!");
                }
                else
                {
                    MessageBox.Show("Path is incorrect!");
                }
            }
           
        }
        private void jumpToNewWindow()
        {
            this.Close();
            workspace.Show();
        }
    }
}
