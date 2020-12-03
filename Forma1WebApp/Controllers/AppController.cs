using Forma1WebApp.Data;
using Forma1WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Controllers
{
    public class AppController : Controller
    {
        private readonly Forma1Context _context;

        public AppController(Forma1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Database.EnsureCreated();
            _context.Teams.Add(new Data.Entities.Team() { Id = 1, Name = "Ferrari", YearOfFoundation = 1950, WonOfChampionship = 9, IsPaid = true });
            _context.Teams.Add(new Data.Entities.Team() { Id = 2, Name = "Mercedes-AMG", YearOfFoundation = 1954, WonOfChampionship = 3, IsPaid = true });
            _context.Teams.Add(new Data.Entities.Team() { Id = 3, Name = "McLaren", YearOfFoundation = 1966, WonOfChampionship = 3, IsPaid = false });
            _context.Teams.Add(new Data.Entities.Team() { Id = 4, Name = "Haas", YearOfFoundation = 2016, WonOfChampionship = 0, IsPaid = false });
            _context.Teams.Add(new Data.Entities.Team() { Id = 5, Name = "Renault DP", YearOfFoundation = 1977, WonOfChampionship = 2, IsPaid = true });
            _context.Teams.Add(new Data.Entities.Team() { Id = 6, Name = "Scuderia AlphaTauri", YearOfFoundation = 2020, WonOfChampionship = 0, IsPaid = true });
            _context.Teams.Add(new Data.Entities.Team() { Id = 7, Name = "Williams ", YearOfFoundation = 1977, WonOfChampionship = 4, IsPaid = true });
            _context.SaveChanges();
            return View(_context.Teams.ToList());
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
