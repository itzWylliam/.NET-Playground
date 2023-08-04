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
    public partial class Form1 : Form
    {

        List<int> palList = new List<int>();

        SettingDialog settingDialog = new SettingDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {

            DialogResult resultValue = settingDialog.ShowDialog();

            if (resultValue == DialogResult.OK)
            {
                palList = findPalindrome(settingDialog.startingInt, settingDialog.count);
            }
            else if (resultValue == DialogResult.Cancel) 
            {
                palList.Clear();
            }

            this.resultListView.Items.Clear();
            foreach (int i in palList) 
            {
                ListViewItem item = new ListViewItem(i.ToString());
                this.resultListView.Items.Add(item);
            }
            Console.WriteLine(this.resultListView.Items.Count);
        }

        private List<int> findPalindrome(int start, int count)
        {
            int currentNumOfPalindrome = 0;
            int currentInt = start;
            List<int> result = new List<int>();
            String currentEval = "";

            while (currentNumOfPalindrome == count)
            {
                currentEval = currentInt.ToString();
                if (currentEval.ToCharArray().Equals(currentEval.ToCharArray().Reverse()))
                {
                    Console.WriteLine("Adding");
                    result.Add(currentInt);
                    currentInt++;
                    currentNumOfPalindrome++;
                }
            }

            Console.WriteLine("Result Palindrome: ");
            foreach (int i in result) { 
                Console.WriteLine("\t" + i.ToString());
            }
            return result;
        }
    }
}
