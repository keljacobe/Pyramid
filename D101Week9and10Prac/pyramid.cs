using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace D101Week9and10Prac
{
    class Pyramid
    {
        private int topHeight;
        private int topWidth;
        private Color topColour;
        private int midHeight;
        private int midWidth;
        private Color midColour;
        private int btmHeight;
        private int btmWidth;
        private Color btmColour;
        private string myName;

        public Pyramid()
        {
            topHeight = 20;
            topWidth = 20;
            topColour = Color.Red;

            midHeight = 20;
            midWidth = 20;
            midColour = Color.Blue;

            btmHeight = 20;
            btmWidth = 20;
            btmColour = Color.Green;
        }

        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }

        public int TopHeight
        {
            get { return topHeight; }
            set { topHeight = value; }
        }

        public int TopWidth
        {
            get { return topWidth; }
            set { topWidth = value; }
        }

        public Color TopColour
        {
            get { return topColour; }
            set { topColour = value; }
        }

        public int MidHeight
        {
            get { return midHeight; }
            set { midHeight = value; }
        }

        public int MidWidth
        {
            get { return midWidth; }
            set { midWidth = value; }
        }

        public Color MidColour
        {
            get { return midColour; }
            set { midColour = value; }
        }

        public int BtmHeight
        {
            get { return btmHeight; }
            set { btmHeight = value; }
        }

        public int BtmWidth
        {
            get { return btmWidth; }
            set { btmWidth = value; }
        }

        public Color BtmColour
        {
            get { return btmColour; }
            set { btmColour = value; }
        }

        public string MyName
        {
            get { return myName; }
            set { myName = value; }
        }

        public override string ToString()
        {
            return myName;
        }
    }
}
