using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the IdentityProjectUser class
public class IdentityProjectUser : IdentityUser
{
    public string? Company { get; set; }
}

