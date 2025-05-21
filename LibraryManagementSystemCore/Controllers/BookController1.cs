using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystemCore.Models;
//using LibraryManagementSystemCore.Data;
using System.Threading.Tasks;

namespace LibraryManagementSystemCore.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext DbContext;

        public BooksController(LibraryContext context)
        {
            DbContext = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await DbContext.books.ToListAsync());
        }

        
        public IActionResult Create() => View();

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(book);
                await DbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await DbContext.books.FindAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return NotFound();

            if (ModelState.IsValid)
            {
                DbContext.Update(book);
                await DbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await DbContext.books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null) return NotFound();

            return View(book);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await DbContext.books.FindAsync(id);
            DbContext.books.Remove(book);
            await DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var book = await DbContext.books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null) return NotFound();

            return View(book);
        }
    }
}
