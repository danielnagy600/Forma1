using Forma1WebApp.Data.Entities;

namespace Forma1WebApp.Data;

public interface ITeamRepository
{
    IEnumerable<Team> GetAllTeam();
    void AddTeam(Team team);
    bool SaveAll();
    void Update(Team team);
    Team? GetElementById(int Id);
    void DeleteTeam(Team team);
}
