namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdData1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FaculityDetails", "FaculityName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FaculityDetails", "FaculityName", c => c.String(maxLength: 200));
        }
    }
}
