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
using ExileHelper.Models;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool TradeWindowOpen = false;
        Settings _settings;
        MessageReader _messageReader;
        private HotkeyManager _hotkey;

        public MainWindow()
        {
            
            
            MessageReader.NewMessage += NewMessageDetected;
            InitializeComponent();

            _settings = Settings.Load();
            _settings.Save();
            pathTextBox.Text = _settings.LogPath;

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = System.Windows.WindowState.Normal;
                };

        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();
            base.OnStateChanged(e);
        }

        private void NewMessageDetected(object sender, MessageEventArgs args)
        {
            if (args.Message.Type == Message.MessageType.IncTradeMessage && !TradeWindowOpen)
            {
                TradeWindowOpen = true;

                Application.Current.Dispatcher.Invoke((Action)delegate {
                    TradeWindow tradeWindow = new TradeWindow();
                    tradeWindow.Show();
                });
            }
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
            }
        }

        private void debugButton_Click(object sender, RoutedEventArgs e)
        {
            _messageReader = new MessageReader();
            _messageReader.DebugMessage(debugTextBox.Text);
        }

        private void demoButton_Click(object sender, RoutedEventArgs e)
        {
            var InfoWindow = new InformationWindow(new Message("") { });
            var TradeWindow = new TradeWindow();

            InfoWindow.Show();
            TradeWindow.Show();
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow();
            window.Show();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            _hotkey = new HotkeyManager(this);
            _hotkey.RegisterHotKey();
        }
        

        protected override void OnClosed(EventArgs e)
        {
            _hotkey.UnregisterHotKey();
            base.OnClosed(e);
        }

    }
}
