using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class SectorStatusChangeDTO
    {
        public string DepotName { get; set; }
        public int TrackNumber { get; set; }
        public int SectorPosition { get; set; }
        public int SectorStatus { get; set; }
    }
}
