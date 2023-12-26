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
    public class DeleteModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public DeleteModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public IdentityProjectInventory IdentityProjectInventory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IdentityProjectInventory == null)
            {
                return NotFound();
            }

            var identityprojectinventory = await _context.IdentityProjectInventory.FirstOrDefaultAsync(m => m.Id == id);

            if (identityprojectinventory == null)
            {
                return NotFound();
            }
            else 
            {
                IdentityProjectInventory = identityprojectinventory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IdentityProjectInventory == null)
            {
                return NotFound();
            }
            var identityprojectinventory = await _context.IdentityProjectInventory.FindAsync(id);

            if (identityprojectinventory != null)
            {
                IdentityProjectInventory = identityprojectinventory;
                _context.IdentityProjectInventory.Remove(IdentityProjectInventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
