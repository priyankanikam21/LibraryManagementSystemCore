using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemCore.Models
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> books { get; set; }
    }
}
