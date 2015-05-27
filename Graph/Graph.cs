using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph<TVertex> : IGraph<TVertex, IEdge<TVertex>>
    {
        #region Private Members
        private IList<TVertex> nodes;
        private IList<IEdge<TVertex>> edges;

        private Dictionary<TVertex, IList<IEdge<TVertex>>> outgoingEdgeList;

        #endregion

        #region Public Members

        public Graph()
        {
            nodes = new List<TVertex>();
            edges = new List<IEdge<TVertex>>();
            outgoingEdgeList = new Dictionary<TVertex, IList<IEdge<TVertex>>>();
        }

        public Graph(IList<TVertex> vertexList)
        {
            nodes = vertexList;
        }

        public void AddVertex(TVertex vertex)
        {
            nodes.Add(vertex);
        }

        public void AddDirectedEdge(TVertex source, TVertex destination)
        {
            if (!nodes.Contains(source))
            {
                AddVertex(source);
            }

            if (!nodes.Contains(destination))
            {
                AddVertex(destination);
            }

            IEdge<TVertex> e = new Edge<TVertex>(source, destination, 0);
            if (outgoingEdgeList[source] == null)
            {
                outgoingEdgeList[source] = new List<IEdge<TVertex>>();
            }
            outgoingEdgeList[source] = e;
            edges.Add(e);
        }

        public void AddDirectedEdge(TVertex source, TVertex destination, int cost)
        {
            if (!nodes.Contains(source))
            {
                AddVertex(source);
            }

            if (!nodes.Contains(destination))
            {
                AddVertex(destination);
            }

            Edge<TVertex> e = new Edge<TVertex>(source, destination, cost);
            if (outgoingEdgeList[source] == null)
            {
                outgoingEdgeList[source] = new List<IEdge<TVertex>>();
            }
            outgoingEdgeList[source] = e;
            edges.Add(e);
        }

        public IList<TVertex> GetShortestPath(TVertex source, TVertex destination)
        {
            //Dictionary<TVertex, TVertex> preShort = new Dictionary<TVertex, TVertex>();
            //Dictionary<TVertex, int> NodeCost = new Dictionary<TVertex, int>();

            //NodeCost.Add(source, 0);

            //Queue<TVertex> unvisistedVertex = new Queue<TVertex>();

            //unvisistedVertex.Enqueue(source);

            //foreach(TVertex node in nodes)
            //{
            //    if(node != source)
            //    {
            //        unvisistedVertex.Enqueue(node);
            //    }

            //}

            //TVertex curr;
            //while (unvisistedVertex.Count >= 0)
            //{
            //    curr  = unvisistedVertex.Dequeue();





            //}


        }

        #endregion        
    }
}
