using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Models
{
    //Courtesy of https://github.com/Panaetius/PoETradeMonitor
    public class Message
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
        public bool Recived { get; set; }
        public DateTime Time { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public TradeMessage TradeMessage { get; set; }

        public Message(string message)
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
            Player = Player.Split(' ').Last();

            Text = matches[0].Groups[4].Value;

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

            if (Type == MessageType.Private)
            {
                Recived = message.Contains("From") ? true : false;
            }

            if (Type == MessageType.Private && Text.Contains("I would like to buy"))
            {
                Type = MessageType.PoETrade;
                TradeMessage = new TradeMessage(Text);
            }
        }

    }
}
