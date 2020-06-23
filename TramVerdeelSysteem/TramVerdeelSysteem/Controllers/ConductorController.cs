using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace TramVerdeelSysteem.Controllers
{
    public class ConductorController : Controller
    {
        conductor conductorLogic = new conductor();

        Depot depotLogic = new Depot();

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
                if(Model.TramNumber != 0)
                {
                    conductorLogic.AddTramToCleaning(Model);
                    this.depotLogic.AddTrain(Model.TramNumber);
                }

                return Index();
            }
            catch
            {
                return Index();
            }
        }
    }
}