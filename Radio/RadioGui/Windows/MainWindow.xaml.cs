using RadioClasses.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RadioGui.Windows
{
    public partial class MainWindow : Window
    {
        ///////////////////////Fields///////////////////////
        private readonly IRadio _radio = IRadioConstructor.CreateRadio();

        private int _currentChannelID = 0;

        ///////////////////////Methods///////////////////////

        public MainWindow()
        {
            InitializeComponent();

            ChangePlayerVolume();

            //UI initialization
            RefreshUI();
        }

        internal void RefreshUI()
        {
            volumeLabel.Content = !_radio.IsOn ? "" : _radio.IsMuted ? "Muted" : $"Volume: {_radio.Volume}";
            channelLabel.Content = _radio.IsOn ? _radio.GetStation(_currentChannelID).Name : "Powered off";

            PowerImage.Source = new BitmapImage(new Uri(_radio.IsOn ? @"\Images\PowerOff.png" : @"\Images\PowerOff.png", UriKind.Relative));
            MuteImage.Source = new BitmapImage(new Uri(_radio.IsOn && _radio.IsMuted ? @"\Images\UnmuteIcon.png" : @"\Images\MuteIcon.png", UriKind.Relative));

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
                RefreshUI();
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            _radio.ToggelPower();

            RefreshUI();

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
                RefreshUI();
            }
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_radio.IsOn)
            {
                _radio.ToggleMute();
                mediaElement.IsMuted = _radio.IsMuted;
                RefreshUI();
            }
        }

        private void AdjustVolumeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int volAdjustment = int.Parse((string)button.DataContext);
            _radio.Volume += volAdjustment;
            RefreshUI();
            ChangePlayerVolume();
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
            mediaElement.Source = null;
        }

        public void ShowQuickConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!_radio.IsOn)
            {
                _radio.ToggelPower();
                RefreshUI();
            }
            QuickPlayWindow quickPlayWindow = new QuickPlayWindow(this);
            quickPlayWindow.Show();
        }

        public void ShowManageStations_Click(object sender, RoutedEventArgs e)
        {
            ManageStationsWindow manageStationsWindow = new ManageStationsWindow(this, _radio);
            manageStationsWindow.Show();
        }

        public void PlayStation(IStreamable station)
        {
            ChangePlayingStation(station.URL);
            channelLabel.Content = _radio.IsOn ? station.Name : "Powered off";
        }

        public void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void ChangePlayerVolume() => mediaElement.Volume = _radio.Volume / 20d;
    }
}