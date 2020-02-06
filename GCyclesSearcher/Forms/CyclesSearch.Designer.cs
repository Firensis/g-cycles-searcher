namespace GCyclesSearcher.Forms
{
    partial class CyclesSearch
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
            this.graphPicture = new System.Windows.Forms.PictureBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileChoose = new System.Windows.Forms.Button();
            this.bSearchCycles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cyclesSelect = new System.Windows.Forms.ComboBox();
            this.panelCycles = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.selectCyclesType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphPicture)).BeginInit();
            this.panelCycles.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphPicture
            // 
            this.graphPicture.Location = new System.Drawing.Point(13, 144);
            this.graphPicture.Name = "graphPicture";
            this.graphPicture.Size = new System.Drawing.Size(330, 100);
            this.graphPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.graphPicture.TabIndex = 0;
            this.graphPicture.TabStop = false;
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Файлы GraphEdges и GraphMatrix|*.gedges;*.gmatrix";
            // 
            // fileChoose
            // 
            this.fileChoose.Location = new System.Drawing.Point(13, 13);
            this.fileChoose.Name = "fileChoose";
            this.fileChoose.Size = new System.Drawing.Size(123, 23);
            this.fileChoose.TabIndex = 1;
            this.fileChoose.Text = "Выбрать файл";
            this.fileChoose.UseVisualStyleBackColor = true;
            this.fileChoose.Click += new System.EventHandler(this.FileChoose_Click);
            // 
            // bSearchCycles
            // 
            this.bSearchCycles.Enabled = false;
            this.bSearchCycles.Location = new System.Drawing.Point(220, 65);
            this.bSearchCycles.Name = "bSearchCycles";
            this.bSearchCycles.Size = new System.Drawing.Size(123, 23);
            this.bSearchCycles.TabIndex = 4;
            this.bSearchCycles.Text = "Поиск циклов";
            this.bSearchCycles.UseVisualStyleBackColor = true;
            this.bSearchCycles.Click += new System.EventHandler(this.SearchCycles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Отображаемый цикл:";
            // 
            // cyclesSelect
            // 
            this.cyclesSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cyclesSelect.FormattingEnabled = true;
            this.cyclesSelect.Location = new System.Drawing.Point(3, 20);
            this.cyclesSelect.Name = "cyclesSelect";
            this.cyclesSelect.Size = new System.Drawing.Size(327, 21);
            this.cyclesSelect.TabIndex = 5;
            this.cyclesSelect.SelectedIndexChanged += new System.EventHandler(this.CyclesSelect_SelectedIndexChanged);
            // 
            // panelCycles
            // 
            this.panelCycles.Controls.Add(this.cyclesSelect);
            this.panelCycles.Controls.Add(this.label2);
            this.panelCycles.Location = new System.Drawing.Point(13, 94);
            this.panelCycles.Name = "panelCycles";
            this.panelCycles.Size = new System.Drawing.Size(331, 44);
            this.panelCycles.TabIndex = 6;
            this.panelCycles.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(143, 13);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(100, 23);
            this.help.TabIndex = 8;
            this.help.Text = "Помощь";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // selectCyclesType
            // 
            this.selectCyclesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCyclesType.FormattingEnabled = true;
            this.selectCyclesType.Items.AddRange(new object[] {
            "Простые  циклы",
            "Циклы Эйлера",
            "Циклы Гамильтона"});
            this.selectCyclesType.Location = new System.Drawing.Point(16, 67);
            this.selectCyclesType.Name = "selectCyclesType";
            this.selectCyclesType.Size = new System.Drawing.Size(139, 21);
            this.selectCyclesType.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Вид циклов:";
            // 
            // CyclesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectCyclesType);
            this.Controls.Add(this.bSearchCycles);
            this.Controls.Add(this.help);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelCycles);
            this.Controls.Add(this.fileChoose);
            this.Controls.Add(this.graphPicture);
            this.MaximizeBox = false;
            this.Name = "CyclesSearch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск циклов";
            ((System.ComponentModel.ISupportInitialize)(this.graphPicture)).EndInit();
            this.panelCycles.ResumeLayout(false);
            this.panelCycles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphPicture;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button fileChoose;
        private System.Windows.Forms.Button bSearchCycles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cyclesSelect;
        private System.Windows.Forms.Panel panelCycles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.ComboBox selectCyclesType;
        private System.Windows.Forms.Label label1;
    }
}