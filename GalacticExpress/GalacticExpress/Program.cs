using System.Text;
using System;
namespace GalactixExpressOefenen

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Geef je naam: ");
            string name = Console.ReadLine();
            name = name.Trim().Replace(" ", "-");

            Console.Write("Geef je bestemming: ");
            string destination = Console.ReadLine();
            destination.Trim();
            string destinationCode = destination.ToUpper().Substring(0, 3);



            Console.Write("Geef je vertrekdatum (yyyy-MM-dd):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime departure))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geef een geldige vertrekdatum in.");
                Console.ResetColor();
            }

            TimeSpan dayTillDeparture = departure - DateTime.Today;
            string departureDay = departure.DayOfWeek.ToString();
            DateTime retourDate = departure.AddDays(7);

            Console.Write("Geef het gewicht van je bagage in kg: ");
            if (!int.TryParse(Console.ReadLine(), out int weightLugage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geef een geldige gewicht in kg in.");
                Console.ResetColor();
            }

            Random rng = new Random();
            int gate = rng.Next(1, 13);
            int row = rng.Next(1, 31);
            int seat = rng.Next(1, 6);
            int controlCode = rng.Next(1000, 10000);

            decimal basePrice = 89.95m;
            decimal lugagePriceKg = 1.75m;

            basePrice = basePrice + (weightLugage * lugagePriceKg);
            if (dayTillDeparture.TotalDays < 7)
            {
                basePrice = +12.50m;
            }

            decimal totalPrice = Math.Round(basePrice, MidpointRounding.AwayFromZero);


            Console.WriteLine("===================================");
            Console.WriteLine("=========GALACTIC EXPRESS==========");
            Console.WriteLine("=========  BOARDING PASS  =========");
            Console.WriteLine("===================================");

            Console.WriteLine($"\n{"Reiziger",-20} : {name}");
            Console.WriteLine($"{"Bestemming",-20} : {destination}");
            Console.WriteLine($"{"Code",-20} : {destinationCode}");
            Console.WriteLine($"{"Vertrekdatum",-20} : {departure:yyyy-MM-dd}");
            Console.WriteLine($"{"Vertrekdag",-20} : {departureDay}");
            Console.WriteLine($"{"Dagen tot vertrek",-20} : {dayTillDeparture.Days}");
            Console.WriteLine($"\n{"Gate",-20} : {gate}");
            Console.WriteLine($"{"Stoel",-20} : Rij {row} - Stoel {seat}");
            Console.WriteLine($"{"Controlecode",-20} : {controlCode}");
            Console.WriteLine($"\n{"Bagage",-20} : {weightLugage} kg");
            Console.WriteLine($"{"Totale prijs",-20} : {totalPrice:C}");
            Console.WriteLine($"{"Boekingscode",-20} : {name}");
            Console.WriteLine($"\n{"Retourdatum",-20} : {retourDate:yyyy-MM-dd}");


        }
    }
}
