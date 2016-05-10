namespace Entity7Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Author_UserId", c => c.Int());
            CreateIndex("dbo.Posts", "Author_UserId");
            AddForeignKey("dbo.Posts", "Author_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Author_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Author_UserId" });
            DropColumn("dbo.Posts", "Author_UserId");
        }
    }
}
