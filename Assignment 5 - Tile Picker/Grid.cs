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
        private int Score;

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
            for (int h = 0; h < 5; h++)
            {

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
        public Tile GetTile(int x, int y)
        {
            if(x > (mRows-1) || y > (mColumns-1))
            {
                return null;
            }
            else
            {
                return mGrid[x, y];
            }
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