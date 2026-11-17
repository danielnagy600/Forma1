using Forma1WebApp.Data;
using Forma1WebApp.Data.Entities;
using Forma1WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forma1WebApp.Controllers;

[Authorize]
public class TeamsController : Controller
{
    private const string SaveErrorMessage = "Saving failed, please try again!";
    private const string DeleteErrorMessage = "Deleting failed, please try again!";

    private readonly ITeamRepository repository;

    public TeamsController(ITeamRepository repository)
    {
        this.repository = repository;
    }

    // GET: /Teams
    public async Task<IActionResult> Index()
    {
        var teams = await repository.GetAllAsync();
        return View(teams.Select(TeamViewModel.FromEntity).ToList());
    }

    // GET: /Teams/Create
    public IActionResult Create()
    {
        return View(new TeamViewModel());
    }

    // POST: /Teams/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TeamViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var team = new Team();
        model.ApplyTo(team);

        try
        {
            repository.Add(team);
            await repository.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, SaveErrorMessage);
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Teams/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var team = await repository.GetByIdAsync(id);
        if (team == null)
        {
            return NotFound();
        }

        return View(TeamViewModel.FromEntity(team));
    }

    // POST: /Teams/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, TeamViewModel model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var team = await repository.GetByIdAsync(id);
        if (team == null)
        {
            return NotFound();
        }

        // The loaded entity is tracked by EF, so copying the changed fields is enough.
        model.ApplyTo(team);

        try
        {
            await repository.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, SaveErrorMessage);
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Teams/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var team = await repository.GetByIdAsync(id);
        if (team == null)
        {
            return NotFound();
        }

        return View(TeamViewModel.FromEntity(team));
    }

    // POST: /Teams/Delete/5
    [HttpPost]
    [ActionName(nameof(Delete))]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
    {
        var team = await repository.GetByIdAsync(id);
        if (team == null)
        {
            return NotFound();
        }

        try
        {
            repository.Remove(team);
            await repository.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, DeleteErrorMessage);
            return View(TeamViewModel.FromEntity(team));
        }

        return RedirectToAction(nameof(Index));
    }
}
