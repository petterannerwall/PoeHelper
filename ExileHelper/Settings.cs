using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExileHelper
{

    public class Settings : AppSettings<Settings>
    {
        public string LogPath = "";
        public string CharacterName = "";
        public double TradeWindowTop = 0;
        public double TradeWindowLeft = 0;
        public double TradeWindowHeight = 300;
        public string InMapMessage = "In map at the moment, il get back when i go to town";
        public string SoldMessage = "Item already sold: ";
        public bool AutoTrade = false;
        public string Hideout = "Battle-scarred Hideout";
        public bool FadeTradelist = true;
    }

    public class AppSettings<T> where T : new()
    {
        public delegate void EventHandler(object sender, EventArgs args);
        public static EventHandler SettingsSaved;
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));

            if (Settings.SettingsSaved != null)
            {
                SettingsSaved(null, new EventArgs());
            }
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }
}
