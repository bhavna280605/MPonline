// ============================================================
// Assignment 06: Exam Form Submission with Custom Exception
//   - Throws custom exception if submitted after the deadline
// ============================================================
using System;

namespace ExamFormSubmission
{
    public class DeadlineExpiredException : Exception
    {
        public DateTime Deadline { get; }
        public DateTime SubmittedAt { get; }

        public DeadlineExpiredException(DateTime deadline, DateTime submittedAt)
            : base($"Exam form submission FAILED. Deadline was {deadline:dd-MM-yyyy HH:mm}, " +
                   $"but submission attempted at {submittedAt:dd-MM-yyyy HH:mm}.")
        {
            Deadline    = deadline;
            SubmittedAt = submittedAt;
        }
    }

    public class ExamForm
    {
        public string  StudentName { get; }
        public string  Subject     { get; }
        public DateTime SubmittedAt { get; private set; }
        public bool     IsSubmitted { get; private set; }

        public ExamForm(string student, string subject)
        { StudentName = student; Subject = subject; }

        public void Submit(DateTime deadline)
        {
            DateTime now = DateTime.Now;
            SubmittedAt = now;

            if (now > deadline)
                throw new DeadlineExpiredException(deadline, now);

            IsSubmitted = true;
            Console.WriteLine($"[OK] {StudentName}'s exam form for '{Subject}' submitted at {now:dd-MM-yyyy HH:mm}.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Case 1: Valid submission (deadline in the future)
            var form1 = new ExamForm("Anshika", "Data Structures");
            try
            {
                form1.Submit(DateTime.Now.AddDays(3));
            }
            catch (DeadlineExpiredException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Case 2: Late submission (deadline already passed)
            var form2 = new ExamForm("Neha", "Operating Systems");
            try
            {
                form2.Submit(DateTime.Now.AddDays(-2));  // deadline 2 days ago
            }
            catch (DeadlineExpiredException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine($"  Late by: {(ex.SubmittedAt - ex.Deadline).TotalHours:F1} hours");
            }

            // Case 3: Deadline is exactly now
            var form3 = new ExamForm("Kabir", "DBMS");
            try
            {
                form3.Submit(DateTime.Now.AddSeconds(-1)); // 1 sec ago
            }
            catch (DeadlineExpiredException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
