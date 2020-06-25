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
using Model.DTOs;

namespace TramVerdeelSysteem.Controllers
{
    public class MaintenanceController : Controller
    {
        Logic.Maintenance maintenanceLogic = new Logic.Maintenance();
        

        [HttpGet]
        public IActionResult Index()
        {
            MaintenanceMasterView Model = new MaintenanceMasterView();
            Model.maintenances = new List<MaintenanceView>();
            //ReparatieDienstViewModel Model = new ReparatieDienstViewModel();
            // GeoFeature geoFeature = new GeoFeature();
            
            try
            {
                Model.maintenances = maintenanceLogic.GetServiceList();
                Model.maintenance = new MaintenanceView();
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            

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
                TempData["Error"] = "Probeer het later opnieuw.";
                return View();
            }
        }

        public class GeoList
        {
            List<string> stringss = new List<string>();
            
            
        }

    }
}