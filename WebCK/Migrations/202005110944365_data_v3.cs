namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data_v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "IDFaculity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IDFaculity", c => c.Int(nullable: false));
        }
    }
}
