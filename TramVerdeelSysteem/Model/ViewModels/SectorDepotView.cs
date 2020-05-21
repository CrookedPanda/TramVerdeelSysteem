using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Model.ViewModels
{
    public class SectorDepotView
    {
        public SectorDepotView(DTOs.SectorDepotDTO sector)
        {
            idSectorStatus = sector.idSectorStatus;
            idTram = sector.idTram;
            Position = sector.Position;
        }

        public SectorDepotView(SectorDepotView sector)
        {
            idSectorStatus = sector.idSectorStatus;
            idTram = sector.idTram;
            Position = sector.Position;
        }

        public int idSectorStatus { get; set; }
        public int idTram { get; set; }
        public int Position { get; set; }
    }
}
