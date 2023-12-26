﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Data;
using IdentityProject.Model;
using Microsoft.AspNetCore.Authorization;

namespace IdentityProject.Areas.Identity.Pages.CustomersManagent
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IdentityProject.Data.IdentityProjectContext _context;

        public IndexModel(IdentityProject.Data.IdentityProjectContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
