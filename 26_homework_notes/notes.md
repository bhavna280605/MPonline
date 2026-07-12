# Homework Notes — SDLC / Entity Framework / ORM / HTML / CSS / ER Diagrams / Database Design

---

## 1. SDLC (Software Development Life Cycle)

The **Software Development Life Cycle** is a structured process used by software engineering teams to design, develop, test, and deploy high-quality software. It defines a series of phases that transform a business need into a working system.

### Phases of SDLC

1. **Requirement Gathering & Analysis**
   - Stakeholders describe what the system should do.
   - Output: Software Requirements Specification (SRS) document.
   - Techniques: interviews, surveys, observation.

2. **System Design**
   - Translates requirements into architecture.
   - High-Level Design (HLD): overall architecture, modules, technology stack.
   - Low-Level Design (LLD): detailed class diagrams, ER diagrams, API contracts.
   - Output: Design documents.

3. **Implementation / Coding**
   - Developers write code based on the design.
   - Follows coding standards, version control, code reviews.
   - This is usually the longest phase.

4. **Testing**
   - Unit, integration, system, and acceptance testing.
   - Bugs found are reported and fixed.
   - Output: test reports, defect logs.

5. **Deployment**
   - The application is released to production.
   - May be staged (dev → test → staging → prod).

6. **Maintenance**
   - Bug fixes, enhancements, patches, support.
   - Continues for the lifetime of the software.

### Popular SDLC Models

| Model | Description |
|-------|-------------|
| **Waterfall**       | Sequential, each phase completed before the next. |
| **V-Model**         | Verification & Validation paired — each dev phase has a corresponding test phase. |
| **Iterative**       | Builds the system in small increments. |
| **Spiral**          | Risk-driven, iterative, with risk analysis at each loop. |
| **Agile**           | Iterative, collaborative, customer-focused, short sprints (Scrum / Kanban). |
| **DevOps**          | Continuous integration + continuous delivery + close dev-ops collaboration. |

---

## 2. ORM (Object-Relational Mapping)

**ORM** is a technique that lets you query and manipulate data from a relational database using objects in your programming language, without writing raw SQL.

### Benefits
- **Productivity** — no boilerplate SQL/AAD code.
- **Type safety** — compile-time checks.
- **Maintainability** — code in one language.
- **Database-agnostic** — switch providers with minimal changes.
- **Security** — built-in protection against SQL injection (parameterized queries).

### Drawbacks
- Performance overhead vs hand-tuned SQL.
- Complex joins can be inefficient if not understood well.
- "Impedance mismatch" between OOP and relational models.

### Popular ORMs
- **.NET:** Entity Framework Core, Dapper (micro-ORM), NHibernate
- **Java:** Hibernate, JPA
- **Python:** SQLAlchemy, Django ORM
- **Node.js:** Prisma, Sequelize, TypeORM

---

## 3. Entity Framework (EF Core)

**Entity Framework Core** is Microsoft's official ORM for .NET. It supports LINQ queries, change tracking, migrations, and works with SQL Server, SQLite, PostgreSQL, MySQL, and more.

### Key Concepts
- **DbContext** — the main entry point. Represents a session with the database.
- **DbSet<T>** — represents a table; used to query and save instances of `T`.
- **Entity** — a class mapped to a database table.
- **Migration** — a code-based representation of schema changes.
- **Convention over configuration** — EF infers schema from your POCO classes by default.

### Workflow

1. **Install packages**
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

2. **Define entity classes** — plain C# classes (POCOs).

3. **Create a DbContext** with `DbSet<T>` properties for each entity.

4. **Create a migration**
   ```bash
   dotnet ef migrations add InitialCreate
   ```
   This generates a `Migrations/` folder with C# code describing the schema.

5. **Apply the migration to the database**
   ```bash
   dotnet ef database update
   ```

6. **Use the DbContext** in your application for CRUD operations:
   ```csharp
   using var ctx = new AppDbContext();
   ctx.Users.Add(new User { Name = "Anshika" });
   ctx.SaveChanges();

   var all = ctx.Users.Where(u => u.Age > 18).ToList();
   ```

### Approaches
- **Database-First** — reverse-engineer model from existing DB.
- **Model-First** — design model visually, EF generates DB.
- **Code-First** (most common today) — write C# classes, EF generates migrations & DB.

---

## 4. HTML (HyperText Markup Language)

HTML is the standard markup language for creating web pages. It describes the **structure** of a webpage using a series of elements (tags) which the browser renders.

### Skeleton
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>My Page</title>
</head>
<body>
    <h1>Hello, world!</h1>
    <p>This is a paragraph.</p>
