using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for Video.xaml
    /// </summary>
    public partial class Video : Page
    {
        public Video()
        {
            InitializeComponent();
        }

        private void browse_btnClick(object sender, RoutedEventArgs e)
        {
            Source.Text = FileOperations.browseImageFileDialog();
        }

        public string generateCommand()
        {
            string command = "";

            command += "<video class = \"VideoElement_" + Globals.videoElementCtr + "\" controls=\"controls\" src=\"" + Source.Text + "\"/>";

            return command;
        }

        public string generateCSSCommand()
        {
            string command = ".VideoElement_" + Globals.videoElementCtr + " \n{";

            command += getAlignmentCommand();

            command += "}";
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
                command += "margin: 0 auto;\n";
            }
            else if (alignmentComboBox.SelectedIndex == 2)
            {
                command += "float: right;\n";
            }

            return command;
        }
    }
}
