using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class SchoonTeMakenTram
    {
        public int TramNummer { get; set; }
        public int SpoorNummer { get; set; }
        public int SectorNummer { get; set; }

        public SchoonTeMakenTram()
        {

        }

        public SchoonTeMakenTram(int TramNummer, int SpoorNummer, int SectorNummer)
        {
            this.TramNummer = TramNummer;
            this.SpoorNummer = SpoorNummer;
            this.SectorNummer = SectorNummer;
        }
    }
}
