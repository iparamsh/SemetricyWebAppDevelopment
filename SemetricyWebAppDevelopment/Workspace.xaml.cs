using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using DragDropEffects = System.Windows.Forms.DragDropEffects;

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for Workspace.xaml
    /// </summary>
    public partial class Workspace : Window
    {
        private string selectedItem = "";
        public Workspace()
        {
            InitializeComponent();
        }

        private void loadedWindow_action(object sender, RoutedEventArgs e)
        {
            htmlVisualizer.Navigate(Container.pathToProject + "\\" + "index.html");
        }

        private void Text_mouseClick(object sender, MouseButtonEventArgs e)
        {
            this.selectedItem = "text";
        }

        private void AddObject_btnClick(object sender, RoutedEventArgs e)
        {
            if (selectedItem == "text")
            {
                HTMLEditor.addLineToWebPageCode(contentOfTheSelectedObject.Text);
                htmlVisualizer.Refresh();
            }
        }

        private void newLineCommand_btnClick(object sender, RoutedEventArgs e)
        {
            HTMLEditor.addLineToWebPageCode("<br>");
        }
    }
}
