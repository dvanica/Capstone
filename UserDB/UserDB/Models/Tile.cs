using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDB.Models
{
    public class Tile
    {
        private string value;
        private int score;
        public string imagePath;
        public string owner;


        public Tile(string letter, int num)
        {
            value = letter;
            score = num;
        }

        public string getValue()
        {
            return value;
        }

        public int getScore()
        {
            return score;
        }

        public String getNewSource()
        {

            return "";
        }

        public string getLink()
        {
            string newSrc;
            switch (value)
            {
                case "A": newSrc = "http://i.imgur.com/z9vlX9v.png"; break;
                case "B": newSrc = "http://i.imgur.com/fFkw2qO.png"; break;
                case "C": newSrc = "http://i.imgur.com/pB2ZqNf.png"; break;
                case "D": newSrc = "http://i.imgur.com/VakY6cL.png"; break;
                case "E": newSrc = "http://i.imgur.com/3hefvZn.png"; break;
                case "F": newSrc = "http://i.imgur.com/zbM0gGB.png"; break;
                case "G": newSrc = "http://i.imgur.com/dhMwX4r.png"; break;
                case "H": newSrc = "http://i.imgur.com/DC7eoit.png"; break;
                case "I": newSrc = "http://i.imgur.com/P54aVv9.png"; break;
                case "J": newSrc = "http://i.imgur.com/59svHlI.png"; break;
                case "K": newSrc = "http://i.imgur.com/a6vhVs0.png"; break;
                case "L": newSrc = "http://i.imgur.com/E7Qcpcs.png"; break;
                case "M": newSrc = "http://i.imgur.com/xpZ0aNL.png"; break;
                case "N": newSrc = "http://i.imgur.com/F3vhM76.png"; break;
                case "O": newSrc = "http://i.imgur.com/AVWZiZC.png"; break;
                case "P": newSrc = "http://i.imgur.com/aP0IZON.png"; break;
                case "Q": newSrc = "http://i.imgur.com/oZ2PRaC.png"; break;
                case "R": newSrc = "http://i.imgur.com/nkNStiz.png"; break;
                case "S": newSrc = "http://i.imgur.com/tKEtukb.png"; break;
                case "T": newSrc = "http://i.imgur.com/Z5WAOCQ.png"; break;
                case "U": newSrc = "http://i.imgur.com/QECvVp2.png"; break;
                case "V": newSrc = "http://i.imgur.com/XeJJE3h.png"; break;
                case "W": newSrc = "http://i.imgur.com/gTNftV6.png"; break;
                case "X": newSrc = "http://i.imgur.com/zzftSWE.png"; break;
                case "Y": newSrc = "http://i.imgur.com/e77tePd.png"; break;
                case "Z": newSrc = "http://i.imgur.com/gBcJFEM.png"; break;
                default: newSrc = "http://i.imgur.com/bbaSk8D.png"; break;
            }

            return newSrc;
        }

    }
}