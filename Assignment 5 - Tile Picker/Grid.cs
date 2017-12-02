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
        private int mScore = 0;
        private Tile[,] mNoSpam;
        private bool Check = false;

        //Constructors
        public Grid(int Rows, int Columns, int TileSize)
        {
            //store rows, columns, and tile size
            this.mRows = Rows;
            this.mColumns = Columns;
            this.mTileSize = TileSize;

            //set the grid sizes
            mGrid = new Tile[mRows, mColumns];
            mNoSpam = new Tile[mRows, mColumns];

            //create each tile in the array
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mColumns; j++)
                {
                    mGrid[i, j] = new Tile();
                    mNoSpam[i, j] = new Tile();
                }
            }

            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    mNoSpam[i, j].BackgroundColour = Color.Transparent;
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

            //looping through the colors, placing a fixed amount of each.
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

            //setting the amount of times the randomizer will run
            for (int h = 0; h < 50; h++)
            {
                //looping through the rows and columns
                for (int i = 0; i < mRows; i++)
                {
                    for (int j = 0; j < mColumns; j++)
                    {
                        //setting the bounds for the randomizer
                        Rows = ColorOrder.Next(0, 7);
                        Columns = ColorOrder.Next(0, 7);

                        //randomizing the colors
                        TempTile = mGrid[i, j].TileColour;
                        mGrid[i, j].TileColour = mGrid[Rows, Columns].TileColour;
                        mGrid[Rows, Columns].TileColour = TempTile;
                    }
                }
            }
        }

        //Methods

        //find the cell clicked on and return it
        public Tile GetTile(int x, int y)
        {
            //if the user clicks outside of the grid
            if (x > (mRows - 1) || y > (mColumns - 1))
            {
                return null;
            }
            else
            {
                return mGrid[x, y];
            }
        }

        //check to see if the user has already clicked the cell
        public bool CheckTile(int x, int y)
        {
            if (x > (mRows - 1) || y > (mColumns - 1))
            {
                Check = false;
            }
            else
            {
                if (mNoSpam[x, y].BackgroundColour == Color.Transparent)
                {
                    mNoSpam[x, y].BackgroundColour = Color.Orange;
                    Check = false;
                    return Check;
                }
                else if (mNoSpam[x,y].BackgroundColour == Color.Orange)
                {
                    Check = true;
                    return Check;
                }
            }
            return Check;
        }

        //adding a value to the score counter depending on the color of the cell clicked on
        //returning that value back to the form
        public int GetScore(int x, int y)
        {
            if (mGrid[x, y].TileColour == Color.Red)
            {
                mScore += 1;
            }
            else if (mGrid[x, y].TileColour == Color.Blue)
            {
                mScore += 2;
            }
            else if (mGrid[x, y].TileColour == Color.Green)
            {
                mScore += 3;
            }
            else if (mGrid[x, y].TileColour == Color.Maroon)
            {
                mScore += 5;
            }
            else if (mGrid[x, y].TileColour == Color.Aqua)
            {
                mScore += 10;
            }
            else if (mGrid[x, y].TileColour == Color.Brown)
            {
                mScore += -1;
            }
            else if (mGrid[x, y].TileColour == Color.Black)
            {
                mScore += -3;
            }
            return mScore;
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