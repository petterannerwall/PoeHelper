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
            this.inviteButton = new System.Windows.Forms.Button();
            this.soldButton = new System.Windows.Forms.Button();
            this.inMapButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inviteButton
            // 
            this.inviteButton.BackColor = System.Drawing.Color.Gray;
            this.inviteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inviteButton.FlatAppearance.BorderSize = 0;
            this.inviteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inviteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inviteButton.ForeColor = System.Drawing.Color.White;
            this.inviteButton.Location = new System.Drawing.Point(18, 134);
            this.inviteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(124, 49);
            this.inviteButton.TabIndex = 1;
            this.inviteButton.Text = "Invite";
            this.inviteButton.UseVisualStyleBackColor = false;
            this.inviteButton.Click += new System.EventHandler(this.inviteButton_Click);
            // 
            // soldButton
            // 
            this.soldButton.BackColor = System.Drawing.Color.Gray;
            this.soldButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.soldButton.FlatAppearance.BorderSize = 0;
            this.soldButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldButton.ForeColor = System.Drawing.Color.White;
            this.soldButton.Location = new System.Drawing.Point(165, 191);
            this.soldButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.soldButton.Name = "soldButton";
            this.soldButton.Size = new System.Drawing.Size(124, 49);
            this.soldButton.TabIndex = 3;
            this.soldButton.Text = "Sold";
            this.soldButton.UseVisualStyleBackColor = false;
            this.soldButton.Click += new System.EventHandler(this.soldButton_Click);
            // 
            // inMapButton
            // 
            this.inMapButton.BackColor = System.Drawing.Color.Gray;
            this.inMapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inMapButton.FlatAppearance.BorderSize = 0;
            this.inMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inMapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inMapButton.ForeColor = System.Drawing.Color.White;
            this.inMapButton.Location = new System.Drawing.Point(165, 134);
            this.inMapButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inMapButton.Name = "inMapButton";
            this.inMapButton.Size = new System.Drawing.Size(124, 49);
            this.inMapButton.TabIndex = 4;
            this.inMapButton.Text = "In Map";
            this.inMapButton.UseVisualStyleBackColor = false;
            this.inMapButton.Click += new System.EventHandler(this.inMapButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Gray;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(18, 191);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(124, 49);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(13, 9);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(276, 121);
            this.descriptionLabel.TabIndex = 7;
            this.descriptionLabel.Text = "Poorjoy\'s Asylum for 10 chaos in Legacy";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(302, 253);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.inMapButton);
            this.Controls.Add(this.soldButton);
            this.Controls.Add(this.inviteButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TradeForm";
            this.Text = "TradeForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button inviteButton;
        private System.Windows.Forms.Button soldButton;
        private System.Windows.Forms.Button inMapButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label descriptionLabel;
    }
}