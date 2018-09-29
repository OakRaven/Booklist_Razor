using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookList_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;

            DefaultBook = new Book();
        }

        public IEnumerable<Book> Books { get; set; }

        public Book DefaultBook { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);

            await _db.SaveChangesAsync();

            Message = "Book has been been deleted successfully";

            return RedirectToPage();
        }
    }
}