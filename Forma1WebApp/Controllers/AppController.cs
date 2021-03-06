﻿using Forma1WebApp.Data;
using Forma1WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Forma1WebApp.Data.Entities;

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

        [Authorize]
        public IActionResult EditableList()
        {
            var result = repository.GetAllTeam();
            return View(result);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team newTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                newTeam.Id = repository.GetMaxId()+1;
                repository.AddTeam(newTeam);
                repository.SaveAll();
                return RedirectToAction(nameof(EditableList));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var selectedTeam = repository.GetElementById(id);
            return View(selectedTeam);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team selectedTeam)
        {
            try
            {
                repository.Update(selectedTeam);
                repository.SaveAll();
                return RedirectToAction(nameof(EditableList));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var toBeDeleted = repository.GetElementById(id);
            return View(toBeDeleted);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Team team)
        {
            try
            {
                repository.DeleteTeam(team);
                repository.SaveAll();
                return RedirectToAction(nameof(EditableList));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
