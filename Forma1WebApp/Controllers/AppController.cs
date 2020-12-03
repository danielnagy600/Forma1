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
        private readonly ITeamRepository repository;

        public AppController(ITeamRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var result = repository.GetAllTeam();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
