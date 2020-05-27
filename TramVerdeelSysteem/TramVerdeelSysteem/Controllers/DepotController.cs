using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;
using Logic;
using TramVerdeelSysteem.Views.Depot;

namespace TramVerdeelSysteem.Controllers
{
    public class DepotController : Controller
    {
        DepotModelDumpView depotDumpView = new DepotModelDumpView();
        Depot lDepot = new Depot();
        public IActionResult Index()
        {
            depotDumpView.trackPartitions = new List<TrackPartition>();
            DepotView depotView = lDepot.GetDepotView("Remise Havenstraat");
            for(int i = 1; i <= depotView.Tracks.Last().OrderNumber; i++)
            {
                TrackPartition trackPartition = new TrackPartition();
                IEnumerable<TrackDepotView> query = from track in depotView.Tracks where track.OrderNumber == i select new TrackDepotView(track);
                trackPartition.trackDepots = query.ToList();
                depotDumpView.trackPartitions.Add(trackPartition);
            }
            return View(depotDumpView);
        }

        /*public IActionResult AddPopUp()
        {
            return View();
        }*/
    }
}