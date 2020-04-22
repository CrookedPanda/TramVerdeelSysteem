using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class ConductorDTO
    {
        public int TramNumber { get; set; }
        public bool Maintenance { get; set; }
        public bool Cleaning { get; set; }
        public Logic.TramModel Tram { get; set; }
    }
}
