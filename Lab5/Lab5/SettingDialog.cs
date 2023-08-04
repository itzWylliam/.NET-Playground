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
                if (Convert.ToInt32(this.countTextBox.Text) <= 0 && Convert.ToInt32(this.startingIntTextBox.Text) <= 0)
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
