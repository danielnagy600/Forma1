using Forma1WebApp.Data.Entities;
using System.Collections.Generic;

namespace Forma1WebApp.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeam();
        void AddTeam(Team team);
        bool SaveAll();
        int GetMaxId();
        void Update(Team team);
        Team GetElementById(int Id);
        void DeleteTeam(Team team);
    }
}