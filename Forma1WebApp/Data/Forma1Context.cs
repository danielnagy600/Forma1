using Forma1WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data
{
    public class Forma1Context : DbContext
    {
        public Forma1Context(DbContextOptions<Forma1Context> options):base(options){}
        protected Forma1Context() { }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = 1, Name = "Ferrari", YearOfFoundation = 1950, WonOfChampionship = 9, IsPaid = true },
                new Team() { Id = 2, Name = "Mercedes-AMG", YearOfFoundation = 1954, WonOfChampionship = 3, IsPaid = true },
                new Team() { Id = 3, Name = "McLaren", YearOfFoundation = 1966, WonOfChampionship = 3, IsPaid = false },
                new Team() { Id = 4, Name = "Haas", YearOfFoundation = 2016, WonOfChampionship = 0, IsPaid = false },
                new Team() { Id = 5, Name = "Renault DP", YearOfFoundation = 1977, WonOfChampionship = 2, IsPaid = true },
                new Team() { Id = 6, Name = "Scuderia AlphaTauri", YearOfFoundation = 2020, WonOfChampionship = 0, IsPaid = true },
                new Team() { Id = 7, Name = "Williams ", YearOfFoundation = 1977, WonOfChampionship = 4, IsPaid = true });
        }
    }
}
