using ClassesApp;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RadioGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Radio _radio = new Radio();
        private int _currentChannelID = 0;

        public MainWindow()
        {
            InitializeComponent();
            ChangePlayerVolume();
            UpdateVolLabel();
            UpdateChanelLabel();

            channel1Button.Content = _radio.PlayStation(0).Name;
            channel2Button.Content = _radio.PlayStation(1).Name;
            channel3Button.Content = _radio.PlayStation(2).Name;
            channel4Button.Content = _radio.PlayStation(3).Name;
        }

        private void ChannelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentChannelID = int.Parse((string)button.DataContext);
            _radio.Channel = _currentChannelID;
            ChangePlayingStation(_radio.PlayStation(_currentChannelID).URL);
            UpdateChanelLabel();
        }

        private void OnOffButton_Click(object sender, RoutedEventArgs e)
        {
            _radio.ToggelPower();
            UpdateChanelLabel();
            UpdateVolLabel();

            if (_radio.IsOn)
            {
                ChangePlayingStation(_radio.PlayStation(_currentChannelID).URL);
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
            mediaElement.Stop();
            mediaElement.Source = url;
            mediaElement.Play();
        }

        private void UpdateVolLabel()
        {
            if (!_radio.IsOn)
                volumeLabel.Content = "";
            else
                volumeLabel.Content = _radio.IsMuted ? $"Muted" : $"Volume: {_radio.Volume}";
        }


        private void UpdateChanelLabel() => channelLabel.Content = _radio.IsOn ? $"Channel: {_radio.PlayStation(_currentChannelID).Name}" : "Powered off";

        private void UpdateMuteButton()
        {
            if (!_radio.IsOn)
                muteButton.Content = "Mute";
            else
                muteButton.Content = _radio.IsMuted ? "Unmute" : "Mute";
        }
    }
}
