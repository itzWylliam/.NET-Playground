using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {

        private double currentVal;
        private TextBox input = new TextBox();
        private TextBox output = new TextBox();
        private Button clear = new Button();
        private Button add = new Button();
        private Button sub = new Button();
        private Button mul = new Button();
        private Button div = new Button();
        public Form1()
        {
            currentVal = 0;
            InitializeComponent();
            input = this.Input;
            output = this.Output;
            clear = this.Clear;
            add = this.Add;
            sub = this.Sub;
            mul = this.Mul;
            div = this.Div;

            add.Click += new EventHandler(this.onClick);
            sub.Click += new EventHandler(this.onClick);
            div.Click += new EventHandler(this.onClick);
            mul.Click += new EventHandler(this.onClick);
            clear.Click += new EventHandler(this.onClick);

        }

        private void onClick(object sender, EventArgs e) 
        { 
            Button currentButton = (Button)sender;

            try
            {
                switch (currentButton.Name) 
                {
                    case "Add":
                        currentVal = currentVal + Convert.ToDouble(input.Text);
                        break;
                    case "Mul":
                        currentVal = currentVal * Convert.ToDouble(input.Text);
                        break;
                    case "Sub":
                        currentVal = currentVal - Convert.ToDouble(input.Text);
                        break;
                    case "Div":
                        currentVal = currentVal / Convert.ToDouble(input.Text);
                        break;
                    case "Clear":
                        currentVal = 0;
                        break;
                    default:
                        break;
                }
                updateValOnScreen();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Missing or invalid input value");
            }
        }

        private void updateValOnScreen() {
            this.output.Text = currentVal.ToString();
            this.input.Text = "";
        }
    }
}
