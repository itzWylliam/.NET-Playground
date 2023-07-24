namespace Lab4
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.HintCheckBox = new System.Windows.Forms.CheckBox();
            this.ResultTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(287, 65);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // HintCheckBox
            // 
            this.HintCheckBox.AutoSize = true;
            this.HintCheckBox.Location = new System.Drawing.Point(180, 67);
            this.HintCheckBox.Name = "HintCheckBox";
            this.HintCheckBox.Size = new System.Drawing.Size(52, 20);
            this.HintCheckBox.TabIndex = 1;
            this.HintCheckBox.Text = "Hint";
            this.HintCheckBox.UseVisualStyleBackColor = true;
            this.HintCheckBox.CheckedChanged += new System.EventHandler(this.HintCheckBox_CheckedChanged);
            // 
            // ResultTextLabel
            // 
            this.ResultTextLabel.AutoSize = true;
            this.ResultTextLabel.Location = new System.Drawing.Point(395, 68);
            this.ResultTextLabel.Name = "ResultTextLabel";
            this.ResultTextLabel.Size = new System.Drawing.Size(203, 16);
            this.ResultTextLabel.TabIndex = 2;
            this.ResultTextLabel.Text = "You have 0 queens on the board.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultTextLabel);
            this.Controls.Add(this.HintCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Name = "Form1";
            this.Text = "Eight Queens by Wai Yuen Cheng";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBoard);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox HintCheckBox;
        private System.Windows.Forms.Label ResultTextLabel;
    }
}

