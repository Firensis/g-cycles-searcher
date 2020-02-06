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
    abstract class SearchCore
    {
        private VisualGraph Graph { get; set; }
        protected int VerticesCount
        {
            get
            {
                return Graph.VerticesCount;
            }
        }
        protected bool Oriented
        {
            get
            {
                return Graph.Oriented;
            }
        }

        protected bool CloneCycles { get; set; } = true;

        protected bool SaveSteps { get; set; }

        protected VisualManager VisualManager { get; private set; }
        
        protected LinkedList<Step> Steps { get; set; }
        protected List<Path> Cycles { get; set; }
        

        protected enum VertexState
        {
            notVisited,
            active,
            visited
        };


        public SearchCore(VisualGraph graph, bool saveSteps)
        {
            SaveSteps = saveSteps;
            Graph = GraphFactory.Clone(graph);
            VisualManager = new VisualManager(Graph);
        }


        public SearchCore(SearchCore parent)
        {
            Graph = parent.Graph;
            VisualManager = parent.VisualManager;
            Steps = parent.Steps;
            Cycles = parent.Cycles;
            SaveSteps = parent.SaveSteps;
        }
        

        protected virtual void AddCurrentStep(string description)
        {
            Steps.AddLast(new Step
            {
                Description = description,
                DOT = VisualManager.GetDOTString(),
                Cycles = CloneCycles ? GetCyclesClone() : Cycles
            });
        }

        protected bool IsEdgeExist(int from, int to)
        {
            return Graph.Edges[from, to].Exist;
        }

        protected double GetWeight(int from, int to)
        {
            return Graph.Edges[from, to].Weight;
        }

        protected List<Path> GetCyclesClone()
        {
            List<Path> clone = new List<Path>();
            List<Path>.Enumerator enumer = Cycles.GetEnumerator();
            for (int i = 0; i < Cycles.Count; i++)
            {
                enumer.MoveNext();
                Path cur = enumer.Current;
                clone.Add(new Path
                {
                    Vertices = cur.Vertices,
                    Weight = cur.Weight
                });
            }

            return clone;
        }

        protected EdgesSetter GetEdgesSetter()
        {
            return new EdgesSetter(Graph);
        }
    }
}
