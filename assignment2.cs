using System;

class InvalidLocationException : Exception
{
    public InvalidLocationException(string message) : base(message)
    {
    }
}

class GPSFailureException : Exception
{
    public GPSFailureException(string message) : base(message)
    {
    }
}

class CabBooking
{
    public static void BookCab(string location, bool gpsStatus)
    {
        if (!gpsStatus)
        {
            throw new GPSFailureException("GPS service is currently unavailable.");
        }

        if (string.IsNullOrWhiteSpace(location))
        {
            throw new InvalidLocationException("Pickup location cannot be empty.");
        }

        if (location.Length < 3)
        {
            throw new InvalidLocationException("Entered pickup location is invalid.");
        }

        Console.WriteLine("Cab booked successfully from: " + location);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Pickup Location: ");
            string location = Console.ReadLine();

            Console.Write("Is GPS Working? (true/false): ");
            bool gpsStatus = Convert.ToBoolean(Console.ReadLine());

            CabBooking.BookCab(location, gpsStatus);
        }
        catch (InvalidLocationException ex)
        {
            Console.WriteLine("Location Error: " + ex.Message);
        }
        catch (GPSFailureException ex)
        {
            Console.WriteLine("GPS Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Cab Booking Process Completed.");
        }
    }
}