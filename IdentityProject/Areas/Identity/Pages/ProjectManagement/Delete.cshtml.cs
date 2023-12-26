using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.ProjectManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public DeleteModel(IdentityProject.Data.IdentityProjectContext context)
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
            else 
            {
                IdentityProjectProjects = identityprojectprojects;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IdentityProjectProjects == null)
            {
                return NotFound();
            }
            var identityprojectprojects = await _context.IdentityProjectProjects.FindAsync(id);

            if (identityprojectprojects != null)
            {
                IdentityProjectProjects = identityprojectprojects;
                _context.IdentityProjectProjects.Remove(IdentityProjectProjects);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
