using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Data;

namespace Project.Pages
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal GrandTotal { get; set; }

        public List<OrderItem> Items { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
    }
    public class CartItemVM
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }

    public class ShopingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ShopingModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CartItemVM CartItem { get; set; }
        [BindProperty]
        public List<OrderItem> Items { get; set; }
        //onGet
        public void OnGet()
        {
            Items = new List<OrderItem>
            {
                new OrderItem() // 👈 This creates one empty row
            };
        }
        //OnPost
        public class CartItemDto
        {
            public string Title { get; set; }
            public decimal Price { get; set; }
            public int Qty { get; set; }
        }

        public async Task<IActionResult> OnPostSaveOrderAsync([FromBody] List<CartItemDto> cart)
        {
            if (cart == null || !cart.Any())
                return new JsonResult(new { success = false, message = "Cart is empty" });

            decimal grandTotal = 0;

            var order = new Order
            {
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>()
            };

            foreach (var item in cart)
            {
                var total = item.Price * item.Qty;
                grandTotal += total;

                order.Items.Add(new OrderItem
                {
                    Title = item.Title,
                    Price = item.Price,
                    Qty = item.Qty,
                    Total = total
                });
            }

            order.GrandTotal = grandTotal;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                success = true,
                invoiceId = order.Id,
                grandTotal = grandTotal
            });
        }
    }
}
