// ============================================================
// Assignment 04: Manager Application
//   - Three employee types: Developer, Tester, Manager
//   - All can GenerateReport() — different content per role
//   - Demonstrates abstract class + polymorphism
// ============================================================
using System;
using System.Collections.Generic;

namespace EmployeeReports
{
    public abstract class Employee
    {
        public int    Id    { get; }
        public string Name  { get; }
        protected Employee(int id, string name) { Id = id; Name = name; }
        public abstract void GenerateReport();
    }

    public class Developer : Employee
    {
        public string ProjectName  { get; }
        public int    ModulesBuilt { get; }
        public int    BugsFixed    { get; }

        public Developer(int id, string name, string project, int modules, int bugs)
            : base(id, name)
        { ProjectName = project; ModulesBuilt = modules; BugsFixed = bugs; }

        public override void GenerateReport()
        {
            Console.WriteLine("----- DEVELOPER REPORT -----");
            Console.WriteLine($"Developer   : {Name} (Id={Id})");
            Console.WriteLine($"Project     : {ProjectName}");
            Console.WriteLine($"Modules built: {ModulesBuilt}");
            Console.WriteLine($"Bugs fixed   : {BugsFixed}");
            Console.WriteLine("Status      : Project development in progress.\n");
        }
    }

    public class Tester : Employee
    {
        public string ProjectName   { get; }
        public int    TestCasesRun  { get; }
        public int    BugsReported  { get; }
        public int    BugsClosed    { get; }

        public Tester(int id, string name, string project, int run, int reported, int closed)
            : base(id, name)
        { ProjectName = project; TestCasesRun = run; BugsReported = reported; BugsClosed = closed; }

        public override void GenerateReport()
        {
            Console.WriteLine("----- TESTER REPORT -----");
            Console.WriteLine($"Tester       : {Name} (Id={Id})");
            Console.WriteLine($"Project      : {ProjectName}");
            Console.WriteLine($"Test cases run: {TestCasesRun}");
            Console.WriteLine($"Bugs reported : {BugsReported}");
            Console.WriteLine($"Bugs closed   : {BugsClosed}");
            Console.WriteLine($"Open bugs     : {BugsReported - BugsClosed}\n");
        }
    }

    public class Manager : Employee
    {
        private readonly List<Employee> _team = new();

        public Manager(int id, string name) : base(id, name) { }

        public void AddToTeam(Employee e) => _team.Add(e);

        public override void GenerateReport()
        {
            Console.WriteLine("===== MANAGER REPORT =====");
            Console.WriteLine($"Manager: {Name} (Id={Id})");
            Console.WriteLine($"Team size: {_team.Count}");
            Console.WriteLine();
            foreach (var e in _team)
                e.GenerateReport();

            Console.WriteLine("----- Manager Summary -----");
            Console.WriteLine($"Reviewed reports from all {_team.Count} team members.\n");
        }
    }

    class Program
    {
        static void Main()
        {
            var dev1   = new Developer(101, "Anshika",  "InventoryApp", modules: 12, bugs: 8);
            var dev2   = new Developer(102, "Neha",   "InventoryApp", modules: 9,  bugs: 6);
            var tester = new Tester   (201, "Kabir",  "InventoryApp", run: 240, reported: 25, closed: 18);

            var manager = new Manager(301, "Mr. Sharma");
            manager.AddToTeam(dev1);
            manager.AddToTeam(dev2);
            manager.AddToTeam(tester);

            // Polymorphic call — same method, different behaviour
            Console.WriteLine("### Individual reports ###\n");
            dev1.GenerateReport();
            tester.GenerateReport();

            Console.WriteLine("### Manager's consolidated report ###\n");
            manager.GenerateReport();
        }
    }
}
