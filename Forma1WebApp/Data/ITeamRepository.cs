using Forma1WebApp.Data.Entities;
using System.Collections.Generic;

namespace Forma1WebApp.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeam();
        bool SaveAll();
    }
}