</body>
</html>
```

### Common Tags
| Tag | Purpose |
|-----|---------|
| `<h1>` – `<h6>` | Headings |
| `<p>`           | Paragraph |
| `<a href="…">`  | Hyperlink |
| `<img src="…" alt="…">` | Image |
| `<ul>`, `<ol>`, `<li>` | Lists |
| `<table>`, `<tr>`, `<td>`, `<th>` | Tables |
| `<form>`, `<input>`, `<button>` | Forms |
| `<div>`, `<span>` | Generic containers |
| `<header>`, `<nav>`, `<main>`, `<footer>`, `<section>`, `<article>` | Semantic structure |

HTML5 added semantic elements, native form validation, audio/video, canvas, and many new input types (date, email, number, range, color).

---

## 5. CSS (Cascading Style Sheets)

CSS describes the **presentation** of HTML — colors, fonts, layout, spacing, animations, responsive behaviour.

### Ways to Apply CSS
1. **Inline** — `<p style="color:red;">…</p>`
2. **Internal** — `<style>` block inside `<head>`
3. **External** (recommended) — `<link rel="stylesheet" href="style.css">`

### Selectors
```css
p              { color: navy; }              /* element */
.highlight     { background: yellow; }       /* class */
#main-header   { font-size: 2rem; }          /* id */
div > p        { margin-left: 1rem; }        /* direct child */
input[type="text"] { border: 1px solid #ccc; }/* attribute */
```

### Box Model
Every element is a box consisting of: **content → padding → border → margin**.

### Layout Systems
- **Flexbox** — 1-D layout (row or column).
- **CSS Grid** — 2-D layout (rows and columns).
- **Positioning** — static / relative / absolute / fixed / sticky.

### Responsive Design
```css
@media (max-width: 768px) {
    body { font-size: 14px; }
}
```

Modern CSS also offers CSS variables, animations, transitions, transforms, and container queries.

---

## 6. ER Diagrams (Entity-Relationship Diagrams)

An **ER Diagram** is a visual blueprint of a database. It shows entities (tables), their attributes (columns), and the relationships between them.

### Components

| Symbol | Meaning |
|--------|---------|
| **Rectangle** | Entity (table) |
| **Ellipse**   | Attribute (column) |
| **Diamond**   | Relationship |
| **Lines**     | Connect attributes/relationships to entities |
| **Primary key** | underlined attribute |
| **Foreign key** | italicised / dashed |

### Cardinality Notations
- **One-to-One (1:1)** — each entity instance relates to exactly one of the other.
- **One-to-Many (1:N)** — one parent can have many children.
- **Many-to-Many (M:N)** — usually resolved via a junction table.

### Example: Library Database
```
[Book]──<holds>──[Loan]──<borrowed by>──[Member]
  ISBN (PK)         LoanId (PK)           MemberId (PK)
  Title             BookId (FK)           Name
  Author            MemberId (FK)         Email
  PubYear           BorrowDate
                    ReturnDate
```

---

## 7. Database Design

**Database design** is the process of producing a detailed data model of a database that supports business requirements and ensures data integrity, performance, and scalability.

### Steps
1. **Requirement analysis** — what data must be stored, what queries must be answered?
2. **Conceptual design** — produce an ER diagram (entities, relationships).
3. **Logical design** — convert ER to relational schema (tables, columns, keys).
4. **Normalization** — apply normal forms to remove redundancy:
   - **1NF:** atomic values, no repeating groups.
   - **2NF:** 1NF + no partial dependency on composite keys.
   - **3NF:** 2NF + no transitive dependency (non-key depends on non-key).
   - **BCNF:** stronger 3NF.
5. **Physical design** — choose data types, indexes, partitioning, storage.
6. **Implementation** — write `CREATE TABLE` DDL with constraints.
7. **Tuning** — index optimisation, query plans, denormalisation if needed.

### Key Constraints
| Constraint | Purpose |
|------------|---------|
| `PRIMARY KEY`  | Unique + non-null identifier |
| `FOREIGN KEY`  | Referential integrity to another table |
| `UNIQUE`       | No duplicate values |
| `NOT NULL`     | Mandatory field |
| `CHECK`        | Custom boolean condition (e.g. Age > 18) |
| `DEFAULT`      | Default value when not supplied |

### Best Practices
- Choose **natural keys** only when truly stable; otherwise use **surrogate keys** (auto-increment INT / GUID).
- Index columns frequently used in `WHERE`, `JOIN`, and `ORDER BY`.
- Avoid premature denormalisation — normalize first, denormalise only when measured performance demands it.
- Use consistent naming conventions (e.g., `snake_case` for tables/columns).
- Document every table with a comment describing its purpose.

---

## Putting It All Together

A typical .NET web application ties all these concepts together:

- **SDLC** guides the project from requirements to maintenance.
- **HTML + CSS** form the front-end that the user sees.
- **ER diagrams** model the data.
- **Database design + SQL** stores the data.
- **ORM (EF Core)** bridges C# objects and the relational database.
- **C# / .NET** contains the business logic.

Mastering these foundational topics is essential for any full-stack .NET developer.
