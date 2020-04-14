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
        [HttpGet]
        public IActionResult Index()
        {
            ReparatieDienstViewModel Model = new ReparatieDienstViewModel();

            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(CleaningView vieuwModel)
        {
            try
            {
                //Post het model met de index die gecleand moet worden
                return Index();
            }
            catch
            {
                return Index();
            }
        }
    }
}