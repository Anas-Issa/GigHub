namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNotification : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserNotifications", "userid");
            CreateIndex("dbo.UserNotifications", "NotificationId");
            AddForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserNotifications", "userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "userid" });
        }
    }
}
