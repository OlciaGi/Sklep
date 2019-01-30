using Microsoft.AspNet.Identity.EntityFramework;
using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.DAL
{
    public class KsiazkiContext : IdentityDbContext<ApplicationUser>
    {
        public KsiazkiContext() : base("KsiazkiContext")
        {

        }
        static KsiazkiContext()
        {
            Database.SetInitializer<KsiazkiContext>(new KsiazkiInitializer());
            //uruchamiam initializer zeby dane dodac do tabel
        }
        public static KsiazkiContext Create()
        {
            return new KsiazkiContext();
        }

        public virtual DbSet<Ksiazka> Ksiazki { get; set; }
        public virtual DbSet<Kategoria> Kategorie { get; set; }
        public virtual DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }
         
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // using System.Data.Entity.ModelConfiguration.Conventions;
            // Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel w bazie danych
            // Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //usuwa liczbe mnoga
        }
    }
}
