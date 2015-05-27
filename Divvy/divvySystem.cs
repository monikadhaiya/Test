using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSharing;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Divvy
{
    /// <summary>
    /// chicago Bike Sharing system
    /// </summary>
    public class DivvySystem : IBikeSharingSystem
    {

        DateTime lastUpdate;

        IBikeStation[] stationInfo;
        /// <summary>
        /// Get all bike station information in Chicago.
        /// </summary>
        public IBikeStation[] GetAllStationInformation
        {
            get
            {
                lastUpdate = DateTime.Now;

                List<IBikeStation> bikeStationList = new List<IBikeStation>();
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(@"http://www.divvybikes.com/stations/json");

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DivvySystemDTO));

                    using (Stream s = GenerateStreamFromString(json))
                    {
                        DivvySystemDTO DivvyDTO = (DivvySystemDTO)jsonSerializer.ReadObject(s);

                        foreach (DivvyStationDTO station in DivvyDTO.stationBeanList)
                        {
                            bikeStationList.Add(new DivvyStation()
                            {
                                EmptySlot = station.availableDocks,
                                ReadableName = station.stationName,
                                TotalBikeSlot = station.totalDocks,
                                BikeAvaiable = station.availableBikes,
                                Location = new Loc() {Latitude = station.latitude, Longitude = station.longitude, Name = station.stationName}
                            });
                        }
                    }
                }

                stationInfo = bikeStationList.ToArray();
                return stationInfo;
            }
        }  

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }



        public DateTime executionTime
        {
            get { throw new NotImplementedException(); }
        }


        public IBikeStation[] GiveFiveNearestStation(Ilocation currentLoc)
        {
            if (DateTime.Now.Subtract(lastUpdate).Minutes > 15)
            {
                stationInfo = GetAllStationInformation;
            }

            return stationInfo.OrderBy(item => item.Location.GetDistanceTo(currentLoc)).Take(5).ToArray();
        }
    }
}
