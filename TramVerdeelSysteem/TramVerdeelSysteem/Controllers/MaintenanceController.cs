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
using Microsoft.VisualBasic;

namespace TramVerdeelSysteem.Controllers
{
    public class MaintenanceController : Controller
    {
        Logic.Maintenance maintenanceLogic = new Logic.Maintenance();

        [HttpGet]
        public IActionResult Index()
        {
            //ReparatieDienstViewModel Model = new ReparatieDienstViewModel();

            MaintenanceMasterView Model = new MaintenanceMasterView();

            Model.maintenances = maintenanceLogic.GetServiceList();
            Model.maintenance = new MaintenanceView();
            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(MaintenanceView Model)
        {
            try
            {
                string authKey = HttpContext.Request.Cookies["key"];
                Model.Key = authKey;
                maintenanceLogic.IndicateCompleteService(Model);
                return Index();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        List<string> stringss = new List<string>();
        public List<Tuple<int, float, float>> TrackCoordinates = new List<Tuple<int, float, float>>();
        

    }
}