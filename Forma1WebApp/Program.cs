using Forma1WebApp.Data;
using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Az SQLite in-memory adatbázis addig él, amíg ez a kapcsolat nyitva van.
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddDbContext<Forma1Context>(options => options.UseSqlite(connection));

builder.Services.AddIdentity<StoreUser, IdentityRole>(cfg =>
    {
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequireUppercase = false;
        cfg.Password.RequiredUniqueChars = 0;
        cfg.User.RequireUniqueEmail = false;
    })
    .AddEntityFrameworkStores<Forma1Context>();

builder.Services.AddTransient<TeamSeeder>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/App/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Fallback",
    pattern: "{controller=App}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<TeamSeeder>();
    await seeder.SeedAsynv();
}

app.Run();
