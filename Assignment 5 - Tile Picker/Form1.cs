﻿using System;
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
        //global fields
        Grid GameGrid;
        int GridRows = 8;
        int GridColumns = 8;
        int MaxClicks = 0;
        int UserScore = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            GameGrid = new Grid(GridRows, GridColumns, 50);
            this.Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (GameGrid != null)
            {

                Graphics g = this.CreateGraphics();
                GameGrid.Draw(g, 5, 5);

            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(GameGrid == null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    MessageBox.Show("You must initialize the grid!");
                }
            }
            else
            {

                //creating a loop to detect where the player clicks
                for (int i = 0; i < GridRows; i++)
                {
                    for (int j = 0; j < GridColumns; j++)
                    {
                        if (MaxClicks > 0)
                        {
                            // add if(mouse left click is true)
                            if (GameGrid[i,j].BackgroundColour == Color.Red)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Blue)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Green)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Maroon)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Aqua)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Brown)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                            else if (GameGrid[i, j].BackgroundColour == Color.Black)
                            {
                                UserScore += 1;
                                MaxClicks--;
                            }
                        }
                        else
                        {
                            //once the user has maxed out the amount of times they can click
                        }
                    }
                }
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
