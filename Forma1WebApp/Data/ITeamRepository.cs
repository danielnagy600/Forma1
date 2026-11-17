using Forma1WebApp.Data.Entities;

namespace Forma1WebApp.Data;

public interface ITeamRepository
{
    Task<List<Team>> GetAllAsync();
    Task<Team?> GetByIdAsync(int id);
    void Add(Team team);
    void Remove(Team team);
    Task SaveChangesAsync();
}
