namespace Entity7Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author_UserId = c.Int(),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.Author_UserId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .Index(t => t.Author_UserId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Author_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.Comments", new[] { "Author_UserId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
