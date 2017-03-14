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
            inMapTextBox.Text = _settings.InMapMessage;
            soldTextBox.Text = _settings.SoldMessage;
            autoTradeCheckbox.IsChecked = _settings.AutoTrade;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _settings.SoldMessage = soldTextBox.Text;
            _settings.InMapMessage = inMapTextBox.Text;
            _settings.AutoTrade = (bool)autoTradeCheckbox.IsChecked;
            _settings.Save();
            this.Close();
        }

        private void autoTradeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            _settings.AutoTrade = (bool)autoTradeCheckbox.IsChecked;
        }
    }
}
