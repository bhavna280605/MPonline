using System;
using System.Collections.Generic;

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsIssued { get; set; }

    public Book(int id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
        IsIssued = false;
    }
}

class LibraryManagementSystem
{
    static List<Book> books = new List<Book>();

    static void AddBook()
    {
        Console.Write("Enter Book ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine();

        books.Add(new Book(id, title, author));

        Console.WriteLine("Book Added Successfully!");
    }

    static void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("\nLibrary Books:");
        foreach (Book book in books)
        {
            Console.WriteLine(
                $"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Issued: {book.IsIssued}");
        }
    }

    static void IssueBook()
    {
        Console.Write("Enter Book ID to Issue: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Book book in books)
        {
            if (book.BookId == id)
            {
                if (!book.IsIssued)
                {
                    book.IsIssued = true;
                    Console.WriteLine("Book Issued Successfully!");
                }
                else
                {
                    Console.WriteLine("Book is already issued.");
                }
                return;
            }
        }

        Console.WriteLine("Book not found.");
    }

    static void ReturnBook()
    {
        Console.Write("Enter Book ID to Return: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Book book in books)
        {
            if (book.BookId == id)
            {
                if (book.IsIssued)
                {
                    book.IsIssued = false;
                    Console.WriteLine("Book Returned Successfully!");
                }
                else
                {
                    Console.WriteLine("Book was not issued.");
                }
                return;
            }
        }

        Console.WriteLine("Book not found.");
    }

    static void Main()
    {
        // Predefined collection of books
        books.Add(new Book(101, "C# Programming", "Herbert Schildt"));
        books.Add(new Book(102, "Data Structures", "Seymour Lipschutz"));
        books.Add(new Book(103, "Operating Systems", "Galvin"));

        int choice;

        do
        {
            Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Display Books");
            Console.WriteLine("3. Issue Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;

                case 2:
                    DisplayBooks();
                    break;

                case 3:
                    IssueBook();
                    break;

                case 4:
                    ReturnBook();
                    break;

                case 5:
                    Console.WriteLine("Thank You!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }

        } while (choice != 5);
    }
}