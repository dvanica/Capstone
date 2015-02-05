using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Models
{
    public class UserDB : DbContext
    {
        public UserDB() : base("name=DefaultConnection")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HighScore> HighScores {get; set;}
    }
}