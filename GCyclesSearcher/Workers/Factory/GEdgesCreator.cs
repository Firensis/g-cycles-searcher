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
        private class GEdgesCreator
        {
            private VisualGraph Graph { get; set; }
            private string[] Lines { get; set; }
            private int VerticesCount { get; set; }
            private bool Oriented { get; set; }

            private EdgesSetter Manager { get; set; }

            private int curVertex;

            public VisualGraph Create(string file)
            {
                Lines = File.ReadAllLines(file);

                if (Lines.Length == 0)
                {
                    throw new WrongFileException("выбран пустой файл");
                }

                CreateBase();

                Manager = new EdgesSetter(Graph);

                curVertex = -1;
                for (int i = 1; i < Lines.Length; i++)
                {
                    ParseLine(i);
                }

                return Graph;
            }

            private void CreateBase()
            {
                string[] parts = Lines[0].Split(' ');

                if (int.TryParse(parts[0], out int count))
                {
                    if (count < 1)
                    {
                        throw new WrongFileException("количество вершин в графе не может быть меньше 1");
                    }
                }
                else
                {
                    throw new WrongFileException("формат первой строки файла .gedges: \"{количество вершин} oriented\", где oriented - необязательный флаг, указывающий на то, что граф яляется ориентированным");
                }

                VerticesCount = count;

                Oriented = parts.Length > 1 && parts[1] == "oriented";

                Graph = GraphFactory.Create(VerticesCount, Oriented);
            }


            private bool ParseLine(int index)
            {
                string line = Lines[index];
                if (line == null || line == "")
                {
                    return false;
                }
                string[] parts = line.Split(' ');

                if (curVertex == -1 && parts.Length > 1)
                {
                    throw new WrongFileException();
                }

                if (parts.Length == 1)
                {
                    SetNewCurVertex(parts[0]);
                }
                else if (parts.Length == 2)
                {
                    SetEdge(parts[0], parts[1]);
                }
                else
                {
                    throw new WrongFileException();
                }

                return true;
            }

            private void SetNewCurVertex(string newCur)
            {
                if (!int.TryParse(newCur, out curVertex))
                {
                    throw new WrongFileException($"ожидалась строка, содержащая целочисленный номер вершины; получено: {newCur}");
                }

                if (curVertex >= VerticesCount)
                {
                    throw new WrongFileException("индекс любой вершины должен быть меньше общего количества вершин! Нумерация вершин начинается с нуля");
                }
            }

            private void SetEdge(string connectedVertex, string edgeWeight)
            {
                if (!int.TryParse(connectedVertex, out int connected))
                {
                    throw new WrongFileException($"ожидалась строка, содержащая целочисленный номер вершины; получено: {connectedVertex}");
                }

                if (connected > VerticesCount)
                {
                    throw new WrongFileException("индекс любой вершины должен быть меньше общего количества вершин! Нумерация вершин начинается с нуля");
                }

                if (!double.TryParse(edgeWeight, out double weight))
                {
                    throw new WrongFileException($"ожидалась строка, содержащая вес(целое или десятичная дробь) ребра, соединяющего вершины {curVertex} и {connected}; получено: {edgeWeight}");
                }

                Manager.SetEdgeWeight(curVertex, connected, weight);
            }
        }

    }
}
