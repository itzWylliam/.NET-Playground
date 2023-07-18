using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {

        // false => white, true => black
        private Boolean[,] boardBooleanMatrix = {
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
        };

        private Boolean[,] cellOccupiedMatrix = {
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false }
        };

        private int boardStartPositionX = 100;
        private int boardStartPositionY = 100;

        public Form1()
        {
            InitializeComponent();
        }



        private void PaintBoard(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            Brush redBrush = new SolidBrush(Color.Red);

            Rectangle currentRectangle;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    currentRectangle = new Rectangle(boardStartPositionX + (i * 50), boardStartPositionY + (j * 50), 50, 50);
                    g.DrawRectangle(blackPen, currentRectangle);

                    if (boardBooleanMatrix[i, j])
                    {
                        g.FillRectangle(blackBrush, currentRectangle);
                    }
                    else
                    {
                        g.FillRectangle(whiteBrush, currentRectangle);
                    }
                }
            }
        }
    }
}
