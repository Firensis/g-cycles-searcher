namespace GCyclesSearcher.Forms
{
    partial class StepsVisualizer
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
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFile = new System.Windows.Forms.Button();
            this.algorithmSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchControls = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imgContainer = new System.Windows.Forms.PictureBox();
            this.stepControls = new System.Windows.Forms.Panel();
            this.toEnd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cyclesSelect = new System.Windows.Forms.ComboBox();
            this.toBegin = new System.Windows.Forms.Button();
            this.StepDescription = new System.Windows.Forms.Label();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.searchControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).BeginInit();
            this.stepControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Файлы GraphEdges и GraphMatrix|*.gedges;*.gmatrix";
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(320, 17);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(102, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Выбрать файл";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // algorithmSelect
            // 
            this.algorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmSelect.FormattingEnabled = true;
            this.algorithmSelect.Items.AddRange(new object[] {
            "Простые циклы",
            "Циклы Эйлера",
            "Циклы Гамильтона"});
            this.algorithmSelect.Location = new System.Drawing.Point(6, 20);
            this.algorithmSelect.Name = "algorithmSelect";
            this.algorithmSelect.Size = new System.Drawing.Size(172, 21);
            this.algorithmSelect.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбор искомых циклов";
            // 
            // searchControls
            // 
            this.searchControls.Controls.Add(this.button1);
            this.searchControls.Controls.Add(this.label1);
            this.searchControls.Controls.Add(this.algorithmSelect);
            this.searchControls.Enabled = false;
            this.searchControls.Location = new System.Drawing.Point(13, 13);
            this.searchControls.Name = "searchControls";
            this.searchControls.Size = new System.Drawing.Size(301, 47);
            this.searchControls.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SearchCycles_Click);
            // 
            // imgContainer
            // 
            this.imgContainer.Location = new System.Drawing.Point(13, 214);
            this.imgContainer.Name = "imgContainer";
            this.imgContainer.Size = new System.Drawing.Size(452, 24);
            this.imgContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgContainer.TabIndex = 6;
            this.imgContainer.TabStop = false;
            // 
            // stepControls
            // 
            this.stepControls.Controls.Add(this.toEnd);
            this.stepControls.Controls.Add(this.label2);
            this.stepControls.Controls.Add(this.cyclesSelect);
            this.stepControls.Controls.Add(this.toBegin);
            this.stepControls.Controls.Add(this.StepDescription);
            this.stepControls.Controls.Add(this.next);
            this.stepControls.Controls.Add(this.previous);
            this.stepControls.Location = new System.Drawing.Point(13, 83);
            this.stepControls.Name = "stepControls";
            this.stepControls.Size = new System.Drawing.Size(491, 125);
            this.stepControls.TabIndex = 7;
            this.stepControls.Visible = false;
            // 
            // toEnd
            // 
            this.toEnd.Location = new System.Drawing.Point(386, 72);
            this.toEnd.Name = "toEnd";
            this.toEnd.Size = new System.Drawing.Size(102, 23);
            this.toEnd.TabIndex = 12;
            this.toEnd.Text = "К последнему";
            this.toEnd.UseVisualStyleBackColor = true;
            this.toEnd.Click += new System.EventHandler(this.ToEnd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Циклы:";
            // 
            // cyclesSelect
            // 
            this.cyclesSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cyclesSelect.FormattingEnabled = true;
            this.cyclesSelect.Location = new System.Drawing.Point(66, 101);
            this.cyclesSelect.Name = "cyclesSelect";
            this.cyclesSelect.Size = new System.Drawing.Size(422, 21);
            this.cyclesSelect.TabIndex = 10;
            // 
            // toBegin
            // 
            this.toBegin.Location = new System.Drawing.Point(19, 72);
            this.toBegin.Name = "toBegin";
            this.toBegin.Size = new System.Drawing.Size(111, 23);
            this.toBegin.TabIndex = 9;
            this.toBegin.Text = "К первому";
            this.toBegin.UseVisualStyleBackColor = true;
            this.toBegin.Click += new System.EventHandler(this.ToBegin_Click);
            // 
            // StepDescription
            // 
            this.StepDescription.AutoSize = true;
            this.StepDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StepDescription.Location = new System.Drawing.Point(3, 0);
            this.StepDescription.MaximumSize = new System.Drawing.Size(456, 0);
            this.StepDescription.Name = "StepDescription";
            this.StepDescription.Size = new System.Drawing.Size(110, 17);
            this.StepDescription.TabIndex = 8;
            this.StepDescription.Text = "Описание шага";
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(261, 72);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(119, 23);
            this.next.TabIndex = 1;
            this.next.Text = "Следующий шаг";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // previous
            // 
            this.previous.Enabled = false;
            this.previous.Location = new System.Drawing.Point(136, 72);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(119, 23);
            this.previous.TabIndex = 0;
            this.previous.Text = "Предыдущий шаг";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(390, 46);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(75, 23);
            this.help.TabIndex = 9;
            this.help.Text = "Помощь";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(17, 67);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(189, 13);
            this.loadingLabel.TabIndex = 10;
            this.loadingLabel.Text = "Загрузка... Пожалуйста, подождите";
            this.loadingLabel.Visible = false;
            // 
            // StepsVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(516, 271);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.help);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.stepControls);
            this.Controls.Add(this.imgContainer);
            this.Controls.Add(this.searchControls);
            this.Controls.Add(this.openFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StepsVisualizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пошаговый поиск";
            this.searchControls.ResumeLayout(false);
            this.searchControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).EndInit();
            this.stepControls.ResumeLayout(false);
            this.stepControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.ComboBox algorithmSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel searchControls;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox imgContainer;
        private System.Windows.Forms.Panel stepControls;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Label StepDescription;
        private System.Windows.Forms.Button toBegin;
        private System.Windows.Forms.ComboBox cyclesSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button toEnd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Label loadingLabel;
    }
}