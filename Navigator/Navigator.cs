using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSharing;
using Divvy;
using Google.Maps;
using Google.Maps.DistanceMatrix;
using QuickGraph;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;

namespace ActiveCommute.Navigator
{
    public class Navigator
    {
        #region Private Members
        IBikeSharingSystem bikeSharingSystem;

        #endregion
        public Navigator(string city)
        {
            bikeSharingSystem = new DivvySystem();
        }

        /// <summary>
        /// Get all station list
        /// </summary>
        public IReadOnlyList<IBikeStation> StationList
        {
            get
            {
                return bikeSharingSystem.GetAllStationInformation;
            }
        }

        /// <summary>
        /// Get Nearest station to current location
        /// </summary>
        /// <param name="currLocation"></param>
        /// <returns></returns>
        public IReadOnlyList<IBikeStation> GetNearestStation(Ilocation currLocation)
        {
            return bikeSharingSystem.GiveFiveNearestStation(currLocation);
        }

        public IReadOnlyList<Ilocation> GetShortestPath(Ilocation source, Ilocation des)
        {
            AdjacencyGraph<Ilocation, SEdge<Ilocation>> graph = new AdjacencyGraph<Ilocation, SEdge<Ilocation>>();
            IEnumerable<Ilocation> stationList = StationList.Select(item => item.Location);

            double distance = 0;
 
            var weights = new Dictionary<SEdge<Ilocation>, double>();

            foreach (var originStation in stationList)
            {
                foreach (var desstation in stationList)
                {
                    if(originStation != desstation)
                    {
                        distance = originStation.GetDistanceTo(desstation);
                        if (distance < 10000)
                        {
                            var edge = new SEdge<Ilocation>(originStation, desstation);
                            graph.AddVerticesAndEdge(edge);
                            weights.Add(edge, (distance/1000) * 3); 
                        }
                    }
                }

                distance = originStation.GetDistanceTo(source);
                if(distance < 1500)
                {
                    var edge = new SEdge<Ilocation>(source, originStation);
                    graph.AddVerticesAndEdge(edge);
                            weights.Add(edge, (distance/1000) * 12);
                }

                distance = originStation.GetDistanceTo(des);
                if(distance < 1500)
                {
                    var edge = new SEdge<Ilocation>(originStation, des);
                    graph.AddVerticesAndEdge(edge);
                            weights.Add(edge, (distance/1000) * 12);
                }

            }

            var algo = new DijkstraShortestPathAlgorithm<Ilocation, SEdge<Ilocation>>(
                graph,
                e => weights[e]
                );
            var predecessors = new VertexPredecessorRecorderObserver<Ilocation, SEdge<Ilocation>>();
            using (predecessors.Attach(algo))
                algo.Compute(source);


            List<Ilocation> returnval = new List<Ilocation>();

            var cur = des;
            returnval.Add(des);
            while (cur != source)
            {
                cur = predecessors.VertexPredecessors[cur].Source;
                returnval.Add(cur);
            }

            returnval.Reverse();
            return     returnval.AsReadOnly();

        }
    }
}
