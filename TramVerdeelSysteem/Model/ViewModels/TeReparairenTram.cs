using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class TeReparairenTram
    {
        public int TramNummer { get; set; }
        public int SpoorNummer { get; set; }
        public int SectorNummer { get; set; }


        public TeReparairenTram(int TramNummer, int SpoorNummer, int SectorNummer)
        {
            this.TramNummer = TramNummer;
            this.SpoorNummer = SpoorNummer;
            this.SectorNummer = SectorNummer;
        }
    }
}
