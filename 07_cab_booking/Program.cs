// ============================================================
// Assignment 07: Cab Booking Application
//   - User enters pickup location
//   - If GPS service fails OR location is invalid,
//     a custom exception is thrown and handled gracefully.
// ============================================================
using System;

namespace CabBooking
{
    public class GpsServiceUnavailableException : Exception
    {
        public GpsServiceUnavailableException(string msg) : base(msg) { }
    }

    public class InvalidLocationException : Exception
    {
        public string EnteredLocation { get; }
        public InvalidLocationException(string location)
            : base($"Invalid pickup location: '{location}'. Please enter a valid address.")
        { EnteredLocation = location; }
    }

    public class GpsService
    {
        private static readonly string[] ValidLocations =
            { "Connaught Place", "IGI Airport", "Cyber Hub", "Noida Sector 62", "Karol Bagh" };

        // Simulate random GPS outage
        public string ResolveLocation(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                throw new InvalidLocationException(userInput ?? "<empty>");

            // Simulate flaky GPS hardware
            if (new Random().Next(1, 6) == 3) // 20% chance
                throw new GpsServiceUnavailableException(
                    "GPS service is temporarily unavailable. Please try again.");

            bool valid = Array.Exists(ValidLocations,
                v => v.Equals(userInput, StringComparison.OrdinalIgnoreCase));

            if (!valid)
                throw new InvalidLocationException(userInput);

            return userInput + " (resolved coordinates: 28.61N, 77.20E)";
        }
    }

    public class CabBookingApp
    {
        private readonly GpsService _gps = new();

        public void BookCab(string pickup, string drop)
        {
            Console.WriteLine($"\nBooking cab: {pickup} -> {drop}");
            try
            {
                string resolved = _gps.ResolveLocation(pickup);
                Console.WriteLine($"  Pickup confirmed: {resolved}");
                Console.WriteLine($"  Driver 'Ramesh' (DL-01-XY-9999) arriving in 5 min.");
                Console.WriteLine("  Booking ID: CAB-" + DateTime.Now.Ticks.ToString()[^6..]);
            }
            catch (InvalidLocationException ex)
            {
                Console.WriteLine("  [Invalid Location] " + ex.Message);
                Console.WriteLine("  Tip: try one of the supported locations.");
            }
            catch (GpsServiceUnavailableException ex)
            {
                Console.WriteLine("  [GPS Error] " + ex.Message);
                Console.WriteLine("  Fallback: dispatching based on last known location...");
            }
            finally
            {
                Console.WriteLine("  --- Booking attempt finished ---");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var app = new CabBookingApp();

            // Try several bookings to demonstrate different exception paths
            app.BookCab("Cyber Hub",            "IGI Airport");
            app.BookCab("",                       "Noida Sector 62");
            app.BookCab("Nowhere Random Place",  "Karol Bagh");
            app.BookCab("Connaught Place",       "Cyber Hub");

            // Run a few more times to possibly trigger the simulated GPS failure
            for (int i = 0; i < 3; i++)
                app.BookCab("Cyber Hub", "IGI Airport");
        }
    }
}
