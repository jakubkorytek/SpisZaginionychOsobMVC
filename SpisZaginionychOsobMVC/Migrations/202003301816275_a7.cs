namespace SpisZaginionychOsobMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LostPersons", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LostPersons", "Gender", c => c.String());
        }
    }
}
