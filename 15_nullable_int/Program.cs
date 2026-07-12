// ============================================================
// Assignment 15: Nullable<int> behaviour
//   - assign null
//   - compare with another nullable
//   - HasValue and GetValueOrDefault
// ============================================================
using System;

namespace NullableIntDemo
{
    class Program
    {
        static void Main()
        {
            // --- 1. Declare and assign null ---
            int? a = null;
            Console.WriteLine($"a = null");
            Console.WriteLine($"  HasValue           = {a.HasValue}");
            Console.WriteLine($"  GetValueOrDefault()= {a.GetValueOrDefault()}");
            Console.WriteLine($"  GetValueOrDefault(99)= {a.GetValueOrDefault(99)}");
            // Console.WriteLine(a.Value);  // would throw InvalidOperationException

            // --- 2. Assign a real value ---
            int? b = 42;
            Console.WriteLine($"\nb = 42");
            Console.WriteLine($"  HasValue = {b.HasValue}");
            Console.WriteLine($"  Value    = {b.Value}");

            // --- 3. Compare two nullables ---
            int? c = null;
            int? d = 42;
            int? e = 42;

            Console.WriteLine("\n--- Comparisons (lifted operators) ---");
            Console.WriteLine($"  (c == null)         = {c == null}");    // True
            Console.WriteLine($"  (d == e)            = {d == e}");       // True
            Console.WriteLine($"  (c == d)            = {c == d}");       // False (null != 42)
            Console.WriteLine($"  (d > 10)            = {d > 10}");       // True
            Console.WriteLine($"  (c > 10)            = {c > 10}");       // False (null lifted -> false)
            Console.WriteLine($"  (c >= d)            = {c >= d}");       // False

            // --- 4. Use in arithmetic ---
            int? x = 10, y = null;
            int? sum = x + y;          // null propagates
            Console.WriteLine($"\n10 + null = {sum ?? -1} (sum.HasValue = {sum.HasValue})");

            // --- 5. Coalescing operator ?? ---
            int actual = a ?? 0;       // 0 because a is null
            Console.WriteLine($"a ?? 0  = {actual}");
            int fromB = b ?? 0;        // 42 (b has value)
            Console.WriteLine($"b ?? 0  = {fromB}");

            // --- 6. GetValueOrDefault in expression ---
            int result = (a.GetValueOrDefault() + b.GetValueOrDefault());
            Console.WriteLine($"\na.GetValueOrDefault() + b.GetValueOrDefault() = {result}");
        }
    }
}
