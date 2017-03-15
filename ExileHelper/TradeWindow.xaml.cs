using Core;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Interop;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for TradesWindow.xaml
    /// </summary>
    public partial class TradeWindow : Window
    {
        private HotkeyManager _hotkey;
        private Settings _settings;
        private InputSender _inputSender;
        private MessageReader _messageReader;
        public ObservableCollection<Message> TradeList;
        private InformationWindow _informationWindow;
        private bool _currentlyTrading = false;

        public TradeWindow()
        {

            _settings = Settings.Load();
            this.Top = _settings.TradeWindowTop;
            this.Left = _settings.TradeWindowLeft;
            this.Height = _settings.TradeWindowHeight;
            this.Topmost = true;
            
            _messageReader = new MessageReader();
            _inputSender = new InputSender();
            MessageReader.NewMessage += NewMessageDetected;
            InitializeComponent();
            
            updateList();
        }

        private void NewMessageDetected(object sender, MessageEventArgs args)
        {
            if (args.Message.Type == Message.MessageType.OtherJoinArea && _settings.AutoTrade && !_currentlyTrading)
            {
                var pendingTrade = Player.AcceptedTrades.FirstOrDefault(t => t.Player == args.Message.Player);
                if (pendingTrade != null)
                {
                    _inputSender.SendTradeRequest(args.Message.Player);
                    _currentlyTrading = true;
                    Application.Current.Dispatcher.Invoke((Action)delegate {
                        InformationWindow informationWindow = new InformationWindow(pendingTrade);
                        informationWindow.Show();
                        _informationWindow = informationWindow;
                    });
                }
            }

            updateList();
        }

        private void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Player.PendingTrades = new List<Message>();
            Player.AcceptedTrades = new List<Message>();
            MainWindow.TradeWindowOpen = false;
            if (_informationWindow != null)
            {
                _informationWindow.Close();
                _informationWindow = null;
            }
            this.Close();
        }

        private void inviteButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            cmd.Content = "Reinvite";
            
            Message message = (Message)cmd.DataContext;
            _inputSender.InvitePlayerToParty(message.Player);
            Player.AcceptedTrades.Add(message);

            var inviteButton = Helpers.FindVisualChildren<Button>(tradeListBox).FirstOrDefault(t => t.Name == "inviteButton");
            var inMapButton = Helpers.FindVisualChildren<Button>(tradeListBox).FirstOrDefault(t => t.Name == "inMapButton");
            var soldButton = Helpers.FindVisualChildren<Button>(tradeListBox).FirstOrDefault(t => t.Name == "soldButton");

            if (inviteButton != null)
                inviteButton.Content = "Reinvite";
            if (inMapButton != null)
                inMapButton.Visibility = Visibility.Hidden;
            if (soldButton != null)
                soldButton.Visibility = Visibility.Hidden;

        }

        private void inMapButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendWhisperTo(message.Player, _settings.InMapMessage);
        }

        private void soldButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendWhisperTo(message.Player, _settings.SoldMessage+ " " + message.Item);
            closeButton_Click(sender, e);
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            Player.PendingTrades.RemoveAll(x => x.ID == message.ID);
            Player.AcceptedTrades.RemoveAll(x => x.ID == message.ID);
            updateList();

            if (_informationWindow.message.ID == message.ID)
            {
                _informationWindow.Close();
                _informationWindow = null;
            }

            if (Player.PendingTrades.Count == 0)
            {

                this.Close();
            }
        }

        private void tradesListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void updateList()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                //TradeList = new ObservableCollection<Message>(Player.PendingTrades);
                //TradeList.OrderBy(t => t.Time);
                //tradeListBox.ItemsSource = TradeList;
            });
        }

        private void TradeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendTradeRequest(message.Player);
        }

        private void ThankButton_OnClick(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendWhisperTo(message.Player,"Thanks");
            _currentlyTrading = true;
        }
        

        private void tradeListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _settings.TradeWindowTop = this.Top;
            _settings.TradeWindowLeft = this.Left;
            _settings.TradeWindowHeight = this.Height;

            _settings.Save();
        }
    }
}
