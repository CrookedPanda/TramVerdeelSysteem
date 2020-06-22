using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class AddTrainView
    {
        public int TramId { get; set; }
        public int TrackNumber { get; set; }
        public int SectorPosition { get; set; }
        public int SectorStatus { get; set; }
        public string DepotName { get; set; }

        public enum Status
        {
            Open,
            Blocked,
            Reserved,
            occupied
        }
    }
}
