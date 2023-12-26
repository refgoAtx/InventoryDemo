using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.UsersManagement
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
            return Page();
        }

        [BindProperty]
        public IdentityProjectUsers IdentityProjectUsers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.IdentityProjectUsers == null || IdentityProjectUsers == null)
            {
                return Page();
            }

            _context.IdentityProjectUsers.Add(IdentityProjectUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
