using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Visual
{
    partial class VisualManager
    {
        class ToDOTConverter
        {
            private const string GRAPH_DOT_DIRECTION = "LR";
            private const string VERTEX_DOT_SHAPE = "circle";

            private const string ORIENTED_GRAPH_TYPE = "digraph";
            private const string ORIENTED_CONNECTION_SIGN = "->";

            private const string NOT_ORIENTED_GRAPH_TYPE = "graph";
            private const string NOT_ORIENTED_CONNECTION_SIGN = "--";


            private string CurDOTGraphType { get; set; }
            private string CurDOTConnectionSign { get; set; }

            private VisualGraph Graph { get; set; }
            private bool Oriented { get
                {
                    return Graph.Oriented;
                }
            }
            private int VerticesCount { get
                {
                    return Graph.VerticesCount;
                }
            }

            public string GetDOTString(VisualGraph graph)
            {
                Graph = graph;



                if (Oriented)
                {
                    CurDOTGraphType = ORIENTED_GRAPH_TYPE;
                    CurDOTConnectionSign = ORIENTED_CONNECTION_SIGN;
                }
                else
                {
                    CurDOTGraphType = NOT_ORIENTED_GRAPH_TYPE;
                    CurDOTConnectionSign = NOT_ORIENTED_CONNECTION_SIGN;
                }

                return $" {CurDOTGraphType} g {{rankdir=\"{GRAPH_DOT_DIRECTION}\" {GetVerticesInfoString()} { GetEdgesInfoString()} }}";
            }

            private string GetVerticesInfoString()
            { 
                string result = "";

                int i = 0;
                foreach (Vertex vertex in Graph.Vertices)
                {
                    result += $"{i} [shape=\"{vertex.Shape}\" fillcolor=\"{vertex.FillColor}\" style=\"filled\"];";
                    i++;
                }

                return result;
            }

            private string GetEdgesInfoString()
            {
                string result = "";
                for (int i = 0; i < VerticesCount; i++)
                {
                    for (int j = 0; j < (Oriented ? VerticesCount : i + 1); j++)
                    {
                        Edge cur = Graph.Edges[i, j];
                        if (cur.Exist)
                        {
                            result += $"{i} {CurDOTConnectionSign} {j} [label=\"{cur.Weight}\" color=\"{cur.Color}\"];";
                        }
                    }
                }

                return result;
            }
        }

    }
}
