using RadioClasses;
using System;
using System.Diagnostics;
using System.Windows;

namespace RadioGui
{
    /// <summary>
    /// Interaction logic for QuickPlayWindow.xaml
    /// </summary>
    public partial class QuickPlayWindow : Window
    {
        private MainWindow _mainWindow;

        public QuickPlayWindow()
        {
            InitializeComponent();
        }

        public QuickPlayWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void quickPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "" && urlTextBox.Text != "")
            {
                IStreamable quickPlayStation = Radio.MakeStation("", nameTextBox.Text, urlTextBox.Text);
                _mainWindow.PlayStation(quickPlayStation);
                Close();
            }
        }

        private void GetMoreUrlButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd", "/C start" + " " + "http://www.radiofeeds.co.uk/mp3.asp");
        }
    }
}
