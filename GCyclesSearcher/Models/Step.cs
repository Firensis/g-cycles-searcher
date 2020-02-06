using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Models
{
    class Step
    {
        public string Description { get; set; } = "";
        public string DOT { get; set; }
        public List<Path> Cycles { get; set; } = new List<Path>();
    }
}
