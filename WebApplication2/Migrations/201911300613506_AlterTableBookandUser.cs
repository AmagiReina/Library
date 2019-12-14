namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableBookandUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            DropColumn("dbo.Books", "Pages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Pages", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Address");
        }
    }
}
