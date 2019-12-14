namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Int(nullable: false),
                        Pages = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.__MigrationHistory",
            //    c => new
            //        {
            //            MigrationId = c.String(nullable: false, maxLength: 150),
            //            ContextKey = c.String(nullable: false, maxLength: 300),
            //            Model = c.Binary(nullable: false),
            //            ProductVersion = c.String(nullable: false, maxLength: 32),
            //        })
            //    .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
