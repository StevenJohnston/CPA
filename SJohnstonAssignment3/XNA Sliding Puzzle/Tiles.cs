//Name: Steven Johnston
//Program: 2250
//Section: 1
//date: 10/31/2012
//Program Name 15 Puzzle
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJohnstonAssignment3
{
    /// <summary>
    /// Tiles class used to create buttons with extra information
    /// </summary>
    public class Tiles : Button
    {
        public int posX, posY;
        public string originalText;
        const int WIDTH = 50;
        const int HEADERSPACE = 100;
        /// <summary>
        /// called if data loaded from file
        /// </summary>
        public Tiles(int y, int x,int columns)
        {
            Text = Convert.ToString(y * columns + x + 1);
            ifFileLoad(y, x, columns);
            originalText = Convert.ToString(y * columns + x + 1);
        }
        /// <summary>
        /// called if data is from fresh from create new game
        /// </summary>
        public Tiles(int y, int x, int columns, String text)
        {
            Text = text;
            ifFileLoad(y, x, columns);
            originalText = Convert.ToString(y * columns + x + 1);
        }
        /// <summary>
        /// Adds dimensions to buttons
        /// </summary>
        public void ifFileLoad(int y, int x,int rows)
        {
            Size = new Size(WIDTH, WIDTH);
            Top = y * WIDTH + HEADERSPACE;
            Left = x * WIDTH+WIDTH;
            posX = x;
            posY = y;
            BackColor = Color.RoyalBlue;
            ForeColor = Color.White;
            
        }
    }
}
