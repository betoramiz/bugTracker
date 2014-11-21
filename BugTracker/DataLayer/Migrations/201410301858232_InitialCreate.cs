namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        project_id = c.Int(),
                        status_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Projects", t => t.project_id)
                .ForeignKey("dbo.Status", t => t.status_id)
                .Index(t => t.project_id)
                .Index(t => t.status_id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        messageText = c.String(nullable: false),
                        commentedDate = c.DateTime(nullable: false),
                        bug_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bugs", t => t.bug_id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.bug_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        role_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.role_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserBugs",
                c => new
                    {
                        User_id = c.Int(nullable: false),
                        Bug_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_id, t.Bug_id })
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .ForeignKey("dbo.Bugs", t => t.Bug_id, cascadeDelete: true)
                .Index(t => t.User_id)
                .Index(t => t.Bug_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "status_id", "dbo.Status");
            DropForeignKey("dbo.Bugs", "project_id", "dbo.Projects");
            DropForeignKey("dbo.Users", "role_id", "dbo.Roles");
            DropForeignKey("dbo.Messages", "user_id", "dbo.Users");
            DropForeignKey("dbo.UserBugs", "Bug_id", "dbo.Bugs");
            DropForeignKey("dbo.UserBugs", "User_id", "dbo.Users");
            DropForeignKey("dbo.Messages", "bug_id", "dbo.Bugs");
            DropIndex("dbo.UserBugs", new[] { "Bug_id" });
            DropIndex("dbo.UserBugs", new[] { "User_id" });
            DropIndex("dbo.Users", new[] { "role_id" });
            DropIndex("dbo.Messages", new[] { "user_id" });
            DropIndex("dbo.Messages", new[] { "bug_id" });
            DropIndex("dbo.Bugs", new[] { "status_id" });
            DropIndex("dbo.Bugs", new[] { "project_id" });
            DropTable("dbo.UserBugs");
            DropTable("dbo.Status");
            DropTable("dbo.Projects");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Bugs");
        }
    }
}
