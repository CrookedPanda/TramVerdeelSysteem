using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class DepotDTO
    {
        public List<TrackDepotDTO> Tracks { get; set; }
        public string Name { get; set; }
    }
}
