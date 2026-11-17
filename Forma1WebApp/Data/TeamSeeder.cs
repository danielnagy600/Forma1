using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Forma1WebApp.Data;

public class TeamSeeder
{
    private const string AdminUserName = "admin";
    private const string AdminPassword = "f1test2018";

    private readonly Forma1Context ctx;
    private readonly UserManager<StoreUser> userManager;

    public TeamSeeder(Forma1Context ctx, UserManager<StoreUser> userManager)
    {
        this.ctx = ctx;
        this.userManager = userManager;
    }

    public async Task SeedAsync()
    {
        await ctx.Database.EnsureCreatedAsync();

        if (await userManager.FindByNameAsync(AdminUserName) == null)
        {
            var result = await userManager.CreateAsync(new StoreUser { UserName = AdminUserName }, AdminPassword);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to create the default user!");
            }
        }

        if (!ctx.Teams.Any())
        {
            ctx.Teams.AddRange(
                new Team { Name = "Ferrari", YearOfFoundation = 1950, WonOfChampionship = 9, IsPaid = true },
                new Team { Name = "Mercedes-AMG", YearOfFoundation = 1954, WonOfChampionship = 3, IsPaid = true },
                new Team { Name = "McLaren", YearOfFoundation = 1966, WonOfChampionship = 3, IsPaid = false },
                new Team { Name = "Haas", YearOfFoundation = 2016, WonOfChampionship = 0, IsPaid = false },
                new Team { Name = "Renault DP", YearOfFoundation = 1977, WonOfChampionship = 2, IsPaid = true },
                new Team { Name = "Scuderia AlphaTauri", YearOfFoundation = 2020, WonOfChampionship = 0, IsPaid = true },
                new Team { Name = "Williams", YearOfFoundation = 1977, WonOfChampionship = 4, IsPaid = true });
            await ctx.SaveChangesAsync();
        }
    }
}
