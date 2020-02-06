using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Models
{
    class VisualGraph
    {
        public bool Oriented { get; set; }
        public int VerticesCount { get; set; }
        public Edge[,] Edges { get; set; }
        public Vertex[] Vertices { get; set; }
    }
}
