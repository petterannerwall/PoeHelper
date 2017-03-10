namespace FormHelper
{
    partial class Form1
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.savePathButton = new System.Windows.Forms.Button();
            this.pathToLogFileLabel = new System.Windows.Forms.Label();
            this.chatListBox = new System.Windows.Forms.ListBox();
            this.chatListBoxLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.debugButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 589);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(486, 20);
            this.pathTextBox.TabIndex = 0;
            // 
            // savePathButton
            // 
            this.savePathButton.Location = new System.Drawing.Point(504, 589);
            this.savePathButton.Name = "savePathButton";
            this.savePathButton.Size = new System.Drawing.Size(75, 23);
            this.savePathButton.TabIndex = 1;
            this.savePathButton.Text = "Save path";
            this.savePathButton.UseVisualStyleBackColor = true;
            this.savePathButton.Click += new System.EventHandler(this.savePathButton_Click);
            // 
            // pathToLogFileLabel
            // 
            this.pathToLogFileLabel.AutoSize = true;
            this.pathToLogFileLabel.Location = new System.Drawing.Point(9, 573);
            this.pathToLogFileLabel.Name = "pathToLogFileLabel";
            this.pathToLogFileLabel.Size = new System.Drawing.Size(74, 13);
            this.pathToLogFileLabel.TabIndex = 2;
            this.pathToLogFileLabel.Text = "Path to log file";
            // 
            // chatListBox
            // 
            this.chatListBox.FormattingEnabled = true;
            this.chatListBox.Location = new System.Drawing.Point(12, 90);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(567, 472);
            this.chatListBox.TabIndex = 3;
            // 
            // chatListBoxLabel
            // 
            this.chatListBoxLabel.AutoSize = true;
            this.chatListBoxLabel.Location = new System.Drawing.Point(9, 74);
            this.chatListBoxLabel.Name = "chatListBoxLabel";
            this.chatListBoxLabel.Size = new System.Drawing.Size(55, 13);
            this.chatListBoxLabel.TabIndex = 4;
            this.chatListBoxLabel.Text = "Messages";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(477, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(102, 72);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(369, 12);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(102, 72);
            this.debugButton.TabIndex = 6;
            this.debugButton.Text = "Debug";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 621);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.chatListBoxLabel);
            this.Controls.Add(this.chatListBox);
            this.Controls.Add(this.pathToLogFileLabel);
            this.Controls.Add(this.savePathButton);
            this.Controls.Add(this.pathTextBox);
            this.Name = "Form1";
            this.Text = "PoE Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button savePathButton;
        private System.Windows.Forms.Label pathToLogFileLabel;
        private System.Windows.Forms.ListBox chatListBox;
        private System.Windows.Forms.Label chatListBoxLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button debugButton;
    }
}

