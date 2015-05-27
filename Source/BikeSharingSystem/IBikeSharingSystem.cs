using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSharing;

namespace BikeSharing
{
    /// <summary>
    /// Bike sharing system
    /// </summary>
    public interface IBikeSharingSystem
    {
        IBikeStation[] GetAllStationInformation { get; }

        DateTime executionTime {get;}

        IBikeStation[] GiveFiveNearestStation(Ilocation currentLoc);
    }
}
