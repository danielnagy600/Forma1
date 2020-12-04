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

        public void AddTeam(Team team)
        {
            _ctx.Database.EnsureCreated();
            _ctx.Teams.Add(team);
        }

        public int GetMaxId()
        {
            _ctx.Database.EnsureCreated();
            //TODO: Ha üres a lista elhasal
            return _ctx.Teams.Max(x => x.Id);
        }

        public Team GetElementById(int Id)
        {
            _ctx.Database.EnsureCreated();
            return _ctx.Teams.FirstOrDefault(x => x.Id == Id);
        }

        public void DeleteTeam(Team team)
        {
            _ctx.Database.EnsureCreated();
            _ctx.Teams.Remove(team);
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
