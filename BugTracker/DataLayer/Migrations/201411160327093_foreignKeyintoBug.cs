namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyintoBug : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserBugs", "User_id", "dbo.Users");
            DropForeignKey("dbo.UserBugs", "Bug_id", "dbo.Bugs");
            DropIndex("dbo.UserBugs", new[] { "User_id" });
            DropIndex("dbo.UserBugs", new[] { "Bug_id" });
            AddColumn("dbo.Bugs", "priorityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bugs", "userId");
            CreateIndex("dbo.Bugs", "priorityId");
            AddForeignKey("dbo.Bugs", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Bugs", "priorityId", "dbo.Priorities", "id", cascadeDelete: true);
            DropTable("dbo.UserBugs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserBugs",
                c => new
                    {
                        User_id = c.Int(nullable: false),
                        Bug_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_id, t.Bug_id });
            
            DropForeignKey("dbo.Bugs", "priorityId", "dbo.Priorities");
            DropForeignKey("dbo.Bugs", "userId", "dbo.Users");
            DropIndex("dbo.Bugs", new[] { "priorityId" });
            DropIndex("dbo.Bugs", new[] { "userId" });
            DropColumn("dbo.Bugs", "priorityId");
            CreateIndex("dbo.UserBugs", "Bug_id");
            CreateIndex("dbo.UserBugs", "User_id");
            AddForeignKey("dbo.UserBugs", "Bug_id", "dbo.Bugs", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserBugs", "User_id", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
