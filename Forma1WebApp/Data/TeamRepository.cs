using Forma1WebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data
{
    public class TeamRepository : ITeamRepository
    {
        private readonly Forma1Context _ctx;

        public TeamRepository(Forma1Context ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Team> GetAllTeam()
        {
            _ctx.Database.EnsureCreated();
            return _ctx.Teams.ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges()>0;
        }
    }
}
