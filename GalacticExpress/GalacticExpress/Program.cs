using System;
using System.Text;
using System.Text.Unicode;

namespace GalacticExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Naam: ");
            string name = Console.ReadLine();
            name = name.Trim();
            string BookingCode = name.Replace(" ", "-");

            Console.Write("Bestemming: ");
            string destination = Console.ReadLine();
            destination = destination.Trim();

            Console.Write("Vertrekdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime departure))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geen geldige datum");
                Console.ResetColor();
                return;
            }

            Console.Write("Gewicht van bagage (kg): ");
            if (!int.TryParse(Console.ReadLine(), out int weightLugage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geen geldig gewicht voor bagage.");
                Console.ResetColor();
                return;
            }

            string destinationAbr = destination.Substring(0, 3).ToUpper();

            Console.WriteLine(name);
            Console.WriteLine(destination);
            Console.WriteLine(destinationAbr);

            int dayToDeparture = (departure.Date - DateTime.Today).Days;
            string dayOfWeek = departure.DayOfWeek.ToString();

            decimal basePrice = 89.95m;

            basePrice += (1.75m * weightLugage);

            if (dayToDeparture < 7)
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

            sb.AppendLine("========================");
            sb.AppendLine("GALACTIC EXPRESS");
            sb.AppendLine("BOARDING PASS");
            sb.AppendLine("========================");

            sb.AppendLine();

            sb.AppendLine($"Reiziger: {name}");
            sb.AppendLine($"Bestemming: {destination}");
            sb.AppendLine($"Code: {destinationAbr}");
            sb.AppendLine($"Vertrekdatum: {departure:yyyy-MM-dd}");
            sb.AppendLine($"Vertrekdag: {dayOfWeek}");
            sb.AppendLine($"Dagen tot vertrek: {dayToDeparture}");

            sb.AppendLine();

            sb.AppendLine($"Gate: {gateNumber}");
            sb.AppendLine($"stoel: rij {row} - stoel {seat}");
            sb.AppendLine($"Controlecode: {controlCode}");

            sb.AppendLine();

            sb.AppendLine($"Bagage: {weightLugage} kg");
            sb.AppendLine($"Totale prijs: {totalPrice:c}");
            sb.AppendLine($"Boekingscode: {BookingCode}");

            Console.WriteLine(sb);

        }
    }
}
