using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserDB.Models
{
    public class Board : Controller
    {
        public Tile[,] tArray;

        //Arrays used in assigning values to tiles
        private string[] vowels = { "A", "E", "I", "O", "U" };
        private string[] common = { "B", "C", "D", "F", "G", "H", "L", "M", "N", "R", "T", "S", "P", "W", "Y" };
        private string[] uncommon = { "J", "K", "Q", "V", "X", "Z" };
        static Dictionary<string, int> letterValues = new Dictionary<string, int> { {"A", 1}, {"B", 5},
            {"C", 3}, {"D", 2}, {"E", 0}, {"F", 4}, {"G", 4}, {"H", 2}, {"I", 1}, {"J", 8},
            {"K", 6}, {"L", 2}, {"M", 3}, {"N", 2}, {"O", 1}, {"P", 5}, {"Q", 10}, {"R", 2},
            {"S", 1}, {"T", 1}, {"U", 3}, {"V", 6}, {"W", 4}, {"X", 8}, {"Y", 4}, {"Z", 10} };

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
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string letter = assignValue(rand);      // get random letter
                    tArray[i, j] = new Tile(letter, letterValues[letter]);
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
            int num = rand.Next(0, 5);
            int num2 = 0;
            switch (num)
            {
                case 0:     // 40% chance of vowel
                case 1:
                    num2 = rand.Next(0, 5);
                    val = vowels[num2];
                    break;
                case 2:     // 40% chance of common consonant
                case 3:
                    num2 = rand.Next(0, 15);
                    val = common[num2];
                    break;
                case 4:     // 20% chance of uncommon consonant
                    num2 = rand.Next(0, 6);
                    val = uncommon[num2];
                    break;
            }

            return val;
        }

        [HttpPost]
        [AllowAnonymous]
        public string processWord(string word)
        {
            return word;
        }
    }
}