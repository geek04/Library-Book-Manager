using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryBookManager
{
    class Program
    {
        static List<Book> books = new List<Book>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Library Book Manager ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddBook(); break;
                    case "2": ListBooks(); break;
                    case "3": SearchBook(); break;
                    case "4": DeleteBook(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option."); break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();

            books.Add(new Book { Title = title, Author = author });
            Console.WriteLine("Book added successfully.");
        }

        static void ListBooks()
        {
            if (!books.Any())
            {
                Console.WriteLine("No books available.");
                return;
            }

            Console.WriteLine("\nBooks:");
            int i = 1;
            foreach (var book in books)
            {
                Console.WriteLine($"{i++}. {book.Title} by {book.Author}");
            }
        }

        static void SearchBook()
        {
            Console.Write("Enter title to search: ");
            string keyword = Console.ReadLine().ToLower();

            var found = books.Where(b => b.Title.ToLower().Contains(keyword)).ToList();

            if (!found.Any())
            {
                Console.WriteLine("No matching books found.");
                return;
            }

            Console.WriteLine("\nResults:");
            foreach (var book in found)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }

        static void DeleteBook()
        {
            ListBooks();
            Console.Write("Enter book number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= books.Count)
            {
                books.RemoveAt(num - 1);
                Console.WriteLine("Book deleted.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
