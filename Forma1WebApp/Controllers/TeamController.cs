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
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
