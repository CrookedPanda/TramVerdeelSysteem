using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class ConductorView
    {
        public int TramNumber { get; set; }
        public int Maintenance { get; set; }
        public int Cleaning { get; set; }
        public Logic.TramModel Tram { get; set; }
        public string Key { get; set; }

        public ConductorView()
        {
            TramNumber = 0;
            Maintenance = 0;
            Cleaning = 0;
            Tram = new Logic.TramModel();
            Key = "" ;
        }
        public ConductorView(int cTramNummer)
        {
            TramNumber = cTramNummer;
            Maintenance = 0;
            Cleaning = 0;
            Tram = new Logic.TramModel();
            Key = "";
        }
    }
}
