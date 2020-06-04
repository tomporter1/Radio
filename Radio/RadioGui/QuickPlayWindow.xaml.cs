using RadioClasses;
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
                Station quickPlayStation = new Station("", nameTextBox.Text, urlTextBox.Text);
                _mainWindow.PlayStation(quickPlayStation);
                Close();
            }
        }
    }
}
