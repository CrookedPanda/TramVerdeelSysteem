using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Model.DTOs
{
    public class ChangeSectorStatusDTO : EditSectorDTO
    {
        public int SectorStatus { get; set; }
    }
}
