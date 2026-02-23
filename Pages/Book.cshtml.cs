using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Data;
using System;

namespace Project.Pages
{
    public class BookingModel
    {
        public int Id { get; set; }   // Primary key

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Persons { get; set; }
        public DateTime Date { get; set; }
    }

    public class BookModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public BookingModel Booking { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Bookings.Add(Booking);
            _context.SaveChanges();

            TempData["Success"] = "Booking submitted successfully!";
            return RedirectToPage();
        }


        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //        return Page();

        //    // Example: Save to database here

        //    Console.WriteLine($"New Booking: {Booking.Name}");

        //    TempData["Success"] = "Booking submitted successfully!";
        //    return RedirectToPage();
        //}
    }
}
