using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IGeoFeature
    {
        public GeoFeatueDTO getFeature(int tramNumber);

        public List<GeoFeatueDTO> GetAllFeatures(List<int> tramNumbers);

    }
}
