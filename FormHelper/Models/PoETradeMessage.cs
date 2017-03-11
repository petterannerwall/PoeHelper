using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormHelper.Models
{
    public class PoETradeMessage
    {
        public string Item { get; set; }
        public string Price { get; set; }
        public string League { get; set; }
        public string Location { get; set; }

        public PoETradeMessage(string message)
        {
            Item = GetSubstringByString("buy your", "listed for", message).Trim();
            Price = GetSubstringByString("listed for", "in", message).Trim();
            League = GetSubstringByString("in", "(stash", message).Trim();
            Location = GetSubstringByString("(", ")", message).Trim();

        }


        public string GetSubstringByString(string a, string b, string c)
        {

            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }

    }

    
}
