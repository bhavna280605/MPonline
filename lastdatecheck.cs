using System;

// Custom Exception Class
class LateSubmissionException : Exception
{
    public LateSubmissionException(string message) : base(message)
    {
    }
}

class Program
{
    static void CheckSubmission(int submissionDay, int lastDate)
    {
        if (submissionDay > lastDate)
        {
            throw new LateSubmissionException(
                "Application submitted after the deadline!");
        }
        else
        {
            Console.WriteLine("Application submitted successfully before the deadline.");
        }
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter submission day: ");
            int submissionDay = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter last date: ");
            int lastDate = Convert.ToInt32(Console.ReadLine());

            CheckSubmission(submissionDay, lastDate);
        }
        catch (LateSubmissionException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}