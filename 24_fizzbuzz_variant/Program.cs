// ============================================================
// Assignment 24: FizzBuzz Variant
//   Print 1..50 with these rules (in priority order):
//     - Divisible by both 3 and 5  -> "3-5"
//     - Divisible by 3              -> "3"
//     - Divisible by 5              -> "5"
//     - Prime number                -> "Prime"
//     - Otherwise                   -> the number itself
// ============================================================
using System;

namespace FizzBuzzVariant
{
    class Program
    {
        static void Main()
        {
            for (int n = 1; n <= 50; n++)
                Console.WriteLine(Classify(n));
        }

        static string Classify(int n)
        {
            if (n < 1) return n.ToString();

            bool div3 = n % 3 == 0;
            bool div5 = n % 5 == 0;

            if (div3 && div5) return "3-5";
            if (div3)         return "3";
            if (div5)         return "5";

            if (IsPrime(n))   return "Prime";

            return n.ToString();
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i += 2)
                if (n % i == 0) return false;
            return true;
        }
    }
}
