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
            return "<img class = \"ImageElement_" + Globals.imageElementCtr +"\" src=\"" + Source.Text + "\">";
        }

        public string generateCSSCommand()
        {
            string command = ".ImageElement_" + Globals.imageElementCtr + "{\n";

            command += getBorderRadiusCommand();
            command += getAlignmentCommand();

            command += getWidthCommand();
            command += getHeightCommand();

            command += "}\n";

            return command;
        }

        private string getAlignmentCommand()
        {
            string command = "";

            if (alignmentComboBox.SelectedIndex == 0)
            {
                command += "float: left;\n";
            }
            else if (alignmentComboBox.SelectedIndex == 1)
            {
                command += "display: block;\nmargin: 0 auto;\n";
            }
            else if (alignmentComboBox.SelectedIndex == 2)
            {
                command += "float: right;\n";
            }

            return command;
        }

        private string getBorderRadiusCommand ()
        {
            return "border-radius: " + borderRadiusSlider.Value + "px;\n";
        }

        private string getWidthCommand()
        {
            if (widthTB.Text == "auto")
                return "width: auto;\n";
            else if (int.TryParse(widthTB.Text, out int width))
                return "width: " + width + "px;\n";
            return "";
        }

        private string getHeightCommand()
        {
            if (heightTB.Text == "auto")
                return "width: auto;\n";
            else if (int.TryParse(heightTB.Text, out int height))
                return "width: " + height + "px;\n";

            return "";
        }
    }
}
