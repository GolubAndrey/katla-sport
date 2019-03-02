using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class AddRequestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.requests",
                c => new
                    {
                        request_id = c.Int(nullable: false, identity: true),
                        request_product_id = c.Int(nullable: false),
                        request_hive_section_id = c.Int(nullable: false),
                        request_product_quantity = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.request_id)
                .ForeignKey("dbo.product_hive_sections", t => t.request_hive_section_id, cascadeDelete: true)
                .ForeignKey("dbo.catalogue_products", t => t.request_product_id, cascadeDelete: true)
                .Index(t => t.request_product_id)
                .Index(t => t.request_hive_section_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.requests", "request_product_id", "dbo.catalogue_products");
            DropForeignKey("dbo.requests", "request_hive_section_id", "dbo.product_hive_sections");
            DropIndex("dbo.requests", new[] { "request_hive_section_id" });
            DropIndex("dbo.requests", new[] { "request_product_id" });
            DropTable("dbo.requests");
        }
    }
}
