using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class GeoFeatueDTO
    {     

        public class Feature
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }
        }

        public class Properties
        {
        }

        public class Geometry
        {
            public string type { get; set; }
            public float[][][] coordinates { get; set; }
        }
    }
}
