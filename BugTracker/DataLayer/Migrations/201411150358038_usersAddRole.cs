namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersAddRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "role_id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "role_id" });
            RenameColumn(table: "dbo.Users", name: "role_id", newName: "roleId");
            AlterColumn("dbo.Users", "roleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "roleId");
            AddForeignKey("dbo.Users", "roleId", "dbo.Roles", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            AlterColumn("dbo.Users", "roleId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "roleId", newName: "role_id");
            CreateIndex("dbo.Users", "role_id");
            AddForeignKey("dbo.Users", "role_id", "dbo.Roles", "id");
        }
    }
}
