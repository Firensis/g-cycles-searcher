using GCyclesSearcher.Forms.Exceptions;
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
    public partial class CreateGraphDialog : Form
    {
        int verticesCount;
        bool oriented;

        public delegate void OnInputParsed(int verticesCount, bool oriented);

        public event OnInputParsed InputParsed;

        public CreateGraphDialog()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ParseInput();
                InputParsed(verticesCount, oriented);
                Close();
            }
            catch (WrongInputException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ParseInput()
        {
            if (!int.TryParse(inputVerticesNum.Text.Trim(), out verticesCount) || verticesCount < 1)
            {
                throw new WrongInputException("Введено некорректное количество вершин! (допустимы положительные целые числа)");
            }

            oriented = checkOriented.Checked;
        }
    }
}
