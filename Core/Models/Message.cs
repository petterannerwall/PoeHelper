using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Models
{
    // Heavily inspired by https://github.com/Panaetius/PoETradeMonitor
    // And https://github.com/Exslims/MercuryTrade
    // Specifically https://github.com/Exslims/MercuryTrade/blob/master/app-core/src/main/java/com/mercury/platform/shared/MessageParser.java
    public class Message
    {
        public enum MessageType
        {
            //Channels
            TradeChannel = 0,
            PartyChannel,
            WhisperChannel,
            GlobalChannel,
            //Events
            IncTradeMessage,
            OutTradeMessage,
            SelfEnteringArea,
            OtherJoinArea,
            OtherLeaveArea,
            //Other
            Other,

        }

        public Guid ID;
        public string Player { get; set; }
        public bool Recived { get; set; }
        public DateTime Time { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public string Item { get; set; }
        public Price Price { get; set; }
        public string League { get; set; }
        public string Location { get; set; }

        public Message(string message)
        {
            ID = Guid.NewGuid();
            Price = new Price();
            message = message.ToLower();

            const string pattern = @"(\d{4}/\d{2}/\d{2}\s\d{2}:\d{2}:\d{2})[^\]]+\]\s([$@%#]?)([^:]+)?:\s(.*)";
            var matches = Regex.Matches(message, pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);

            if (matches.Count != 1)
            {
                Type = MessageType.Other;
                return;
            }


            Time = DateTime.ParseExact(matches[0].Groups[1].Value, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            Player = matches[0].Groups[3].Value.Split(' ').Last();
            Text = matches[0].Groups[4].Value;

            var type = matches[0].Groups[2].Value;
            
            if ((message.Contains("you have entered") && message.Contains("hideout.")) || message.Contains("you have entered") || message.Contains("entering area hideout"))
                Type = MessageType.SelfEnteringArea;
            else if ((message.Contains("@from") && message.Contains("hi, i would like")) || message.Contains("@from") && message.Contains("hi, i'd like"))
                Type = MessageType.IncTradeMessage;
            else if ((message.Contains("@to") && message.Contains("hi, i would like")) || message.Contains("@to") && message.Contains("hi, i'd like"))
                Type = MessageType.OutTradeMessage;
            else if ((message.Contains("has joined the area")))
                Type = MessageType.OtherJoinArea;
            else if ((message.Contains("has left the area")))
                Type = MessageType.OtherLeaveArea;
            else if (type == "$")
                Type = MessageType.TradeChannel;
            else if (type == "@")
                Type = MessageType.WhisperChannel;
            else if (type == "%")
                Type = MessageType.PartyChannel;
            else if (type == "#")
                Type = MessageType.GlobalChannel;

            if (Type == MessageType.IncTradeMessage)
            {
                if (Text.Contains("hi, i would like")) //Hi, I would like to buy your Booming Essence Leaguestone of Wealth in Legacy(stash tab "Stones"; position: left 3, top 8)
                {
                    if (Text.Contains("listed for"))
                    {
                        Item = SubstringBetween(Text, "to buy your ", " listed for");
                        Price.Text = SubstringBetween(Text, "listed for ", " in ");
                        if (Price.Text != string.Empty)
                        {
                            Price.Count = SubstringBefore(Price.Text, " ");
                            Price.Currency = SubstringAfter(Price.Text, " ");
                        }
                    }
                    else
                    {
                        Item = SubstringBetween(Text, "to buy your ", " in");
                        Price.Text = "Not specified";
                    }
                }
                else if (Text.Contains("hi, i'd like"))
                {
                    Item = SubstringBetween(Text, "to buy your ", " for my");
                    if (Item != string.Empty)
                    {
                        Price.Text = SubstringBetween(Text, "for my ", " in ");
                        if (Price.Text != string.Empty)
                        {
                            Price.Count = SubstringBefore(Price.Text, " ");
                            Price.Currency = SubstringAfter(Price.Text, " ");
                        }
                    }
                }

                if (Text.Contains("in"))
                {
                    League = SubstringBetween(Text, "in ", " (");
                }
                if (Text.Contains("stash tab"))
                {
                    Location = SubstringBetween(Text, "(", ")");
                }

                Core.Player.PendingTrades.Add(this);
            }
            else if (Type == MessageType.SelfEnteringArea)
            {
                if (Text.Contains("you have entered"))
                {
                    Core.Player.Area = SubstringBetween(Text, "you have entered ", ".");
                }
            }
            else if (Type == MessageType.OtherJoinArea)
            {
                var player = SubstringBefore(Text, " has joined the area.");
                Player = player;
                Core.Player.PlayersInArea.Add(player);
            }
            else if (Type == MessageType.OtherLeaveArea)
            {
                var player = SubstringBefore(Text, " has left the area.");
                Player = player;
                Core.Player.PlayersInArea.Remove(player);
            }
        }
                

        public string SubstringBefore(string text, string before)
        {
            return text.Substring(0, text.IndexOf(before));
        }

        public string SubstringAfter(string text, string after)
        {
            return text.Substring(text.IndexOf(after) + after.Length);
        }

        public string SubstringBetween(string text,string start, string end)
        {
            try
            {
                return text.Substring((text.IndexOf(start) + start.Length), (text.IndexOf(end) - text.IndexOf(start) - start.Length));
            }
            catch (Exception e)
            {
                return "";
            }

        }



    }
}
