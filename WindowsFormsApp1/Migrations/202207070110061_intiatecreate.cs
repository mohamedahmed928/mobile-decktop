namespace main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiatecreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerProductAccessierdetailes", "customidaccess", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerProductAccessierdetailes", "idaccess", "dbo.accessierdetailes");
            DropForeignKey("dbo.CustomerProductMobildetailes", "customidmp", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerProductMobildetailes", "idmp", "dbo.mobildetailes");
            DropIndex("dbo.CustomerProductAccessierdetailes", new[] { "customidaccess" });
            DropIndex("dbo.CustomerProductAccessierdetailes", new[] { "idaccess" });
            DropIndex("dbo.CustomerProductMobildetailes", new[] { "customidmp" });
            DropIndex("dbo.CustomerProductMobildetailes", new[] { "idmp" });
            DropTable("dbo.CustomerProductAccessierdetailes");
            DropTable("dbo.CustomerProductMobildetailes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerProductMobildetailes",
                c => new
                    {
                        customidmp = c.Int(nullable: false),
                        idmp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.customidmp, t.idmp });
            
            CreateTable(
                "dbo.CustomerProductAccessierdetailes",
                c => new
                    {
                        customidaccess = c.Int(nullable: false),
                        idaccess = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.customidaccess, t.idaccess });
            
            CreateIndex("dbo.CustomerProductMobildetailes", "idmp");
            CreateIndex("dbo.CustomerProductMobildetailes", "customidmp");
            CreateIndex("dbo.CustomerProductAccessierdetailes", "idaccess");
            CreateIndex("dbo.CustomerProductAccessierdetailes", "customidaccess");
            AddForeignKey("dbo.CustomerProductMobildetailes", "idmp", "dbo.mobildetailes", "id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerProductMobildetailes", "customidmp", "dbo.CustomerProducts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerProductAccessierdetailes", "idaccess", "dbo.accessierdetailes", "id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerProductAccessierdetailes", "customidaccess", "dbo.CustomerProducts", "ID", cascadeDelete: true);
        }
    }
}
