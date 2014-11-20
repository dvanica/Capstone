﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDB.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HighScore> HighScores { get; set; }
    }
}