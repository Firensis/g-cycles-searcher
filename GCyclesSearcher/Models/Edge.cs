using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Models
{
    class Edge
    {
        public double Weight { get; set; } = 0;
        public bool Exist
        {
            get
            {
                return Weight != 0;
            }
        }
        public string Color { get; set; } = Settings.DEFAULT_EDGE_COLOR;

    }
}
