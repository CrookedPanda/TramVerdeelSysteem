using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDatabaseSector
    {
        public bool SectorStatusChange(SectorStatusChangeDTO DTO);
        public bool ClearSector(SectorDTO DTO);
        //public bool ReserveSector(SectorDTO DTO);
        public bool AddTrain(SectorDTO DTO);
    }
}
