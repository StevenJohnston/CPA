/*SJohnstonAssignment2.cs
 * Assignment 2
 * 
 * Revision History
 *  Steven Johnston, 2013.9.25: Started
 *  Steven Johnston, 2013.10.1: Completed */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJohnstonAssignment2
{
    /// <summary>
    /// Tic Tac Toe game, X goes first first to 3 in a row wins.
    /// </summary>
    public partial class SJohnstonAssignment2 : Form
    {
        const int ROWS = 3;
        const int WIDTH = 146;
        const int SPACE = 20;
        PictureBox[,] tiles = new PictureBox[ROWS, ROWS];
        int[,] taken = new int[ROWS, ROWS];
        int turn = 1; // 1 = X , 2 = O
        Image[] xOPicture = new Image[3];
        int turnCount = 0;
        string[] xO = {"","X","O" };
        public SJohnstonAssignment2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creates all the pictureboxs for the grid. fetches pictures from resource folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int y=0;y<ROWS;y++)
                for (int x = 0; x < ROWS; x++)
                {
                    tiles[x, y] = new PictureBox();
                    tiles[x, y].Size = new Size(WIDTH,WIDTH);
                    tiles[x, y].Left = x * WIDTH+(SPACE*x);
                    tiles[x, y].Top = y * WIDTH+SPACE*y;
                    this.Controls.Add(tiles[x, y]);
                    tiles[x, y].Click += SJohnstonAssignment2_Click;
                }
            xOPicture[1] = Properties.Resources.X;
            xOPicture[2] = Properties.Resources.O;
        }
        /// <summary>
        /// On pictureBox click, finds the one thats was clicked, 
        ///     checks if its open, updates properties 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SJohnstonAssignment2_Click(object sender, EventArgs e)
        {
            int tempX=0;
            int tempY=0;
            for (int y = 0; y < ROWS; y++)
                for (int x = 0; x < ROWS; x++)
                    if (sender == tiles[x, y])
                    {
                        tempX = x;
                        tempY = y;
                        goto endloops;
                    }
            endloops:
            switch (taken[tempX,tempY])
            { 
                case 0:
                    taken[tempX, tempY] = turn;
                    tiles[tempX, tempY].Image = xOPicture[turn];
                    turnCount++;
                    checkWinner(tempX, tempY);
                    if (turnCount == 9)
                    {
                        MessageBox.Show("Tie Game, Game will reset");
                        gameReset();
                    }   
                    turn = turn == 1 ? 2 : 1;
                    break;
                case 1: case 2:
                    MessageBox.Show("Taken");
                    break;
            }
        }
        /// <summary>
        /// Checks after players turn if the move they made is a 
        ///     winning move by checking fields horizontal, 
        ///     vertical to the tile clicked also checks diaginal 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void checkWinner(int x, int y)
        {
            int horizontalTotal = 0;
            int verticalTotal = 0;
            int backslashTotal = 0;
            int forwardslashTotal = 0;
            for (int i = 0; i < ROWS; i++)
            {
                horizontalTotal += taken[i, y] == turn ? 1 : 0;
                verticalTotal += taken[x, i] == turn ? 1 : 0;
                backslashTotal += taken[i, i] == turn ? 1 : 0;
                forwardslashTotal += taken[(ROWS-1) - i, i] == turn ? 1 : 0;
            }
            if (horizontalTotal == ROWS || verticalTotal == ROWS ||
                backslashTotal == ROWS || forwardslashTotal == ROWS)
            {
                MessageBox.Show(xO[turn] + " is the winner, Game will reset");
                gameReset();
            }
        }
        /// <summary>
        /// resets all important variables
        /// </summary>
        public void gameReset()
        { 
            for (int y = 0; y < ROWS; y++)
                for (int x = 0; x < ROWS; x++)
                {
                    tiles[x, y].Image=xOPicture[0];
                    taken[x, y] = 0;
                    turn = 2;
                    turnCount = 0;
                }
        }
    }
}
