namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecendDemoData : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Students");
            CreateTable(
                "dbo.Faculities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FaculityName = c.String(maxLength: 200),
                        FaculityDetails_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FaculityDetails", t => t.FaculityDetails_ID)
                .Index(t => t.FaculityDetails_ID);
            
            CreateTable(
                "dbo.FaculityDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDFaculity = c.Int(nullable: false),
                        FaculityName = c.String(maxLength: 200),
                        IndustryName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fanpages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubTitle = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        Link = c.String(),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        IDFaculity = c.Int(nullable: false),
                        MSSV = c.String(maxLength: 9),
                        Address = c.String(),
                        NGAYSINH = c.DateTime(storeType: "smalldatetime"),
                        SDT = c.String(maxLength: 13),
                        EMAIL = c.String(maxLength: 255),
                        GIOITINH = c.Boolean(),
                        DATEBEGIN = c.DateTime(storeType: "smalldatetime"),
                        ID_QUYEN = c.Int(nullable: false),
                        Faculities_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculities", t => t.Faculities_ID)
                .Index(t => t.Faculities_ID);
            
            AddColumn("dbo.Students", "IDFaculity", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Faculities_ID", c => c.Int());
            CreateIndex("dbo.Students", "Faculities_ID");
            AddForeignKey("dbo.Students", "Faculities_ID", "dbo.Faculities", "ID");
            DropTable("dbo.Specializes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specializes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Teachers", "Faculities_ID", "dbo.Faculities");
            DropForeignKey("dbo.Students", "Faculities_ID", "dbo.Faculities");
            DropForeignKey("dbo.Faculities", "FaculityDetails_ID", "dbo.FaculityDetails");
            DropIndex("dbo.Teachers", new[] { "Faculities_ID" });
            DropIndex("dbo.Students", new[] { "Faculities_ID" });
            DropIndex("dbo.Faculities", new[] { "FaculityDetails_ID" });
            DropColumn("dbo.Students", "Faculities_ID");
            DropColumn("dbo.Students", "IDFaculity");
            DropTable("dbo.Teachers");
            DropTable("dbo.Slides");
            DropTable("dbo.Fanpages");
            DropTable("dbo.FaculityDetails");
            DropTable("dbo.Faculities");
            RenameTable(name: "dbo.Students", newName: "Users");
        }
    }
}
