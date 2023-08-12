using LibraryBazzar.Data;
using LibraryBazzar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Security.Claims;

namespace LibraryBazzar.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
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

        public async Task<IActionResult> BookDetails(int? id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(book => book.BookId == id);

            return View(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int BookId, int quantity)
        {
            if (User == null) return NotFound();

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _context.Carts
                   .FirstOrDefaultAsync(cart => cart.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };

                if (!ModelState.IsValid) return NotFound();
                await _context.AddAsync(cart);
                await _context.SaveChangesAsync();

            }
            var book = await _context.Books
                .FirstOrDefaultAsync(book => book.BookId == BookId);
            if (book == null) return NotFound();
            var cartItem = new CartItem
            {
                Cart = cart,
                Book = book,
                Quantity = quantity,
                Price = (decimal)book.Price
            };

            if (!ModelState.IsValid) return NotFound();
            await _context.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return View(Index);

        }
    }
}
