using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                case "F4":
                    SendWhisperReply("In map at the moment. Il get back when i go to town.");
                    break;
            }
        }

        private void SendCommand(string text)
        {
            Console.WriteLine(@"Sent command: " + text);
            SendKeys.Send("{ENTER}");
            TypeString(text);
            SendKeys.Send("{ENTER}");
        }

        private void SendWhisperReply(string reply)
        {
            Console.WriteLine(@"Sent whisper reply: " + reply);
            SendKeys.Send("^{ENTER}");
            TypeString(reply);
            SendKeys.Send("{ENTER}");
        }

        private void TypeString(string text)
        {
            foreach (char ch in text)
            {
                SendKeys.Send(ch.ToString());
            }
        }
    }
}
