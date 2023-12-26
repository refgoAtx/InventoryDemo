using IdentityProject.Areas.Identity.Data;
using IdentityProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Data;

public class IdentityProjectContext : IdentityDbContext<IdentityProjectUser>
{
	public DbSet<Invoices> Invoices { get; set; }
	public DbSet<Users> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Inventory> Inventory { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public IdentityProjectContext(DbContextOptions<IdentityProjectContext> options)
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);


		// Customize the ASP.NET Identity model and override the defaults if needed.
		// For example, you can rename the ASP.NET Identity table names and more.
		// Add your customizations after calling base.OnModelCreating(builder);
	}
	public DbSet<IdentityProject.Areas.Identity.Data.IdentityProjectInvoices>? IdentityProjectInvoices { get; set; }
	public DbSet<IdentityProject.Areas.Identity.Data.IdentityProjectUsers>? IdentityProjectUsers { get; set; }
    public DbSet<IdentityProject.Areas.Identity.Data.IdentityProjectCustomer>? IdentityProjectCustomers { get; set; }
    public DbSet<IdentityProject.Areas.Identity.Data.IdentityProjectInventory>? IdentityProjectInventory { get; set; }
    public DbSet<IdentityProject.Areas.Identity.Data.IdentityProjectProjects>? IdentityProjectProjects { get; set; }

}
