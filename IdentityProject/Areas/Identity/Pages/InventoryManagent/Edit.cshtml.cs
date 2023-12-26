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

namespace IdentityProject.Areas.Identity.Pages.InventoryManagent
{
	public class EditModel : PageModel
	{
		private readonly IdentityProject.Data.IdentityProjectContext _context;

		public EditModel(IdentityProject.Data.IdentityProjectContext context)
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
			IdentityProjectInventory = identityprojectinventory;
			ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "firstname");
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

			_context.Attach(IdentityProjectInventory).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!IdentityProjectInventoryExists(IdentityProjectInventory.Id))
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

		private bool IdentityProjectInventoryExists(int id)
		{
			return (_context.IdentityProjectInventory?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
