using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserDB.Models
{
        // Sets all the attributes of the UserProfile db
        [Table("UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            // Every user will have an ID, username, university, highscore, and last played score
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string University { get; set; }
            public int isPlaying { get; set; }
            public int lastPlayedScore { get; set; }
            public int highScore { get; set; }
        }
    
}