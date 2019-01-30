namespace SklepKsiegarniaInt.Migrations
{
    using SklepKsiegarniaInt.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SklepKsiegarniaInt.DAL.KsiazkiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SklepKsiegarniaInt.DAL.KsiazkiContext";
        }

        protected override void Seed(SklepKsiegarniaInt.DAL.KsiazkiContext context)
        {
            KsiazkiInitializer.SeedKsiazkiData(context);
            KsiazkiInitializer.SeedUzytkownicy(context);
      
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
