namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(maxLength: 100),
                        Content = c.String(maxLength: 150),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subjects");
        }
    }
}
