using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramVerdeelSysteem.Models;
using Model.ViewModels;


namespace TramVerdeelSysteem.Controllers
{
    public class TechnischeDienstController : Controller
    {
        public IActionResult Index()
        {
            ReparatieDienstViewModel Model = new ReparatieDienstViewModel();

            return View(Model);
        }
    }
}