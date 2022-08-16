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

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for Workspace.xaml
    /// </summary>
    public partial class Workspace : Window
    {
        public Workspace()
        {
            InitializeComponent();
        }

        private void loadedWindow_action(object sender, RoutedEventArgs e)
        {
            htmlVisualizer.Navigate(Container.pathToProject + "\\" + "index.html");
        }
    }
}
