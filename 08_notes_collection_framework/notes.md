# Collection Framework in C# — Short Note

The C# **Collection Framework** (found in the `System.Collections` and `System.Collections.Generic` namespaces) provides a set of strongly-typed classes and interfaces for storing, retrieving, and manipulating groups of related objects. Collections replace raw arrays when you need dynamic sizing, ordering, key-based lookup, or specialised behaviour (queue/stack semantics).

## 1. Two Generations of Collections

### Non-generic (`System.Collections`) — legacy, stores `object`
| Class | Purpose |
|-------|---------|
| `ArrayList`     | Dynamically-sized array of `object` |
| `Hashtable`     | Key/value pairs, no type safety |
| `Queue`         | FIFO collection |
| `Stack`         | LIFO collection |
| `SortedList`    | Key/value pairs sorted by key |

**Drawbacks:** boxing/unboxing overhead, no compile-time type safety.

### Generic (`System.Collections.Generic`) — modern, type-safe
| Class | Purpose |
|-------|---------|
| `List<T>`         | Dynamic array of type `T` |
| `Dictionary<TKey, TValue>` | Hash map of key→value |
| `HashSet<T>`      | Unique unordered elements |
| `SortedSet<T>`    | Unique elements in sorted order |
| `Queue<T>`        | FIFO |
| `Stack<T>`        | LIFO |
| `LinkedList<T>`   | Doubly linked list |
| `SortedList<TKey, TValue>` | Sorted key/value (array-backed) |
| `SortedDictionary<TKey, TValue>` | Sorted key/value (tree-backed) |
| `ConcurrentDictionary<TKey, TValue>` | Thread-safe dictionary |

## 2. Core Interfaces

| Interface | Meaning |
|-----------|---------|
| `IEnumerable<T>`      | Enables `foreach` iteration |
| `ICollection<T>`      | Base for all generic collections (Count, Add, Remove, CopyTo) |
| `IList<T>`            | Indexed access (List<T>) |
| `IDictionary<TKey,TValue>` | Key/value access |
| `ISet<T>`             | Set semantics (no duplicates) |
| `IComparer<T>`        | External comparison strategy |
| `IEqualityComparer<T>`| Defines equality for hashing |

## 3. Why Use Collections Instead of Arrays?

1. **Dynamic size** — grow/shrink automatically.
2. **Type safety** (generic collections) — compile-time checks.
3. **Rich API** — `Add`, `Remove`, `Contains`, `Find`, `Sort`, `ConvertAll`, etc.
4. **Specialised structures** — queues, stacks, dictionaries, sets.
5. **LINQ support** — `Where`, `Select`, `OrderBy`, `GroupBy`, etc.

## 4. Quick Example

```csharp
List<int> nums = new() { 5, 2, 9, 1 };
nums.Add(7);
nums.Sort();

Dictionary<string, int> ages = new()
{
    ["Alice"] = 22,
    ["Bob"]   = 19
};

HashSet<string> tags = new() { "csharp", "dotnet", "csharp" }; // duplicate ignored
```

## 5. Choosing the Right Collection

| Need | Use |
|------|-----|
| Indexed access, frequent traversal | `List<T>` |
| Fast lookup by key | `Dictionary<TKey, TValue>` |
| Unique items | `HashSet<T>` |
| FIFO order | `Queue<T>` |
| LIFO order | `Stack<T>` |
| Sorted unique items | `SortedSet<T>` |
| Frequent insert/remove in middle | `LinkedList<T>` |

The collection framework is the backbone of almost every C# application — mastering it is essential for writing clean, efficient, and maintainable code.
