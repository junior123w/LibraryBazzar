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
        public async Task<IActionResult> ReviewDetails(int? id)
        {
            var bookreview = await _context.Reviews
                .FirstOrDefaultAsync(bookreview => bookreview.ReviewId == id);

            return View(bookreview);
        }

        public async Task<IActionResult> BookDetails(int? id)
        {
            var bookWithReview = await _context.Books
                .Include(book =>book.Review)
                .FirstOrDefaultAsync(book => book.BookId == id);

            return View(bookWithReview);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int BookId, int quantity)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _context.Carts
                   .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active==true);

            //creating a cart if its not there 
            if (cart == null)
            {
                cart = new Cart { UserId = userId };

                if (!ModelState.IsValid) return NotFound();
                await _context.AddAsync(cart);
                await _context.SaveChangesAsync();

            }

            //fetching the requested book
            var book = await _context.Books
                .FirstOrDefaultAsync(book => book.BookId == BookId);
            if (book == null) return NotFound();
            var cartItem = new CartItem
            {
                Cart = cart,
                Book = book,
                Quantity = quantity,
                Price = book.Price
            };

            if (!ModelState.IsValid) return NotFound();
            await _context.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");



        }
    }
}
