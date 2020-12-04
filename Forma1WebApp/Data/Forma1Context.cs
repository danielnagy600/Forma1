using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data
{
    public class Forma1Context : IdentityDbContext<StoreUser>
    {
        public Forma1Context(DbContextOptions<Forma1Context> options)
            :base(options)
        {
           
        }
        protected Forma1Context() { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<StoreUser> StoreUsers { get; set; }
     
    }
}
