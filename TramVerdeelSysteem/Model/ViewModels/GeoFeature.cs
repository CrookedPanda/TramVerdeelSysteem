using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class GeoFeature
    {
        public List<Tuple<int, double, double>> TrackCoordinates;
        
        public GeoFeature()
        {
            this.TrackCoordinates = new List<Tuple<int, double, double>>();
            TrackCoordinates.Add(Tuple.Create(38, 52.349145, 4.853109));
            TrackCoordinates.Add(Tuple.Create(37, 52.349116, 4.853116));
            TrackCoordinates.Add(Tuple.Create(36, 52.349089, 4.853129));
            TrackCoordinates.Add(Tuple.Create(35, 52.349062, 4.853149));
            TrackCoordinates.Add(Tuple.Create(34, 52.349035, 4.853164));
            TrackCoordinates.Add(Tuple.Create(33, 52.349009, 4.853180));
            TrackCoordinates.Add(Tuple.Create(32, 52.348979, 4.853199));
            TrackCoordinates.Add(Tuple.Create(31, 52.348955, 4.853215));
            TrackCoordinates.Add(Tuple.Create(30, 52.348928, 4.853232));
            TrackCoordinates.Add(Tuple.Create(40, 52.347545, 4.851428));
            TrackCoordinates.Add(Tuple.Create(41, 52.347542, 4.851522));
            TrackCoordinates.Add(Tuple.Create(42, 52.347536, 4.851568));
            TrackCoordinates.Add(Tuple.Create(43, 52.347536, 4.851568));
            TrackCoordinates.Add(Tuple.Create(44, 52.347510, 4.851653));
            TrackCoordinates.Add(Tuple.Create(45, 52.347500, 4.851695));
            TrackCoordinates.Add(Tuple.Create(57, 52.347564, 4.851876));
            TrackCoordinates.Add(Tuple.Create(56, 52.347550, 4.851914));
            TrackCoordinates.Add(Tuple.Create(55, 52.347540, 4.851962));
            TrackCoordinates.Add(Tuple.Create(54, 52.347529, 4.852005));
            TrackCoordinates.Add(Tuple.Create(53, 52.347521, 4.852052));
            TrackCoordinates.Add(Tuple.Create(52, 52.347513, 4.852146));
            TrackCoordinates.Add(Tuple.Create(51, 52.347500, 4.852191));
            TrackCoordinates.Add(Tuple.Create(64, 52.347573, 4.852283));
            TrackCoordinates.Add(Tuple.Create(63, 52.347500, 4.852447));
            TrackCoordinates.Add(Tuple.Create(62, 52.347559, 4.853041));
            TrackCoordinates.Add(Tuple.Create(61, 52.347431, 4.853193));
            TrackCoordinates.Add(Tuple.Create(77, 52.348836, 4.853122));
            TrackCoordinates.Add(Tuple.Create(76, 52.348807, 4.853132));
            TrackCoordinates.Add(Tuple.Create(75, 52.348760, 4.853153));
            TrackCoordinates.Add(Tuple.Create(74, 52.348724, 4.853163));
            TrackCoordinates.Add(Tuple.Create(50, 52.347327, 4.852292));


        }
     
    }
}
