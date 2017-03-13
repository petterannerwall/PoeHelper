using Core;
using System;
using System.Collections.Generic;
using System.IO;
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
using Core.Models;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings _settings;
        MessageReader _messageReader;

        public MainWindow()
        {
            InitializeComponent();
            loadSettings();
            
        }

        private void NewMessageDetected(object sender, MessageEventArgs args)
        {
            if (args.Message.Type == Message.MessageType.PoETrade)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    TradeWindow tradeWindow = new TradeWindow(args.Message);
                    tradeWindow.Show();
                });
            }
        }

        private void loadSettings()
        {
            _settings = Settings.Load();
            pathTextBox.Text = _settings.LogPath;
        }

        private void savePathButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(pathTextBox.Text))
            {
                _settings.LogPath = pathTextBox.Text;
                _settings.Save();
            }
            else
            {
                MessageBox.Show("Wrong path, please try again");
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.Content = startButton.Content.Equals("Start") ? "Stop" : "Start";

            if (_settings.LogPath != string.Empty)
            {
                _messageReader = new MessageReader(_settings.LogPath);
                _messageReader.NewMessage += NewMessageDetected;
            }
        }

        private void debugButton_Click(object sender, RoutedEventArgs e)
        {
            _messageReader = new MessageReader(_settings.LogPath);
            _messageReader.NewMessage += NewMessageDetected;
            _messageReader.DebugMessage(debugTextBox.Text);
        }
    }
}
