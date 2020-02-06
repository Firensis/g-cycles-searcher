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
        private class GMatrixCreator
        {
            private VisualGraph Graph { get; set; }
            private string[] Lines { get; set; }
            private int VerticesCount { get; set; }
            private bool Oriented { get; set; }

            private EdgesSetter Manager { get; set; }

            public VisualGraph Create(string file)
            {
                Lines = File.ReadAllLines(file);

                if (Lines.Length == 0)
                {
                    throw new WrongFileException("выбран пустой файл");
                }

                CreateBase();

                Manager = new EdgesSetter(Graph);

                for (int i = 0; i < VerticesCount; i++)
                {
                    ParseLine(i);
                }

                return Graph;
            }


            private void CreateBase()
            {
                VerticesCount = Lines.Length;
                string[] parts = Lines[0].Split(' ');
                Oriented = (parts.Length == VerticesCount);
                Graph = GraphFactory.Create(VerticesCount, Oriented);
            }

            private void ParseLine(int index)
            {
                string[] parts = Lines[index].Split(' ');
                if (Oriented && parts.Length != VerticesCount)
                {
                    throw new WrongFileException("для ориентированного графа количество значений в каждой строке должно быть равно количеству строк");
                }

                if (!Oriented && parts.Length != index + 1)
                {
                    throw new WrongFileException("для неориентированного графа количество значений в строке должно равняться номеру строки при условии, что нумерация строк начинается с 1");
                }

                int j = 0;
                foreach (string part in parts)
                {
                    if (!double.TryParse(part, out double weight))
                    {
                        throw new WrongFileException($"ожидалась строка, содержащая целое число или десятичную дробь с дробной частью, отделённой запятой; получено: {part}");
                    }

                    Manager.SetEdgeWeight(index, j, weight);
                    j++;
                }
            }
        }
    }
}
