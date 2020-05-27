using System;
using System.Collections.Generic;
using System.Text;
using Model.DTOs;

namespace Data.Interfaces
{
    public interface IDatabaseTrack
    {
        public void changeTrackLine(TrackLineDTO trackLineDTO);
    }
}
