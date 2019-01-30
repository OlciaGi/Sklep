namespace SklepKsiegarniaInt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniePolaOpisSkrocony : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ksiazka", "OpisSkrocony", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ksiazka", "OpisSkrocony");
        }
    }
}
