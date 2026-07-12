// ============================================================
// Assignment 14: Default values of C# types
//   int, bool, string, DateTime  (and a few more for completeness)
// ============================================================
using System;

namespace DefaultValues
{
    class Program
    {
        // Class-level fields get default values automatically
        private static int       _defaultInt;
        private static bool      _defaultBool;
        private static string    _defaultString;     // null
        private static DateTime  _defaultDateTime;   // 01/01/0001 00:00:00
        private static double    _defaultDouble;
        private static decimal   _defaultDecimal;
        private static char      _defaultChar;       // '\0'

        static void Main()
        {
            Console.WriteLine("--- Default values of class-level fields ---");
            Console.WriteLine($"int       = {_defaultInt}       (expected: 0)");
            Console.WriteLine($"bool      = {_defaultBool}      (expected: False)");
            Console.WriteLine($"string    = {(_defaultString ?? "null")}");
            Console.WriteLine($"DateTime  = {_defaultDateTime}  (expected: 01/01/0001 00:00:00)");
            Console.WriteLine($"double    = {_defaultDouble}");
            Console.WriteLine($"decimal   = {_defaultDecimal}");
            Console.WriteLine($"char      = {(int)_defaultChar} (expected: 0 = '\\0')");

            Console.WriteLine("\n--- Using default(T) expression ---");
            Console.WriteLine($"default(int)      = {default(int)}");
            Console.WriteLine($"default(bool)     = {default(bool)}");
            Console.WriteLine($"default(string)   = {default(string) ?? "null"}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(double)   = {default(double)}");
            Console.WriteLine($"default(decimal)  = {default(decimal)}");
            Console.WriteLine($"default(char)     = {(int)default(char)}");
            Console.WriteLine($"default(Guid)     = {default(Guid)}");

            Console.WriteLine("\n--- Local variables need explicit default ---");
            int localInt = default;
            bool localBool = default;
            string localString = default;
            DateTime localDt = default;
            Console.WriteLine($"Local int      = {localInt}");
            Console.WriteLine($"Local bool     = {localBool}");
            Console.WriteLine($"Local string   = {localString ?? "null"}");
            Console.WriteLine($"Local DateTime = {localDt}");
        }
    }
}
