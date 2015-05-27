using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeSharing
{
    /// <summary>
    /// Represent a bike station
    /// </summary>
    public interface IBikeStation
    {
        int EmptySlot { get; }

        Ilocation Location {get;}

        string ReadableName {get;}

        int TotalBikeSlot {get;}

        int PredictEmptySlot(DateTime dateTime);

        int BikeAvaiable { get; }

    }
}
