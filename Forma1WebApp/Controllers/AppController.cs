using System.Diagnostics;
using Forma1WebApp.Data;
using Forma1WebApp.Data.Entities;
using Forma1WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forma1WebApp.Controllers;

public class AppController : Controller
{
    private const string SaveErrorMessage = "A mentés nem sikerült, próbálja újra!";

    private readonly ITeamRepository repository;

    public AppController(ITeamRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        return View(GetTeamList());
    }

    [Authorize]
    public IActionResult EditableList()
    {
        return View(GetTeamList());
    }

    [Authorize]
    public IActionResult Create()
    {
        return View(new TeamViewModel());
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TeamViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var team = new Team();
        model.ApplyTo(team);

        try
        {
            repository.AddTeam(team);
            repository.SaveAll();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", SaveErrorMessage);
            return View(model);
        }

        return RedirectToAction(nameof(EditableList));
    }

    [Authorize]
    public IActionResult Edit(int id)
    {
        var team = repository.GetElementById(id);
        if (team == null)
        {
            return NotFound();
        }

        return View(TeamViewModel.FromEntity(team));
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute] int id, TeamViewModel model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var team = repository.GetElementById(id);
        if (team == null)
        {
            return NotFound();
        }

        model.ApplyTo(team);

        try
        {
            repository.Update(team);
            repository.SaveAll();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", SaveErrorMessage);
            return View(model);
        }

        return RedirectToAction(nameof(EditableList));
    }

    [Authorize]
    public IActionResult Delete(int id)
    {
        var team = repository.GetElementById(id);
        if (team == null)
        {
            return NotFound();
        }

        return View(TeamViewModel.FromEntity(team));
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed([FromRoute] int id)
    {
        var team = repository.GetElementById(id);
        if (team == null)
        {
            return NotFound();
        }

        try
        {
            repository.DeleteTeam(team);
            repository.SaveAll();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "A törlés nem sikerült, próbálja újra!");
            return View(TeamViewModel.FromEntity(team));
        }

        return RedirectToAction(nameof(EditableList));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<TeamViewModel> GetTeamList()
    {
        return repository.GetAllTeam().Select(TeamViewModel.FromEntity).ToList();
    }
}
