using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment_5___Tile_Picker
{

    /* Name: Ian Francis
     * Date: Monday December 4th 2017
     * Assignment 5: Tile Picker Game
     */
    public partial class Form1 : Form
    {
        //global fields
        Grid GameGrid;
        int GridRows = 8;
        int GridColumns = 8;
        //Variables used for the scoring and mouse click events, excluding the starting score
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

            //initializing the values once the start button is clicked.
            UserScore = 0;
            ClicksLeft = 10;
            lblMaxClicks.Text = ClickOutput + ClicksLeft;
            lblScore.Text = ScoreOutput + UserScore;
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
            //resetting the userscore variable.
            UserScore = 0;

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
                //the size of one cell is 60 x 60. Take this size and do an integer calculation (division)
                //to determine which cell was clicked on
                int X = (e.X / 60);
                int Y = (e.Y / 60);

                if (GameGrid.GetTile(Y, X) == null) return;//if the user clicks outside of the grid

                else
                {
                    //Changing the color of the grid once it is clicked on
                    //checking to see if the cell has already been clicked on
                    if (GameGrid.CheckTile(Y, X) == true)
                    {
                        //the user is notified that they have already clicked on the cell
                        MessageBox.Show("You cannot click on the same tile twice!\n(Don't worry, your score has not been reset.)");
                        lblScore.Text = ScoreOutput + UserScore;
                    }
                    else
                    {
                        GameGrid.GetTile(Y, X).BackgroundColour = GameGrid.GetTile(X, Y).TileColour;
                        //score gets updated depending on the value returned (based on the color cliked)
                        UserScore += GameGrid.GetScore(X, Y);
                        ClicksLeft--;
                    }

                    //print the score and clicks left
                    lblMaxClicks.Text = ClickOutput + ClicksLeft;
                    lblScore.Text = ScoreOutput + UserScore;
                }

                //if the user reaches the max score or higher. Message appears, game resets.
                if (UserScore >= 30)
                {
                    MessageBox.Show("Congratualtions! You've won the game! You earned " + UserScore + " points with " + ClicksLeft + " clicks left!");
                    MessageBox.Show("A new grid will be drawn soon!");
                    
                    //all colours are revealed
                    for (int i = 0; i < GridRows; i++)
                    {
                        for (int j = 0; j < GridColumns; j++)
                        {
                            GameGrid.GetTile(j, i).BackgroundColour = GameGrid.GetTile(j, i).TileColour;
                        }
                    }

                    //score and click counter are reset, form is refreshed.
                    UserScore = 0;
                    ClicksLeft = 10;
                    lblMaxClicks.Text = ClickOutput + ClicksLeft;
                    lblScore.Text = ScoreOutput + UserScore;
                    this.Refresh();

                    //after 10 seconds, a new grid is drawn.
                    Thread.Sleep(10000);
                    GameGrid = new Grid(GridRows, GridColumns, 60);
                }

                //if the user runs out of clicks. Message appears, game resets.
                if (ClicksLeft == 0)
                {
                    MessageBox.Show("You have run out of tries! You earned " + UserScore + "/30 points!");
                    MessageBox.Show("A new grid will be drawn soon!");

                    //all colours are revealed
                    for (int i = 0; i < GridRows; i++)
                    {
                        for (int j = 0; j < GridColumns; j++)
                        {
                            GameGrid.GetTile(j, i).BackgroundColour = GameGrid.GetTile(i, j).TileColour;
                        }
                    }
                    //score and click counter are reset, form is refreshed.
                    UserScore = 0;
                    ClicksLeft = 10;
                    lblMaxClicks.Text = ClickOutput + ClicksLeft;
                    lblScore.Text = ScoreOutput + UserScore;
                    this.Refresh();

                    //after 10 seconds, a new grid is drawn.
                    Thread.Sleep(10000);
                    GameGrid = new Grid(GridRows, GridColumns, 60);
                }
            }

            //Refreshing the page once it's all said and done.
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