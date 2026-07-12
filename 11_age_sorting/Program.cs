// ============================================================
// Assignment 11: Age-based sorting for a collection of Persons
//   Uses IComparable<Person> + LINQ OrderBy
// ============================================================
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgeSorting
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int    Age  { get; set; }

        public Person(string name, int age) { Name = name; Age = age; }

        // Default comparison: by Age ascending
        public int CompareTo(Person other) =>
            other is null ? 1 : Age.CompareTo(other.Age);

        public override string ToString() => $"{Name,-15} (Age {Age})";
    }

    class Program
    {
        static void Main()
        {
            var people = new List<Person>
            {
                new Person("Anshika",     21),
                new Person("Neha",      19),
                new Person("Kabir",     35),
                new Person("Ananya",    25),
                new Person("Zoya",      18),
                new Person("Rohit",     28)
            };

            Console.WriteLine("--- Original order ---");
            Print(people);

            // 1. Sort using IComparable (default = age ascending)
            people.Sort();
            Console.WriteLine("\n--- Sorted by Age (ascending, via IComparable) ---");
            Print(people);

            // 2. Sort by age descending using LINQ
            var desc = people.OrderByDescending(p => p.Age).ToList();
            Console.WriteLine("\n--- Sorted by Age (descending, via LINQ) ---");
            Print(desc);

            // 3. Sort by Name ascending
            var byName = people.OrderBy(p => p.Name).ToList();
            Console.WriteLine("\n--- Sorted by Name (ascending, via LINQ) ---");
            Print(byName);
        }

        static void Print(List<Person> list)
        {
            foreach (var p in list) Console.WriteLine("  " + p);
        }
    }
}
