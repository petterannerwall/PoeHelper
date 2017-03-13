using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{

    public class TradeMessage
    {
        public string Item { get; set; }
        public string Price { get; set; }
        public string League { get; set; }
        public string Location { get; set; }

        public TradeMessage(string message)
        {
            Item = "";
            Price = "";
            League = "";
            Location = "";

            if (message.Contains("buy your") && message.Contains("listed for"))
            {
                Item = GetSubstringByString("buy your", "listed for", message).Trim();
            }
            else if (message.Contains("buy your") && message.Contains("in"))
            {
                Item = GetSubstringByString("buy your", "in", message).Trim();
            }

            if (message.Contains("listed for") && message.Contains("in"))
                Price = GetSubstringByString("listed for", "in", message).Trim();

            if (message.Contains("in") && message.Contains("(stash"))
                League = GetSubstringByString("in", "(stash", message).Trim();

            if (message.Contains("(") && message.Contains(")"))
                Location = GetSubstringByString("(", ")", message).Trim();
        }


        public string GetSubstringByString(string a, string b, string c)
        {
            try
            {
                return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
            }
            catch (Exception e)
            {
                return "";
            }

        }

    }
}
