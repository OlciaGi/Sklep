using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.Models
{
    public class Zamowienie
    {
        public int ZamowienieId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Wprowadź imię: ")]
        [StringLength(100)]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko: ")]
        [StringLength(100)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź adres: ")]
        [StringLength(100)]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Wprowadź miasto: ")]
        [StringLength(100)]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy: ")]
        [StringLength(100)]
        public string KodPocztowy { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Komentarz { get; set; }
        public DateTime DataDodania { get; set; }
        public StanZamowienia StanZamowienia { get; set; }
        public decimal WartoscZamowienia { get; set; }

        public List<PozycjaZamowienia> PozycjeZamowienia { get; set; }

    }
    public enum StanZamowienia
    {
        Nowe,
        Zrealizowane
    }
}