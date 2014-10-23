//Name: Steven Johnston
//Program: 2250
//Section: 1
//date: 10/31/2012
//Program Name 15 Puzzle
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJohnstonAssignment3
{
    /// <summary>
    /// Main class 
    /// </summary>
    public partial class Puzzle : Form
    {
        int randomLoop,rows,columns;
        Point empty;
        const int ONEHUNDRED = 100;
        Tiles[,] tiles;
        string[] fileText;
        bool moveXorY;
        Tiles Temp;
        /// <summary>
        /// Intialized components
        /// </summary>
        public Puzzle()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Swaps the empty Tile with the Tile that has x and y offset
        /// </summary>
        /// <param name="emptyY">Y location of the empty tile</param>
        /// <param name="emptyX">X location of the empty tile</param>
        /// <param name="changedY">The Value to change Y</param>
        /// <param name="changedX">The Value to change X</param>
        public void Swap(int emptyY, int emptyX,int changedY,int changedX)
        {
            tiles[emptyY, emptyX].Text = tiles[emptyY+changedY,emptyX+changedX ].Text;
            tiles[emptyY, emptyX].Visible = true;
            tiles[emptyY + changedY, emptyX + changedX].Visible = false;
            tiles[emptyY + changedY, emptyX + changedX].Text = "empty";
            empty = new Point(emptyX+changedX,emptyY+changedY);
        }
        /// <summary>
        /// Randomized the value of the buttons
        /// </summary>
        public void Randomizer()
        {
            Random r = new Random();
            for(int i = 0;i < rows*columns*4+r.Next(4);i++)
            {
                moveXorY = !moveXorY;
                if (moveXorY)
                {
                    while (true)
                    {
                        Temp = tiles[empty.Y, r.Next(0, columns)];
                        if (Temp != tiles[empty.Y, empty.X])
                            break;
                    }
                }
                else
                {
                    while (true)
                    {
                        Temp = tiles[r.Next(0, rows), empty.X];
                        if (Temp != tiles[empty.Y, empty.X])
                            break;
                    }
                }
                preSwap(Temp);
            }
           
        }
        /// <summary>
        /// called to swamp the empty Tile with sent Tile and move all the ones in between 
        /// </summary>
        /// <param name="t"></param>
        public void preSwap(Tiles t)
        {
            if (t.posX == empty.X)
            {
                if (empty.Y < t.posY)
                    for (int i = empty.Y; i < t.posY; i++)
                        Swap(i, empty.X, 1, 0);
                else
                    for (int i = empty.Y; i > t.posY; i--)
                        Swap(i, empty.X, -1, 0);
            }
            else if (t.posY == empty.Y)
            {
                if (empty.X < t.posX)
                    for (int i = empty.X; i < t.posX; i++)
                        Swap(empty.Y, i, 0, 1);
                else
                    for (int i = empty.X; i > t.posX; i--)
                        Swap(empty.Y, i, 0, -1);
            }
        }
        /// <summary>
        /// Creates array of class Tiles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSet_Click(object sender, EventArgs e)
        {
            Reset();
            try { rows = Convert.ToInt16(txtRows.Text); }
            catch (Exception) { };
            try{columns = Convert.ToInt16(txtColumns.Text); }
            catch(Exception){ };
            if ((rows < 2 || columns < 2) && rows * columns < 4000)
                MessageBox.Show("Both rows and columns must be greater then 1");
            else
            {
                tiles = new Tiles[rows, columns];
                empty = new Point(columns - 1, rows - 1);
                for (int y = 0; y < rows; y++)
                    for (int x = 0; x < columns; x++)
                    {
                        tiles[y, x] = new Tiles(y, x, columns);
                        tiles[y, x].Click += Puzzle_Click;
                        this.Controls.Add(tiles[y, x]);
                    }
                tiles[empty.Y, empty.X].Visible = false;
                tiles[empty.Y, empty.X].originalText = "empty";
                randomLoop = (int)(rows * columns * 4);
                Randomizer();
                if (Complete())
                    cmdreset_Click(sender, EventArgs.Empty);
            }
        }
        /// <summary>
        /// onCLick for Tiles Class Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Puzzle_Click(object sender, EventArgs e)
        {
            Tiles t = (Tiles)sender;
            preSwap(t);
            if (Complete())
            {
                MessageBox.Show("Winner Play Again");
                cmdSet_Click(sender , e);
            }
        }
        /// <summary>
        /// Checks if all the Tiles have text Equal to there original text meaning its at a winning state
        /// </summary>
        /// <returns>true if you win false if you dont</returns>
        public bool Complete()
        {
            for (int x = 0; x < tiles.GetLength(0); x++)
                for (int y = 0; y < tiles.GetLength(1); y++)
                    if (tiles[x, y].Text != tiles[x, y].originalText)
                        return false;
            return true;
        }
        /// <summary>
        /// Loops through Tiles and removes them from the Controls
        /// </summary>
        public void Reset()
        {
            try
            {
                foreach (var item in tiles)
                    this.Controls.Remove(item);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Calls reset Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdreset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Opens saveFileDialog to save gae state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileSaver.RestoreDirectory = true;
            if(fileSaver.ShowDialog() == DialogResult.OK)
            {
                    StreamWriter writer = new StreamWriter(fileSaver.FileName);
                    writer.WriteLine(rows + "," + columns);
                    for (int y = 0; y < rows; y++)
                    {
                        string stringLine = "";
                        for (int x = 0; x < columns; x++)
                            stringLine += tiles[y,x].Text + ",";
                        writer.WriteLine(stringLine);
                    }
                    writer.Close();   
            }
        }
        /// <summary>
        /// Opens openFileDialog to load game saves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileReader = new OpenFileDialog();

            fileReader.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileReader.RestoreDirectory = true;

            if (fileReader.ShowDialog() == DialogResult.OK)
            {
                fileText = System.IO.File.ReadAllLines(fileReader.FileName);
                GameSetLoad();
            }
        }
        /// <summary>
        /// Called when need to set game from a load sate
        /// </summary>
        public void GameSetLoad()
        {
            Reset();
            string[] rowsColumns = fileText[0].Split(',');
            rows = Convert.ToInt16(rowsColumns[0]);
            columns = Convert.ToInt16(rowsColumns[1]);
            tiles = new Tiles[rows, columns];
            for (int y = 0; y < rows; y++)
            {
                string[] rowText = fileText[y+1].Split(',');
                for (int x = 0; x < columns; x++)
                {
                    tiles[y, x] = new Tiles(y, x, columns, rowText[x]);
                    tiles[y, x].Click += Puzzle_Click;
                    this.Controls.Add(tiles[y, x]);
                    if (rowText[x] == "empty")
                    {
                        tiles[y, x].Visible = false;
                        empty.X = x;
                        empty.Y = y;
                    }
                }
            }
            tiles[rows-1, columns-1].originalText = "empty";
        }
    }
}
