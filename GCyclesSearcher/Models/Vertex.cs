using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Models
{
    enum Shape
    {
        circle = 0,
        box,
        plaintext
    }

    class Vertex
    {
        public string FillColor { get; set; } = "#ffffff";
        public Shape Shape { get; set; } = Shape.circle;
    }
}
