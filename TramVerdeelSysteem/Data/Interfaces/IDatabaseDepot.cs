using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDatabaseDepot
    {
        public DepotDTO GetDepot(string depotName);
    }
}
