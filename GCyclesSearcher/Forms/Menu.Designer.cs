namespace GCyclesSearcher.Forms
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.addUsers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cyclesSearchContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cycleSearchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.stepCyclesSearchContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stepCyclesSearchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.CreateGraph = new System.Windows.Forms.Button();
            this.createGraphContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createGraphInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cyclesSearchContext.SuspendLayout();
            this.stepCyclesSearchContext.SuspendLayout();
            this.createGraphContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // addUsers
            // 
            this.addUsers.Location = new System.Drawing.Point(32, 152);
            this.addUsers.Name = "addUsers";
            this.addUsers.Size = new System.Drawing.Size(205, 23);
            this.addUsers.TabIndex = 0;
            this.addUsers.Text = "Добавление пользователей";
            this.addUsers.UseVisualStyleBackColor = true;
            this.addUsers.Visible = false;
            this.addUsers.Click += new System.EventHandler(this.AddUsers_Click);
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.cyclesSearchContext;
            this.button1.Location = new System.Drawing.Point(33, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Найти циклы в графе";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cyclesSearchContext
            // 
            this.cyclesSearchContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cycleSearchInfo});
            this.cyclesSearchContext.Name = "cyclesSearchContext";
            this.cyclesSearchContext.Size = new System.Drawing.Size(149, 26);
            // 
            // cycleSearchInfo
            // 
            this.cycleSearchInfo.Name = "cycleSearchInfo";
            this.cycleSearchInfo.Size = new System.Drawing.Size(148, 22);
            this.cycleSearchInfo.Text = "Информация";
            this.cycleSearchInfo.Click += new System.EventHandler(this.CycleSearchInfo_Click);
            // 
            // button2
            // 
            this.button2.ContextMenuStrip = this.stepCyclesSearchContext;
            this.button2.Location = new System.Drawing.Point(32, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Пошаговый поиск";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // stepCyclesSearchContext
            // 
            this.stepCyclesSearchContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepCyclesSearchInfo});
            this.stepCyclesSearchContext.Name = "stepCyclesSearchContext";
            this.stepCyclesSearchContext.Size = new System.Drawing.Size(149, 26);
            // 
            // stepCyclesSearchInfo
            // 
            this.stepCyclesSearchInfo.Name = "stepCyclesSearchInfo";
            this.stepCyclesSearchInfo.Size = new System.Drawing.Size(148, 22);
            this.stepCyclesSearchInfo.Text = "Информация";
            this.stepCyclesSearchInfo.Click += new System.EventHandler(this.StepCyclesSearchInfo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // CreateGraph
            // 
            this.CreateGraph.ContextMenuStrip = this.createGraphContext;
            this.CreateGraph.Location = new System.Drawing.Point(33, 19);
            this.CreateGraph.Name = "CreateGraph";
            this.CreateGraph.Size = new System.Drawing.Size(204, 23);
            this.CreateGraph.TabIndex = 4;
            this.CreateGraph.Text = "Создание и редактирование графов";
            this.CreateGraph.UseVisualStyleBackColor = true;
            this.CreateGraph.Click += new System.EventHandler(this.CreateGraph_Click);
            // 
            // createGraphContext
            // 
            this.createGraphContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGraphInfo});
            this.createGraphContext.Name = "contextMenuStrip1";
            this.createGraphContext.Size = new System.Drawing.Size(149, 26);
            // 
            // createGraphInfo
            // 
            this.createGraphInfo.Name = "createGraphInfo";
            this.createGraphInfo.Size = new System.Drawing.Size(148, 22);
            this.createGraphInfo.Text = "Информация";
            this.createGraphInfo.Click += new System.EventHandler(this.CreateGraphInfo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 219);
            this.Controls.Add(this.CreateGraph);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.cyclesSearchContext.ResumeLayout(false);
            this.stepCyclesSearchContext.ResumeLayout(false);
            this.createGraphContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addUsers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip cyclesSearchContext;
        private System.Windows.Forms.ToolStripMenuItem cycleSearchInfo;
        private System.Windows.Forms.ContextMenuStrip stepCyclesSearchContext;
        private System.Windows.Forms.ToolStripMenuItem stepCyclesSearchInfo;
        private System.Windows.Forms.Button CreateGraph;
        private System.Windows.Forms.ContextMenuStrip createGraphContext;
        private System.Windows.Forms.ToolStripMenuItem createGraphInfo;
    }
}