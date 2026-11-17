using System.Diagnostics;
using Forma1WebApp.Data;
using Forma1WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forma1WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ITeamRepository repository;

    public HomeController(ITeamRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var teams = await repository.GetAllAsync();
        return View(teams.Select(TeamViewModel.FromEntity).ToList());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
