using IdentityProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public IndexModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }
        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;   
        //}
        public IList<Customer> Customer { get; set; } = default!;
		public IList<Inventory> Inventory { get; set; } = default!;
		public IList<Projects> Projects { get; set; } = default!;
		public IList<Users> Users { get; set; } = default!;
		public async Task OnGet()
        {
            if (_context.Customers != null)
            {
				Customer = await _context.Customers.ToListAsync();
				Inventory = await _context.Inventory.ToListAsync();
				Projects = await _context.Projects.ToListAsync();
				Users = await _context.Users.ToListAsync();
				ViewData["Count"] = Customer.Count;
				ViewData["Users"] = Users.Count;
				ViewData["Inventory"] = Inventory.Count;
				ViewData["Projects"] = Projects.Count;
			}

        }
		public void Index()
		{

		}
	}
}