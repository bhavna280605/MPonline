// ============================================================
// Assignment 18: Find Age from entered Date of Birth
// ============================================================
using System;

namespace AgeFromDob
{
    class Program
    {
        static void Main()
        {
            // --- Hardcoded samples ---
            var samples = new[]
            {
                new DateTime(2004, 5, 14),
                new DateTime(1990, 12, 25),
                new DateTime(2010, 1, 1),
                DateTime.Today.AddYears(-20).AddDays(1) // born yesterday 20 years ago
            };

            foreach (var dob in samples)
            {
                var (years, months, days) = CalculateAge(dob);
                Console.WriteLine($"DOB: {dob:dd-MM-yyyy}  ->  Age: {years}y {months}m {days}d");
            }

            // --- Interactive ---
            Console.Write("\nEnter your Date of Birth (dd-MM-yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(),
                    "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None,
                    out DateTime userDob))
            {
                var (y, m, d) = CalculateAge(userDob);
                Console.WriteLine($"Your age: {y} years, {m} months, {d} days.");
                Console.WriteLine($"Total days alive: {(DateTime.Today - userDob).TotalDays:F0}");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        static (int years, int months, int days) CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            if (dob > today)
                return (0, 0, 0);

            int years  = today.Year - dob.Year;
            int months = today.Month - dob.Month;
            int days   = today.Day - dob.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(dob.Year, today.AddMonths(-1).Month);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years, months, days);
        }
    }
}
