namespace OOP_book_reader.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        private DateTime _dateOfRelease;

        public DateTime DateOfRelease
        {
            get => _dateOfRelease;
            set
            {
                if (value < new DateTime(1500, 1, 1))
                    throw new ArgumentException("Date is too old!");
                if (value > DateTime.Now)
                    throw new ArgumentException("Date cannot be in the future!");
                _dateOfRelease = value;
            }
        }

        //constructor - initialize the object’s properties.
        public Book(string title, string author, DateTime date)
        {
            Title = title;
            Author = author;
            DateOfRelease = date;
        }

        public Book()
        {
        }

        public override string ToString()
        {
            return $"Tidfhgftle: {Title}  \n Author:{Author} \n Date of release: {DateOfRelease}";
        }

        public interface Iserialization
        {
            void JSONser(Book book, string Path);
            void XMLser(Book book, string Path);
        }
    }
}
