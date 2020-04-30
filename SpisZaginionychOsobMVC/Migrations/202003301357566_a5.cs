namespace SpisZaginionychOsobMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsContentManager", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsBanned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsContentManager");
        }
    }
}
