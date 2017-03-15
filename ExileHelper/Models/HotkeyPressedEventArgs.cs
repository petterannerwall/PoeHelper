using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileHelper.Models
{
    public class HotkeyPressedEventArgs : EventArgs
    {
        public HotkeyPressedEventArgs(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}
