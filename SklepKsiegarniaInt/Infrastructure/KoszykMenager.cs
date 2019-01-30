using SklepKsiegarniaInt.DAL;
using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.Infrastructure
{
    public class KoszykMenager
    {
        private KsiazkiContext db;
        private ISessionMenager session;

        public KoszykMenager(ISessionMenager session, KsiazkiContext db)
        {
            this.session = session;
            this.db = db;
        }
        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if (session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }
        public void DodajDoKoszyka(int ksiazkaId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Ksiazka.KsiazkaId == ksiazkaId);

            if (pozycjaKoszyka != null)
                pozycjaKoszyka.Ilosc++;
            else
            {
                var ksiazkaDoDodania = db.Ksiazki.Where(k => k.KsiazkaId == ksiazkaId).SingleOrDefault();

                if (ksiazkaDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Ksiazka = ksiazkaDoDodania,
                        Ilosc = 1,
                        Wartosc = ksiazkaDoDodania.CenaKsiazki
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Consts.KoszykSessionKlucz, koszyk);
        }

        public int UsunZKoszyka(int ksiazkaId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Ksiazka.KsiazkaId == ksiazkaId);

            if (pozycjaKoszyka != null)
            {
                if (pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }

            return 0;
        }
        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Ksiazka.CenaKsiazki));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);
            return ilosc;
        }
        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            noweZamowienie.UserId = userId;

            db.Zamowienia.Add(noweZamowienie);

            if (noweZamowienie.PozycjeZamowienia == null)
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();

            decimal koszykWartosc = 0;

            foreach (var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    KsiazkaId = koszykElement.Ksiazka.KsiazkaId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Ksiazka.CenaKsiazki
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Ksiazka.CenaKsiazki);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz, null);
        }

    }
}

