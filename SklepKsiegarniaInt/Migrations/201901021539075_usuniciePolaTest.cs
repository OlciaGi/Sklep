namespace SklepKsiegarniaInt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniciePolaTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ksiazka", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ksiazka", "Test", c => c.String());
        }
    }
}
