using OOP_book_reader;

public class BookManager
{
    private static List<Book> BookList = new List<Book>();

    public static void AddBook()
    {
        Console.WriteLine("Write book name:");
        string? name = Console.ReadLine();

        Console.WriteLine("Write book author:");
        string? author = Console.ReadLine();

        Console.WriteLine("Write Release Date (yyyy-MM-dd):");
        string? input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime dateOfRelease))
        {
            var newBook = new Book(name ?? "", author ?? "", dateOfRelease);
            BookList.Add(newBook);
            Console.WriteLine($"Book '{name}' added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date");
        }
    }

    public static void ShowAllData()
    {
        if (BookList.Count == 0)
        {
            Console.WriteLine("No books in the list.");
            return;
        }

        foreach (var book in BookList)
        {
            Console.WriteLine($"Title: {book.Title} \nAuthor: {book.Author} \nDate of release: {book.DateOfRelease:yyyy-MM-dd}\n");
        }
    }

    public static void SearchByName()
    {
        Console.WriteLine("Enter book's title:");
        string? searchTitle = Console.ReadLine();

        var foundBooks = BookList
            .Where(b => !string.IsNullOrEmpty(b.Title) && b.Title.Contains(searchTitle ?? "", StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (foundBooks.Count > 0)
        {
            Console.WriteLine($"Found {foundBooks.Count} book(s):");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}, released on {book.DateOfRelease:yyyy-MM-dd}");
            }
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("No book with this title in data");
            Console.ResetColor();
        }
    }

    public static void UI()
    {
        while (true)
        {
            Console.WriteLine("Welcome to book manager! Choose what to do:");
            Console.WriteLine("1 -- Add book \n2 -- Show all data \n3 -- Search book by title \n4 -- Exit");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        ShowAllData();
                        break;
                    case 3:
                        SearchByName();
                        break;
                    case 4:
                        return; // exit
                    default:
                        Console.WriteLine("Invalid option number");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
