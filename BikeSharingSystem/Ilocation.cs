using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Device.Location;

namespace BikeSharing
{
    public interface Ilocation
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        string Name { get; set; }

        double GetDistanceTo(Ilocation destination);
    }

    public class Loc : Ilocation
    {
        private double latitude;
        private double longitude;

        public Loc(double latitude, double longitude)
        {
            // TODO: Complete member initialization
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Loc()
        {
            // TODO: Complete member initialization
        }
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Find distance to a point
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public double GetDistanceTo(Ilocation destination)
        {
            GeoCoordinate source = new GeoCoordinate(Latitude, Longitude);
            return source.GetDistanceTo(new GeoCoordinate(destination.Latitude, destination.Longitude));
        }
    }
}
