namespace LibraryAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Связь с книгами — один автор может написать много книг
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}