using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data.Entities
{
    public class TeamSeeder
    {
        private readonly Forma1Context ctx;
        private readonly UserManager<StoreUser> userManager;

        public TeamSeeder(Forma1Context ctx, UserManager<StoreUser> userManager)
        {
            this.ctx = ctx;
            this.userManager = userManager;
        }

        public async Task SeedAsynv()
        {
            ctx.Database.EnsureCreated();
            
            StoreUser user = new StoreUser() { UserName = "admin" };
              
            var result = await userManager.CreateAsync(user, "f1test2018");
            

            if (result !=IdentityResult.Success)
            {
                throw new InvalidOperationException("Az alapértelmezett felhasználó létrehozása nem sikerült!");
            }

            //Todo:Javítás, mert nem tároljuk le a kívánt jelszót a táblában
            //ctx.StoreUsers.Add(user);

            if (!ctx.Teams.Any())
            {

                List<Team> teams = new List<Team>()
                {
                    new Team() { Id = 1, Name = "Ferrari", YearOfFoundation = 1950, WonOfChampionship = 9, IsPaid = true },
                    new Team() { Id = 2, Name = "Mercedes-AMG", YearOfFoundation = 1954, WonOfChampionship = 3, IsPaid = true },
                    new Team() { Id = 3, Name = "McLaren", YearOfFoundation = 1966, WonOfChampionship = 3, IsPaid = false },
                    new Team() { Id = 4, Name = "Haas", YearOfFoundation = 2016, WonOfChampionship = 0, IsPaid = false },
                    new Team() { Id = 5, Name = "Renault DP", YearOfFoundation = 1977, WonOfChampionship = 2, IsPaid = true },
                    new Team() { Id = 6, Name = "Scuderia AlphaTauri", YearOfFoundation = 2020, WonOfChampionship = 0, IsPaid = true },
                    new Team() { Id = 7, Name = "Williams ", YearOfFoundation = 1977, WonOfChampionship = 4, IsPaid = true }
                };
                ctx.Teams.AddRange(teams);
                ctx.SaveChanges();
            }
        }
    }
}

