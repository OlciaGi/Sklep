using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.ViewModels
{
    public class EditKsiazkiViewModel
    {
        public Ksiazka Ksiazka { get; set; }
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}
