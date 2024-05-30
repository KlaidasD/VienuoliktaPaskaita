using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VienuoliktaPaskaita.Services.NuomaService;
using VienuoliktaPaskaita.Models;
using VienuoliktaPaskaita.Services;

namespace VienuoliktaPaskaita.Services
{
    public class NuomaConsoleUI
    {
        private readonly NuomaService _nuomaService;

        public NuomaConsoleUI(NuomaService nuomaService)
        {
            _nuomaService = nuomaService;
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Registruoti nauja automobili");
                Console.WriteLine("2. Atnaujinti automobilio informacija");
                Console.WriteLine("3. Perziureti visus automobilius");
                Console.WriteLine("4. Istrinti automobili");
                Console.WriteLine("5. Isnuomoti automobili");
                Console.WriteLine("6. Baigti");
                Console.Write("Pasirinkite funkcija: ");
                string ivestis = Console.ReadLine();

                switch (ivestis)
                {
                    case "1":
                        RegistruotiAutomobili();
                        break;
                    case "2":
                        AtnaujintiAutomobili();
                        break;
                    case "3":
                        PerziuretiVisusAutomobilius();
                        break;
                    case "4":
                        IstrintiAutomobili();
                        break;
                    case "5":
                        IsnuomotiAutomobili();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Neteisinga opcija.");
                        break;
                }
            }
        }

        private void RegistruotiAutomobili()
        {
            Console.Write("Iveskite automobilio tipa (1 - Naftos Kuro, 2 - Elektromobilis): ");
            string type = Console.ReadLine();
            Console.Write("Iveskite automobilio marke: ");
            string brand = Console.ReadLine();
            Console.Write("Iveskite automobilio modeli: ");
            string model = Console.ReadLine();
            Console.Write("Iveskite automobilio metus: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Iveskite registracijos numeri: ");
            string registrationNumber = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Iveskite bako talpa: ");
                double bakoTalpa = double.Parse(Console.ReadLine());
                NaftosKuroAutomobilis kuroAutomobilis = new NaftosKuroAutomobilis
                {
                    Marke = brand,
                    Modelis = model,
                    Metai = year,
                    RegistracijosNumeris = registrationNumber,
                    BakoTalpa = (int)bakoTalpa
                };
                _nuomaService.RegistruotiAutomobilis(kuroAutomobilis);
            }
            else if (type == "2")
            {
                Console.Write("Iveskite baterijos talpa: ");
                double baterijosTalpa = double.Parse(Console.ReadLine());
                Elektromobilis elektrinisAutomobilis = new Elektromobilis
                {
                    Marke = brand,
                    Modelis = model,
                    Metai = year,
                    RegistracijosNumeris = registrationNumber,
                    BaterijosTalpa = (int)baterijosTalpa
                };
                _nuomaService.RegistruotiAutomobilis(elektrinisAutomobilis);
            }
        }

        private void AtnaujintiAutomobili()
        {
            Console.Write("Iveskite automobilio ID, kuri norite atnaujinti: ");
            int id = int.Parse(Console.ReadLine());
            var car = _nuomaService.GautiAutomobiliai().FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                Console.WriteLine("Automobilis nerastas.");
                return;
            }

            Console.Write("Iveskite nauja marke: ");
            car.Marke = Console.ReadLine();
            Console.Write("Iveskite nauja modeli: ");
            car.Modelis = Console.ReadLine();
            Console.Write("Iveskite naujus metus: ");
            car.Metai = int.Parse(Console.ReadLine());
            Console.Write("Iveskite nauja registracijos numeri: ");
            car.RegistracijosNumeris = Console.ReadLine();

            _nuomaService.AtnaujintiAutomobilis(car);
        }

        private void PerziuretiVisusAutomobilius()
        {
            var cars = _nuomaService.GautiAutomobiliai();
            foreach (Automobilis car in cars)
            {
                Console.WriteLine($"ID: {car.Id}, Marke: {car.Marke}, Modelis: {car.Modelis}, Metai: {car.Metai}, RegistracijosNumeris: {car.RegistracijosNumeris}");
            }
        }

        private void IstrintiAutomobili()
        {
            Console.Write("Iveskite automobilio ID, kuri norite istrinti: ");
            int id = int.Parse(Console.ReadLine());
            _nuomaService.IstrintiAutomobilis(id);
        }

        private void IsnuomotiAutomobili()
        {
            Console.Write("Iveskite automobilio ID, kuri norite isnuomoti: ");
            int carId = int.Parse(Console.ReadLine());
            Console.Write("Iveskite kliento ID: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Iveskite nuomos pradzios data (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Iveskite nuomos pabaigos data (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Nuoma rental = new Nuoma
            {
                AutomobilisId = carId,
                KlientasId = clientId,
                Nuo = startDate,
                Iki = endDate
            };

        }


    }
}
    
