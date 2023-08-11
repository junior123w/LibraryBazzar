using LibraryBazzar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryBazzar.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _context.Books
                .OrderBy(department => department.Title)
                .ToListAsync();

            return View(departments);            
        }
        public async Task<IActionResult> Details(int? id)
        {
            var bookdetails = await _context.Books
                .FirstOrDefaultAsync(book => book.BookId == id);

            return View(bookdetails);
        }
    }
}
