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

namespace IdentityProject.Areas.Identity.Pages.UsersManagement
{
    public class EditModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public EditModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityProjectUsers IdentityProjectUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IdentityProjectUsers == null)
            {
                return NotFound();
            }

            var identityprojectusers =  await _context.IdentityProjectUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (identityprojectusers == null)
            {
                return NotFound();
            }
            IdentityProjectUsers = identityprojectusers;
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

            _context.Attach(IdentityProjectUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityProjectUsersExists(IdentityProjectUsers.Id))
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

        private bool IdentityProjectUsersExists(int id)
        {
          return (_context.IdentityProjectUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
