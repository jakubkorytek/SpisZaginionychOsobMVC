namespace SpisZaginionychOsobMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsContentManager");
            DropColumn("dbo.AspNetUsers", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsContentManager", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Role");
        }
    }
}
