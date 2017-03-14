using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Player
    {
        public static List<Message> PendingTrades { get; set; }
        public static string Area { get; set; }      
        public static List<string> PlayersInArea { get; set; }
        public static List<Message> AcceptedTrades { get; set; }
        
        static Player()
        {
            PlayersInArea = new List<string>();
            PendingTrades = new List<Message>();
            AcceptedTrades = new List<Message>();
        } 
    }
}
