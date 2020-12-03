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
        public Forma1Context(DbContextOptions<Forma1Context> options):base(options)
        {
        }

        protected Forma1Context() { }

        public DbSet<Team> Teams { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Team>()
        //        .HasData(new Team()
        //        {
        //            Id = 1,
        //            Name = "Alfa",
        //            YearOfFoundation = 1993,
        //            WonOfChampionship = 2,
        //            IsPaid = true
        //        });
        //}
    }
}
