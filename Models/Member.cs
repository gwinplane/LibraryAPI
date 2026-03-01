namespace LibraryAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }

        // Связь с выдачами книг
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}