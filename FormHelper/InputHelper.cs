using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormHelper
{
    public class InputSender
    {

        public void Command(List<string> lastKeys, string key)
        {
            switch (key)
            {
                case "F1":
                    SendCommand("/remaining");
                    break;
                case "Oem5":
                    SendCommand("/remaining");
                    break;
                case "F2":
                    SendCommand("/hideout");
                    break;
            }
        }

        public void SendWhisperTo(string player, string message)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                string text = string.Format("@{0} {1}", player, message);
                SendKeys.Send("{ENTER}");
                TypeString(text);
                SendKeys.Send("{ENTER}");
                BlockInput(false);
            }
        }

        public void InvitePlayerToParty(string player)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                SendKeys.Send("{ENTER}");
                TypeString("/invite " + player);
                SendKeys.Send("{ENTER}");
                BlockInput(false);
            }
        }

        private void SendCommand(string text)
        {
            BlockInput(true);
            SendKeys.Send("{ENTER}");
            TypeString(text);
            SendKeys.Send("{ENTER}");
            BlockInput(false);
        }

        private void SendWhisperReply(string reply)
        {
            BlockInput(true);
            SendKeys.Send("^{ENTER}");
            TypeString(reply);
            SendKeys.Send("{ENTER}");
            BlockInput(false);
        }



        private void TypeString(string text)
        {
            foreach (char ch in text)
            {
                SendKeys.Send(ch.ToString());
            }
        }

        
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);
        
        public static void BlockInput(TimeSpan span)
        {
            try
            {
                BlockInput(true);
                Thread.Sleep(span);
            }
            finally
            {
                BlockInput(false);
            }
        }
    }
}
