namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EMAIL = c.String(maxLength: 255),
                        PASSWORD = c.String(),
                        Roles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Roles_ID)
                .Index(t => t.Roles_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        IDFaculity = c.Int(nullable: false),
                        MSGV = c.String(maxLength: 9),
                        Address = c.String(),
                        NGAYSINH = c.DateTime(storeType: "smalldatetime"),
                        SDT = c.String(maxLength: 13),
                        EMAIL = c.String(maxLength: 255),
                        GIOITINH = c.Boolean(),
                        DATEBEGIN = c.DateTime(storeType: "smalldatetime"),
                        Faculities_ID = c.Int(),
                        Roles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculities", t => t.Faculities_ID)
                .ForeignKey("dbo.Roles", t => t.Roles_ID)
                .Index(t => t.Faculities_ID)
                .Index(t => t.Roles_ID);
            
            CreateTable(
                "dbo.Faculities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FaculityName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IndustryofFaculities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FaculityID = c.Int(nullable: false),
                        IndustryName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculities", t => t.FaculityID, cascadeDelete: true)
                .Index(t => t.FaculityID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        IDFaculity = c.Int(nullable: false),
                        MSSV = c.String(maxLength: 9),
                        Classs = c.String(maxLength: 50),
                        Address = c.String(),
                        NGAYSINH = c.DateTime(storeType: "smalldatetime"),
                        SDT = c.String(maxLength: 13),
                        EMAIL = c.String(maxLength: 255),
                        GIOITINH = c.Boolean(),
                        DATEBEGIN = c.DateTime(storeType: "smalldatetime"),
                        Faculities_ID = c.Int(),
                        IndustryofFaculities_ID = c.Int(),
                        Subjects_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculities", t => t.Faculities_ID)
                .ForeignKey("dbo.IndustryofFaculities", t => t.IndustryofFaculities_ID)
                .ForeignKey("dbo.Subjects", t => t.Subjects_ID)
                .Index(t => t.Faculities_ID)
                .Index(t => t.IndustryofFaculities_ID)
                .Index(t => t.Subjects_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(maxLength: 100),
                        Content = c.String(maxLength: 150),
                        Description = c.String(),
                        Teachers_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teachers", t => t.Teachers_ID)
                .Index(t => t.Teachers_ID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Roles_ID", "dbo.Roles");
            DropForeignKey("dbo.Teachers", "Faculities_ID", "dbo.Faculities");
            DropForeignKey("dbo.Subjects", "Teachers_ID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Subjects_ID", "dbo.Subjects");
            DropForeignKey("dbo.Students", "IndustryofFaculities_ID", "dbo.IndustryofFaculities");
            DropForeignKey("dbo.Students", "Faculities_ID", "dbo.Faculities");
            DropForeignKey("dbo.IndustryofFaculities", "FaculityID", "dbo.Faculities");
            DropForeignKey("dbo.Accounts", "Roles_ID", "dbo.Roles");
            DropIndex("dbo.Subjects", new[] { "Teachers_ID" });
            DropIndex("dbo.Students", new[] { "Subjects_ID" });
            DropIndex("dbo.Students", new[] { "IndustryofFaculities_ID" });
            DropIndex("dbo.Students", new[] { "Faculities_ID" });
            DropIndex("dbo.IndustryofFaculities", new[] { "FaculityID" });
            DropIndex("dbo.Teachers", new[] { "Roles_ID" });
            DropIndex("dbo.Teachers", new[] { "Faculities_ID" });
            DropIndex("dbo.Accounts", new[] { "Roles_ID" });
            DropTable("dbo.Slides");
            DropTable("dbo.Fanpages");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.IndustryofFaculities");
            DropTable("dbo.Faculities");
            DropTable("dbo.Teachers");
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
        }
    }
}
