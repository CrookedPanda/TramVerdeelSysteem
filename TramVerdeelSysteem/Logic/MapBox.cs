using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Model.DTOs;
using Newtonsoft.Json;

namespace Logic
{
    class MapBox
    {


        private string GeoJsonHelper(GeoFeatueDTO GeoFeatue)
        {
            string geoJson = JsonConvert.SerializeObject(GeoFeatue);
            return geoJson;

        }
    }
}
