namespace WebCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDemoData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Specializes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        MSSV = c.String(maxLength: 9),
                        Classs = c.String(maxLength: 50),
                        Address = c.String(),
                        NGAYSINH = c.DateTime(storeType: "smalldatetime"),
                        SDT = c.String(maxLength: 13),
                        EMAIL = c.String(maxLength: 255),
                        GIOITINH = c.Boolean(),
                        DATEBEGIN = c.DateTime(storeType: "smalldatetime"),
                        ID_QUYEN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Specializes");
            DropTable("dbo.Roles");
        }
    }
}
