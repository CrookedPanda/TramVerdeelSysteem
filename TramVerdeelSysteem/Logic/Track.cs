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
        public int TrackNumber { get; set; }
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

        public void ChangeLine(int pLine)
        {
            Line = pLine;
            // roep data aan om de verandering door te voeren in de database.
        }

        public void AddSector(Sector pSector)
        {
            sectors.Add(pSector);
        }

        public void ChangeSectorStatus(Sector.Status pStatus, string pRemeseName, int pPosition)
        {
            try
            {
                sectors.Where(i => i.position == pPosition).FirstOrDefault().ChangeSectorStatus(pStatus, TrackNumber, pRemeseName);
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
