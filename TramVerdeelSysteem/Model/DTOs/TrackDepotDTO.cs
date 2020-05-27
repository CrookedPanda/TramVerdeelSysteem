using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class TrackDepotDTO
    {
        public int TrackNumber { get; set; }
        public int Line { get; set; }
        public int OrderNumber { get; set; }
        public List<SectorDepotDTO> Sectors { get; set; }
    }
}
