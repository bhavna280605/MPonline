// ============================================================
// Assignment 16: Password Encode / Decode
//   Encode: shift each char by +2 in ASCII table, then reverse the string
//   Decode: reverse the process (reverse first, then shift by -2)
// ============================================================
using System;

namespace PasswordCodec
{
    public static class PasswordEncoder
    {
        // Encode: shift +2 then reverse
        public static string Encode(string plain)
        {
            if (plain == null) return null;

            char[] shifted = new char[plain.Length];
            for (int i = 0; i < plain.Length; i++)
                shifted[i] = (char)(plain[i] + 2);

            Array.Reverse(shifted);
            return new string(shifted);
        }

        // Decode: reverse the encoded string then shift -2
        public static string Decode(string encoded)
        {
            if (encoded == null) return null;

            char[] arr = encoded.ToCharArray();
            Array.Reverse(arr);

            for (int i = 0; i < arr.Length; i++)
                arr[i] = (char)(arr[i] - 2);

            return new string(arr);
        }
    }

    class Program
    {
        static void Main()
        {
            var passwords = new[] { "Hello123", "Anshika@2004", "AbC", "z" };

            foreach (var pwd in passwords)
            {
                string enc = PasswordEncoder.Encode(pwd);
                string dec = PasswordEncoder.Decode(enc);
                Console.WriteLine($"Original : {pwd}");
                Console.WriteLine($"Encoded  : {enc}");
                Console.WriteLine($"Decoded  : {dec}");
                Console.WriteLine($"Round-trip OK : {pwd == dec}");
                Console.WriteLine(new string('-', 40));
            }

            // --- Interactive demo ---
            Console.Write("\nEnter a password to encode: ");
            string input = Console.ReadLine();
            string encodedInput = PasswordEncoder.Encode(input);
            Console.WriteLine($"Encoded  : {encodedInput}");
            Console.WriteLine($"Decoded  : {PasswordEncoder.Decode(encodedInput)}");
        }
    }
}
