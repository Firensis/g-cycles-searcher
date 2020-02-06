using GCyclesSearcher.Models;
using GCyclesSearcher.Workers.Searchers.EulerExistCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Searchers
{
    class EulerSearcher : CyclesSearcher
    {
        private int StartVertex {get;set;}
       
        private bool[,] EdgesActive { get; set; }
        private int ActiveEdgesCount { get; set; }
        private int EdgesCount { get; set; }

        public EulerSearcher(VisualGraph graph, bool saveSteps) : base(graph, saveSteps) {}

        protected override void LoadCycles()
        {
            ExistChecker checker = new ExistChecker(this);

            if (!checker.CheckEulerExist()) {
                return;
            }
            StartVertex = checker.VertexWithEdges;
            EdgesCount = checker.EdgesCount;

            DFC(-1, StartVertex);
            AddHeadToCycles();

            if (SaveSteps)
            {
                CloneCycles = false;
                AddCurrentStep($"Общее количество найденных циклов Эйлера: {Cycles.Count}. Все найденные циклы отображены в списке. Следующие шаги отобразят прохождение первого из них.");
                GoPath(Cycles.First());
            }
        }

        protected override void InitSearch()
        {
            base.InitSearch();
            EdgesActive = new bool[VerticesCount, VerticesCount];
            ActiveEdgesCount = 0;
        }

        private void DFC(int prevVertex, int vertex)
        {
            ActivateEdge(prevVertex, vertex);

            for (int i = 0; i < VerticesCount; i++)
            {
                CheckVertices(vertex, i);
            }

            DeactivateEdge(prevVertex, vertex);
        }

        private void CheckVertices(int from, int to)
        {
            if (
                !IsEdgeExist(from, to) ||
                EdgesActive[from, to]
            )
            {
                return;
            }

            if (to == StartVertex && ActiveEdgesCount == EdgesCount - 1)
            {
                AddEulerCycle(from);
            }
            else
            {
                DFC(from, to);
            }
        }

        private void ActivateEdge(int from, int to)
        {
            PrevVertices.Push(to);

            if (
                from == -1
                )
            {
                return;
            }

            EdgesActive[from, to] = true;
            if (!Oriented)
            {
                EdgesActive[to, from] = true;
            }

            ActiveEdgesCount++;

            if (SaveSteps)
            {
                AddActivateEdgeStep(from, to);
            }
        }

        private void AddActivateEdgeStep(int from, int to)
        {
            VisualManager.SetVertexColor(from, Settings.VERTEX_FROM_COLOR);
            VisualManager.SetVertexColor(to, Settings.VERTEX_TO_COLOR);
            VisualManager.SetEdgeColor(from, to, Settings.ACTIVE_EDGE_COLOR);

            AddCurrentStep($"Переходим из {from} в {to}. Отмечаем соответствующее ребро как активное.");
            VisualManager.SetVertexColor(from, Settings.DEFAULT_VERTEX_COLOR);
            VisualManager.SetVertexColor(to, Settings.DEFAULT_VERTEX_COLOR);
        }


        private void DeactivateEdge(int from, int to)
        {
            if (from != -1)
            {
                EdgesActive[from, to] = false;
                if (!Oriented)
                {
                    EdgesActive[to, from] = false;
                }

                ActiveEdgesCount--;
                PrevVertices.Pop();
            }

            if (SaveSteps)
            {
                AddDeactivateEdgeStep(from, to);
            }
        }

        private void AddDeactivateEdgeStep(int from, int to)
        {
            if (from == -1)
            {
                AddCurrentStep($"Выходим из {to}.");
            }
            else
            {
                VisualManager.SetVertexColor(from, Settings.ACTIVE_VERTEX_COLOR);
                VisualManager.SetEdgeColor(from, to, Settings.DEFAULT_EDGE_COLOR);
                AddCurrentStep($"Выходим из {to}, возвращаеся в {from}. Снимаем отметку активности с соответствующего ребра.");
                VisualManager.SetVertexColor(from, Settings.DEFAULT_VERTEX_COLOR);
            }
        }

        private void AddEulerCycle(int cycleEnd)
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
            VisualManager.SetEdgeColor(cycleEnd, StartVertex, Settings.ACTIVE_EDGE_COLOR);
            AddCurrentStep($"При переходе из {cycleEnd} в {StartVertex} найден цикл Эйлера. Он добавляется в список");
            VisualManager.UnsetEdgeColor(cycleEnd, StartVertex);
        }
        
    }
}
