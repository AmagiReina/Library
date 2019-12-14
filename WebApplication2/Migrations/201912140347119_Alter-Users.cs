namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUsers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
        }
    }
}
