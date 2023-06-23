using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int h = Font.Height;
            string s = "";

            int n = 2; 
            for (int i = 1; i <= 8; ++i) {
                s = String.Format("{0} {1}", i, n);
                g.DrawString(s, Font, Brushes.Black, 20, 20 + (h * (i-1)));
                n *= 2; 
            }


        }
    }
}
