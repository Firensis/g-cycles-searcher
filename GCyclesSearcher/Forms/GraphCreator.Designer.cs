namespace GCyclesSearcher.Forms
{
    partial class GraphCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureGraph = new System.Windows.Forms.PictureBox();
            this.groupEdgeCreate = new System.Windows.Forms.GroupBox();
            this.comboStartVertex = new System.Windows.Forms.ComboBox();
            this.comboFinishVertex = new System.Windows.Forms.ComboBox();
            this.inputEdgeWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSetEdge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveGraphDialog = new System.Windows.Forms.SaveFileDialog();
            this.openGraphDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOpenGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveGraphAs = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).BeginInit();
            this.groupEdgeCreate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureGraph
            // 
            this.pictureGraph.Location = new System.Drawing.Point(13, 195);
            this.pictureGraph.Name = "pictureGraph";
            this.pictureGraph.Size = new System.Drawing.Size(123, 18);
            this.pictureGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureGraph.TabIndex = 4;
            this.pictureGraph.TabStop = false;
            // 
            // groupEdgeCreate
            // 
            this.groupEdgeCreate.Controls.Add(this.comboStartVertex);
            this.groupEdgeCreate.Controls.Add(this.comboFinishVertex);
            this.groupEdgeCreate.Controls.Add(this.inputEdgeWeight);
            this.groupEdgeCreate.Controls.Add(this.label4);
            this.groupEdgeCreate.Controls.Add(this.buttonSetEdge);
            this.groupEdgeCreate.Controls.Add(this.label3);
            this.groupEdgeCreate.Controls.Add(this.label2);
            this.groupEdgeCreate.Enabled = false;
            this.groupEdgeCreate.Location = new System.Drawing.Point(13, 38);
            this.groupEdgeCreate.Name = "groupEdgeCreate";
            this.groupEdgeCreate.Size = new System.Drawing.Size(215, 125);
            this.groupEdgeCreate.TabIndex = 5;
            this.groupEdgeCreate.TabStop = false;
            this.groupEdgeCreate.Text = "Задание рёбер";
            // 
            // comboStartVertex
            // 
            this.comboStartVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStartVertex.FormattingEnabled = true;
            this.comboStartVertex.Location = new System.Drawing.Point(122, 12);
            this.comboStartVertex.Name = "comboStartVertex";
            this.comboStartVertex.Size = new System.Drawing.Size(76, 21);
            this.comboStartVertex.TabIndex = 12;
            // 
            // comboFinishVertex
            // 
            this.comboFinishVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFinishVertex.FormattingEnabled = true;
            this.comboFinishVertex.Location = new System.Drawing.Point(122, 39);
            this.comboFinishVertex.Name = "comboFinishVertex";
            this.comboFinishVertex.Size = new System.Drawing.Size(76, 21);
            this.comboFinishVertex.TabIndex = 6;
            // 
            // inputEdgeWeight
            // 
            this.inputEdgeWeight.Location = new System.Drawing.Point(122, 68);
            this.inputEdgeWeight.Name = "inputEdgeWeight";
            this.inputEdgeWeight.Size = new System.Drawing.Size(76, 20);
            this.inputEdgeWeight.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Вес ребра:";
            // 
            // buttonSetEdge
            // 
            this.buttonSetEdge.Location = new System.Drawing.Point(56, 94);
            this.buttonSetEdge.Name = "buttonSetEdge";
            this.buttonSetEdge.Size = new System.Drawing.Size(98, 23);
            this.buttonSetEdge.TabIndex = 3;
            this.buttonSetEdge.Text = "Задать ребро";
            this.buttonSetEdge.UseVisualStyleBackColor = true;
            this.buttonSetEdge.Click += new System.EventHandler(this.ButtonSetEdge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Конечная вершина:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стартовая вершина:";
            // 
            // saveGraphDialog
            // 
            this.saveGraphDialog.FileName = "graph";
            this.saveGraphDialog.Filter = "Файлы GraphEdges|*.gedges|Файлы GraphMatrix|*.gmatrix";
            this.saveGraphDialog.SupportMultiDottedExtensions = true;
            // 
            // openGraphDialog
            // 
            this.openGraphDialog.Filter = "Файлы GraphEdges и GraphMatrix|*.gedges;*.gmatrix";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графToolStripMenuItem,
            this.buttonShowHelp,
            this.buttonToMainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(324, 24);
            this.menuStrip1.TabIndex = 11;
            // 
            // графToolStripMenuItem
            // 
            this.графToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCreateGraph,
            this.buttonOpenGraph,
            this.buttonSaveGraph,
            this.buttonSaveGraphAs});
            this.графToolStripMenuItem.Name = "графToolStripMenuItem";
            this.графToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.графToolStripMenuItem.Text = "Граф";
            // 
            // buttonCreateGraph
            // 
            this.buttonCreateGraph.Name = "buttonCreateGraph";
            this.buttonCreateGraph.Size = new System.Drawing.Size(153, 22);
            this.buttonCreateGraph.Text = "Создать";
            this.buttonCreateGraph.Click += new System.EventHandler(this.ButtonCreateGraph_Click);
            // 
            // buttonOpenGraph
            // 
            this.buttonOpenGraph.Name = "buttonOpenGraph";
            this.buttonOpenGraph.Size = new System.Drawing.Size(153, 22);
            this.buttonOpenGraph.Text = "Открыть файл";
            this.buttonOpenGraph.Click += new System.EventHandler(this.OpenGraph_Click);
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Enabled = false;
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(153, 22);
            this.buttonSaveGraph.Text = "Сохранить";
            this.buttonSaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // buttonSaveGraphAs
            // 
            this.buttonSaveGraphAs.Enabled = false;
            this.buttonSaveGraphAs.Name = "buttonSaveGraphAs";
            this.buttonSaveGraphAs.Size = new System.Drawing.Size(153, 22);
            this.buttonSaveGraphAs.Text = "Сохранить как";
            this.buttonSaveGraphAs.Click += new System.EventHandler(this.ButtonSaveGraphAs_Click);
            // 
            // buttonShowHelp
            // 
            this.buttonShowHelp.Name = "buttonShowHelp";
            this.buttonShowHelp.Size = new System.Drawing.Size(93, 24);
            this.buttonShowHelp.Text = "Информация";
            this.buttonShowHelp.Click += new System.EventHandler(this.Help_Click);
            // 
            // buttonToMainMenu
            // 
            this.buttonToMainMenu.Name = "buttonToMainMenu";
            this.buttonToMainMenu.Size = new System.Drawing.Size(108, 24);
            this.buttonToMainMenu.Text = "В главное меню";
            this.buttonToMainMenu.Click += new System.EventHandler(this.ToMenu_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(13, 170);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 13);
            this.labelFileName.TabIndex = 12;
            // 
            // GraphCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(334, 238);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.groupEdgeCreate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "GraphCreator";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание/редактирование";
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).EndInit();
            this.groupEdgeCreate.ResumeLayout(false);
            this.groupEdgeCreate.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureGraph;
        private System.Windows.Forms.GroupBox groupEdgeCreate;
        private System.Windows.Forms.TextBox inputEdgeWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSetEdge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveGraphDialog;
        private System.Windows.Forms.OpenFileDialog openGraphDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonCreateGraph;
        private System.Windows.Forms.ToolStripMenuItem buttonOpenGraph;
        private System.Windows.Forms.ToolStripMenuItem buttonSaveGraph;
        private System.Windows.Forms.ToolStripMenuItem buttonSaveGraphAs;
        private System.Windows.Forms.ToolStripMenuItem buttonShowHelp;
        private System.Windows.Forms.ComboBox comboStartVertex;
        private System.Windows.Forms.ComboBox comboFinishVertex;
        private System.Windows.Forms.ToolStripMenuItem buttonToMainMenu;
        private System.Windows.Forms.Label labelFileName;
    }
}