using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormHelper.Models;

namespace FormHelper
{
    public partial class TradeForm : Form
    {
        private ChatMessage _chatMessage;
        private InputSender _inputSender;

        public TradeForm(ChatMessage message)
        {
            this.ShowInTaskbar = false;
            _chatMessage = message;
            _inputSender = new InputSender();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            descriptionLabel.Text = string.Format("{0} wants to buy {1} for {2} in {3}", message.Player, message.TradeMessage.Item, message.TradeMessage.Price, message.TradeMessage.Location);
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void soldButton_Click(object sender, EventArgs e)
        {
            _inputSender.SendWhisperTo(_chatMessage.Player, "Sorry " + _chatMessage.TradeMessage.Item + " is already sold");
            this.Close();
        }

        private void inMapButton_Click(object sender, EventArgs e)
        {
            _inputSender.SendWhisperTo(_chatMessage.Player, "In map at the moment, il get back when i go to town");
            this.Close();
        }

        private void inviteButton_Click(object sender, EventArgs e)
        {
            _inputSender.InvitePlayerToParty(_chatMessage.Player);
            closeButton.Width = 200;
            thankButton.Show();
            inviteButton.Hide();
            inMapButton.Hide();
            soldButton.Hide();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void thankButton_Click(object sender, EventArgs e)
        {
            _inputSender.SendWhisperTo(_chatMessage.Player, "Thanks!");
        }
    }
}
