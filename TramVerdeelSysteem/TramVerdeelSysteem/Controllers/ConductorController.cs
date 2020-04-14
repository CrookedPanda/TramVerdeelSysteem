using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TramVerdeelSysteem.Controllers
{
    public class ConductorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}