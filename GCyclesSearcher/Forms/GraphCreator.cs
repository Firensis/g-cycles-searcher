using GCyclesSearcher.Forms.Exceptions;
using GCyclesSearcher.Models;
using GCyclesSearcher.Workers;
using GCyclesSearcher.Workers.Factory;
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
    public partial class GraphCreator : Form
    {
        private VisualGraph Graph { get; set; }

        private CreateGraphDialog CreateGraphDialog { get; set; }

        private VisualManager VisualManager { get; set; }
        private EdgesSetter EdgesManager { get; set; }

        private int VertexFrom { get; set; }
        private int VertexTo { get; set; }
        private double Weight { get; set; }
        private bool ChangesSaved { get; set; } = true;
        private bool goToMenu = false;

        private string filename = "";
        private string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                string[] parts = value.Split('\\');
                labelFileName.Text = parts.Last();
            }
        }

        public GraphCreator()
        {
            InitializeComponent();
            FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!goToMenu)
            {
                e.Cancel = !CheckChangesSaved();
            }
        }

        private void ButtonSetEdge_Click(object sender, EventArgs e)
        {
            try
            {
                SetEdgeFromInput();
            }
            catch (WrongInputException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void SetEdgeFromInput()
        {
            int start = comboStartVertex.SelectedIndex;
            int finish = comboFinishVertex.SelectedIndex;

            if (!double.TryParse(inputEdgeWeight.Text, out double weight))
            {
                throw new WrongInputException("Введено недопустимое значение веса ребра!(ожидается ввод целых чисел и десятичных дробей, в которых целая и дробные части разделены заятой. Для удаления ребра задайте ему вес \"0\"!)");
            }

            EdgesManager.SetEdgeWeight(start, finish, weight);
            ChangesSaved = false;
            RenderGraph();
        }


        private void ToMenu_Click(object sender, EventArgs e)
        {
            if (!CheckChangesSaved())
            {
                return;
            }
            goToMenu = true;
            FormsSystem.ChangeForm(new Menu());
        }


        private void Help_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowCreateGraphHelp(false);
        }

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCurrentGraph();
            }
            catch (DialogCancelException) { }
            catch (WrongFileException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void SaveCurrentGraph()
        {
            if (FileName == "")
            {
                FileName = GetFileNameFromDialog();
            }

            GraphSaver.SaveToFile(Graph, filename);

            ChangesSaved = true;
        }

        private string GetFileNameFromDialog()
        {
            if (saveGraphDialog.ShowDialog() == DialogResult.Cancel)
            {
                throw new DialogCancelException();
            }
            return saveGraphDialog.FileName;
        }


        private bool CheckChangesSaved()
        {
            if (!ChangesSaved)
            {
                try
                {
                    OfferSaveChanges();
                }
                catch (DialogCancelException)
                {
                    return false;
                }
                catch (WrongFileException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

            return true;
        }

        private void OfferSaveChanges()
        {
            DialogResult result = MessageBox.Show("Некоторые изменения не были сохранены. Выполнить сохранение? В противном случае они будут потеряны.", "Сохранение изменений", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveCurrentGraph();
                    break;
                case DialogResult.Cancel:
                    throw new DialogCancelException();
            }
        }


        private void OpenGraph_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFromFile();
            }
            catch (WrongFileException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void CreateFromFile()
        {
            if (!CheckChangesSaved())
            {
                return;
            }

            if (openGraphDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            Graph = GraphFactory.CreateFromFile(openGraphDialog.FileName);
            InitGraph();
            FileName = openGraphDialog.FileName;
            ChangesSaved = true;
        }


        

        private void RenderGraph()
        {
            pictureGraph.Image = VisualManager.GetImage();
        }

        private void InitGraph()
        {
            InitManagers();
            RenderGraph();

            buttonSaveGraph.Enabled = true;
            buttonSaveGraphAs.Enabled = true;
            groupEdgeCreate.Enabled = true;
            InitComboBoxes();
        }
        private void InitComboBoxes()
        {
            comboStartVertex.Items.Clear();
            comboFinishVertex.Items.Clear();
            for (int i = 0; i < Graph.VerticesCount; i++)
            {
                comboStartVertex.Items.Add(i);
                comboFinishVertex.Items.Add(i);
            }

            comboStartVertex.SelectedIndex = comboFinishVertex.SelectedIndex = 0;
        }
        private void InitManagers()
        {
            VisualManager = new VisualManager(Graph);
            EdgesManager = new EdgesSetter(Graph);
        }


        private void ButtonCreateGraph_Click(object sender, EventArgs e)
        {
            ShowCreateGraphDialog();
        }

        private void CreateNewGraph(int verticesCount, bool oriented)
        {
            if (!CheckChangesSaved())
            {
                return;
            }

            Graph = GraphFactory.Create(verticesCount, oriented);
            FileName = "";
            InitGraph();
            ChangesSaved = false;
        }

        private void ShowCreateGraphDialog()
        {
            CreateGraphDialog = new CreateGraphDialog();
            CreateGraphDialog.InputParsed += CreateNewGraph;
            CreateGraphDialog.ShowDialog(this);
        }

        private void ButtonSaveGraphAs_Click(object sender, EventArgs e)
        {
            string oldFileName = FileName;
            FileName = "";

            try
            {
                SaveCurrentGraph();
            }
            catch (DialogCancelException)
            {
                FileName = oldFileName;
            }
            catch (WrongFileException exception)
            {
                MessageBox.Show(exception.Message);
                FileName = oldFileName;
            }
        }
    }
}
