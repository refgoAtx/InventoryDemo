using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.ProjectManagement
{
    public class CreateModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public CreateModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "firstname");
        ViewData["InventoryID"] = new SelectList(_context.Inventory, "Id", "ItemName");
            return Page();
        }

        [BindProperty]
        public IdentityProjectProjects IdentityProjectProjects { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.IdentityProjectProjects == null || IdentityProjectProjects == null)
            {
                return Page();
            }

            _context.IdentityProjectProjects.Add(IdentityProjectProjects);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
