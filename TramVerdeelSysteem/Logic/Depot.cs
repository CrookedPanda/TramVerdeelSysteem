using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
using Data.Interfaces;

namespace Logic
{
    class Depot
    {
        IDatabaseDepot iDepot;
        public Depot(IDatabaseDepot iDatabaseDepot)
        {
            this.iDepot = iDatabaseDepot;
        }

        public Model.ViewModels.DepotView GetDepotView(string depotName)
        {
            Model.ViewModels.DepotView depotView = new Model.ViewModels.DepotView(this.iDepot.GetDepot(depotName));
            return depotView;
        }

        public bool AddTrain()
        {
            return false;
        }

        public bool ClearSector(string depotName, int trackNumber,int position)
        {
            return false;
        }

        public bool ReserveSector(string depotName, int trackNumber, int position/*, tramView tram*/)
        {
            return false;
        }

        public bool ChangeSectorStatus(string depotName, int trackNumber, int position, Enum status)
        {
            return false;
        }
    }
}
