using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    interface IGraph<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
        /// <summary>
        /// Add a new Vertex to graph
        /// </summary>
        /// <param name="vertex"></param>
        void AddVertex(TVertex vertex);

        /// <summary>
        /// Create A new edge between source and destination vertex.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        void AddDirectedEdge(TVertex source, TVertex destination);

        /// <summary>
        /// Create A new edge between source and destination vertex.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        void AddDirectedEdge(TVertex source, TVertex destination, int cost);

        /// <summary>
        /// Find shortest path between source and deatination vertex.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        IList<TVertex> GetShortestPath(TVertex source, TVertex destination);
    }
}
