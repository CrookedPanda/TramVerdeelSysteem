using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class MapBox
    {
        public GeoFeatueDTO GeoFeatureMaker()
        {
            var request = new Request()
            {
                Id = 1,
                Name = "MyRequest",
                Fence = new Fence()
                {
                    Type = 2,
                    Values = featureCollection
                }
            };
        }
    }
}
