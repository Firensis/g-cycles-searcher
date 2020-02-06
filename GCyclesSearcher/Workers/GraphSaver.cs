using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers
{
    static class GraphSaver
    {
        public static void SaveToFile(VisualGraph graph, string filename)
        {
            string ext = filename.Split('.').Last();
            

            switch (ext)
            {
                case "gmatrix":
                    SaveToGMatrix(graph, filename);
                    break;
                case "gedges":
                    SaveToGEdges(graph, filename);
                    break;
                default:
                    throw new WrongFileException("Поддерживается сохранение графа только в файлы форматов gedges и gmatrix");
            }
        }

        private static void SaveToGEdges(VisualGraph graph, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            string first = graph.VerticesCount.ToString();
            if (graph.Oriented)
            {
                first += " oriented";
            }

            writer.WriteLine(first);

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                bool written = false;
                for (int j = 0; j < (graph.Oriented ? graph.VerticesCount : i + 1); j++)
                {
                    Edge cur = graph.Edges[i, j];
                    if (cur.Exist)
                    {
                        if (!written)
                        {
                            writer.WriteLine(i);
                            written = true;
                        }
                        writer.WriteLine($"{j} {cur.Weight}");
                    }
                }
            }

            writer.Close();
        }

        private static void SaveToGMatrix(VisualGraph graph, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                List<double> weights = new List<double>();
                for (int j = 0; j < (graph.Oriented ? graph.VerticesCount : i + 1); j++)
                {
                    weights.Add(graph.Edges[i, j].Weight);
                }

                string line = Program.Join(weights, " ");
                writer.WriteLine(line);
            }

            writer.Close();
        }
    }
}
