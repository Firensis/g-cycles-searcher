using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher
{
    static class Settings
    {
        public const string DEFAULT_VERTEX_COLOR = "#FFFFFF";
        public const string ACTIVE_VERTEX_COLOR = "#0095B6";
        public const string VISITED_VERTEX_COLOR = "#9C9C9C";
        public const string VERTEX_FROM_COLOR = "#036b82";
        public const string VERTEX_TO_COLOR = "#0095B6";

        public const string NEW_CYCLE_COLOR = "#009900";
        public const string EXIST_CYCLE_COLOR = "#B00000";
        

        public const string DEFAULT_EDGE_COLOR = "#000000";
        public const string ACTIVE_EDGE_COLOR = "#0095B6";
        public const string INPUT_EDGE_COLOR = "#0095B6";
        public const string OUTPUT_EDGE_COLOR = "#009900";
        public const string LOOP_EDGE_COLOR = "#B00000";
        public const string REMOVED_EDGE_COLOR = "#cccccc";
    }
}
