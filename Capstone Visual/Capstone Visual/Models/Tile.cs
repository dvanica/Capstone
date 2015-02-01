using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Visual.Models
{
    public class Tile
    {
        public int value;
        public string imagePath;
        public string color;
        public Boolean isClicked;

        public Tile()
        {
            isClicked = false;
            imagePath = "http://i.imgur.com/iPXQebh.png?1";
            value = 0;
        }

        public void click()
        {
            if (isClicked)
            {
                isClicked = false;
                imagePath = "http://i.imgur.com/iPXQebh.png?1";
            }
            else
            {
                isClicked = true;
                imagePath = "http://i.imgur.com/rVwGtys.png";
            }
        }

    }

    public class TileArray
    {
        public Tile[,] TileBoard = new Tile[8,8];

        public TileArray()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    TileBoard[i, j] = new Tile();
                }
            }
        }



    }

    
}