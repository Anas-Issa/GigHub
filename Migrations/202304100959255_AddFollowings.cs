namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.followings", new[] { "FolloweeId" });
            DropIndex("dbo.followings", new[] { "FollowerId" });
            DropTable("dbo.followings");
        }
    }
}
