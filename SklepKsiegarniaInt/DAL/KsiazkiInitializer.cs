using SklepKsiegarniaInt.Models;
using SklepKsiegarniaInt.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Configuration = SklepKsiegarniaInt.Migrations.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SklepKsiegarniaInt.DAL
{
    public class KsiazkiInitializer : MigrateDatabaseToLatestVersion<KsiazkiContext, Configuration>
    {           //migruje baze danych do najnowszej wersji, nie usuwajac danych wczesniej zapisanych
        public static void SeedKsiazkiData(KsiazkiContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId=1, NazwaKategorii="Przygodowe", NazwaPlikuIkony="przygodowe.png", OpisKategorii=" opis przygodowe"  },
                new Kategoria() {KategoriaId=2, NazwaKategorii="Horror", NazwaPlikuIkony="horror.png", OpisKategorii=" opis horror"  },
                new Kategoria() {KategoriaId=3, NazwaKategorii="Fantastyka", NazwaPlikuIkony="fantastyka.png", OpisKategorii=" opis famtastyka"  },
                new Kategoria() {KategoriaId=4, NazwaKategorii="Klasyka", NazwaPlikuIkony="klasyka.png", OpisKategorii=" opis klasyka"  },
                new Kategoria() {KategoriaId=5, NazwaKategorii="Kryminał", NazwaPlikuIkony="kryminal.png", OpisKategorii=" opis kryminal"  },
                new Kategoria() {KategoriaId=6, NazwaKategorii="Romans", NazwaPlikuIkony="romans.png", OpisKategorii=" opis romans"  },
                new Kategoria() {KategoriaId=7, NazwaKategorii="Dla Dzieci", NazwaPlikuIkony="dladzieci.png", OpisKategorii=" opis dla dzieci"  },
            };
            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));//AddOrUpdate
            context.SaveChanges();

            var ksiazki = new List<Ksiazka>
            {
                new Ksiazka() { KsiazkaId = 1, AutorKsiazki="W. Bruce Cameron", TytulKsiazki=" Był sobie pies", KategoriaId=1, CenaKsiazki=24, Bestseller=true, NazwaPlikuObrazka ="bylsobiepies.png", DataDodania =DateTime.Now, OpisKsiazki = "Ksiązka, która doczekała się ekranizacji – przedstawia losy najbardziej wyszczekanego bohatera wszech czasów. Oto pełna głębokich uczuć i zdumiewająca opowieść o oddanym psie, który życiową misją czyni wpajanie swoim właścicielom znaczenia miłości i pogody ducha" },
                new Ksiazka() { KsiazkaId = 2, AutorKsiazki="Stephen King", TytulKsiazki=" Cmętarz zwieżąt", KategoriaId=2, CenaKsiazki=25, Bestseller=false, NazwaPlikuObrazka ="cmentarzzwierzat.png", DataDodania =DateTime.Now, OpisKsiazki = "Ksiązka, która doczekała się ekranizacji – przedstawia losy najbardziej wyszczekanego bohatera wszech czasów. Oto pełna głębokich uczuć i zdumiewająca opowieść o oddanym psie, który życiową misją czyni wpajanie swoim właścicielom znaczenia miłości i pogody duchaNa świecie istnieją dobre i złe miejsca. Nowy dom rodziny Creedów w Ludlow był niewątpliwie dobrym miejscem - przytulną, przyjazną wiejską przystanią po zgiełku i chaosie Chicago. Cudowne otoczenie Nowej Anglii, łąki, las; idealna siedziba dla młodego lekarza, jego żony, dwójki dzieci i kota. Wspaniała praca, mili sąsiedzi - i droga, po której nieustannie przetaczają się ciężarówki. Droga i miejsce za domem, w lesie, pełne wzniesionych dziecięcymi rękami nagrobków, z napisem na bramie: CMĘTARZ ZWIEŻĄT (cóż, nie wszystkie dzieci znają dobrze ortografię...). " },
                new Ksiazka() { KsiazkaId = 3, AutorKsiazki="Susan Ee", TytulKsiazki="Angelfall.Opowieść Penryn o końcu świata (tom 1) ", KategoriaId=3, CenaKsiazki=30, Bestseller=true, NazwaPlikuObrazka ="angelfall.png", DataDodania =DateTime.Now, OpisKsiazki = "Aniele, stróżu mój... szeptaliśmy przez setki lat. Myliliśmy się. Teraz to właśnie ONE okazały się naszym największym koszmarem.Ziemię ogarnęły ciemności. Państwa upadły, szpitale, szkoły i urzędy stoją puste, nie działają komórki. Za dnia na ulicach rządzą brutalne gangi, ale kiedy zapada mrok wszyscy wracają do kryjówek, kryjąc się przed grozą Najeźdźców. Anioły. Niektóre piękne, inne jakby wyjęte z najgorszych koszmarów, a wszystkie nadludzko potężne. Przez wieki uważaliśmy je za swoich stróżów, teraz okazały się agresorami siejącymi śmierć. Dlaczego zstąpiły na ziemię? Z czyjego rozkazu? Jaki mają plan? Czy ludzie zdołają im się przeciwstawić?"  },
                new Ksiazka() { KsiazkaId = 4, AutorKsiazki="Adam Mickiewicz", TytulKsiazki=" Pan Tadeusz", KategoriaId=4, CenaKsiazki=24, Bestseller=false, NazwaPlikuObrazka ="pantadeusz.png", DataDodania =DateTime.Now, OpisKsiazki = "Luksusowe wydanie w twardej oprawie zawierające ilustracje E. M. Andriollego. Reprint przedwojennego lwowskiego wydania, które ukazało się nakładem księgarni F. H. Richtera.",  },
                new Ksiazka() { KsiazkaId = 5, AutorKsiazki="Camilla Läckberg", TytulKsiazki=" Księżniczka z lodu", KategoriaId=5, CenaKsiazki=29, Bestseller=true, NazwaPlikuObrazka ="ksiezniczkazlodu.png", DataDodania =DateTime.Now, OpisKsiazki = "W niewielkiej miejscowości na zachodnim wybrzeżu Szwecji, wśród małej, zamkniętej społeczności, gdzie wszyscy się znają i wszystko o sobie wiedzą – w jednym z domów odkryto zwłoki młodej kobiety. Początkowo wszystko wskazuje na samobójstwo, okazuje się jednak, że Alex została zamordowana. Prywatne śledztwo rozpoczyna Erika Falck – pisarka i przyjaciółka Alex z dzieciństwa, do której dołącza miejscowy policjant Patrik Hedström." },
                new Ksiazka() { KsiazkaId = 6, AutorKsiazki="Nicholas Sparks", TytulKsiazki=" I wciąż ją kocham", KategoriaId=6, CenaKsiazki=28, Bestseller=false, NazwaPlikuObrazka ="iwciazjakocham.png", DataDodania =DateTime.Now, OpisKsiazki = "John, młody żołnierz, nigdy nie zastanawiał się nad swoimi życiowymi wyborami. Bawił się, surfował, podrywał kobiety, nawet zawód żołnierza wybrał spontanicznie. Nie myślał o przyszłości, nie wiedział, czy w ogóle będzie mu dana… Dopóki nie spotkał Savannah. Dopóki jej nie pokochał i nie postanowił założyć z nią rodziny. Dopóki nie został wysłany na front i nie stracił ukochanej." },
                new Ksiazka() { KsiazkaId = 7, AutorKsiazki="Carlo Collodi", TytulKsiazki=" Pinokio", KategoriaId=7, CenaKsiazki=24, Bestseller=false, NazwaPlikuObrazka ="pinokio.png", DataDodania =DateTime.Now, OpisKsiazki = "Pinokio to drewniany pajacyk wystrugany przez cierpliwego, serdecznego majstra Dżeppetto. Pajacyk nieoczekiwanie jednak ożył i od razu dał się we znaki swojemu staremu ojcu, jako chłopiec krnąbrny i nieposłuszny. Dżeppeto, a także jego przyjaciele – wróżka i Gadający Świerszcz – starają się utemperować jego charakter, by potrafił odróżniać dobro od zła. Jednak Pinokio na swej drodze spotyka wiele niegodziwych osób, które namawiają go do złych rzeczy. Początkowo chłopiec daje się im zwieść i ponosi za to bolesne kary, ale ostatecznie dociera do niego, jakim to też egoistycznym chłopcem jest. Po wielu dramatycznych przygodach powraca do ojca i staje się dobrym pajacykiem. W nagrodę za tę niezwykłą przemianę spełnione zostaje jego największe marzenie: staje się prawdziwym chłopcem!" },
                new Ksiazka() { KsiazkaId = 8, AutorKsiazki="Rowling J.K.", TytulKsiazki=" Harry Potter. Tom 1. Harry Potter i Kamień Filozoficzny", KategoriaId=1, CenaKsiazki=30, Bestseller=true, NazwaPlikuObrazka ="harrypotter1.png", DataDodania =DateTime.Now, OpisKsiazki = "Harry Potter, sierota i podrzutek, od niemowlęcia wychowywany był przez ciotkę i wuja, którzy traktowali go jak piąte koło u wozu. Pochodzenie chłopca owiane jest tajemnicą; jedyną pamiątką Harry'ego z przeszłości jest zagadkowa blizna na czole. Skąd jednak biorą się niesamowite zjawiska, które towarzyszą nieświadomemu niczego Potterowi? Wszystko zmienia się w dniu jedenastych urodzin chłopca, kiedy dowiaduje się o istnieniu świata, o którym nie miał dotąd pojęcia.",  },
                new Ksiazka() { KsiazkaId = 9, AutorKsiazki="Douglas Penelope", TytulKsiazki=" Birthday Girl", KategoriaId=6, CenaKsiazki=24, Bestseller=true, NazwaPlikuObrazka ="birthdaygirl.png", DataDodania =DateTime.Now, OpisKsiazki = "Jordan : Przygarnął mnie, gdy nie miałam dokąd iść. Nie wykorzystuje mnie, nie rani ani o mnie nie zapomina. Nie traktuje tak, jakbym była niczym. Nie bierze mnie za pewnik. Nie sprawia, że czuję się zagrożona. Nie zapomina o mnie. Śmieje się razem ze mną. Patrzy na mnie. Słucha. Broni. Zauważa. Czuję na sobie jego oczy, gdy razem jemy śniadanie. Kiedy wraca z pracy, moje serce zaczyna bić szybciej na dźwięk parkującego na podjeździe samochodu. Muszę to zatrzymać. To się nie może wydarzyć. Siostra powiedziała mi kiedyś, że porządni faceci nie istnieją, a nawet jeśli na jakiegoś trafię, to i tak pewnie będzie zajęty. Sęk w tym, że to nie Pike Lawson jest zajęty. Tylko ja." }
            };
            ksiazki.ForEach( k=> context.Ksiazki.AddOrUpdate(k));
            context.SaveChanges();

        }
        public static void SeedUzytkownicy(KsiazkiContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@sklepksiegarnia.pl";
            const string password = "Sklep@123";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, DaneUzytkownika = new DaneUzytkownika() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
