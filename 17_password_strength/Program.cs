// ============================================================
// Assignment 17: Password Strength Checker
//   Rules:
//     1. Length should be exactly 8 (treated as min length 8 here)
//     2. Must have at least one capital letter
//     3. One digit is compulsory
//   Returns: Weak / Medium / Strong  based on how many rules pass
// ============================================================
using System;
using System.Linq;

namespace PasswordStrength
{
    public class PasswordResult
    {
        public string Strength { get; set; }
        public bool   LengthOk { get; set; }
        public bool   HasUpper { get; set; }
        public bool   HasDigit { get; set; }
    }

    public static class PasswordChecker
    {
        public static PasswordResult Check(string pwd)
        {
            if (pwd == null) pwd = "";

            bool lengthOk = pwd.Length >= 8;
            bool hasUpper = pwd.Any(char.IsUpper);
            bool hasDigit = pwd.Any(char.IsDigit);

            int score = (lengthOk ? 1 : 0) + (hasUpper ? 1 : 0) + (hasDigit ? 1 : 0);

            string strength = score switch
            {
                3 => "Strong",
                2 => "Medium",
                _ => "Weak"
            };

            return new PasswordResult
            {
                Strength = strength,
                LengthOk = lengthOk,
                HasUpper = hasUpper,
                HasDigit = hasDigit
            };
        }
    }

    class Program
    {
        static void Main()
        {
            var samples = new[]
            {
                "abc",                // weak: fails all
                "abcdefgh",           // weak: length only
                "Abcdefgh",           // medium: length + upper
                "Abcdefg1",           // strong: all 3 rules
                "Password1",          // strong
                "short1A",            // weak: too short
            };

            foreach (var pwd in samples)
            {
                var r = PasswordChecker.Check(pwd);
                Console.WriteLine($"Password : {pwd}");
                Console.WriteLine($"  Length>=8 : {r.LengthOk}");
                Console.WriteLine($"  Has upper : {r.HasUpper}");
                Console.WriteLine($"  Has digit : {r.HasDigit}");
                Console.WriteLine($"  Strength  : {r.Strength}\n");
            }

            Console.Write("Enter your own password to check: ");
            string input = Console.ReadLine();
            var res = PasswordChecker.Check(input);
            Console.WriteLine($"Strength: {res.Strength} " +
                              $"(len={res.LengthOk}, upper={res.HasUpper}, digit={res.HasDigit})");
        }
    }
}
