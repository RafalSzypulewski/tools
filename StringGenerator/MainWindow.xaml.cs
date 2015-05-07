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
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace StringGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private StringGen gen = null;
        //generate new random string and save it to clipboard
        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            if (gen == null)
            {
                gen = new StringGen(CharStringToUse.Text);
            }
            else
            {
                gen.SetCharList(CharStringToUse.Text);
            }
            var finalString = gen.GenerateString(howLong.Text,
                spaceEveryX.Text, spaceEveryY.Text, (bool)isInsertSpacesOn.IsChecked,
                newLineEveryX.Text, newLineEveryY.Text, (bool)isInsertNewLineOn.IsChecked);

            System.Windows.Clipboard.SetText(finalString);
            if (finalString.Length > 100000)
            {
                finalString = "String is too long to display (whole string is in clipboard)";
            }
            output.Text = finalString;

        }

        //generate counter string
        private void generateCounterString_Click(object sender, RoutedEventArgs e)
        {
            if (gen == null)
            {
                gen = new StringGen(CharStringToUse.Text);
            }
            else
            {
                gen.SetCharList(CharStringToUse.Text);
            }

            var finalString = gen.GenerateCounterString(counterStringSize.Text, counterStringSign.Text);

            System.Windows.Clipboard.SetText(finalString);
            if (finalString.Length > 100000)
            {
                finalString = "String is too long to display (whole string is in clipboard)";
            }
            output.Text = finalString;
        }


    }
}
