using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;
using Logic;

namespace TramVerdeelSysteem.Controllers
{
    public class DepotController : Controller
    {
        Depot lDepot = new Depot();
        public IActionResult Index()
        {
            DepotView depotView = lDepot.GetDepotView("Remise Havenstraat");
            return View(depotView);
        }

        /*public IActionResult AddPopUp()
        {
            return View();
        }*/
    }
}