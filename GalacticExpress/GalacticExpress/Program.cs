using System;
using System.Text;

namespace GalacticExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Naam: ");
            string name = Console.ReadLine();
            name = name.Trim().Replace(" ", "-");

            Console.Write("Bestemming: ");
            string destination = Console.ReadLine();
            destination.Trim();

            Console.Write("Vertrekdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime departure))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geen geldige datum");
                Console.ResetColor();
            }

            Console.Write("Gewicht van bagage (kg): ");
            if (!int.TryParse(Console.ReadLine(), out int weightLugage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geen geldig gewicht voor bagage.");
                Console.ResetColor();
            }

            string destinationAbr = destination.Substring(0, 3).ToUpper();

            Console.WriteLine(name);
            Console.WriteLine(destination);
            Console.WriteLine(destinationAbr);

            TimeSpan dayToDeparture = departure - DateTime.Today;
            string dayOfWeek = departure.DayOfWeek.ToString();

            decimal basePrice = 89.95m;

            basePrice *= (1.75m * weightLugage);

            if (dayToDeparture.TotalDays < 7)
            {
                basePrice += 12.50m;
            }

            decimal totalPrice = Math.Round(basePrice, MidpointRounding.AwayFromZero);

            Random rng = new Random();
            int gateNumber = rng.Next(1, 13);

            int row = rng.Next(1, 30);
            int seat = rng.Next(1, 6);
            int controlCode = rng.Next(1000, 10000);

            StringBuilder sb = new StringBuilder();
            string result = sb.ToString();

            sb.AppendLine("=====================");
        }
    }
}
