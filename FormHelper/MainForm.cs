using PoEHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormHelper.Models;

namespace FormHelper
{
    public partial class MainForm : Form
    {
        private HelperSettings _helperSettings;
        private readonly ChatReader _chatReader;
        private readonly InputSender _inputSender;

        public MainForm()
        {
            InterceptKeys.KeyPressedEvent += KeyPressedEvent;
            ChatReader.ChatMessageDetected += ChatMessageDetected;
            this.Resize += Form1_Resize;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            InitializeComponent();
            
            _chatReader = new ChatReader();
            _inputSender = new InputSender();

            loadApplicationSettings();
        }

        private void loadApplicationSettings()
        {
            _helperSettings = HelperSettings.Load();
            pathTextBox.Text = _helperSettings.LogPath;
            _chatReader.SetLogPath(_helperSettings.LogPath);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void ChatMessageDetected(object sender, ChatMessageEventArgs args)
        {
            string text = string.Format("{0} Type: {1} Player: {2} Message: {3}", args.Message.Time, args.Message.Type, args.Message.Player, args.Message.Message);

            if (args.Message.Type == ChatMessage.MessageType.PoETrade && args.Message.Recived)
            {
                var tradeForm = new TradeForm(args.Message);
                Invoke(new MethodInvoker( delegate { WindowHelper.ShowInactiveTopmost(tradeForm); }));
            }            
        }

        private void savePathButton_Click(object sender, EventArgs e)
        {
            _helperSettings.LogPath = pathTextBox.Text;
            _helperSettings.Save();
            loadApplicationSettings();
        }

        private void KeyPressedEvent(object sender, PoEHelper.KeyEventArgs args)
        {
            _inputSender.Command(args.LastKeys, args.Key);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Text = startButton.Text == "Start" ? "Stop" : "Start";
            _chatReader.ToggleTimer();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            var message = new ChatMessage("2017/03/10 15:18:54 365324296 951 [INFO Client 9156] @From Big_P: Hi, I would like to buy your Poorjoy\'s Asylum Temple Map listed for 10 chaos in Legacy (stash tab \"<3\"; position: left 10, top 8)");

            var tradeForm = new TradeForm(message);
            WindowHelper.ShowInactiveTopmost(tradeForm);            
        }
        
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
