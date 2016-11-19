namespace HRSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAspModif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "Adresse", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Adresse");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
