using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core
{
    public class InputSender
    {

        
        public void SendWhisperTo(string player, string message)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                string text = string.Format("@{0} {1}", player, message);
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                TypeString(text);
                SendKeys.SendWait("{ENTER}");
                BlockInput(false);
            }
        }

        public void InvitePlayerToParty(string player)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                TypeString("/invite " + player);
                SendKeys.SendWait("{ENTER}");
                BlockInput(false);
            }
        }

        private void SendCommand(string text)
        {
            BlockInput(true);
            SendKeys.SendWait("{DELETE}");
            SendKeys.SendWait("{ENTER}");
            TypeString(text);
            SendKeys.SendWait("{ENTER}");
            BlockInput(false);
        }

        private void SendWhisperReply(string reply)
        {
            BlockInput(true);
            SendKeys.SendWait("{DELETE}");
            SendKeys.SendWait("^{ENTER}");
            TypeString(reply);
            SendKeys.SendWait("{ENTER}");
            BlockInput(false);
        }

        public void SendTradeRequest(string player)
        {
            BlockInput(true);
            SendKeys.SendWait("{DELETE}");
            SendKeys.SendWait("{ENTER}");
            TypeString("/tradewith " + player);
            SendKeys.SendWait("{ENTER}");
            BlockInput(false);
        }


        private void TypeString(string text)
        {
            foreach (char ch in text)
            {
                SendKeys.SendWait(ch.ToString());
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
