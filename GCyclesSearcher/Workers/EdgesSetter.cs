using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers
{
    class EdgesSetter
    {
        private VisualGraph Graph { get; set; }

        public EdgesSetter(VisualGraph graph)
        {
            Graph = graph;
        }

        public void SetEdgeWeight(int from, int to, double weight)
        {
            Graph.Edges[from, to].Weight = weight;

            if (!Graph.Oriented)
            {
                Graph.Edges[to, from].Weight = weight;
            }
        }

        public void SetEdgeColor(int from, int to, string color)
        {
            Graph.Edges[from, to].Color = color;

            if (!Graph.Oriented)
            {
                Graph.Edges[to, from].Color = color;
            }
        }   
        
        public void RemoveEdge(int from, int to)
        {
            SetEdgeWeight(from, to, 0);
        }
    }
}
