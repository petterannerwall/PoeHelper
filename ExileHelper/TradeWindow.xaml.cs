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
        public ObservableCollection<Message> _pendingTrades;
        public ObservableCollection<Message> _acceptedTrades;
        //private InformationWindow _informationWindow;
        private bool _currentlyTrading = false;

        public TradeWindow()
        {

            _settings = Settings.Load();
            this.Top = _settings.TradeWindowTop;
            this.Left = _settings.TradeWindowLeft;
            this.Height = _settings.TradeWindowHeight;
            this.Topmost = true;
            if (_settings.FadeTradelist && !this.IsMouseOver)
                this.Opacity = 0.1;

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
                    //Application.Current.Dispatcher.Invoke((Action)delegate
                    ////{
                    ////    InformationWindow informationWindow = new InformationWindow(pendingTrade);
                    ////    informationWindow.Show();
                    ////    _informationWindow = informationWindow;
                    //});
                }
            }

            updateList();
        }

        private void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Player.PendingTrades = new List<Message>();
            Player.AcceptedTrades = new List<Message>();
            MainWindow.TradeWindowOpen = false;
            //if (_informationWindow != null)
            //{
            //    _informationWindow.Close();
            //    _informationWindow = null;
            //}
            this.Close();
        }

        private void inviteButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.InvitePlayerToParty(message.Player);
            Player.PendingTrades.Remove(message);
            Player.AcceptedTrades.Add(message);
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
            _inputSender.SendWhisperTo(message.Player, _settings.SoldMessage + " " + message.Item);
            Player.PendingTrades.RemoveAll(x => x.ID == message.ID);
            updateList();

        }

        private void tradesListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void updateList()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                _pendingTrades = new ObservableCollection<Message>(Player.PendingTrades);
                _acceptedTrades = new ObservableCollection<Message>(Player.AcceptedTrades);
                _pendingTrades.OrderBy(t => t.Time);
                _acceptedTrades.OrderBy(t => t.Time);
                pendingTradesListBox.ItemsSource = _pendingTrades;
                acceptedTradesListBox.ItemsSource = _acceptedTrades;
            });
        }

        private void TradeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendTradeRequest(message.Player);
            //InformationWindow informationWindow = new InformationWindow(message);
            //informationWindow.Show();
            //_informationWindow = informationWindow;
        }

        private void ThankButton_OnClick(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            _inputSender.SendWhisperTo(message.Player, "Thanks, stay safe!");
            _currentlyTrading = false;

            _inputSender.KickPlayerFromParty(message.Player);
            Player.AcceptedTrades.RemoveAll(x => x.ID == message.ID);
            closeIfEmptyElseUpdate();

        }


        private void tradeListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _settings.TradeWindowTop = this.Top;
            _settings.TradeWindowLeft = this.Left;
            _settings.TradeWindowHeight = this.Height;

            _settings.Save();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_settings.FadeTradelist)
            {
                this.Opacity = 0.1;
            }
        }

        private void closePendingButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            Player.PendingTrades.RemoveAll(x => x.ID == message.ID);
            closeIfEmptyElseUpdate();
        }

        private void closeAcceptedButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            Message message = (Message)cmd.DataContext;
            Player.AcceptedTrades.RemoveAll(x => x.ID == message.ID);
            closeIfEmptyElseUpdate();
        }

        private void closeIfEmptyElseUpdate()
        {

            if (Player.PendingTrades.Count == 0 && Player.AcceptedTrades.Count == 0)
            {
                MainWindow.TradeWindowOpen = false;
                this.Close();
            }
            else
            {
                updateList();
            }
        }
    }
}
