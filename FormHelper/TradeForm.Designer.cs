namespace FormHelper
{
    partial class TradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tradeAlternativesLabel = new System.Windows.Forms.Label();
            this.inviteButton = new System.Windows.Forms.Button();
            this.soldButton = new System.Windows.Forms.Button();
            this.inMapButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tradeAlternativesLabel
            // 
            this.tradeAlternativesLabel.AutoSize = true;
            this.tradeAlternativesLabel.Location = new System.Drawing.Point(9, 8);
            this.tradeAlternativesLabel.Name = "tradeAlternativesLabel";
            this.tradeAlternativesLabel.Size = new System.Drawing.Size(93, 13);
            this.tradeAlternativesLabel.TabIndex = 0;
            this.tradeAlternativesLabel.Text = "Trade Alternatives";
            // 
            // inviteButton
            // 
            this.inviteButton.Location = new System.Drawing.Point(9, 24);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(69, 40);
            this.inviteButton.TabIndex = 1;
            this.inviteButton.Text = "Invite";
            this.inviteButton.UseVisualStyleBackColor = true;
            // 
            // soldButton
            // 
            this.soldButton.Location = new System.Drawing.Point(159, 24);
            this.soldButton.Name = "soldButton";
            this.soldButton.Size = new System.Drawing.Size(69, 40);
            this.soldButton.TabIndex = 3;
            this.soldButton.Text = "Sold";
            this.soldButton.UseVisualStyleBackColor = true;
            // 
            // inMapButton
            // 
            this.inMapButton.Location = new System.Drawing.Point(84, 24);
            this.inMapButton.Name = "inMapButton";
            this.inMapButton.Size = new System.Drawing.Size(69, 40);
            this.inMapButton.TabIndex = 4;
            this.inMapButton.Text = "In Map";
            this.inMapButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 70);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(216, 40);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 118);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.inMapButton);
            this.Controls.Add(this.soldButton);
            this.Controls.Add(this.inviteButton);
            this.Controls.Add(this.tradeAlternativesLabel);
            this.Name = "TradeForm";
            this.Text = "TradeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tradeAlternativesLabel;
        private System.Windows.Forms.Button inviteButton;
        private System.Windows.Forms.Button soldButton;
        private System.Windows.Forms.Button inMapButton;
        private System.Windows.Forms.Button closeButton;
    }
}