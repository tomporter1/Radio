using RadioClasses.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace RadioGui.Windows
{
    /// <summary>
    /// Interaction logic for ManageStationsWindow.xaml
    /// </summary>
    public partial class ManageStationsWindow : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly IRadio _radio;

        public ManageStationsWindow(MainWindow mainWindow, IRadio radio)
        {
            InitializeComponent();
            _radio = radio;
            _mainWindow = mainWindow;

            PopulateListBox();
        }

        private void PopulateListBox()
        {
            stationsListBox.ItemsSource = _radio.AllStations;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //get new data from the UI
            int selectedIndex = stationsListBox.SelectedIndex;

            //Update the information in the radio
            _radio.UpdateChannelData(stationsListBox.SelectedItem, nameTextBox.Text.Trim(), urlTextBox.Text.Trim());

            //refresh the ui to have the updata in it
            _mainWindow.ReloadStations();
            PopulateListBox();
            stationsListBox.SelectedIndex = selectedIndex;

            _mainWindow.RefreshUI();

            MessageBox.Show("Changes Saved", "Radio");
        }

        private void StationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gets the station info from the radio
            ListBox listBox = (ListBox)sender;
            IStreamable selectedStation = _radio.GetStation(listBox.SelectedIndex);

            //puts the data in the text boxes for editing
            urlTextBox.Text = selectedStation.URL.ToString();
            nameTextBox.Text = selectedStation.Name;
        }
    }
}