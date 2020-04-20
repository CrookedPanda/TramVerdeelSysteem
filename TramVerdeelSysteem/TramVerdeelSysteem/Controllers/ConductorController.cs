using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace TramVerdeelSysteem.Controllers
{
    public class ConductorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ConductorView Model = new ConductorView();

            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(ConductorView Model)
        {
            try
            {
                // implement hier de get location logic e plaats trijn in de Depot
                return View(Model);
            }
            catch
            {
                return Index();
            }
        }
    }
}