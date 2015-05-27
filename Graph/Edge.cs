using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge<TVertex> : IEdge<TVertex>
    {
        TVertex src;
        TVertex des;
        int cost;

        public Edge(TVertex src, TVertex des, int cost)
        {
            this.src = src;
            this.des = des;
            this.cost = cost;
        }

        public Edge(TVertex src, TVertex des)
        {
            this.src = src;
            this.des = des;
        }
 
        public TVertex Source
        {
            get
            {
                return src;
            }
            private set
            {
                src = value;
            }
        }

        public TVertex Destination
        {
            get
            {
                return des;
            }
            private set
            {
                des = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
    }
}
