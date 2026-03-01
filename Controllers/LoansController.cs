using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .ToListAsync();
        }

        // POST: api/loans — выдать книгу
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
            // Проверяем что книга существует
            var book = await _context.Books.FindAsync(loan.BookId);
            if (book == null)
                return NotFound("Книга не найдена");

            // Проверяем что есть доступные копии
            if (book.AvailableCopies <= 0)
                return BadRequest("Нет доступных копий книги");

            // Проверяем что читатель существует
            var member = await _context.Members.FindAsync(loan.MemberId);
            if (member == null)
                return NotFound("Читатель не найден");

            // Устанавливаем даты
            loan.LoanDate = DateTime.Now;
            loan.DueDate = DateTime.Now.AddDays(14); // 2 недели на чтение

            // Уменьшаем количество доступных копий
            book.AvailableCopies--;

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoans), new { id = loan.Id }, loan);
        }

        // PUT: api/loans/1/return — вернуть книгу
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (loan == null)
                return NotFound("Выдача не найдена");

            if (loan.ReturnDate != null)
                return BadRequest("Книга уже возвращена");

            // Отмечаем дату возврата
            loan.ReturnDate = DateTime.Now;

            // Увеличиваем количество доступных копий
            loan.Book!.AvailableCopies++;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/loans/overdue — просроченные выдачи
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetOverdueLoans()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now)
                .ToListAsync();
        }
    }
}