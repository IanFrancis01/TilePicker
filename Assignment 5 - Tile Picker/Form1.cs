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
        //global fields
        Grid GameGrid;
        int GridRows = 8;
        int GridColumns = 8;
        string ClickOutput = "Clicks left: ";
        string ScoreOutput = "Score: ";
        int ClicksLeft = 10;
        int UserScore = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //initializing the grid
            GameGrid = new Grid(GridRows, GridColumns, 60);
            this.Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (GameGrid != null)
            {
                //drawing the grid
                Graphics g = this.CreateGraphics();
                GameGrid.Draw(g, 5, 5);

            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameGrid == null)
            {
                //if the user clicks on the screen before starting the game
                if (e.Button == MouseButtons.Left)
                {
                    MessageBox.Show("You must initialize the grid to play!");
                }
            }
            else
            {

                //code to detect mouse click, add to score depending on the color clicked
                int X = (e.X / 60);
                int Y = (e.Y / 60);
                if (GameGrid.GetTile(Y, X) != null)
                {

                    GameGrid.GetTile(Y, X).BackgroundColour = GameGrid.GetTile(X, Y).TileColour;
                    ClicksLeft--;

                    if (GameGrid.GetTile(X, Y).TileColour == Color.Red)
                    {
                        UserScore += 1;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Blue)
                    {
                        UserScore += 2;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Green)
                    {
                        UserScore += 3;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Maroon)
                    {
                        UserScore += 5;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Aqua)
                    {
                        UserScore += 10;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Brown)
                    {
                        UserScore += -1;
                    }
                    else if (GameGrid.GetTile(X, Y).TileColour == Color.Black)
                    {
                        UserScore += -3;
                    }

                    //print the score and clicks left
                    lblMaxClicks.Text = ClickOutput + ClicksLeft;
                    lblScore.Text = ScoreOutput + UserScore;
                }
                else
                {
                    //if the user clicks outside of the grid
                    MessageBox.Show("Oops! You have clicked outside of the grid!");
                }

                //if the user reaches the max score or higher
                if (UserScore >= 30)
                {
                    MessageBox.Show("Congratualtions! You've won the game!");
                    GameGrid = new Grid(GridRows, GridColumns, 60);
                    UserScore = 0;
                    ClicksLeft = 10;
                    lblMaxClicks.Text = ClickOutput + ClicksLeft;
                    lblScore.Text = ScoreOutput + UserScore;
                }

                //if the user runs out of clicks
                if (ClicksLeft == 0)
                {
                    MessageBox.Show("You have run out of tries! You had " + UserScore + " points.");
                    GameGrid = new Grid(GridRows, GridColumns, 60);
                    UserScore = 0;
                    ClicksLeft = 10;
                    lblMaxClicks.Text = ClickOutput + UserScore;
                    lblScore.Text = ScoreOutput + UserScore;
                }
            }
            this.Refresh();

        }

        private void btnStart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
