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

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Page
    {
        public Image()
        {
            InitializeComponent();
        }

        private void BrowseImage_btnClick(object sender, RoutedEventArgs e)
        {
            Source.Text = FileOperations.browseImageFileDialog();
        }

        public string generateCommand()
        {
            return "<img src=\"" + Source.Text + "\">";
        }
    }
}
