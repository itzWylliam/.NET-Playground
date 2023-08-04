namespace Lab5
{
    partial class SettingDialog
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
            this.startingIntRefText = new System.Windows.Forms.Label();
            this.startingIntTextBox = new System.Windows.Forms.TextBox();
            this.countRefText = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.errorText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startingIntRefText
            // 
            this.startingIntRefText.AutoSize = true;
            this.startingIntRefText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingIntRefText.Location = new System.Drawing.Point(66, 105);
            this.startingIntRefText.Name = "startingIntRefText";
            this.startingIntRefText.Size = new System.Drawing.Size(329, 20);
            this.startingIntRefText.TabIndex = 0;
            this.startingIntRefText.Text = "Enter a starting integer (1 - 1,000,000,000):";
            // 
            // startingIntTextBox
            // 
            this.startingIntTextBox.Location = new System.Drawing.Point(445, 103);
            this.startingIntTextBox.Name = "startingIntTextBox";
            this.startingIntTextBox.Size = new System.Drawing.Size(157, 22);
            this.startingIntTextBox.TabIndex = 1;
            // 
            // countRefText
            // 
            this.countRefText.AutoSize = true;
            this.countRefText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countRefText.Location = new System.Drawing.Point(646, 105);
            this.countRefText.Name = "countRefText";
            this.countRefText.Size = new System.Drawing.Size(169, 20);
            this.countRefText.TabIndex = 2;
            this.countRefText.Text = "Enter count (1 - 100):";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(836, 105);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(157, 22);
            this.countTextBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(412, 286);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 36);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(604, 286);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(94, 36);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "OK";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorText.Location = new System.Drawing.Point(258, 197);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(591, 36);
            this.errorText.TabIndex = 6;
            this.errorText.Text = "Please enter a positive integer within range.";
            this.errorText.Visible = false;
            // 
            // SettingDialog
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1145, 453);
            this.ControlBox = false;
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.countRefText);
            this.Controls.Add(this.startingIntTextBox);
            this.Controls.Add(this.startingIntRefText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingDialog";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startingIntRefText;
        private System.Windows.Forms.TextBox startingIntTextBox;
        private System.Windows.Forms.Label countRefText;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label errorText;
    }
}