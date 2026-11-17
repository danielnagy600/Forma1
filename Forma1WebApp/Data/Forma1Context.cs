using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forma1WebApp.Data;

public class Forma1Context : IdentityDbContext<StoreUser>
{
    public Forma1Context(DbContextOptions<Forma1Context> options)
        : base(options) { }

    // Users are managed by IdentityDbContext through the Users set.
    public DbSet<Team> Teams => Set<Team>();
}
