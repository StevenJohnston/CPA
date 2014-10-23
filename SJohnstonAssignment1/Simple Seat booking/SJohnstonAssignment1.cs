/* SJassignment1.cs 
 * * Assignment 1 
 * 
 *  Revision History 
 *      Steven Johnston, 2013.9.12: Started
 *      Steven Johnston, 2013.9.19: completed */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJAssignment1
{
    public partial class sjassignment1 : Form
    {
        const int ROWS = 5;
        const int COLUMNS = 3;
        const int BTNSIZE = 40;
        string[] letters = { "A", "B", "C", "D", "E" };
        Button[,] cmdSeats = new Button[ROWS, COLUMNS];
        string[,] seats = new string[ROWS, COLUMNS];
        List<string> waiting = new List<string>();

        public sjassignment1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Onload Creates the grid of buttons and adds letters and number to the listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            lstLetters.Items.RemoveAt(0);
            lstNumbers.Items.RemoveAt(0);
            for(int y = 0; y < ROWS; y++)
            {
                for(int x = 0 ; x < COLUMNS ;x++)
                {
                    Button cmdSeats = new Button();
                    cmdSeats.Top = y * BTNSIZE + BTNSIZE;
                    cmdSeats.Left = x * BTNSIZE + BTNSIZE;
                    cmdSeats.Size = new Size(BTNSIZE, BTNSIZE);
                    cmdSeats.Text = Convert.ToString(letters[y] + x);
                    this.Controls.Add(cmdSeats);
                }
                lstLetters.Items.Add(letters[y]);
            }
            for (int x = 0; x < COLUMNS; x++)
                lstNumbers.Items.Add(Convert.ToString(x));
        }

        private void lstLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStatus();
        }

        private void lstNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStatus();
        }

        /// <summary>
        /// Adds name to seat makes seat unavalible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Enter a name");
            else
            {
                seats[lstLetters.SelectedIndex, lstNumbers.SelectedIndex] = txtName.Text;
                updateWaiting();
                updateStatus();
                cmdWaiting.Enabled = isSeatsFull();
                updateTaken();
                MessageBox.Show("Seat Reserved");
            }
        }

        /// <summary>
        /// Clears seat Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (waiting.Count != 0)
            {
                seats[lstLetters.SelectedIndex, lstNumbers.SelectedIndex] = waiting[0];
                waiting.RemoveAt(0);
                MessageBox.Show("Seat cleared and re-filled by waiting");
            }
            else
            {
                seats[lstLetters.SelectedIndex, lstNumbers.SelectedIndex] = null;
                MessageBox.Show("Seat now empty");
            }
            updateStatus();
            cmdWaiting.Enabled = isSeatsFull();
            updateTaken();
            updateWaiting();

        }

        /// <summary>
        /// adds name to waiting list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdWaiting_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Enter a name");
            else waiting.Add(txtName.Text);
            updateWaiting();
        }

        /// <summary>
        /// fills all 15 seats with names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFill_Click(object sender, EventArgs e)
        {
            seats = new string[,]
            { 
                { "Steven", "David", "Cathy" }, 
                { "Kevin", "Randy", "Fred" },
                { "Harley", "Jimmy", "Glen" }, 
                { "Zach", "Brandon", "Robert" }, 
                { "Joe", "Wes", "Andrew" } 
            };
            updateWaiting();
            updateTaken();
            updateStatus();
            cmdWaiting.Enabled = isSeatsFull();
        }

        /// <summary>
        /// Returns true if all the seats are full
        /// </summary>
        /// <returns></returns>
        public bool isSeatsFull()
        {
            foreach (string item in seats)
                if (item == null)
                    return false;
            return true;
            
        }

        /// <summary>
        /// updates the seats taken list
        /// </summary>
        public void updateTaken()
        {
            lstTaken.Items.Clear();
            for (int x = 0; x < ROWS; x++)
                for (int y = 0; y < COLUMNS; y++)
                    if (seats[x, y]!=null)
                        lstTaken.Items.Add(seats[x, y] + "\t" + letters[x] + Convert.ToString(y));
        }

        /// <summary>
        /// refreshes waiting list
        /// </summary>
        public void updateWaiting()
        {
            lstWaiting.Items.Clear();
            foreach (string item in waiting)
                lstWaiting.Items.Add(item);
        }

        /// <summary>
        /// Updates the state of the buttons and the status textbox depending on the seat selecteds 
        /// avalibility
        /// </summary>
        public void updateStatus()
        {

            if (lstLetters.SelectedIndex != -1 && lstNumbers.SelectedIndex != -1)
            {
                if (seats[lstLetters.SelectedIndex, lstNumbers.SelectedIndex] == null)
                {
                    lblcStatus.Text = "Avalible";
                    cmdRemove.Enabled = false;
                    cmdBook.Enabled = true;
                }
                else
                {
                    lblcStatus.Text = "Taken";
                    cmdRemove.Enabled = true;
                    cmdBook.Enabled = false;
                }
            }
        }
    }
}
