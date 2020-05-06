using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace Logic
{
    public class Track
    {
        public int Line { get; set; }
        private List<Sector> sectors;

        public Track(int cLine, List<Sector> cSectors)
        {
            Line = cLine;
            sectors = cSectors;
        }
        public Track(int cLine)
        {
            Line = cLine;
        }

        public void AddSector(Sector pSector)
        {
            sectors.Add(pSector);
        }

        public void ChangeSectorStatus(int position, Sector.Status status)
        {
            try
            {
                sectors.Where(i => i.position == position).FirstOrDefault().ChangeSectorStatus(status);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void ReserveSector(int position, Train train)
        {
            try
            {
                sectors.Where(i => i.position == position).FirstOrDefault().ReserveForTrain(train);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
