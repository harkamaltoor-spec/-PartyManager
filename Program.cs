using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PartyManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Add Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// ✅ SIMPLE DATABASE SETUP (NO ADMIN CREATION - WE'LL DO THAT MANUALLY)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    try
    {
        // Create database if it doesn't exist
        context.Database.EnsureCreated();
        Console.WriteLine("✅ Database created successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Database warning: {ex.Message}");
        // Continue anyway - app will still run
    }
}

app.Run();