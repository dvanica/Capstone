namespace UserDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "University", c => c.String());
            AddColumn("dbo.UserProfile", "isPlaying", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "isPlaying");
            DropColumn("dbo.UserProfile", "University");
        }
    }
}
