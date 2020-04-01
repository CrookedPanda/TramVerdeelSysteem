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
    public class SchoonmaakDienstController : Controller
    {
        public IActionResult Index()
        {
            SchoonmaakDienstVieuwModel model = new SchoonmaakDienstVieuwModel();

            return View(model);
        }
    }
}