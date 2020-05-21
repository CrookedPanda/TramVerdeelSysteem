using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class TrackDepotView
    {
        public TrackDepotView(DTOs.TrackDepotDTO track)
        {
            TrackNumber = track.TrackNumber;
            Line = track.Line;

            for(int i = 0; i < track.Sectors.Count; i++)
            {
                SectorDepotView sector = new SectorDepotView(track.Sectors[i]);
                Sectors.Add(sector);
            }
        }

        public int TrackNumber { get; set; }
        public int Line { get; set; }
        public int OrderNumber { get; set; }
        public List<SectorDepotView> Sectors { get; set; }
    }
}
