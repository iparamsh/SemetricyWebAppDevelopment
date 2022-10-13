using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for Workspace.xaml
    /// </summary>
    public partial class Workspace : Window
    {
        Text textElement = new Text();
        Button buttonElement = new Button();
        Image imageElement = new Image();  
        Background backgroundElement = new Background();  
        Video videoElement = new Video();

        private string selectedItem = "";
        public Workspace()
        {
            InitializeComponent();
        }

        private void loadedWindow_action(object sender, RoutedEventArgs e)
        {
            htmlVisualizer.Source = new Uri(Globals.pathToProject + "\\" + "index.html");
        }

        private void Text_mouseClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Content = textElement;
            this.selectedItem = "text";
        }
        private void buttonSelection_mouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Content = buttonElement;
            this.selectedItem = "button";
        }

        private void imageSelection_doubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Content = imageElement;
            this.selectedItem = "image";
        }

        private void backgroundSelection_Click(object sender, MouseButtonEventArgs e)
        {
            Properties.Content = backgroundElement;
            this.selectedItem = "background";
        }

        private void videoSelection_Click(object sender, MouseButtonEventArgs e)
        {
            Properties.Content = videoElement;
            this.selectedItem = "video";
        }

        private void shapeSelection_Click(object sender, MouseButtonEventArgs e)
        {

        }

        //----------------

        private void AddObject_btnClick(object sender, RoutedEventArgs e)
        {
            if (selectedItem == "text")
            {
                HTMLEditor.addLineToWebPageCode(textElement.generateCommand());
                CSSEditor.addCommandToCSSFile(textElement.generateCSSCommand());
                Globals.textElementCtr++;
            }
            else if (selectedItem == "button")
            {
                HTMLEditor.addLineToWebPageCode(buttonElement.generateCommand());
                CSSEditor.addCommandToCSSFile(buttonElement.generateCSSCommand());
                Globals.buttonElementCtr++;
            }
            else if (selectedItem == "image")
            {
                HTMLEditor.addLineToWebPageCode(imageElement.generateCommand());
                CSSEditor.addCommandToCSSFile(imageElement.generateCSSCommand());
                Globals.imageElementCtr++;
            }
            else if (selectedItem == "background")
            {
                CSSEditor.addCommandToCSSFile(backgroundElement.generateCSSCommand());
            }
            else if (selectedItem == "video")
            {
                HTMLEditor.addLineToWebPageCode(videoElement.generateCommand());
                Globals.videoElementCtr++;
            }
            htmlVisualizer.Reload();

            FileOperations.saveCounterData();
        }

        private void newLineCommand_btnClick(object sender, RoutedEventArgs e)
        {
            HTMLEditor.addLineToWebPageCode("<br>");
        }

        
    }
}
