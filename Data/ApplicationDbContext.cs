using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Pages;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BookingModel> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
