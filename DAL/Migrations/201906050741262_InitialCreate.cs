namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "FullName", c => c.String(nullable: false));
        }
    }
}
