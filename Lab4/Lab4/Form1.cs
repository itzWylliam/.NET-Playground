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

        // N -> nothing ; Q -> queens
        private enum select { N, Q };

        private enum color { WHITE, BLACK, RED };

        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush redBrush = new SolidBrush(Color.Red);

        Pen blackPen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);

        private color[,] boardMatrix;

        // false -> cannot be occupied by a queen
        private bool[,] validator;

        private select[,] cellSelected;

        private int boardStartPositionX = 100;
        private int boardStartPositionY = 100;
        private int deltaBox = 50;
        private int boardEndPositionX = 500;
        private int boardEndPositionY = 500;
        private String resultText;
        private int countQueen = 0;

        public Form1()
        {

            resultText = "You have " + countQueen.ToString() + " queens on the board.";
            initializeMatrix();
            this.MouseDown += new MouseEventHandler(this.mouseDown);
            InitializeComponent();
            MinimumSize = new Size(600, 600);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void PaintBoard(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Rectangle currentRectangle;

            int[] index = new int[2];

            resultText = "You have " + countQueen.ToString() + " queens on the board.";
            ResultTextLabel.Text = resultText;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    currentRectangle = new Rectangle(boardStartPositionX + (i * 50), boardStartPositionY + (j * 50), 50, 50);
                    index[0] = i;
                    index[1] = j;

                    // DRAW BORDER
                    drawBorder(currentRectangle, g);
                    fillCell(index, currentRectangle, g);

                    if (cellSelected[i, j] == select.Q)
                    {
                        drawQ(new int[2] { i, j }, g);
                    }

                }
            }
            
        }

        private void Transform(Graphics g)
        {
            g.ScaleTransform(1000, 1000);
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            PointF position = new Point(e.X, e.Y);

            int[] cellIndex = getCellIndex(position);

            try
            {
                if (inRange(position))
                {
                    if (validator[cellIndex[0], cellIndex[1]] && e.Button == MouseButtons.Left)
                    {
                        // NEED SUCH ORDER SINCE updateValidator(cellIndex) NEED THE NEW cellSelected MATRIX
                        cellSelected[cellIndex[0], cellIndex[1]] = select.Q;
                        updateValidator(cellIndex);
                        countQueen++;
                    }
                    else if (e.Button == MouseButtons.Right && cellSelected[cellIndex[0], cellIndex[1]] == select.Q)
                    {
                        // NEED SUCH ORDER SINCE updateValidator(cellIndex) NEED THE NEW cellSelected MATRIX
                        cellSelected[cellIndex[0], cellIndex[1]] = select.N;
                        updateValidator(cellIndex);
                        countQueen--;
                    }
                    else if (inRange(position))
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
            } catch (Exception ef) {

                // DEBUG
                Console.WriteLine("Processed X: " + cellIndex[0].ToString());
                Console.WriteLine("Processed Y: " + cellIndex[1].ToString());

                Console.WriteLine("X: " + position.X.ToString());
                Console.WriteLine("Y: " + position.Y.ToString());
            }


            onChecked(sender, e, true);

            Invalidate();
        }

        // USED IN PaintBoard() BY INVALIDATE
        private void drawQ(int[] cellIndex, Graphics g)
        {
            if (boardMatrix[cellIndex[0], cellIndex[1]] == color.WHITE || boardMatrix[cellIndex[0], cellIndex[1]] == color.RED)
            {
                g.DrawString("Q", new Font("Arial Black", 30, FontStyle.Bold), Brushes.Black, new Point(  100 + (cellIndex[0] * 50), 100 + (cellIndex[1] * 50)));
            }
            else if (boardMatrix[cellIndex[0], cellIndex[1]] == color.BLACK)
            {
                g.DrawString("Q", new Font("Arial Black", 30, FontStyle.Bold), Brushes.White, new Point( 100 + (cellIndex[0] * 50), 100 + (cellIndex[1] * 50)));
            }

        }

        private void fillCell(int[] cellIndex, Rectangle currentRectangle, Graphics g)
        {

            if (boardMatrix[cellIndex[0], cellIndex[1]] == color.BLACK)
            {
                g.FillRectangle(blackBrush, currentRectangle);
            }
            else if (boardMatrix[cellIndex[0], cellIndex[1]] == color.WHITE)
            {
                g.FillRectangle(whiteBrush, currentRectangle);
            }
            else if (boardMatrix[cellIndex[0], cellIndex[1]] == color.RED)
            {
                g.FillRectangle(redBrush, currentRectangle);
            }
        }

        private void drawBorder(Rectangle currentRectangle, Graphics g)
        {
            g.DrawRectangle(this.blackPen, currentRectangle);
        }

        private void onChecked(Object sender, EventArgs e, bool mouseEvent)
        {

            if (this.HintCheckBox.Checked)
            {
                // YES HINT
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (!validator[i, j])
                        {
                            this.boardMatrix[i, j] = color.RED;
                        }
                    }
                }
            }
            else
            {
                // NO HINT
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (this.boardMatrix[i, j] == color.RED)
                        {
                            if (i % 2 == 0)
                            {
                                if (j % 2 != 0)
                                {
                                    this.boardMatrix[i, j] = color.BLACK;
                                }
                                else
                                {
                                    this.boardMatrix[i, j] = color.WHITE;
                                }
                            }
                            else
                            {
                                if (j % 2 != 0)
                                {
                                    this.boardMatrix[i, j] = color.WHITE;
                                }
                                else
                                {
                                    this.boardMatrix[i, j] = color.BLACK;
                                }
                            }
                        }
                    }
                }
            }
            Invalidate();
            if (mouseEvent) 
            {
                checkWin();
            }
        }

        private void updateValidator(int[] changedCellIndex)
        {
            if (cellSelected[changedCellIndex[0], changedCellIndex[1]] == select.N)
            {
                updateDiagonal(changedCellIndex, true);
                updateRow(changedCellIndex[0], true);
                updateColumn(changedCellIndex[1], true);
            }
            else if (cellSelected[changedCellIndex[0], changedCellIndex[1]] == select.Q)
            {
                updateDiagonal(changedCellIndex, false);
                updateRow(changedCellIndex[0], false);
                updateColumn(changedCellIndex[1], false);
            }
        }

        private int[] getCellIndex(PointF mousePosition)
        {
            if (inRange(mousePosition))
            {
                int i = (int)( (mousePosition.X - 100) / deltaBox);
                int j = (int)( (mousePosition.Y - 100) / deltaBox);
                return new int[] { i, j };
            }
            return null;
        }

        private void updateDiagonal(int[] changedCellIndex, bool newStatus)
        {
            int i = 0;
            while (i <= Math.Max(
                Math.Max(8 - changedCellIndex[0], 8 - changedCellIndex[1]),
                Math.Max(changedCellIndex[0], changedCellIndex[1])
                )
            )
            {
                if (changedCellIndex[0] - i >= 0 && changedCellIndex[1] - i >= 0)
                {
                    validator[changedCellIndex[0] - i, changedCellIndex[1] - i] = newStatus;
                }

                if (changedCellIndex[0] + i < 8 && changedCellIndex[1] + i < 8)
                {
                    validator[changedCellIndex[0] + i, changedCellIndex[1] + i] = newStatus;
                }

                if (changedCellIndex[0] + i < 8 && changedCellIndex[1] - i >= 0)
                {
                    validator[changedCellIndex[0] + i, changedCellIndex[1] - i] = newStatus;
                }

                if (changedCellIndex[0] - i >= 0 && changedCellIndex[1] + i < 8)
                {
                    validator[changedCellIndex[0] - i, changedCellIndex[1] + i] = newStatus;
                }

                i++;
            }
        }

        private void updateRow(int rowIndex, bool newStatus) 
        {
            for (int i = 0; i < 8; i++)
            {
                validator[rowIndex, i] = newStatus;
            }
        }

        private void updateColumn(int columnIndex, bool newStatus) 
        {
            for (int i = 0; i < 8; i++) 
            {
                validator[i, columnIndex] = newStatus;
            }
        }

        private bool inRange(PointF mousePosition) 
        {
            return mousePosition.X <= boardEndPositionX &&
                mousePosition.X >= boardStartPositionX &&
                mousePosition.Y <= boardEndPositionY &&
                mousePosition.Y >= boardStartPositionY;
        }

        private void initializeMatrix() {
            validator = new bool[8, 8] {
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true }
            };

            boardMatrix = new color[8, 8] {
                { color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK},
                { color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE },
                { color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK },
                { color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE },
                { color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK },
                { color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE },
                { color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK },
                { color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE, color.BLACK, color.WHITE }
            };

            cellSelected = new select[8, 8] {
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
                { select.N, select.N, select.N, select.N, select.N, select.N, select.N, select.N },
            };
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            initializeMatrix();
            countQueen = 0;
            Invalidate();
        }

        private void HintCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onChecked(sender, e, false);
        }

        private void checkWin() 
        {
            if (countQueen == 8) {
                MessageBox.Show("You did it!");
            }
        }
    }
}
