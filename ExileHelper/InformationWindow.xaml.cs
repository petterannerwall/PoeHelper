using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        private Settings _settings;
        public Message message;

        public InformationWindow(Message message)
        {
            this.message = message;

            InitializeComponent();

            _settings = Settings.Load();

            this.Left = _settings.TradeWindowLeft - 210;
            this.Top = _settings.TradeWindowTop;
            this.informationTextBlock.Text = string.Format("{0} wants to trade {1} for {1}",message.Player,message.Item,message.Price);
        }

        private void closeLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
