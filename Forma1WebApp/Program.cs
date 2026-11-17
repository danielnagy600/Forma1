using Forma1WebApp.Data;
using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// The SQLite in-memory database lives only as long as this connection stays open.
// Registered as a singleton, so the DI container disposes it when the app shuts down.
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
builder.Services.AddSingleton(connection);

builder.Services.AddDbContext<Forma1Context>(options => options.UseSqlite(connection));

builder.Services.AddIdentity<StoreUser, IdentityRole>(cfg =>
    {
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequireUppercase = false;
        cfg.Password.RequiredUniqueChars = 0;
        cfg.User.RequireUniqueEmail = false;
    })
    .AddEntityFrameworkStores<Forma1Context>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<TeamSeeder>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<TeamSeeder>();
    await seeder.SeedAsync();
}

app.Run();
