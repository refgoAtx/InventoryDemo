using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Data;
using IdentityProject.Areas.Identity.Data;


public class Program
{
    public static async Task Main(string[] args)

    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = "server=mysql.eixsys.com;database=armada_prod;uid=armada;pwd=Ehoffice1234#;";

        builder.Services.AddDbContext<IdentityProjectContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 24))));

       

        builder.Services.AddDefaultIdentity<IdentityProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityProjectContext>();

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();

        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin", "Manager", "Member" };
            foreach (var role in roles)
            {
                if (!await roleManger.RoleExistsAsync(role))
                    await roleManger.CreateAsync(new IdentityRole(role));
            }
        }
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityProjectUser>>();
            string email = "admin@admin.com";
            string password = "Test123#";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityProjectUser();
                user.UserName = email;
                user.Email = password;
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
        app.Run();
    }
}



