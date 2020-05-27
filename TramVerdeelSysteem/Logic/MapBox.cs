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
        public List<int> TrainNumbers;

        public MapBox(List<int> trainNumbers)
        {
            TrainNumbers = trainNumbers;
        }

        /*
        public List<string> ReturnFeatures()
        {
            foreach(int number in TrainNumbers)
            {

            }
        }
        */

        private string GeoJsonHelper(GeoFeatueDTO GeoFeatue)
        {
            string geoJson = JsonConvert.SerializeObject(GeoFeatue);
            return geoJson;

        }
    }
}
