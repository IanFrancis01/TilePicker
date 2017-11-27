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