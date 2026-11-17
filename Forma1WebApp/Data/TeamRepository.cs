using Forma1WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forma1WebApp.Data;

public class TeamRepository : ITeamRepository
{
    private readonly Forma1Context _ctx;

    public TeamRepository(Forma1Context ctx)
    {
        _ctx = ctx;
    }

    public Task<List<Team>> GetAllAsync()
    {
        return _ctx.Teams
            .AsNoTracking()
            .OrderBy(t => t.Id)
            .ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _ctx.Teams.FindAsync(id);
    }

    public void Add(Team team)
    {
        _ctx.Teams.Add(team);
    }

    public void Remove(Team team)
    {
        _ctx.Teams.Remove(team);
    }

    public Task SaveChangesAsync()
    {
        return _ctx.SaveChangesAsync();
    }
}
