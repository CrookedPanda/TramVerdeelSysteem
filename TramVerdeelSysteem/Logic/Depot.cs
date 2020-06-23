using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
using Data.Interfaces;

namespace Logic
{
    public class Depot
    {
        IDatabaseDepot iDepot;

        private IDatabaseMaintenance iMaintenance;

        public Depot()
        {
            this.iDepot = new Data.Depot();
            this.iMaintenance = new Data.Maintenance();
        }
        public Depot(IDatabaseDepot iDatabaseDepot)
        {
            this.iDepot = iDatabaseDepot;
        }

        public Model.ViewModels.DepotView GetDepotView(string depotName)
        {
            Model.ViewModels.DepotView depotView = new Model.ViewModels.DepotView(this.iDepot.GetDepot(depotName));
            return depotView;
        }

        public bool AddTrain(int tramNumber)
        {
            //is there need for maintenance? go to free maintenance sector
            //is there a specific track assigned to the tram?
            //is there a free non specific track?

            var maintenanceList = this.iMaintenance.GetServiceList();
            foreach (var maintenance in maintenanceList)
            {
                if (maintenance.TramNumber == tramNumber)
                {
                    AddTrainToTrack(tramNumber,  new List<int>{74,75});
                }
            }


            return false;
        }

        public bool AddTrainToTrack(int tramNumber, List<int> trackNumber)
        {
            return true;
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
