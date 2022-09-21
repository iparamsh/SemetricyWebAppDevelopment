using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemetricyWebAppDevelopment
{
    /// <summary>
    /// Interaction logic for Background.xaml
    /// </summary>
    public partial class Background : Page
    {
        private string rgbBackground = "";
        public Background()
        {
            InitializeComponent();
        }
        private void browseButtonClick(object sender, RoutedEventArgs e)
        {
            Source.Text = FileOperations.browseImageFileDialog();
        }

        private void backgroundColorSelector_click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.rgbBackground = new SolidColorBrush(Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A)).ToString();
            }
        }

        public string generateCSSCommand()
        {
            string command = "body {\n";

            command += getBackgroundColorCommand();
            command += getBackgroundImageCommand();

            command += "}\n";
            return command;
        }

        private string getBackgroundColorCommand()
        {
            if (rgbBackground != "")
                return "background-color: " + rgbBackground + ";\n";

            return "";
        }

        private string getBackgroundImageCommand()
        {
            if (Source.Text != "")
                return "background-image: \"" + Source.Text + "\";\n";
            return "";
        }
    }
}
