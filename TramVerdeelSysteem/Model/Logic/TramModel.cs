using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Logic
{
    public class TramModel
    {
        public int Number { get; set; }
        public int Rails { get; set; }
        public int Sector { get; set; }
        public StatusModel Status { get; set; }
    }
}
