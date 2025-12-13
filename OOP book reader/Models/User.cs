namespace OOP_book_reader.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public User(string name, string surname, int? phone, DateTime? dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            DateOfBirth = dateOfBirth;
        }
    }
}
