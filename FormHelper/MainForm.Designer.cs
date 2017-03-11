namespace FormHelper
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.pathToLogFileLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.debugButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.characterNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(13, 75);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(388, 22);
            this.pathTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(10, 152);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(391, 28);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.savePathButton_Click);
            // 
            // pathToLogFileLabel
            // 
            this.pathToLogFileLabel.AutoSize = true;
            this.pathToLogFileLabel.Location = new System.Drawing.Point(7, 54);
            this.pathToLogFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pathToLogFileLabel.Name = "pathToLogFileLabel";
            this.pathToLogFileLabel.Size = new System.Drawing.Size(98, 17);
            this.pathToLogFileLabel.TabIndex = 2;
            this.pathToLogFileLabel.Text = "Path to log file";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(265, 13);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(136, 37);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(13, 13);
            this.debugButton.Margin = new System.Windows.Forms.Padding(4);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(136, 37);
            this.debugButton.TabIndex = 6;
            this.debugButton.Text = "Debug";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Character Name";
            // 
            // characterNameTextBox
            // 
            this.characterNameTextBox.Location = new System.Drawing.Point(10, 122);
            this.characterNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.characterNameTextBox.Name = "characterNameTextBox";
            this.characterNameTextBox.Size = new System.Drawing.Size(388, 22);
            this.characterNameTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 188);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.characterNameTextBox);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pathToLogFileLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Trade Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label pathToLogFileLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox characterNameTextBox;
    }
}

