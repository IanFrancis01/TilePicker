using System;
using System.Drawing;
namespace Assignment_5___Tile_Picker
{
    class Grid
    {
        //private fields/members
        private Tile[,] mGrid;
        private int mRows, mColumns;
        private int mTileSize;

        //Constructors
        public Grid(int Rows, int Columns, int TileSize)
        {
            //store rows, columns, and tile size
            this.mRows = Rows;
            this.mColumns = Columns;
            this.mTileSize = TileSize;

            //set the grid size
            mGrid = new Tile[mRows, mColumns];

            //create each tile in the array
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mColumns; j++)
                {
                    mGrid[i, j] = new Tile();
                }
            }

            //creating variables for the colors being used
            int Red = 0;
            int Blue = 0;
            int Green = 0;
            int Maroon = 0;
            int Aqua = 0;
            int Brown = 0;
            int Black = 0;
            //looping through the colors, displaying them onto the screen.
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    if (Red < 20)
                    {
                        mGrid[i, j].TileColour = Color.Red;
                        Red++;
                    }
                    else if (Blue < 20)
                    {
                        mGrid[i, j].TileColour = Color.Blue;
                        Blue++;
                    }
                    else if (Green < 5)
                    {
                        mGrid[i, j].TileColour = Color.Green;
                        Green++;
                    }
                    else if (Maroon < 5)
                    {
                        mGrid[i, j].TileColour = Color.Maroon;
                        Maroon++;
                    }
                    else if (Aqua < 4)
                    {
                        mGrid[i, j].TileColour = Color.Aqua;
                        Aqua++;
                    }
                    else if (Brown < 5)
                    {
                        mGrid[i, j].TileColour = Color.Brown;
                        Brown++;
                    }
                    else if (Black < 5)
                    {
                        mGrid[i, j].TileColour = Color.Black;
                        Black++;
                    }
                }
            }


            //Creating a randomizer and a temp Color
            Random ColorOrder = new Random();
            Color TempTile;

            //looping through the rows and columns
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    //setting the bounds for the randomizer
                    Rows = ColorOrder.Next(0, 7);
                    Columns = ColorOrder.Next(0, 7);
                    //randomizing the colors
                    TempTile = mGrid[i, j].BackgroundColour;
                    mGrid[i, j].BackgroundColour = mGrid[Rows, Columns].BackgroundColour;
                    mGrid[Rows, Columns].BackgroundColour = TempTile;
                }
            }

            /*
            //creating a loop to detect where the player clicks
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (MaxClicks > 0)
                    {
                        // add if(mouse left click is true)
                        if (mGrid[i, j].BackgroundColour == Color.Red)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Blue)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Green)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Maroon)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Aqua)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Brown)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                        else if (mGrid[i, j].BackgroundColour == Color.Black)
                        {
                            Score += 1;
                            MaxClicks--;
                        }
                    }
                    else
                    {
                        //once the user has maxed out the amount of times they can click
                    }
                }
            }
             */
        }

        //Methods
        public Tile GetTile(int x, int y)
        {
            return mGrid[x, y];
        }

        //X and Y are the left and top of the grid
        public void Draw(Graphics g, int X, int Y)
        {
            int pX = X;
            int pY = Y;
            for (int i = 0; i < this.mRows; i++)
            {
                pY = Y + (i * mTileSize);

                for (int j = 0; j < this.mColumns; j++)
                {
                    pX = X + (j * mTileSize);
                    mGrid[i, j].Draw(g, pX, pY);
                }
            }
        }

    }
}