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
            return View(_context.Teams.ToList());
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
