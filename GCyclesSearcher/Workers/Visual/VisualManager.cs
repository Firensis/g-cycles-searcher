using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Visual
{
    partial class VisualManager
    {
        const string DEFAULT_EDGE_COLOR = "#000000";

        ToDOTConverter Converter { get; set; }

        VisualGraph Graph { get; set; }
        private int VerticesCount { get; set; }
        private bool Oriented { get; set; }

        public VisualManager(VisualGraph graph)
        {
            Graph = graph;
            VerticesCount = graph.VerticesCount;
            Oriented = graph.Oriented;
            Converter = new ToDOTConverter();
        }
        

        public void SelectPath(Path path, string color = "red")
        {
            SelectPath(path.Vertices, color);
        }

        public void SelectPath(List<int> vertices, string color="red")
        {
            int last = -1;
            foreach (int vertNum in vertices)
            {
                if (last != -1)
                {
                    SetEdgeColor(last, vertNum, color);
                }
                last = vertNum;
            }
        }

        public void UnselectPath(Path path)
        {
            SelectPath(path, DEFAULT_EDGE_COLOR);
        }
        public void UnselectPath(List<int> vertices)
        {
            SelectPath(vertices, DEFAULT_EDGE_COLOR);
        }



        public void SelectVerticesIn(List<int> path, string color="red")
        {
            foreach (int vertex in path)
            {
                SetVertexColor(vertex, color);
            }
        }
        


        public void SetEdgeColor(int from, int to, string color="red")
        {
            Graph.Edges[from, to].Color = color;
            if (!Graph.Oriented)
            {
                Graph.Edges[to, from].Color = color;
            }
        }
        public void UnsetEdgeColor(int from, int to)
        {
            SetEdgeColor(from, to, DEFAULT_EDGE_COLOR);
        }

        public void SetVertexColor(int vertex, string color)
        {
            Graph.Vertices[vertex].FillColor = color;
        }
        

        public string GetDOTString()
        {
            return Converter.GetDOTString(Graph);
        }

        public Image GetImage()
        {
            return DOTVisualizer.GetImageFromDOT(GetDOTString());
        }

        public Image GetImageWithSelected(Path path, string color)
        {
            SelectPath(path, color);
            Image result = GetImage();
            UnselectPath(path);
            return result;
        }

        public void SelectEdges(List<int> from, int to, string color)
        {
            foreach (int vertex in from)
            {
                SetEdgeColor(vertex, to, color);
            }
        }

        public void SelectEdges(int from, List<int> to, string color)
        {
            foreach (int vertex in to)
            {
                SetEdgeColor(from, vertex, color);
            }
        }

        public void SelectEnvironment(int vertex, string color)
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                if (Graph.Edges[i, vertex].Exist)
                {
                    SetEdgeColor(i, vertex, color);
                }
            }
        }

        public void UnselectEnvironment(int vertex)
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                if (Graph.Edges[i, vertex].Exist)
                {
                    UnsetEdgeColor(i, vertex);
                }

                if (Graph.Edges[vertex, i].Exist)
                {
                    UnsetEdgeColor(vertex, i);
                }
            }
        }
    }
}
