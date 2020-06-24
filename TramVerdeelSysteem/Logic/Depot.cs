using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
using Data.Interfaces;

namespace Logic
{
    using Model.DTOs;

    public class Depot
    {
        IDatabaseDepot iDepot;

        private IDatabaseMaintenance iMaintenance;

        private IDatabaseSector iSector;

        private Data.Track iTrack;

        private Data.Tram iTram;

        public Depot()
        {
            this.iDepot = new Data.Depot();
            this.iMaintenance = new Data.Maintenance();
            this.iTrack = new Data.Track();
            this.iSector = new Data.Sector();
            this.iTram = new Data.Tram();
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

                    if (AddTrainToTrack(tramNumber, new List<int> { 74, 75 }))
                    {
                        return true;
                    }

                }
            }

            var specificTracks = this.iTrack.GetTrackWithLine(this.iTram.GetTramWithNumber(tramNumber));
            if (specificTracks.Count != 0)
            {
                if (AddTrainToTrack(tramNumber, specificTracks))
                {
                    return true;
                }
            }

            var nonSpecificTracks = this.iTrack.GetTrackWithLine(0);
            if (nonSpecificTracks.Count != 0)
            {
                if (AddTrainToTrack(tramNumber, nonSpecificTracks))
                {
                    return true;
                }
            }

            return false;
        }

        public bool AddTrainToTrack(int tramNumber, List<int> trackNumbers)
        {

            List<SectorDTO> sectors = new List<SectorDTO>();
            foreach (var trackNumber in trackNumbers)
            {
                var trackSectors = this.iTrack.GetTrack(trackNumber);
                foreach (var sector in trackSectors)
                {
                    sectors.Add(sector);
                }
            }

            for (int i = 0; i < sectors.Count; i++)
            {
                if (sectors[i].TramId == 0 && sectors[i].SectorStatus == 0)
                {
                    sectors[i].TramId = tramNumber;
                    sectors[i].DepotName = "Remise Havenstraat";
                    if (this.AddTrainToSector(sectors[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddTrainToSector(SectorDTO sector)
        {
            return this.iSector.AddTrain(sector);
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
