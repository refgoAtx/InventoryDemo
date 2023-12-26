using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.UsersManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public DeleteModel(IdentityProject.Data.IdentityProjectContext context)
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

            var identityprojectusers = await _context.IdentityProjectUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (identityprojectusers == null)
            {
                return NotFound();
            }
            else 
            {
                IdentityProjectUsers = identityprojectusers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IdentityProjectUsers == null)
            {
                return NotFound();
            }
            var identityprojectusers = await _context.IdentityProjectUsers.FindAsync(id);

            if (identityprojectusers != null)
            {
                IdentityProjectUsers = identityprojectusers;
                _context.IdentityProjectUsers.Remove(IdentityProjectUsers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
