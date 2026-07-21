# My Coding Assignments 👩‍💻

Hey there! 👋 Here are my coding assignments for C# (.NET) and SQL. I've made sure each folder contains a self-contained, runnable solution, along with my comments to explain the logic.

## Index

| # | Folder | Topic | Language |
|---|--------|-------|----------|
| 01 | `01_sql_users`                          | Users table (Age > 18 CHECK) + 5 SELECT queries (avg, IN, EXISTS, correlated avg, overall avg) | SQL |
| 02 | `02_drone_system`                       | Drone surveillance system — encapsulation, state, battery/altitude private | C# |
| 03 | `03_shopping_app`                       | Customer + DeliveryAgent + Order + Payment (abstract User) | C# |
| 04 | `04_employee_reports`                   | Developer / Tester / Manager polymorphic reports | C# |
| 05 | `05_shopping_discounts`                 | Prime loyalty, Festival, Coupon — Strategy pattern | C# |
| 06 | `06_exam_form_exception`                | Custom exception when exam form submitted after deadline | C# |
| 07 | `07_cab_booking`                        | Cab booking with GPS service failure / invalid location exceptions | C# |
| 08 | `08_notes_collection_framework`         | Short note on C# Collection Framework | Notes |
| 09 | `09_notes_object_methods`               | Short note on Equals / ToString / GetHashCode | Notes |
| 10 | `10_playlist_menu`                      | Menu-driven playlist with index + title | C# |
| 11 | `11_age_sorting`                        | Age-based sorting of persons (IComparable + LINQ) | C# |
| 12 | `12_employee_custom_sorting`            | Custom sorting by salary, joining date, employee ID (IComparer) | C# |
| 13 | `13_sql_customer_product_order`         | Customer/Product/Order joins (INNER, LEFT, RIGHT) | SQL |
| 14 | `14_default_values`                     | Default values of int / bool / string / DateTime / etc. | C# |
| 15 | `15_nullable_int`                       | Nullable&lt;int&gt; demo: null, HasValue, GetValueOrDefault, comparisons | C# |
| 16 | `16_password_encode_decode`             | Encode: shift +2 then reverse; Decode: reverse then shift -2 | C# |
| 17 | `17_password_strength`                  | Length ≥ 8, capital, digit → Weak/Medium/Strong | C# |
| 18 | `18_age_from_dob`                       | Calculate age (years/months/days) from DOB | C# |
| 19 | `19_hours_to_days`                      | Convert hours → days (days = h / 24) | C# |
| 20 | `20_anagram_groups`                     | Print groups of anagrams from a word list | C# |
| 21 | `21_number_guessing`                    | Number guessing challenge vs computer (binary search) | C# |
| 22 | `22_sql_sales`                          | Sales by Salesman & Category + monthly sales grouped by salesman | SQL |
| 23 | `23_sql_shipments`                      | Shipment status, delivered today, avg transit, in-transit | SQL |
| 24 | `24_fizzbuzz_variant`                   | 1..50 with rules: 3 / 5 / 3-5 / Prime / number | C# |
| 25 | `25_expense_sharing_efcore`             | Expense sharing app with EF Core (SQLite by default) | C# |
| 26 | `26_homework_notes`                     | Notes: SDLC / EF / ORM / HTML / CSS / ER / DB design | Notes |

## How to Run

### C# Assignments

Each C# folder contains a single `Program.cs`. Pick one of these options:

**Option A — run with `dotnet` (recommended)**

```bash
cd 02_drone_system
dotnet new console -n temp -o . --force
# Program.cs will be picked up automatically
dotnet run
```

Or convert each folder into its own SDK-style project by adding a `.csproj` like the one in `25_expense_sharing_efcore`.

**Option B — .NET Fiddle / online**

Paste `Program.cs` contents into https://dotnetfiddle.net/ and click Run.

### SQL Assignments

Open in SSMS, Azure Data Studio, DBeaver, or any SQL client. Each `.sql` file is self-contained:
- Creates tables (drop them first if rerunning)
- Inserts sample data
- Runs all the required queries

Tested with SQL Server syntax (`IDENTITY`, `GETDATE()`, `DATEDIFF`, `DATENAME`). For MySQL/PostgreSQL, minor tweaks to `IDENTITY`/`GETDATE()` may be needed.

### EF Core Expense Sharing App (`25_expense_sharing_efcore`)

```bash
cd 25_expense_sharing_efcore
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

Uses **SQLite** by default (file-based — no server required).

## Notes

- All code is original and written to demonstrate clean C# / SQL practices.
- Comments at the top of each file explain the assignment objective.
- The repository is **private** — only the owner can see it.

## Author

Bhavna Rathi ✨
