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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private Settings _settings;

        public SettingsWindow()
        {
            InitializeComponent();
            
            _settings = Settings.Load();
            hideoutTextbox.Text = _settings.Hideout;
            soldTextBox.Text = _settings.SoldMessage;
            inMapTextBox.Text = _settings.InMapMessage;
            autoTradeCheckbox.IsChecked = _settings.AutoTrade;
            fadeTradeListCheckbox.IsChecked = _settings.FadeTradelist;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _settings.Hideout = hideoutTextbox.Text;
            _settings.SoldMessage = soldTextBox.Text;
            _settings.InMapMessage = inMapTextBox.Text;
            _settings.AutoTrade = (bool)autoTradeCheckbox.IsChecked;
            _settings.FadeTradelist = (bool)fadeTradeListCheckbox.IsChecked;
            _settings.Save();
            this.Close();
        }

        private void autoTradeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            _settings.AutoTrade = (bool)autoTradeCheckbox.IsChecked;
        }
    }
}
