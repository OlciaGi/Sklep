namespace SklepKsiegarniaInt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniePolaTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ksiazka", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ksiazka", "Test");
        }
    }
}
