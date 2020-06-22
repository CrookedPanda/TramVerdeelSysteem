using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.ViewModels;

namespace TramVerdeelSysteem.Views.Depot
{
    public class DepotModelDumpView
    {
        public List<TrackPartition> trackPartitions { get; set; }
        public AddTrainView Train { get; set; }
    }
}
