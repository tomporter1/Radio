using RadioClasses.Interfaces;
using System.Collections.Generic;
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
            stationsListBox.ItemsSource = null;
            List<string> names = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                names.Add(_radio.GetStation(i).Name);
            }
            stationsListBox.ItemsSource = names;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //get new data from the UI
            int selectedIndex = stationsListBox.SelectedIndex;
            IStreamable newStation = IRadio.MakeStation(keyTextBox.Text.Trim(), nameTextBox.Text.Trim(), urlTextBox.Text.Trim());

            //Update the information in the radio
            _radio.UpdateChannelData(newStation, selectedIndex);

            //refresh the ui to have the updata in it
            _mainWindow.ReloadStations();
            PopulateListBox();
            stationsListBox.SelectedIndex = selectedIndex;

            MessageBox.Show("Changes Saved", "Radio");
        }

        private void StationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gets the station info from the radio
            ListBox listBox = (ListBox)sender;
            IStreamable selectedStation = _radio.GetStation(listBox.SelectedIndex);

            //puts the data in the text boxes for editing
            keyTextBox.Text = selectedStation.ID;
            urlTextBox.Text = selectedStation.URL.ToString();
            nameTextBox.Text = selectedStation.Name;
        }
    }
}