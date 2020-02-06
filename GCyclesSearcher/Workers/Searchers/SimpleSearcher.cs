using GCyclesSearcher.Models;
using GCyclesSearcher.Workers.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GCyclesSearcher.Workers.Searchers.CyclesSearcher;

namespace GCyclesSearcher.Workers.Searchers
{
    class SimpleSearcher : CyclesSearcher
    {

        public SimpleSearcher(VisualGraph graph, bool saveSteps) : base(graph, saveSteps) { }


        protected override void LoadCycles()
        {
            InitSearch();

            if (SaveSteps)
            {
                AddStartStep();
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                if (VerticesStates[i] == VertexState.notVisited)
                {
                    DFC(-1, i);
                }
            }

            AddHeadToCycles();


            if (SaveSteps)
            {
                LinkedList<Step> steps = Steps;
                steps.Last.Value.Description += $"\nПоиск циклов завершён. Найденое количество: {Cycles.Count}";
                UnselectVertices();
            }
        }



        private void DFC(int prevVertex, int curVertex)
        {
            VerticesStates[curVertex] = VertexState.active;
            PrevVertices.Push(curVertex);
            if (SaveSteps)
            {
                AddActivationStep(prevVertex, curVertex);
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                CheckConnectedVertex(prevVertex, curVertex, i);
            }


            VerticesStates[curVertex] = VertexState.visited;
            PrevVertices.Pop();
            if (SaveSteps)
            {
                AddLeavingStep(curVertex, prevVertex);
            }
        }



        private void CheckConnectedVertex(int prevVertex, int curVertex, int nextVertex)
        {
            if (
                    !IsEdgeExist(curVertex, nextVertex) ||
                    !Oriented && nextVertex == prevVertex
                )
            {
                return;
            }


            if (VerticesStates[nextVertex] == VertexState.active)
            {
                AddCycle(nextVertex, curVertex);
            }
            else
            {
                DFC(curVertex, nextVertex);
            }
        }


        private void AddCycle(int cycleStart, int cycleEnd)
        {
            Path cycle = GetPathBack(cycleStart, true);


            CyclesManager.NormalizeCycle(cycle);


            bool exist = IsCycleExist(cycle);

            if (!exist)
            {
                AddCycle(cycle);
            }

            if (SaveSteps)
            {
                List<int> toSelect = new List<int>(cycle.Vertices);
                toSelect.Add(toSelect.First());
                AddFoundCycleStep(cycleEnd, cycleStart, toSelect, exist);
            }
        }


        protected void AddStartStep()
        {
            AddCurrentStep("Начальное состояние. Ни одна из вершин не посещена.");
        }

        protected void AddLeavingStep(int verticeNum, int backTo)
        {
            VisualManager.SetVertexColor(verticeNum, Settings.VISITED_VERTEX_COLOR);


            string text = $"Выходим из {verticeNum}, помечаем как посещённую.";

            if (backTo == -1)
            {
                AddCurrentStep(text);
            }
            else
            {
                AddCurrentStep(text + $" Возвращаемся в {backTo}");
            }
        }

        protected void AddActivationStep(int prevVertex, int vertex)
        {
            VisualManager.SetVertexColor(vertex, Settings.ACTIVE_VERTEX_COLOR);
            if (prevVertex == -1)
            {
                AddCurrentStep($"Заходим в ранее не посещённую вершину {vertex}, помечаем её как активную.");
            }
            else
            {
                VisualManager.SetEdgeColor(prevVertex, vertex, Settings.ACTIVE_EDGE_COLOR);
                AddCurrentStep($"Переходим из {prevVertex} в {vertex}, помечаем {vertex} как активную.");
                VisualManager.UnsetEdgeColor(prevVertex, vertex);
            }
        }

        protected void AddFoundCycleStep(int curVertex, int connectedVertex, List<int> toSelect, bool cycleExist)
        {
            string color, description;

            description = $"При переходе из {curVertex} в {connectedVertex} найден цикл. ";

            if (cycleExist)
            {
                color = Settings.EXIST_CYCLE_COLOR;
                description += "Он не добавляется в список, так как аналогичный цикл уже записан.";
            }
            else
            {
                color = Settings.NEW_CYCLE_COLOR;
                description += "Это новый цикл, добавляем в список.";
            }

            AddFoundCycleStep(toSelect, description, color);
        }
    }
}
