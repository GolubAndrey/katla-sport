using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class fixResolveMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
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
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.UserClaim");
            DropTable("dbo.UserLogin");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });

            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });

            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);

            DropForeignKey("dbo.requests", "request_product_id", "dbo.catalogue_products");
            DropForeignKey("dbo.requests", "request_hive_section_id", "dbo.product_hive_sections");
            DropIndex("dbo.requests", new[] { "request_hive_section_id" });
            DropIndex("dbo.requests", new[] { "request_product_id" });
            DropTable("dbo.requests");
            CreateIndex("dbo.UserLogin", "UserId");
            CreateIndex("dbo.UserClaim", "UserId");
            CreateIndex("dbo.User", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.UserRole", "RoleId");
            CreateIndex("dbo.UserRole", "UserId");
            CreateIndex("dbo.Role", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
    }
}
