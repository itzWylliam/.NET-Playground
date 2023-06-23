using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {

        private ArrayList coordinates = new ArrayList();
        private bool connectBool = false;
        private bool connectAllBool = false;


        public Form1()
        {
            InitializeComponent();
            checkBox2.CheckedChanged += checkChange_CheckBox;
            checkBox1.CheckedChanged += checkChange_CheckBox;
        }

        private void checkChange_CheckBox(object sender, EventArgs e)
        { 
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Only one between connect and connect all could be chosen.");
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                if (checkBox2.Checked)
                {
                    connectAllBool = true;
                }
                else
                {
                    connectAllBool = false;
                }

                if (checkBox1.Checked)
                {
                    connectBool = true;
                }
                else
                {
                    connectBool = false;
                }

                this.Invalidate();
            }
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coordinates.Add(p);
            }
            else if (e.Button == MouseButtons.Right) 
            {
                this.coordinates.Clear();  
            }

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            const int WIDTH = 10;
            const int HEIGHT = 10;

            foreach (Point p in coordinates)
            {
                graphics.FillEllipse(Brushes.Black, p.X - WIDTH / 2, p.Y - HEIGHT / 2, WIDTH, HEIGHT);
            }

            

            if (connectBool)
            {
                for (int i = 0; i < coordinates.Count - 1; i++)
                {
                    graphics.DrawLine(new Pen(Color.Black, 1), (Point)this.coordinates[i], (Point)this.coordinates[i + 1]);
                }
                graphics.DrawLine(new Pen(Color.Black, 1), (Point)this.coordinates[this.coordinates.Count - 1], (Point)this.coordinates[0]);
            }

            if (connectAllBool)
            {
                for (int i = 0; i < coordinates.Count; i++)
                {
                    for (int k = 0; k < coordinates.Count; k++)
                    {
                        if (i != k)
                        {
                            graphics.DrawLine(new Pen(Color.Black, 1), (Point)this.coordinates[i], (Point)this.coordinates[k]);
                        }
                    }

                }
            }
        }
        
    }
}
