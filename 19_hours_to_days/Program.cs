// ============================================================
// Assignment 19: Convert hours to days  (days = h / 24)
// ============================================================
using System;

namespace HoursToDays
{
    class Program
    {
        static void Main()
        {
            double[] hoursList = { 12, 24, 36, 48, 72, 96, 100, 168, 365.25 * 24 };

            Console.WriteLine($"{"Hours",-12}{"Days",-15}{"Days+Hours"}");
            Console.WriteLine(new string('-', 45));

            foreach (double h in hoursList)
            {
                double totalDays = h / 24.0;
                int    wholeDays = (int)(h / 24);
                int    remainder = (int)(h % 24);
                Console.WriteLine($"{h,-12}{totalDays,-15:F2}{wholeDays}d {remainder}h");
            }

            // Interactive
            Console.Write("\nEnter hours: ");
            if (double.TryParse(Console.ReadLine(), out double input))
            {
                Console.WriteLine($"{input} hours = {input / 24.0:F4} days");
                Console.WriteLine($"  = {(int)(input / 24)} full day(s) and {input % 24} hour(s)");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
