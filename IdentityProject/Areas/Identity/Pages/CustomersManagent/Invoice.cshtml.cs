using IdentityProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Areas.Identity.Pages.CustomersManagent
{
    public class InvoiceModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public InvoiceModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }
       
        public IList<Customer> Customer { get; set; } = default!;
        public IEnumerable<Inventory> Customersrecored { get; set; } = default!;
        public async Task OnGet()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "firstname");
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
                Customersrecored = await _context.Inventory.ToListAsync();
                var conttt = Customer.Count();
                ViewData["Count"] = Customer.Count;
            }

        }
        public void OnPost(int id)
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "firstname");
            Customersrecored = (from x in _context.Inventory where (x.Id == id) select x).ToList();
        }
    }
}
