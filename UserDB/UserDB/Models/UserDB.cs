using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UserDB.Models
{
    public class UserDB : DbContext
    {
        // Set connection string
        public UserDB() : base("name=DefaultConnection")
        {}
        
        // Set collections of UserProfiles, Users, and HighScores
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HighScore> HighScores {get; set;}
    }
}