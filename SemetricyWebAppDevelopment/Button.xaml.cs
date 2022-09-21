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
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class Button : Page
    {
        string rgbaBackgroundColor = "";
        string rgbaTextColor = "";

        public Button()
        {
            InitializeComponent();
        }

        private void backgroundColorSelection_btnClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.rgbaBackgroundColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A)).ToString();
            }
        }

        private void textColorSelection_btnClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.rgbaTextColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, colorDialog.Color.A)).ToString();
            }
        }

        //a little messy but works
        public string generateCommand()
        {
            string command = "";
            if (alignmentComboBox.SelectedIndex == 1)
                command += "<center>";

            command += "<button class=\"ButtonElement_" + Globals.buttonElementCtr + "\">" + TextBoxContent.Text + "</button>" + "\n";

            if (alignmentComboBox.SelectedIndex == 1)
                command += "</center>";
            return command;
        }

        public string generateCSSCommand()
        {
            string command = ".ButtonElement_" + Globals.buttonElementCtr + "{\n";

            command += getBackgroundColorCommand();
            command += getTextColorCommand();
            command += getBorderRadiusCommand();
            command += getFontSizeCommand();

            command += "}\n";

            return command;
        }

        private string getBackgroundColorCommand()
        {
            if (rgbaBackgroundColor == "")
                return "";

            return "background-color: " + rgbaBackgroundColor + ";\n";
        }
        private string getTextColorCommand()
        {
            if (rgbaTextColor == "")
                return "";

            return "color: " + rgbaTextColor + ";\n";
        }

        private string getBorderRadiusCommand()
        {
            return "border-radius: " + borderRadiusSlider.Value + "px;\n";
        }

        private string getFontSizeCommand()
        {
            if (fontSizePropertyTextBox.Text == "")
                return "";
            else if (int.TryParse(fontSizePropertyTextBox.Text, out int num))
            {
                return "font-size: " + num + "px;\n";
            }
            return "";
        }
    }
}
