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
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public NotificationWindow(string notification, int secounds)
        {
            InitializeComponent();

            notificationTextBlock.Text = notification;
            Task ignoredAwaitableResult = this.waitUntilClose(secounds);


        }

        private async Task waitUntilClose(int secounds)
        {
            await Task.Delay(secounds * 1000);
            this.closeNotification();
        }

        private void closeNotification()
        {
            this.Close();
        }

        private void closeWindowButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
