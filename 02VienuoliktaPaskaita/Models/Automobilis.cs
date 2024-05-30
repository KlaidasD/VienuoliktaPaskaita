using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienuoliktaPaskaita.Models
{
    /*Sukurkite C# programą, kuri valdytų automobilių nuomos procesą.
 * 
 * Sistema turėtų leisti registruoti naujus automobilius, atnaujinti jų informaciją, peržiūrėti esamų automobilių sąrašą bei valdyti klientų nuomos procesą.
 * Automobiliai bus suskirstyti į du tipus: naftos kuro automobilius ir elektromobilius.


Duomenų saugojimas:
Naudokite Microsoft SQL Server ir Dapper ORM biblioteką duomenų saugojimui ir manipuliavimui.
Duomenų bazėje turi būti šios lentelės:
Automobiliai: bendra lentelė visiems automobiliams.
NaftosKuroAutomobiliai: specifinė informacija naftos kuro automobiliams.
Elektromobiliai: specifinė informacija elektromobiliams.
Klientai: specifinė informacija apie klientus.
Nuoma: lentelėje turi būti informaciją apie automobilių nuomą, tai yra turi būti nuorodos į automobilį, į klientą, bei datos NUO/IKI

Funkcionalumai:
Automobilių registracija ir jų tipų priskyrimas.
Automobilių sąrašo gavimas su galimybe filtruoti pagal tipą.
Automobilių informacijos atnaujinimas.
Automobilių ištrinimas.
Automobilio išnuomavimas pasirinkus automobilį ir pasirinkus klientą, bei priskyrus laiką. Jeigu Automobilis jau yra kažkam tuo laikotarpiu išnuomotas, turi būti metama klaida, jog automobilio išnuomuoti negalima.

LABAI SVARBU
Pasikeitimai - Tai, ką laikėme DatabaseService turi tapti DatabaseRepository ir turi būti laikoma aplanke Repositories
Turi būti sukurtas NuomaService (RentService) kuriame būtų įgyvendinamas programos funkcionalumas.
Programos valdymui su konsole turi būti sukurta klasę (kaip servisas) NuomaConsoleUI (RentConsoleUI),
kuriame turi būti meniu, visi pasirinkimai išbandyti visą programos funkcionalumą. NuomaConsoleUI, turi priimti kaip argumentą objektą pagal NuomaService interface.
Pats, NuomaService turi priimti IDatabaseRepository, per kurį jis atlikinės visus veiksmus su duomenų baze.
NuomaConsoleUI turi galimybę valdyti NuomaService -> NuomaService turi turėti galimybę valdyti IDatabaseRepository.
Laikini sąrašai, meniu ir kita, neturi būti Main dalyje - Main dalyje, galimas tik servisų ir repositories inicializavimas!*/


    public class Automobilis
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int Metai { get; set; }
        public string RegistracijosNumeris { get; set; }
    }

    public class NaftosKuroAutomobilis : Automobilis
    {
        public int BakoTalpa { get; set; }
    }

    public class Elektromobilis : Automobilis
    {
        public int BaterijosTalpa { get; set; }
    }
}
