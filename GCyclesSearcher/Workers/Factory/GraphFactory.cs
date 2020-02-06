using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Factory
{
    static partial class GraphFactory
    {
        public static VisualGraph Create(int verticesCount, bool oriented=false)
        {
            VisualGraph result = new VisualGraph
            {
                Oriented = oriented,
                VerticesCount = verticesCount,
            };
            InitVerticesOf(result);
            InitEdgesOf(result);
            
            return result;
        }
        private static void InitVerticesOf(VisualGraph graph)
        {
            graph.Vertices = new Vertex[graph.VerticesCount];
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                graph.Vertices[i] = new Vertex();
            }
        }
        private static void InitEdgesOf(VisualGraph graph)
        {
            graph.Edges = new Edge[graph.VerticesCount, graph.VerticesCount];

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                for (int j = 0; j < graph.VerticesCount; j++)
                {
                    graph.Edges[i, j] = new Edge();
                }
            }

            
        }

        public static VisualGraph CreateFromFile(string filename)
        {
            string ext = filename.Split('.').Last();

            VisualGraph result;

            switch (ext)
            {
                case "gmatrix":
                    result = new GMatrixCreator().Create(filename);
                    break;
                case "gedges":
                    result = new GEdgesCreator().Create(filename);
                    break;
                default:
                    throw new WrongFileException("Недопустимое расширение файла!(необходимо gedges или gmatrix)");
            }

            return result;
        }

        public static VisualGraph Clone(VisualGraph graph)
        {
            return new VisualGraph
            {
                Edges = CloneEdges(graph.Edges),
                Vertices = CloneVertices(graph.Vertices),
                Oriented = graph.Oriented,
                VerticesCount = graph.VerticesCount
            };
        }

        private static Edge[,] CloneEdges(Edge[,] source)
        {
            int count = source.GetLength(0);

            Edge[,] copy = new Edge[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    copy[i, j] = new Edge
                    {
                        Weight = source[i, j].Weight
                    };
                }
            }

            return copy;
        }
        

        private static Vertex[] CloneVertices(Vertex[] source)
        {
            int count = source.Length;
            Vertex[] copy = new Vertex[count];

            for (int i = 0; i < count; i++)
            {
                copy[i] = new Vertex
                {
                    FillColor = source[i].FillColor,
                    Shape = source[i].Shape
                };
            }

            return copy;
        }
    }
}
