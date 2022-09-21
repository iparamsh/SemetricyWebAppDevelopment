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
    /// Interaction logic for Text.xaml
    /// </summary>
    public partial class Text : Page
    {
        string rgbaColor = "";
        public Text()
        {
            InitializeComponent();
            alignmentComboBox.SelectedIndex = 0;
        }

        private void textColorBtnClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.rgbaColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A)).ToString();
            }
        }

        public string generateCommand()
        {
            string command = "<div class=\"TextElement_"+ Globals.textElementCtr + "\">\n";

            command += TextBoxContent.Text + "\n";

            command += "</div>";
            return command;
        }

        public string generateCSSCommand()
        {
            string command = ".TextElement_" + Globals.textElementCtr + "{\n";

            command += getAlignmentCommand();
            command += getFontCommand();
            command += getColorCommand();

            command += "}\n";

            return command;
        }

        private string getAlignmentCommand()
        {
            string command = "";

            if (alignmentComboBox.SelectedIndex == 0)
            {
                command += "text-align: left;\n";
            }
            else if (alignmentComboBox.SelectedIndex == 1)
            {
                command += "text-align: center;\n";
            }
            else if (alignmentComboBox.SelectedIndex == 2)
            {
                command += "text-align: right;\n";
            }

            return command;
        }

        private string getFontCommand()
        {
            string command = "";

            if (fontSizeProperty.Text == "")
                return "";
            else
            {
                if (int.TryParse(fontSizeProperty.Text, out int num))
                {
                    command = "font-size: " + num + "px;\n";
                }
                else
                {
                    System.Windows.MessageBox.Show("Font element have to contain only numbers");
                }
            }

            return command;
        }

        private string getColorCommand()
        {
            string command = "";

            if (rgbaColor != "")
                return "color: " + rgbaColor + ";\n";

            return command;
        }
    }
}
