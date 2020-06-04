using MiNET.Items;
using RadioClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RadioGui
{
    /// <summary>
    /// Interaction logic for ManageStationsWindow.xaml
    /// </summary>
    public partial class ManageStationsWindow : Window
    {
        private MainWindow _mainWindow;
        private Radio _radio;

        public ManageStationsWindow(MainWindow mainWindow, Radio radio)
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
            int selectedIndex = stationsListBox.SelectedIndex;
            Station newStation = new Station(keyTextBox.Text.Trim(), nameTextBox.Text.Trim(), urlTextBox.Text.Trim());
            _radio.UpdateChannelData(newStation, selectedIndex);
            _mainWindow.ReloadStations();
            PopulateListBox();
            stationsListBox.SelectedIndex = selectedIndex;
            MessageBox.Show("Changes Saved", "Radio");
        }

        private void StationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Station selectedStation = _radio.GetStation(listBox.SelectedIndex);
            keyTextBox.Text = selectedStation.ID;
            urlTextBox.Text = selectedStation.URL.ToString();
            nameTextBox.Text = selectedStation.Name;
        }
    }
}
