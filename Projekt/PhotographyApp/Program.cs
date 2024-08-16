using Microsoft.EntityFrameworkCore;
using PhotographyApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();


// Lägg till tjänster i containern.
builder.Services.AddControllersWithViews();

// Konfigurera databaskontexten för att använda SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Lägg till sessionshantering
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Konfigurera HTTP-begäransrörledningen
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Lägg till sessionsmiddleware
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
