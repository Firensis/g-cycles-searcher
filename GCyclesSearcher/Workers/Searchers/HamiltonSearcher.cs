using GCyclesSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Searchers
{
    class HamiltonSearcher : CyclesSearcher
    {
        private int StartVertex { get; set; }
        private int ActiveVerticesCount { get; set; }

        public HamiltonSearcher(VisualGraph graph, bool saveSteps) : base(graph, saveSteps) {}
        

        protected override void LoadCycles()
        {
            if (SaveSteps)
            {
                AddCurrentStep("Поиск циклов Гамильтона: начальное состояние.");
            }

            DFC(-1, StartVertex);

            AddHeadToCycles();

            if (SaveSteps)
            {
                CloneCycles = false;
                if (Cycles.Count == 0)
                {
                    AddCurrentStep("В данном графе отсутствуют циклы Гамильтона");
                }
                else
                {
                    AddCurrentStep($"Общее количество найденных циклов Гамильтона: {Cycles.Count}. Все найденные циклы отображены в списке. Следующие шаги отобразят прохождение первого из них.");
                    GoPath(Cycles.First());
                }
            }
        }


        protected override void InitSearch()
        {
            base.InitSearch();

            VerticesStates = new VertexState[VerticesCount];

            for (int i = 0; i < VerticesCount; i++)
            {
                VerticesStates[i] = VertexState.notVisited;
            }
            
            StartVertex = 0;
            ActiveVerticesCount = 0;
        }


        private void DFC(int prevVertex, int vertex)
        {
            ActivateVertex(prevVertex, vertex);

            for (int connected = 0; connected < VerticesCount; connected++)
            {
                CheckVertices(vertex, connected);
            }

            DeactivateVertex(prevVertex, vertex);
        }


        private void CheckVertices(int from, int to)
        {
            if (
                from == to ||
                !IsEdgeExist(from, to)
            )
            {
                return;
            }

            if (to == StartVertex && ActiveVerticesCount == VerticesCount)
            {
                AddHamiltonCycle(from);
            }
            else if (VerticesStates[to] != VertexState.active)
            {
                DFC(from, to);
            }
        }


        private void ActivateVertex(int prevVertex, int vertex)
        {
            ActiveVerticesCount++;
            VerticesStates[vertex] = VertexState.active;
            PrevVertices.Push(vertex);

            if (SaveSteps)
            {
                VisualManager.SetVertexColor(vertex, Settings.VERTEX_TO_COLOR);
                
                if (prevVertex == -1)
                {
                    AddCurrentStep($"Переходим к вершине {vertex}, помечаем её как активную");
                }
                else
                {
                    VisualManager.SetVertexColor(prevVertex, Settings.VERTEX_FROM_COLOR);
                    VisualManager.SetEdgeColor(prevVertex, vertex, Settings.ACTIVE_EDGE_COLOR);
                    AddCurrentStep($"Переходим из вершины {prevVertex} в {vertex}, помечаем {vertex} как активную.");
                    VisualManager.UnsetEdgeColor(prevVertex, vertex);
                }
            }
        }


        private void DeactivateVertex(int prevVertex, int vertex)
        {
            ActiveVerticesCount--;
            VerticesStates[vertex] = VertexState.visited;
            PrevVertices.Pop();

            if (SaveSteps)
            {
                AddDeactivateVertexStep(prevVertex, vertex);
            }
        }

        private void AddDeactivateVertexStep(int prevVertex, int vertex)
        {
            VisualManager.SetVertexColor(vertex, Settings.DEFAULT_VERTEX_COLOR);

            if (prevVertex == -1)
            {
                AddCurrentStep($"Выходим из {vertex}, снимаем с неё статус активной.");
            }
            else
            {
                VisualManager.SetVertexColor(prevVertex, Settings.ACTIVE_VERTEX_COLOR);
                AddCurrentStep($"Выходим из вершины {vertex} и снимаем с ней статус активной. Возвращаемся в {prevVertex}.");
            }
        }

        private void AddHamiltonCycle(int cycleEnd)
        {
            Path cycle = GetPathBack(StartVertex);
            

            AddCycle(cycle);

            if (SaveSteps)
            {
                List<int> toSelect = new List<int>(cycle.Vertices);
                toSelect.Add(toSelect.First());
                AddFoundCycleStep(cycleEnd, toSelect);
            }
        }

        private void AddFoundCycleStep(int cycleEnd, List<int> toSelect)
        {
            AddFoundCycleStep(toSelect, $"При переходе из {cycleEnd} в {StartVertex} найден Гамильтонов цикл. Добавляем его в список", Settings.NEW_CYCLE_COLOR);
        }
    }
}
