using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class SettingDialog : Form
    {

        public int count = 0;
        public int startingInt = 1;

        public SettingDialog()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                int currentCount = Convert.ToInt32(this.countTextBox.Text);
                int currentStartInt = Convert.ToInt32(this.startingIntTextBox.Text);

                if (currentCount <= 0 
                    || currentStartInt <= 0 
                    || currentCount > 100 
                    || currentStartInt > 1000000000
                   )
                {
                    showError();
                }
                else 
                {
                    hideError();
                    count = Convert.ToInt32(this.countTextBox.Text);
                    startingInt = Convert.ToInt32(this.startingIntTextBox.Text);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (FormatException ef)
            {
                showError();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void showError() 
        {
            this.errorText.Visible = true;
        }

        private void hideError() 
        {
            this.errorText.Visible = false;
        }

    }
}
