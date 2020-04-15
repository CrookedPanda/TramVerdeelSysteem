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
    }
}
