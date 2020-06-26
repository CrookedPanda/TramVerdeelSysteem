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

        public List<int> GetTramList(int limit)
        {
            return this.iTram.GetTramList(limit);
        }

        public SectorDTO AddTrain(int tramNumber)
        {
            bool isTramInList = false;
            var trams = this.GetTramList(300);
            foreach (var tram in trams)
            {
                if (tram == tramNumber)
                {
                    isTramInList = true;
                    break;
                }
            }
            if (!isTramInList)
            {
                return null;
            }
            iSector.ClearSectorWithTramNumber(tramNumber);
            //is there need for maintenance? go to free maintenance sector
            //is there a specific track assigned to the tram?
            //is there a free non specific track?

            var maintenanceList = this.iMaintenance.GetMaintenanceList();
            foreach (var maintenance in maintenanceList)
            {
                if (maintenance.TramNumber == tramNumber)
                {
                    var sector = AddTrainToTrack(tramNumber, new List<int> { 74, 75 });
                    if (sector != null)
                    {
                        return sector;
                    }

                }
            }

            var line = this.iTram.GetTramWithNumber(tramNumber);
            var specificTracks = this.iTrack.GetTrackWithLine(line);
            if (specificTracks.Count != 0)
            {
                var sector = AddTrainToTrack(tramNumber, specificTracks);
                if (sector != null)
                {
                    return sector;
                }
            }

            var nonSpecificTracks = this.iTrack.GetTrackWithLine(0);
            if (nonSpecificTracks.Count != 0)
            {
                var sector = AddTrainToTrack(tramNumber, nonSpecificTracks);
                if (sector != null)
                {
                    return sector;
                }
            }

            var otherSpecificTracks = this.iTrack.GetOtherTracks(line);
            if (otherSpecificTracks.Count != 0)
            {
                var sector = AddTrainToTrack(tramNumber, otherSpecificTracks);
                if (sector != null)
                {
                    return sector;
                }
            }

            var entryTracks = this.iTrack.GetTrackWithLine(100);
            if (entryTracks.Count != 0)
            {
                var sector = AddTrainToTrack(tramNumber, entryTracks);
                if (sector != null)
                {
                    return sector;
                }
            }

            var exitracks = this.iTrack.GetTrackWithLine(200);
            if (exitracks.Count != 0)
            {
                var sector = AddTrainToTrack(tramNumber, exitracks);
                if (sector != null)
                {
                    return sector;
                }
            }

            return null;
        }

        public SectorDTO AddTrainToTrack(int tramNumber, List<int> trackNumbers)
        {
            bool isFree = false;
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
                    if (this.AddTrainToSector(sectors[i]) != null)
                    {
                        return sectors[i];
                    }
                }
                else if (sectors[i].TramId == 0 && sectors[i].SectorStatus == 1)
                {
                    if (sectors[i].TrackNumber == 32 || sectors[i].TrackNumber == 34 || sectors[i].TrackNumber == 36 || sectors[i].TrackNumber == 38)
                    {
                        if (!this.iSector.IsSectorFree(sectors[i].TrackNumber - 1))
                        {
                            sectors[i].TramId = tramNumber;
                            sectors[i].DepotName = "Remise Havenstraat";
                            if (this.AddTrainToSector(sectors[i]) != null)
                            {
                                return sectors[i];
                            }
                        }
                    }
                }
            }
            return null;
        }

        public SectorDTO AddTrainToSector(SectorDTO sector)
        {
            
            if (this.iSector.AddTrain(sector))
            {
                return sector;
            }

            return null;
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
