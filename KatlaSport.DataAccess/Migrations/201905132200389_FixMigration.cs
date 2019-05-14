using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class FixMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }

        public override void Down()
        {
            DropColumn("dbo.Role", "Discriminator");
        }
    }
}
