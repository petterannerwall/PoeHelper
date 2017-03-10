using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormHelper.Models
{
    //Courtesy of https://github.com/Panaetius/PoETradeMonitor
    public class ChatMessage
    {
        public enum MessageType
        {
            Trade = 0,
            Party,
            Private,
            Global,
            Other,
            PoETrade
        }

        public string Player { get; set; }
        public DateTime Time { get; set; }
        public MessageType Type { get; set; }
        public string Message { get; set; }

        public ChatMessage(string message)
        {
            const string pattern = @"(\d{4}/\d{2}/\d{2}\s\d{2}:\d{2}:\d{2})[^\]]+\]\s([$@%#])([^:]+):\s(.*)";

            var matches = Regex.Matches(message, pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);

            if (matches.Count != 1)
            {
                Type = MessageType.Other;
                return;
            }

            Time = DateTime.ParseExact(matches[0].Groups[1].Value, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            Player = matches[0].Groups[3].Value;
            Message = matches[0].Groups[4].Value;

            var type = matches[0].Groups[2].Value;

            switch (type)
            {
                case "$":
                    Type = MessageType.Trade;
                    break;
                case "@":
                    Type = MessageType.Private;
                    break;
                case "%":
                    Type = MessageType.Party;
                    break;
                case "#":
                    Type = MessageType.Global;
                    break;
                default:
                    Type = MessageType.Other;
                    break;
            }

            if (Type == MessageType.Private && Message.Contains("I would like to buy"))
            {
                Type = MessageType.PoETrade;
            }
        }
    }
}
