using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.Models
{
    public class Ksiazka
    {
        public int KsiazkaId { get; set; }
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Wprowadź tytul książki: ")]
        [StringLength(100)]
        public string TytulKsiazki { get; set; }
        [Required(ErrorMessage = "Wprowadź autora książki: ")]
        [StringLength(100)]
        public string AutorKsiazki { get; set; }
        public DateTime DataDodania { get; set; }
        [StringLength(100)]
        public string NazwaPlikuObrazka { get; set; }
        public string OpisKsiazki { get; set; }
        public decimal CenaKsiazki { get; set; }
        public bool Bestseller { get; set; }
        public bool Ukryty { get; set; }
        public string OpisSkrocony { get; set; }
        

        public virtual Kategoria Kategoria { get; set; }
    }
}