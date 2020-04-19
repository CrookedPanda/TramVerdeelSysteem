using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramVerdeelSysteem.Models;
using Model.ViewModels;

namespace TramVerdeelSysteem.Controllers
{
    public class CleaningController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CleaningView model;
            //model = new CleaningView();
            //tijdelijke model inhoud
            model = new CleaningView("");

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CleaningView vieuwModel)
        {
            try
            {
                CleanTramView cleanTramView = new CleanTramView(vieuwModel);
                return CleanTrain(cleanTramView);
            }
            catch
            {
                // werkt nog niet door null references.
                return Index();
            }
        }

        [HttpGet]
        public IActionResult CleanTrain(CleanTramView Model)
        {
            return View(Model);
        }
    }
}