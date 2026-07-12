# Equals, ToString, and GetHashCode Methods — Short Note

`Equals`, `ToString`, and `GetHashCode` are three virtual methods inherited by every C# type from `System.Object`. They form the **identity and representation contract** of an object. Overriding them correctly is essential for proper behaviour in collections, debugging, serialization, and equality comparisons.

---

## 1. `object.ToString()`

**Purpose:** Returns a human-readable string representation of the object. The default implementation in `System.Object` returns the fully-qualified type name — almost never useful.

**When to override:** Always, for domain entities and DTOs. Useful for debugging, logging, and `Console.WriteLine(obj)`.

```csharp
public class Person
{
    public string Name { get; set; }
    public int    Age  { get; set; }

    public override string ToString() => $"{Name} (Age {Age})";
}
```

Without the override, `new Person { Name = "Anshika", Age = 21 }.ToString()` returns `"MyApp.Person"`.

---

## 2. `object.Equals(object obj)`

**Purpose:** Determines whether the current object is equal to another. Default implementation is **reference equality** (same object in memory) for reference types.

**When to override:** When two distinct instances should be considered "equal" if their fields match (value equality). Always override `Equals` together with `GetHashCode` (rule below).

```csharp
public class Person
{
    public string Name { get; set; }
    public int    Age  { get; set; }

    public override bool Equals(object obj) =>
        obj is Person other
        && Name == other.Name
        && Age  == other.Age;

    public override int GetHashCode() => HashCode.Combine(Name, Age);
}
```

### Equality Contract Rules
1. **Reflexive:** `x.Equals(x)` → true
2. **Symmetric:** `x.Equals(y)` ⇔ `y.Equals(x)`
3. **Transitive:** `x.Equals(y)` and `y.Equals(z)` ⇒ `x.Equals(z)`
4. **Consistent:** repeated calls return the same result as long as state doesn't change
5. **Null:** `x.Equals(null)` → false

---

## 3. `object.GetHashCode()`

**Purpose:** Returns an integer hash code used by hash-based collections (`Dictionary<TKey, TValue>`, `HashSet<T>`, `Hashtable`). Two equal objects **must** return the same hash code (otherwise the collection will silently lose items).

**Rule:** If you override `Equals`, you MUST override `GetHashCode`. The hash code should be based on the **same fields** used in `Equals`.

```csharp
public override int GetHashCode() => HashCode.Combine(Name, Age);
```

### Guidelines
- Fast to compute.
- Well distributed (avoid `return 0;`).
- Stable across the object's lifetime as long as its equality-relevant fields don't change.
- For mutable fields used in hashing, do **not** mutate them while the object is a dictionary key.

---

## 4. Modern C# Alternative — `IEquatable<T>` + Records

For value-like types, implement `IEquatable<T>` for type-safe equality:

```csharp
public class Person : IEquatable<Person>
{
    public string Name { get; set; }
    public int    Age  { get; set; }

    public bool Equals(Person other) =>
        other is not null && Name == other.Name && Age == other.Age;

    public override bool Equals(object obj) => Equals(obj as Person);
    public override int  GetHashCode()       => HashCode.Combine(Name, Age);
}
```

Even simpler: use a **`record`** (C# 9+) — the compiler auto-generates `Equals`, `GetHashCode`, and `ToString` based on the record's properties:

```csharp
public record Person(string Name, int Age);
```

---

## 5. Summary Table

| Method          | Default behaviour            | Override when...                          |
|-----------------|------------------------------|-------------------------------------------|
| `ToString()`    | Returns full type name       | You want a readable representation        |
| `Equals(obj)`   | Reference equality           | You need value equality                   |
| `GetHashCode()` | Based on object identity     | You overrode `Equals` (mandatory!)        |

> ⚠️ Violating the `Equals`/`GetHashCode` contract is one of the most common sources of bugs in C# — always override them together.
