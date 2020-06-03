using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramVerdeelSysteem.Models;
using Model.ViewModels;
using Logic;
using System.Dynamic;

namespace TramVerdeelSysteem.Controllers
{
    public class CleaningHistoryController : Controller
    {
        Logic.Maintenance maintenanceLogic = new Logic.Maintenance();

        [HttpGet]
        public IActionResult Index()
        {
            //CleaningView model;
            //model = new CleaningView();
            //tijdelijke model inhoud

            // implemetn get cleaning list logic;
            //model = new CleaningView();
            //dynamic model = new ExpandoObject();

            CleaningHistoryMasterView Model = new CleaningHistoryMasterView();
            Model.cleanings = maintenanceLogic.GetCleaningHistory();
            Model.cleaning = new CleaningHistoryView();

            return View(Model);
        }
    }
}