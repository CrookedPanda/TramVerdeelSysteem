using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDatabaseSector
    {
        public bool GetSector(SectorDTO sector);
        public bool IsSectorFree(int trackNumber);
        public bool SectorStatusChange(SectorStatusChangeDTO DTO);
        public bool ClearSectorWithTramNumber(int tramNumber);
        public bool ClearSector(SectorDTO DTO);
        //public bool ReserveSector(SectorDTO DTO);
        public bool AddTrain(SectorDTO DTO);
    }
}
