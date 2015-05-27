using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSharing;

namespace Divvy
{
    class DivvyStation : IBikeStation
    {
        public int EmptySlot
        {
            get;
            internal set;
        }

        public Ilocation Location
        {
            get;
            internal set;
        }

        public string ReadableName
        {
            get;
            internal set;
        }

        public int TotalBikeSlot
        {
            get;
            internal set;
        }

        public int PredictEmptySlot(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public int BikeAvaiable
        {
            get;
            internal set;
        }
    }
}
