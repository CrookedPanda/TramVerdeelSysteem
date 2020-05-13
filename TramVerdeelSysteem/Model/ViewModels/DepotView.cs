using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class DepotView
    {
        public DepotView(DTOs.DepotDTO depot)
        {
            Name = depot.Name;

            for(int i = 0; i < depot.Tracks.Count; i++)
            {
                TrackDepotView track = new TrackDepotView(depot.Tracks[i]);
                Tracks.Add(track);
            }
        }

        public List<TrackDepotView> Tracks { get; set; }
        public string Name { get; set; }
    }
}
