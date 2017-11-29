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
        private Color mBackgroundColor;

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
                        mGrid[i, j].BackgroundColour = Color.Red;
                        Red++;
                    }
                    else if (Blue < 20)
                    {
                        mGrid[i, j].BackgroundColour = Color.Blue;
                        Blue++;
                    }
                    else if (Green < 5)
                    {
                        mGrid[i, j].BackgroundColour = Color.Green;
                        Green++;
                    }
                    else if (Maroon < 5)
                    {
                        mGrid[i, j].BackgroundColour = Color.Maroon;
                        Maroon++;
                    }
                    else if (Aqua < 4)
                    {
                        mGrid[i, j].BackgroundColour = Color.Aqua;
                        Aqua++;
                    }
                    else if (Brown < 5)
                    {
                        mGrid[i, j].BackgroundColour = Color.Brown;
                        Brown++;
                    }
                    else if (Black < 5)
                    {
                        mGrid[i, j].BackgroundColour = Color.Black;
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
                    Rows =  ColorOrder.Next(0, 7);
                    Columns = ColorOrder.Next(0, 7);
                    //randomizing the colors
                    TempTile = mGrid[i, j].BackgroundColour;
                    mGrid[i, j].BackgroundColour = mGrid[Rows, Columns].BackgroundColour;
                    mGrid[Rows, Columns].BackgroundColour = TempTile;
                }
            }
            
        }

        //Methods
        public Tile GetTile(int Row, int Column)
        {
            return mGrid[Row - 1, Column - 1];
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