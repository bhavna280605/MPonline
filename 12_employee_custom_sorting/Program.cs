// ============================================================
// Assignment 12: Custom sorting of Employees
//   Sort by:  1) Salary  2) Joining Date  3) Employee ID
//   Uses IComparer<Employee> for each criterion + LINQ equivalents
// ============================================================
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCustomSorting
{
    public class Employee
    {
        public int      EmpId    { get; set; }
        public string   Name     { get; set; }
        public decimal  Salary   { get; set; }
        public DateTime JoinDate { get; set; }

        public Employee(int id, string name, decimal salary, DateTime joinDate)
        { EmpId = id; Name = name; Salary = salary; JoinDate = joinDate; }

        public override string ToString() =>
            $"Id={EmpId,-4} Name={Name,-10} Salary={Salary,8:C} Joined={JoinDate:dd-MM-yyyy}";
    }

    // Comparer 1: by salary descending
    public class SalaryComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) =>
            (y?.Salary ?? 0).CompareTo(x?.Salary ?? 0);
    }

    // Comparer 2: by joining date ascending (oldest first)
    public class JoinDateComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x is null) return y is null ? 0 : 1;
            if (y is null) return -1;
            return x.JoinDate.CompareTo(y.JoinDate);
        }
    }

    // Comparer 3: by employee ID ascending
    public class EmpIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) =>
            (x?.EmpId ?? 0).CompareTo(y?.EmpId ?? 0);
    }

    class Program
    {
        static void Main()
        {
            var employees = new List<Employee>
            {
                new Employee(105, "Anshika",  55000m, new DateTime(2021, 7,  1)),
                new Employee(102, "Neha",   72000m, new DateTime(2019, 3, 15)),
                new Employee(108, "Kabir",  45000m, new DateTime(2023, 1, 10)),
                new Employee(101, "Ananya", 72000m, new DateTime(2018, 9,  5)),
                new Employee(109, "Rohit",  60000m, new DateTime(2020, 12, 1))
            };

            Console.WriteLine("--- Original list ---");
            Print(employees);

            // 1. Sort by Salary (descending) using IComparer
            var bySalary = new List<Employee>(employees);
            bySalary.Sort(new SalaryComparer());
            Console.WriteLine("\n--- Sorted by Salary (desc) ---");
            Print(bySalary);

            // 2. Sort by JoiningDate (ascending) using IComparer
            var byJoin = new List<Employee>(employees);
            byJoin.Sort(new JoinDateComparer());
            Console.WriteLine("\n--- Sorted by Joining Date (asc) ---");
            Print(byJoin);

            // 3. Sort by Employee ID (ascending) using IComparer
            var byId = new List<Employee>(employees);
            byId.Sort(new EmpIdComparer());
            Console.WriteLine("\n--- Sorted by Employee ID (asc) ---");
            Print(byId);

            // 4. Multi-level: Salary desc, then JoinDate asc, then EmpId asc (via LINQ)
            var multi = employees
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.JoinDate)
                .ThenBy(e => e.EmpId)
                .ToList();
            Console.WriteLine("\n--- Multi-level: Salary desc, JoinDate asc, EmpId asc ---");
            Print(multi);
        }

        static void Print(List<Employee> list)
        {
            foreach (var e in list) Console.WriteLine("  " + e);
        }
    }
}
