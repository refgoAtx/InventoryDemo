using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;

namespace IdentityProject.Areas.Identity.Pages.InventoryManagent
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
			return Page();
		}

		[BindProperty]
		public IdentityProjectInventory IdentityProjectInventory { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.IdentityProjectInventory == null || IdentityProjectInventory == null)
			{
				return Page();
			}

			_context.IdentityProjectInventory.Add(IdentityProjectInventory);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
