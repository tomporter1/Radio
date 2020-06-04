using RadioClasses;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RadioGui
{
    public partial class MainWindow : Window
    {
        ///////////////////////Fields///////////////////////
        private Radio _radio = new Radio();
        private int _currentChannelID = 0;

        ///////////////////////Methods///////////////////////

        public MainWindow()
        {
            InitializeComponent();

            //UI initialization 
            ChangePlayerVolume();
            UpdateVolLabel();
            UpdateChanelLabel();

            channel1Button.Content = _radio.GetStation(0).Name;
            channel2Button.Content = _radio.GetStation(1).Name;
            channel3Button.Content = _radio.GetStation(2).Name;
            channel4Button.Content = _radio.GetStation(3).Name;
        }

        private void ChannelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentChannelID = int.Parse((string)button.DataContext);
            _radio.Channel = _currentChannelID;
            if (_radio.IsOn)
            {
                ChangePlayingStation(_radio.GetStation(_currentChannelID).URL);
                UpdateChanelLabel();
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            _radio.ToggelPower();
            UpdateChanelLabel();
            UpdateVolLabel();

            if (_radio.IsOn)
                ChangePlayingStation(_radio.GetStation(_currentChannelID).URL);
            else
                StopPlaying();
        }

        internal void ReloadStations()
        {
            if (_radio.IsOn)
            {
                ChangePlayingStation(_radio.GetStation(_currentChannelID).URL);
                UpdateChanelLabel();
            }
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_radio.IsOn)
            {
                _radio.ToggleMute();
                mediaElement.IsMuted = _radio.IsMuted;
                UpdateMuteButton();
                UpdateVolLabel();
            }
        }

        private void AdjustVolumeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int volAdjustment = int.Parse((string)button.DataContext);
            _radio.Volume += volAdjustment;
            UpdateVolLabel();
            ChangePlayerVolume();
        }

        private void ChangePlayerVolume()
        {
            mediaElement.Volume = _radio.Volume / 10d;
        }

        private void ChangePlayingStation(Uri url)
        {
            StopPlaying();
            mediaElement.Source = url;
            mediaElement.Play();
        }

        private void StopPlaying()
        {
            mediaElement.Stop();
        }

        private void UpdateVolLabel()
        {
            if (!_radio.IsOn)
                volumeLabel.Content = "";
            else
                volumeLabel.Content = _radio.IsMuted ? $"Muted" : $"Volume: {_radio.Volume}";
        }

        public void ShowQuickConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!_radio.IsOn)
            {
                _radio.ToggelPower();
                UpdateVolLabel();
            }
            QuickPlayWindow quickPlayWindow = new QuickPlayWindow(this);
            quickPlayWindow.Show();
        }

        public void ShowManageStations_Click(object sender, RoutedEventArgs e)
        {
            ManageStationsWindow manageStationsWindow = new ManageStationsWindow(this, _radio);
            manageStationsWindow.Show();
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void PlayStation(Station station)
        {
            ChangePlayingStation(station.URL);
            UpdateChanelLabel(station.Name);
        }

        private void UpdateChanelLabel() => channelLabel.Content = _radio.IsOn ? $"Channel: {_radio.GetStation(_currentChannelID).Name}" : "Powered off";

        private void UpdateChanelLabel(string name) => channelLabel.Content = _radio.IsOn ? $"Channel: {name}" : "Powered off";

        private void UpdateMuteButton() => muteButton.Content = _radio.IsOn && _radio.IsMuted ? "Unmute" : "Mute";
    }
}
