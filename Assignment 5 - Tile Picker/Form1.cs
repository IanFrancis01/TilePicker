using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5___Tile_Picker
{
    public partial class Form1 : Form
    {
        //global field
        Grid myGrid;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            myGrid = new Grid(8, 8, 50);

            this.Refresh();

            //randomize the grid, use while loop
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (myGrid != null)
            {

            Graphics g = this.CreateGraphics();
            myGrid.Draw(g, 5, 5);

            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("X = " + e.X + " Y = " + e.Y);
            }
        }

        private void btnStart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
