using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoEHelper
{
    class Program
    {
        private static bool debug = true;

        static void Main(string[] args)
        {
            InterceptKeys.KeyPressedEvent += KeyPressedEvent;
            new InterceptKeys();
        }

        private static void KeyPressedEvent(object sender, KeyEventArgs args)
        {
            string key = args.Key;

            if (debug)
                Console.WriteLine("[DEBUG] Key pressed: " + key);
            
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
                case "F4":
                    SendWhisperReply("In map at the moment. Il get back when i go to town.");
                    break;
            }

        }

        private static void SendCommand(string text)
        {
            Console.WriteLine("Sent command: " + text);
            SendKeys.Send("{ENTER}");
            TypeString(text);
            SendKeys.Send("{ENTER}");
        }

        private static void SendWhisperReply(string reply)
        {
            Console.WriteLine("Sent whisper reply: " + reply);
            SendKeys.Send("^{ENTER}");
            TypeString(reply);
            SendKeys.Send("{ENTER}");
        }

        private static void TypeString(string text)
        {
            foreach (char ch in text)
            {
                SendKeys.Send(ch.ToString());
            }
        }
        
        
    }
}
