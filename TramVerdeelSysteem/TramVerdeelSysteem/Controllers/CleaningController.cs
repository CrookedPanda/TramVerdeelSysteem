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
    using Microsoft.Extensions.WebEncoders.Testing;
    public class CleaningController : Controller
    {
        Logic.Maintenance maintenanceLogic = new Logic.Maintenance();

        [HttpGet]
        public IActionResult Index()
        {
            CleaningMasterView Model = new CleaningMasterView();
            Model.cleanings = new List<CleaningView>();
            //CleaningView model;
            //model = new CleaningView();
            //tijdelijke model inhoud

            // implemetn get cleaning list logic;
            //model = new CleaningView();
            //dynamic model = new ExpandoObject();
            try
            {
                Model.cleanings = maintenanceLogic.GetCleaningList();
                Model.cleaning = new CleaningView();
                GeoFeature geo = new GeoFeature();
                Model.geo = geo;
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            
            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(CleaningView Model)
        {
            try
            {
                string authKey = HttpContext.Request.Cookies["key"];
                Model.Key = authKey;
                maintenanceLogic.IndicateCompleteCleaning(Model);
                return Index();
            }
            catch(Exception e)
            {
                TempData["Error"] = "Probeer het later opnieuw.";
                return View();
            }
        }
    }
}