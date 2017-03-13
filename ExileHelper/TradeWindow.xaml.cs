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
using Core;
using Core.Models;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for TradeWindow.xaml
    /// </summary>
    public partial class TradeWindow : Window
    {
        private InputSender _inputSender;
        private Message _message;

        public TradeWindow(Message message)
        {
            _inputSender = new InputSender();
            _message = message;

            InitializeComponent();

            string text = string.Format("{0} wants to buy {1} for {2} in {3}", message.Player, message.TradeMessage.Item, message.TradeMessage.Price, message.TradeMessage.Location);
            messageTextBlock.Text = text;

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
            


        }

        private void inviteButton_Click(object sender, RoutedEventArgs e)
        {
            _inputSender.InvitePlayerToParty(_message.Player);
        }

        private void inMapButton_Click(object sender, RoutedEventArgs e)
        {
            _inputSender.SendWhisperTo(_message.Player,"In map at the moment, il get back when i go to town");
        }

        private void soldButton_Click(object sender, RoutedEventArgs e)
        {
            _inputSender.SendWhisperTo(_message.Player, "Item already sold: " + _message.TradeMessage.Item);
        }

        private void messageTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
