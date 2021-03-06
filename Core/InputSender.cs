﻿using System;
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
                SendKeys.SendWait(text);
                SendKeys.SendWait("{ENTER}");
            }
            BlockInput(false);
        }

        public void InvitePlayerToParty(string player)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("/invite " + player);
                SendKeys.SendWait("{ENTER}");                
            }
            BlockInput(false);
        }

        public void SendCommand(string text)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                BlockInput(true);
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait(text);
                SendKeys.SendWait("{ENTER}");
            }
            BlockInput(false);
        }

        private void SendWhisperReply(string reply)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                BlockInput(true);
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("^{ENTER}");
                SendKeys.SendWait(reply);
                SendKeys.SendWait("{ENTER}");
            }
            BlockInput(false);
        }


        public void KickPlayerFromParty(string player)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                BlockInput(true);
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("/kick " + player);
                SendKeys.SendWait("{ENTER}");
            }
            BlockInput(false);
        }

        public void SendTradeRequest(string player)
        {
            BlockInput(true);
            var success = WindowHelper.SetFocusToPathOfExileWindow();
            if (success)
            {
                BlockInput(true);
                SendKeys.SendWait("{DELETE}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("/tradewith " + player);
                SendKeys.SendWait("{ENTER}");
                BlockInput(false);
            }
        }
        
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);
        
    }
}
