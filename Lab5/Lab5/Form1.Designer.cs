namespace Lab5
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
            this.titleText = new System.Windows.Forms.Label();
            this.resultListView = new System.Windows.Forms.ListView();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleText
            // 
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.Location = new System.Drawing.Point(35, 28);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(457, 50);
            this.titleText.TabIndex = 0;
            this.titleText.Text = "Find Numeric Palindromes";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultListView
            // 
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(120, 123);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(122, 127);
            this.resultListView.TabIndex = 1;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(308, 174);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 322);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.titleText);
            this.Name = "Form1";
            this.Text = "Palindromes - Wai Yuen Cheng";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.Button GenerateButton;
    }
}

