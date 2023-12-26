using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.InventoryManagent
{
    public class IndexModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public IndexModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        public IList<IdentityProjectInventory> IdentityProjectInventory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.IdentityProjectInventory != null)
            {
                IdentityProjectInventory = await _context.IdentityProjectInventory
                .Include(i => i.Customer).ToListAsync();
            }
        }
    }
}
