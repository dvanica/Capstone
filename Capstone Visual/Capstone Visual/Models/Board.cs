using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Visual.Models
{
    public class Board : Controller
    {
        public Tile[,] tArray;
        //Arrays used in assigning values to tiles
        private string[] vowels = { "A", "E", "I", "O", "U" };
        private string[] common = { "N", "R", "T", "L", "S", "D", "G", "B", "C", "M", "P", "F", "H", "V", "W", "Y" };
        private string[] uncommon = { "K", "J", "X", "Q", "Z" };
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        //Board instance constructor
        //Eventually will be uploaded to take param to see if 
        //need to load previously saved game or start new game board
        public Board()
        {
            tArray = new Tile[8, 8];
            startNewGame();
        }

        //Start new game function
        //Allocates space for tile array and assigns letters
        public void startNewGame()
        {
            Random rand = new Random();
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j <8; j++){
                    tArray[i, j] = new Tile(assignValue(rand));
                }
            }
        }

        //Chooses which letters to assign, weighted
        //based on string arrays vowels, common, uncommon
        //NOTE: Random passed as reference because new instances are created
        //too closely in time -> end up generating same letter. Single reference fixes this problem.
        //TODO: Play with weighting
        //Possibly map letters so they have point values instead of just random math
        private string assignValue(Random rand)
        {
            string val = "";
            int num = rand.Next(0, 3);
            int num2 = 0;
            switch (num)
            {
                case 0: //Maps to vowel array
                    num2 = rand.Next(0, 5);
                    val = vowels[num2];
                    break;
                case 1: //Maps to common consonants 
                    num2 = rand.Next(0, 16);
                    val = common[num2];
                    break;
                case 2: //Maps to uncommon consanants
                    num2 = rand.Next(0, 5);
                    val = common[num2];
                    break;
            }

            return val;
        }
    }
}