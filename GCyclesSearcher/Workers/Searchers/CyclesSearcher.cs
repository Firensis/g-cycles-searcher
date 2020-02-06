using GCyclesSearcher.Models;
using GCyclesSearcher.Workers.Factory;
using GCyclesSearcher.Workers.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Searchers
{
    abstract class CyclesSearcher : SearchCore
    {
        protected VertexState[] VerticesStates { get; set; }
        protected Stack<int> PrevVertices { get; set; }


        public CyclesSearcher(VisualGraph graph, bool saveSteps) : base(graph, saveSteps)
        {
        }
        

        public List<Path> GetCycles()
        {
            InitSearch();
            LoadCycles();
            return Cycles;
        }

        abstract protected void LoadCycles();


        protected virtual void InitSearch()
        {
            if (SaveSteps)
            {
                Steps = new LinkedList<Step>();
                UnselectVertices();
            }

            Cycles = new List<Path>();
            PrevVertices = new Stack<int>();

            VerticesStates = new VertexState[VerticesCount];

            for (int i = 0; i < VerticesCount; i++)
            {
                VerticesStates[i] = VertexState.notVisited;
            }
        }

        protected void AddCycle(Path cycle)
        {
            Cycles.Add(cycle);
        }

        protected bool IsCycleExist(Path cycle)
        {
            return  CyclesManager.IsCycleInList(Cycles, cycle, Oriented);
        }

        public LinkedList<Step> GetSteps()
        {
            return Steps;
        }

        
        protected virtual Path GetPathBack(int pathStart, bool stopOnStart=false)
        {
            Path pathBack = new Path();


            if (stopOnStart)
            {
                pathBack.Vertices = new List<int>();
                Stack<int>.Enumerator stackEnumer = PrevVertices.GetEnumerator();

                while (stackEnumer.MoveNext())
                {
                    int cur = stackEnumer.Current;
                    pathBack.Vertices.Add(cur);

                    if (cur == pathStart)
                    {
                        break;
                    }
                }
            }
            else
            {
                pathBack.Vertices = new List<int>(PrevVertices);
            }

            int pathEnd = pathBack.Vertices.First();

            pathBack.Vertices.Reverse();
            
            
            List<int>.Enumerator enumer = pathBack.Vertices.GetEnumerator();

            enumer.MoveNext();
            int prev = enumer.Current;

            while (enumer.MoveNext())
            {
                pathBack.Weight += GetWeight(prev, enumer.Current);
                prev = enumer.Current;
            }

            pathBack.Weight += GetWeight(pathEnd, pathStart);
            
            return pathBack;
        }


        protected void UnselectVertices()
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                VisualManager.SetVertexColor(i, Settings.DEFAULT_VERTEX_COLOR);
            }
        }


        protected void GoPath(Path path)
        {
            List<int>.Enumerator enumer = path.Vertices.GetEnumerator();
            enumer.MoveNext();

            int previous = enumer.Current;

            string descr = previous.ToString();

            while (enumer.MoveNext())
            {
                int current = enumer.Current;
                descr += $"->{current}";
                VisualManager.SetEdgeColor(previous, current, Settings.ACTIVE_EDGE_COLOR);
                VisualManager.SetVertexColor(previous, Settings.VERTEX_FROM_COLOR);
                VisualManager.SetVertexColor(current, Settings.VERTEX_TO_COLOR);
                AddCurrentStep(descr);

                previous = current;
            }
        }

        protected virtual void AddFoundCycleStep(List<int> toSelect, string description, string color)
        {
            VisualManager.SelectPath(toSelect, color);
            AddCurrentStep(description);
            VisualManager.UnselectPath(toSelect);
        }

        protected void AddHeadToCycles()
        {
            foreach (Path cycle in Cycles)
            {
                cycle.Vertices.Add(cycle.Vertices.First());
            }
        }
    }
}
