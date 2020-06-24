using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDatabaseSector
    {
        public bool GetSector(SectorDTO sector);
        public bool IsSectorFree(SectorDTO sector);
        public bool SectorStatusChange(SectorStatusChangeDTO DTO);
        public bool ClearSectorWithTramNumber(SectorDTO sector);
        public bool ClearSector(SectorDTO DTO);
        //public bool ReserveSector(SectorDTO DTO);
        public bool AddTrain(SectorDTO DTO);
    }
}
