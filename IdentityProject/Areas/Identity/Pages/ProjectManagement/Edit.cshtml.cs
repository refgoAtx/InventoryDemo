using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.ProjectManagement
{
    public class EditModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public EditModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityProjectProjects IdentityProjectProjects { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IdentityProjectProjects == null)
            {
                return NotFound();
            }

            var identityprojectprojects = await _context.IdentityProjectProjects.FirstOrDefaultAsync(m => m.Id == id);
            if (identityprojectprojects == null)
            {
                return NotFound();
            }
            IdentityProjectProjects = identityprojectprojects;
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "firstname");
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "Id", "ItemName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(IdentityProjectProjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityProjectProjectsExists(IdentityProjectProjects.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IdentityProjectProjectsExists(int id)
        {
            return (_context.IdentityProjectProjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
