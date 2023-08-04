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

        SettingDialog settingDialog;

        public Form1()
        {
            settingDialog = new SettingDialog();
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

            this.resultListBox.Items.Clear();
            foreach (int i in palList) 
            {
                this.resultListBox.Items.Add(i);
            }
            Console.WriteLine(this.resultListBox.Items.Count);
        }

        private List<int> findPalindrome(int start, int count)
        {
            int currentNumOfPalindrome = 0;
            int currentInt = start;
            List<int> result = new List<int>();
            String currentEval = "";

            Console.WriteLine("Current parameters:");
            Console.WriteLine("\t# of palindromes needed: " + count);
            Console.WriteLine("\t# of palindromes: " + currentNumOfPalindrome);
            Console.WriteLine("\tstart int: " + currentInt);


            while (currentNumOfPalindrome < count)
            {
                currentEval = currentInt.ToString();

                Console.WriteLine("current evaluated string: " + currentEval);
                Console.WriteLine("in array: " + currentEval.ToString());
                Console.WriteLine("in reversed array: " + reverseString(currentEval));

                if (currentEval.Equals(reverseString(currentEval)))
                {
                    Console.WriteLine("Adding");
                    result.Add(currentInt);
                    currentNumOfPalindrome++;
                }
                currentInt++;

            }

            Console.WriteLine("Result Palindrome: ");
            foreach (int i in result) { 
                Console.WriteLine("\t" + i.ToString());
            }
            return result;
        }

        private String reverseString(String s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
    }
}
