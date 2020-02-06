using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Searchers.EulerExistCheckers
{
    class ExistChecker : SearchCore
    {
        private int[] PrevVertices { get; set; }
        private VertexState[] VerticesStates { get; set; }

        public int VertexWithEdges { get; private set; }
        public int EdgesCount { get; private set; }

        int VisitedEdges { get; set; }


        public ExistChecker(SearchCore parent) : base(parent) { } 


        public bool CheckEulerExist()
        {
            Prepare();

            VertexWithEdges = GetVertexWithEdges();

            if (VertexWithEdges == -1)
            {
                if (SaveSteps)
                {
                    AddCurrentStep("В данном графе отсутствуют рёбра. Таким образом, Эйлеров цикл также отсутствует.");
                }
                return false;
            }

            DFC(VertexWithEdges);


            EdgesCount = GetEdgesCount();

            if (EdgesCount != VisitedEdges)
            {
                if (SaveSteps)
                {
                    AddCurrentStep("В данном графе нет Эйлерова цикла, так как невозможно построить путь, проходящий через все его рёбра.");
                }
                return false;
            }

            if (!CheckDegrees())
            {
                return false;
            }


            return true;
        }

        private void Prepare()
        {
            VertexWithEdges = -1;
            PrevVertices = new int[VerticesCount];
            PrevVertices[0] = -1;
            VisitedEdges = 0;

            VerticesStates = new VertexState[VerticesCount];
            for (int i = 0; i < VerticesCount; i++)
            {
                VerticesStates[i] = VertexState.notVisited;
            }
        }

        private int GetEdgesCount()
        {
            int result = 0;
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < (Oriented ? VerticesCount : i + 1); j++)
                {
                    if (IsEdgeExist(i, j))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private int GetVertexWithEdges()
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                bool hasEdge = false;
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (IsEdgeExist(i, j))
                    {
                        hasEdge = true;
                        break;
                    }
                }

                if (hasEdge)
                {
                    return i;
                }
            }
            
            return -1;
        }

        /// <summary>
        /// Находит количество обойдённых рёбер
        /// </summary>
        /// <returns></returns>
        private void DFC(int vertex = 0)
        {
            VerticesStates[vertex] = VertexState.active;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (IsEdgeExist(vertex, i))
                {
                    CheckEdge(vertex, i);
                }
            }
            VerticesStates[vertex] = VertexState.visited;
        }



        private void CheckEdge(int from, int to)
        {
            if (from == to)
            {
                VisitedEdges++;
                return;
            }

            if (Oriented ||
                VerticesStates[to] != VertexState.visited &&
                PrevVertices[from] != to
            )
            {
                VisitedEdges++;
            }

            if (VerticesStates[to] == VertexState.notVisited)
            {
                PrevVertices[to] = from;
                DFC(to);
            }
        }

        private bool CheckDegrees()
        {
            DegreesChecker checker = new DegreesChecker(this);
            return checker.CheckDegrees();
        }
    }
}
