using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.DTOs;

namespace Data.Interfaces
{
    interface IDatabaseSector
    {
        bool SectorStatusChange(SectorStatusChangeDTO sectorStatusChange);
    }
}
