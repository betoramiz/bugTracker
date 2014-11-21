namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddeadLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "deadLine", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bugs", "deadLine");
        }
    }
}
