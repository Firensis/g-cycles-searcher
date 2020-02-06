using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers
{
    static class CyclesManager
    {
        public static void NormalizeCycle(Path cycle)
        {
            int minI = FindIndexMin(cycle);
            List<int> newVertices = new List<int>();

            for (int i = minI; i < cycle.Vertices.Count; i++)
            {
                newVertices.Add(cycle.Vertices[i]);
            }

            for (int i = 0; i < minI; i++)
            {
                newVertices.Add(cycle.Vertices[i]);
            }

            cycle.Vertices = newVertices;
        }


        private static int FindIndexMin(Path cycle)
        {
            int i = 0;
            int minI = 0;
            int min = -1;
            foreach (int vertNum in cycle.Vertices)
            {
                if (
                    vertNum < min ||
                    i == 0
                )
                {
                    min = vertNum;
                    minI = i;
                }
                i++;
            }

            return minI;
        }


        public static bool IsEqualCycles(Path first, Path second, bool oriented = false)
        {
            if (first.Weight != second.Weight)
            {
                return false;
            }

            return IsEqualCycles(first.Vertices, second.Vertices, oriented);
        }
        public static bool IsEqualCycles(List<int> first, List<int> second, bool oriented = false)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            int diffIndex = GetFirstDiffIndex(first, second);

            if (diffIndex == -1)
            {
                return true;
            }

            //Если по крайней мере первые вершины путей одинаковы и граф не ориентированный, 
            //то идёт проверка на равенство циклов типа 0-1-2 и 0-2-1(палиндромов, если исключить первую вершину): при неориентированном графе они считаются одинаковыми
            if (diffIndex != 0 && !oriented)
            {
                return IsPalindromes(first, second);
            }
            else
            {
                return false;
            }
        }


        private static int GetFirstDiffIndex(List<int> first, List<int> second)
        {
            List<int>.Enumerator firstEnum = first.GetEnumerator();
            List<int>.Enumerator secondEnum = second.GetEnumerator();

            int diffIndex = -1;

            for (int i = 0; i < first.Count; i++)
            {
                firstEnum.MoveNext();
                secondEnum.MoveNext();
                if (firstEnum.Current != secondEnum.Current)
                {
                    diffIndex = i;
                    break;
                }
            }

            return diffIndex;
        }


        private static bool IsPalindromes(List<int> first, List<int> second)
        {
            List<int> path1 = new List<int>(first);
            List<int> path2 = new List<int>(second);
            path1.RemoveAt(0);
            path2.RemoveAt(0);
            path2.Reverse();

            return IsEqualCycles(path1, path2, true);
        }


        public static string ConvertToString(Path cycle, bool oriented = false)
        {
            string result = "";

            List<int>.Enumerator enumerator = cycle.Vertices.GetEnumerator();

            enumerator.MoveNext();

            result += enumerator.Current.ToString();

            string separator = oriented ? "->" : "=";
            for (int i = 1; i < cycle.Vertices.Count; i++)
            {
                enumerator.MoveNext();
                result += separator + enumerator.Current.ToString();
            }

            if (cycle.Weight > 0)
            {
                result += $" [{cycle.Weight}]";
            }

            return result;
        }


        public static bool IsCycleInList(List<Path> cycles, Path cycle, bool oriented)
        {
            bool exist = false;
            foreach (Path existCycle in cycles)
            {
                if (IsEqualCycles(cycle, existCycle, oriented))
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }
    }
}
