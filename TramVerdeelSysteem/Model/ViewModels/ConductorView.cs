using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class ConductorView
    {
        public int TramNumber { get; set; }
        public bool Maintenance { get; set; }
        public bool Cleaning { get; set; }
        public Logic.TramModel Tram { get; set; }
        public string Key { get; set; }

        public ConductorView()
        {
            TramNumber = 0;
            Maintenance = false;
            Cleaning = false;
            Tram = new Logic.TramModel();
            Key = "" ;
        }
        public ConductorView(int cTramNummer)
        {
            TramNumber = cTramNummer;
            Maintenance = false;
            Cleaning = false;
            Tram = new Logic.TramModel();
            Key = "";
        }
    }
}
