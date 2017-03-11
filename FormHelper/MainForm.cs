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
        private Form _tradeForm;
        private static int _tradeFormCount = 0;

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
            characterNameTextBox.Text = _helperSettings.CharacterName;
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
                _tradeForm = new TradeForm(args.Message);
                Invoke(new MethodInvoker( delegate { ShowInactiveTopmost(_tradeForm); }));
            }            
        }

        private void savePathButton_Click(object sender, EventArgs e)
        {
            _helperSettings.LogPath = pathTextBox.Text;
            _helperSettings.CharacterName = characterNameTextBox.Text;
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

            _tradeForm = new TradeForm(message);
            ShowInactiveTopmost(_tradeForm);


        }


        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void ShowInactiveTopmost(Form frm)
        {
            _tradeFormCount++;
            frm.Closed += Frm_Closed;

            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == true)
                    rightmost = screen;
            }

            var left = (rightmost.WorkingArea.Right - frm.Width) + (_tradeFormCount * -10);
            var top = (rightmost.WorkingArea.Bottom - frm.Height) + (_tradeFormCount * -10) + 45;

            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
            left, top, frm.Width, frm.Height,
            SWP_NOACTIVATE);
        }

        private static void Frm_Closed(object sender, EventArgs e)
        {
            _tradeFormCount--;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
