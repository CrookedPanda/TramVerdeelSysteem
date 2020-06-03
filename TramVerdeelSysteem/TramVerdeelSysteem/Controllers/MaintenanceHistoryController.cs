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
    public class MaintenanceHistoryController : Controller
    {
        Logic.Maintenance maintenanceLogic = new Logic.Maintenance();

        [HttpGet]
        public IActionResult Index()
        {
            MaintenanceHistoryMasterView Model = new MaintenanceHistoryMasterView();
            Model.maintenances = maintenanceLogic.GetServiceHistory();
            Model.maintenance = new MaintenanceHistoryView();

            return View(Model);
        }
    }
}
