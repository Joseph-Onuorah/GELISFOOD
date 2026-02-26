using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Pages;
using System.Collections.Generic;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<CartItemVM> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
