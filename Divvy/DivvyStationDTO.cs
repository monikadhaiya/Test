using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Divvy
{
    public class DivvyStationDTO
    {
        public int id { get; set; }

        public string stationName { get; set; }

        public int availableDocks { get; set; }

        public int totalDocks { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        public string statusValue { get; set; }

        public int availableBikes { get; set; }
    }
}
