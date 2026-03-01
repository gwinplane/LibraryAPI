namespace LibraryAPI.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Связь с книгой
        public int BookId { get; set; }
        public Book? Book { get; set; }

        // Связь с читателем
        public int MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
