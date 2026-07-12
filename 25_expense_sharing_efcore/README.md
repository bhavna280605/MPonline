# Assignment 25 — Expense Sharing App (EF Core + MVC)

A simple .NET console application that demonstrates **Entity Framework Core** with a Code-First approach, covering:

- Users
- Groups
- Group Members (many-to-many)
- Expenses
- Expense Splits (how each expense is divided among members)
- Full CRUD operations
- Auto-calculated "who owes whom" settlement report

## Project Structure

```
25_expense_sharing_efcore/
├── ExpenseSharingApp.csproj   ← project file (SDK-style)
├── Program.cs                 ← menu-driven UI + CRUD demo
└── README.md                  ← this file
```

## How to Run

```bash
cd 25_expense_sharing_efcore

# 1. Restore packages
dotnet restore

# 2. (Optional) Install EF tools globally
dotnet tool install --global dotnet-ef

# 3. Create the database (uses SQLite by default — no server needed)
dotnet ef migrations add InitialCreate
dotnet ef database update

# 4. Run the app
dotnet run
```

## What the App Does

On startup it runs a self-contained demo:

1. Creates 3 users (Anshika, Neha, Kabir).
2. Creates a group "Flat 2024" and adds all three as members.
3. Adds 3 expenses:
   - Anshika paid ₹3,000 for Rent (split equally among all 3 → ₹1,000 each).
   - Neha paid ₹900 for Groceries (split equally → ₹300 each).
   - Kabir paid ₹600 for Electricity (split equally → ₹200 each).
4. Shows a **settlement report** listing who owes whom how much.

## Switching to SQL Server

Edit `AppDbContextFactory.cs` (or the `OnConfiguring` method) and replace:

```csharp
optionsBuilder.UseSqlite("Data Source=expenses.db");
```

with:

```csharp
optionsBuilder.UseSqlServer(
    "Server=localhost;Database=ExpenseDb;Trusted_Connection=True;TrustServerCertificate=True;");
```

Then re-run `dotnet ef migrations add InitialCreate` and `dotnet ef database update`.
