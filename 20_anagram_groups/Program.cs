// ============================================================
// Assignment 20: Print groups of anagrams from a given list
// ============================================================
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGroups
{
    class Program
    {
        static void Main()
        {
            string[] words =
            {
                "listen", "silent", "enlist", "google", "gogole", "cat", "act", "tac",
                "rat", "tar", "art", "hello", "world"
            };

            var groups = GroupAnagrams(words);

            int i = 1;
            foreach (var g in groups)
            {
                Console.WriteLine($"Group {i++}: [{string.Join(", ", g)}]");
            }

            // --- Interactive ---
            Console.Write("\nEnter words separated by spaces: ");
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                var userWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var ug = GroupAnagrams(userWords);
                Console.WriteLine($"\nFound {ug.Count} anagram group(s):");
                foreach (var g in ug)
                    Console.WriteLine($"  [{string.Join(", ", g)}]");
            }
        }

        static List<List<string>> GroupAnagrams(IEnumerable<string> words)
        {
            // Key: sorted string of the lowercased word
            return words
                .GroupBy(w => new string(w.ToLower().OrderBy(c => c).ToArray()))
                .Select(g => g.ToList())
                .ToList();
        }
    }
}
