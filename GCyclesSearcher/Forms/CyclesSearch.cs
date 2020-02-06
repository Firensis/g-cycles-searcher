using GCyclesSearcher.Forms.Exceptions;
using GCyclesSearcher.Models;
using GCyclesSearcher.Workers;
using GCyclesSearcher.Workers.Factory;
using GCyclesSearcher.Workers.Searchers;
using GCyclesSearcher.Workers.Visual;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GCyclesSearcher.Forms
{
    public partial class CyclesSearch : Form
    {
        private VisualGraph Graph { get; set; }
        
        private VisualManager VisualManager { get; set; }

        private List<Path> Cycles { get; set; }

        public CyclesSearch()
        {
            InitializeComponent();
            selectCyclesType.SelectedIndex = 0;
        }

        private void FileChoose_Click(object sender, EventArgs e)
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

            graphPicture.Image = VisualManager.GetImage();

            bSearchCycles.Enabled = true;
            panelCycles.Visible = false;
            bSearchCycles.Enabled = true;
        }


        private void SearchCycles_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCycles();
            }
            catch (WrongCycleTypeException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void SearchCycles()
        {
            CyclesSearcher searcher; 
            switch (selectCyclesType.SelectedIndex)
            {
                case 0:
                    searcher = new SimpleSearcher(Graph, false);
                    break;
                case 1:
                    searcher = new EulerSearcher(Graph, false);
                    break;
                case 2:
                    searcher = new HamiltonSearcher(Graph, false);
                    break;
                default:
                    throw new WrongCycleTypeException("При выборе алгоритма произошла ошибка. Просим прощения за доставленные неудобства!");
            }
            
            

            Cycles = searcher.GetCycles();
            
            if (Cycles.Count > 0)
            {
                InitCycleSelector();

                MessageBox.Show($"Найдено следующее количество циклов: {Cycles.Count}.");
                panelCycles.Visible = true;
            }
            else
            {
                MessageBox.Show($"Выявлено отсутствие циклов выбранного типа в данном графе.");
                panelCycles.Visible = false;
            }
        }

       

        private void InitCycleSelector()
        {
            cyclesSelect.Items.Clear();

            foreach (Path cycle in Cycles)
            {
                cyclesSelect.Items.Add(CyclesManager.ConvertToString(cycle, Graph.Oriented));
            }

            cyclesSelect.SelectedIndex = 0;
        }

        private void CyclesSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curIndex = ((ComboBox)sender).SelectedIndex;
            ShowCycle(curIndex);
        }

        private void ShowCycle(int index)
        {
            graphPicture.Image = VisualManager.GetImageWithSelected(Cycles[index], Settings.NEW_CYCLE_COLOR);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new Menu());
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowFindCyclesHelp(false);
        }
    }
}
