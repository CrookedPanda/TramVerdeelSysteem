using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDatabaseSector
    {
        public void ChangeSectorStatus(ChangeSectorStatusDTO DTO);
        public void ClearSector(EditSectorDTO DTO);
        public void ReserveSector(ReserveSectorDTO DTO);
    }
}
