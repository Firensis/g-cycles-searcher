using GCyclesSearcher.Forms.Exceptions;
using GCyclesSearcher.Models;
using GCyclesSearcher.Workers;
using GCyclesSearcher.Workers.Factory;
using GCyclesSearcher.Workers.Searchers;
using GCyclesSearcher.Workers.Visual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCyclesSearcher.Forms
{
    public partial class StepsVisualizer : Form
    {
        VisualGraph Graph { get; set; }
        VisualManager VisualManager { get; set; }

        

        int CurStepIndex { get; set; }
        LinkedList<Step> Steps { get; set; }
        

        LinkedListNode<Step> CurrentStepNode { get; set; }


        public StepsVisualizer()
        {
            InitializeComponent();
            algorithmSelect.SelectedIndex = 0;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGraph();
            }
            catch (WrongFileException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void LoadGraph()
        {
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            Graph = GraphFactory.CreateFromFile(fileDialog.FileName);

            VisualManager = new VisualManager(Graph);

            stepControls.Visible = false;
            

            imgContainer.Image = VisualManager.GetImage();

            searchControls.Enabled = true;
        }

        private void SearchCycles_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCycles();
            }
            catch (WrongCycleTypeException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SearchCycles()
        {
            loadingLabel.Visible = true;

            CyclesSearcher searcher;

            switch (algorithmSelect.SelectedIndex)
            {
                case 0:
                    searcher = new SimpleSearcher(Graph, true);
                    break;
                case 1:
                    searcher = new EulerSearcher(Graph, true);
                    break;
                case 2:
                    searcher = new HamiltonSearcher(Graph, true);
                    break;
                default:
                    throw new WrongCycleTypeException("При выборе вида цикла произошла неизвестная ошибка!");
            }

            searcher.GetCycles();
            Steps = searcher.GetSteps();

            ShowFirstStep();

            loadingLabel.Visible = false;
            stepControls.Visible = true;
        }






        private void Next_Click(object sender, EventArgs e)
        {
            CurStepIndex++;
            CurrentStepNode = CurrentStepNode.Next;
            ShowCurrentStep();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            CurStepIndex--;
            CurrentStepNode = CurrentStepNode.Previous;
            ShowCurrentStep();
        }


        private void ToBegin_Click(object sender, EventArgs e)
        {
            ShowFirstStep();
        }

        private void ToEnd_Click(object sender, EventArgs e)
        {
            ShowLastStep();
        }

        private void ShowFirstStep()
        {
            CurrentStepNode = Steps.First;
            CurStepIndex = 0;
            ShowCurrentStep();
        }

        private void ShowLastStep()
        {
            CurrentStepNode = Steps.Last;
            CurStepIndex = Steps.Count - 1;
            ShowCurrentStep();
        }

        private void ShowCurrentStep()
        {
            RenderCyclesSelect();

            imgContainer.Image = VisualManager.DOTVisualizer.GetImageFromDOT(CurrentStepNode.Value.DOT);

            StepDescription.Text = CurrentStepNode.Value.Description;
            ControlButtons();
        }

        private void ControlButtons()
        {
            previous.Enabled = toBegin.Enabled = CurrentStepNode.Previous != null;
            next.Enabled = toEnd.Enabled = CurrentStepNode.Next != null;
        }

        private void RenderCyclesSelect()
        {
            cyclesSelect.Items.Clear();

            foreach (Path cycle in CurrentStepNode.Value.Cycles)
            {
                cyclesSelect.Items.Add(CyclesManager.ConvertToString(cycle, Graph.Oriented));
            }


            cyclesSelect.SelectedIndex = cyclesSelect.Items.Count - 1;
            cyclesSelect.Enabled = cyclesSelect.Items.Count > 0;
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new Menu());
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowStepFindCyclesHelp(false);
        }
    }
}
