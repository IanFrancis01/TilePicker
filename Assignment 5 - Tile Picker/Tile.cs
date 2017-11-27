using System;
using System.Drawing;

namespace Assignment_5___Tile_Picker
{
    class Tile
    {
        //private fields/members
        private int mSize;
        private Color mBackgroundColour;
        private Color mBorderColour;

        //Constructor
        public Tile()
        {
            //default white to white with black border
            this.mSize = 50;  //default to 50 pixels
            this.mBackgroundColour = Color.White;
            this.mBorderColour = Color.Black;

        }

        public Tile(int Size, Color BackgroundColour, Color BorderColour)
        {
            this.mSize = Size;
            this.mBackgroundColour = BackgroundColour;
            this.mBorderColour = BorderColour;

        }

        //Methods
        public void Draw(Graphics g, int X, int Y)
        {
            //will draw a tile on graphics object
            //x and y represent the location of 
            //top left corner of the tile

            //create a pen and a brush to draw with
            Pen BorderPen = new Pen(this.mBorderColour);
            SolidBrush BackBrush = new SolidBrush(this.mBackgroundColour);

            //draw tile
            g.FillRectangle(BackBrush, X, Y, this.mSize, this.mSize);
            g.DrawRectangle(BorderPen, X, Y, this.mSize, this.mSize);
            

            //dispose of drawing objects
            BorderPen.Dispose();
            BackBrush.Dispose();

        }

        //Properties
        public int Size
        {
            set { this.mSize = value; }
            get { return this.mSize; }
        }

        public Color BackgroundColour
        {
            set { this.mBackgroundColour = value; }
            get { return this.mBackgroundColour; }

        }

        public Color BorderColour
        {
            set { this.mBorderColour = value; }
            get { return this.mBorderColour; }

        }
    }
}
