using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormHelper.Models;

namespace FormHelper
{
    public partial class TradeForm : Form
    {
        private ChatMessage _chatMessage;

        public TradeForm(ChatMessage message)
        {
            _chatMessage = message;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            descriptionLabel.Text = string.Format("{0} for {1} in {2}",message.TradeMessage.Item, message.TradeMessage.Price, message.TradeMessage.League);
            
        }
        

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void soldButton_Click(object sender, EventArgs e)
        {

        }

        private void inMapButton_Click(object sender, EventArgs e)
        {

        }

        private void inviteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
