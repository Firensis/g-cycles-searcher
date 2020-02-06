using GCyclesSearcher.Workers.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Searchers.EulerExistCheckers
{
    class DegreesChecker : SearchCore
    {
        public DegreesChecker(SearchCore parent) : base(parent)
        {
        }

        public bool CheckDegrees()
        {
            return Oriented ? CheckDegreesOriented() : CheckDegreesNotOriented();
        }

        private bool CheckDegreesOriented()
        {
            if (SaveSteps)
            {
                AddCurrentStep("Проверяется наличие Эйлерова Цикла. Если граф ориентированный, то число рёбер, входящих в любую из вершин, должно равняться числу рёбер, исходящих из неё");
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                if (!CheckVertexOriented(i))
                {
                    return false;
                }
            }

            if (SaveSteps)
            {
                AddCheckPassedStep();
            }

            return true;
        }

        private void AddCheckPassedStep()
        {
            AddCurrentStep("Все вершины прошли проверку, следовательно, в графе есть цикл Эйлера.");
        }

        private bool CheckVertexOriented(int vertexNum)
        {
            List<int> inConnections = new List<int>();
            List<int> outConnections = new List<int>();
            bool loop = false;

            for (int j = 0; j < VerticesCount; j++)
            {
                if (vertexNum == j && IsEdgeExist(vertexNum, vertexNum))
                {
                    loop = true;
                    continue;
                }

                if (IsEdgeExist(vertexNum, j))
                {
                    outConnections.Add(j);
                }

                if (IsEdgeExist(j, vertexNum))
                {
                    inConnections.Add(j);
                }
            }
            

            if (SaveSteps)
            {
                AddCheckVertexOrientedStep(vertexNum, inConnections, outConnections, loop);
            }


            return outConnections.Count == inConnections.Count;
        }


        private void AddCheckVertexOrientedStep(int vertexNum, List<int> inConnections, List<int> outConnections, bool loop)
        {
            string text = $"Проверяется вершина {vertexNum}:";

            if (loop)
            {
                text += " найдена петля;";
            }

            text += $" количество исходящих рёбер: {outConnections.Count};" +
                    $" количество входящих рёбер: {inConnections.Count}. Количества входящих и исходящих рёбер";


            VisualManager.SetVertexColor(vertexNum, Settings.ACTIVE_VERTEX_COLOR);

            if (loop)
            {
                VisualManager.SetEdgeColor(vertexNum, vertexNum, Settings.LOOP_EDGE_COLOR);
            }

            VisualManager.SelectEdges(inConnections, vertexNum, Settings.INPUT_EDGE_COLOR);
            VisualManager.SelectEdges(vertexNum, outConnections, Settings.OUTPUT_EDGE_COLOR);



            text += outConnections.Count == inConnections.Count ? " равны." : " не равны. Следовательно, в графе нет Эйлерова цикла.";


            AddCurrentStep(text);
            VisualManager.UnselectEnvironment(vertexNum);
            VisualManager.SetVertexColor(vertexNum, Settings.DEFAULT_VERTEX_COLOR);
        }



        private bool CheckDegreesNotOriented()
        {
            if (SaveSteps)
            {
                AddCurrentStep("Проверяется наличие Эйлерова Цикла. Если граф неориентированный, то количество рёбер, инцидентных любой вершине должно быть чётным");
            }


            for (int i = 0; i < VerticesCount; i++)
            {
                if (!CheckVertexNotOriented(i))
                {
                    return false;
                }
            }

            if (SaveSteps)
            {
                AddCheckPassedStep();
            }

            return true;
        }

        private bool CheckVertexNotOriented(int vertexNum)
        {
            int degree = 0;
            bool loop = false;

            for (int j = 0; j < VerticesCount; j++)
            {
                if (IsEdgeExist(vertexNum, j))
                {
                    degree++;
                    if (vertexNum == j)
                    {
                        degree++;
                        loop = true;
                    }
                }
            }

            if (SaveSteps)
            {
                AddCheckVertexNotOrientedStep(vertexNum, degree, loop);
            }

            return degree % 2 == 0;
        }

        private void AddCheckVertexNotOrientedStep(int vertexNum, int degree, bool loop)
        {
            VisualManager.SetVertexColor(vertexNum, Settings.ACTIVE_VERTEX_COLOR);
            VisualManager.SelectEnvironment(vertexNum, Settings.INPUT_EDGE_COLOR);
            VisualManager.SetEdgeColor(vertexNum, vertexNum, Settings.LOOP_EDGE_COLOR);

            string text = $"Проверяется вершина {vertexNum}:";

            if (loop)
            {
                text += "найдена петля: при подсчёте степени такое ребро прибавляется дважды; ";
            }

            text += $"Степень вершины равна {degree}. ";

            text += degree % 2 == 0 ? "Степень чётна." : "Степень нечётна, следовательно, в графе нет Эйлерова цикла.";

            AddCurrentStep(text);

            VisualManager.SetVertexColor(vertexNum, Settings.DEFAULT_VERTEX_COLOR);
            VisualManager.UnselectEnvironment(vertexNum);
        }
    }
}
