namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterOrderBook : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderBooks", "UserId");
            CreateIndex("dbo.OrderBooks", "BookId");
            AddForeignKey("dbo.OrderBooks", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderBooks", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBooks", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderBooks", "BookId", "dbo.Books");
            DropIndex("dbo.OrderBooks", new[] { "BookId" });
            DropIndex("dbo.OrderBooks", new[] { "UserId" });
        }
    }
}
