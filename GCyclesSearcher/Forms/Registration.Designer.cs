namespace GCyclesSearcher.Forms
{
    partial class Registration
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
            this.registerBut = new System.Windows.Forms.Button();
            this.toPrevBut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordInp = new System.Windows.Forms.TextBox();
            this.loginInp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // registerBut
            // 
            this.registerBut.Location = new System.Drawing.Point(61, 145);
            this.registerBut.Name = "registerBut";
            this.registerBut.Size = new System.Drawing.Size(160, 23);
            this.registerBut.TabIndex = 0;
            this.registerBut.Text = "Добавить пользователя";
            this.registerBut.UseVisualStyleBackColor = true;
            this.registerBut.Click += new System.EventHandler(this.RegisterBut_Click);
            // 
            // toPrevBut
            // 
            this.toPrevBut.Location = new System.Drawing.Point(77, 174);
            this.toPrevBut.Name = "toPrevBut";
            this.toPrevBut.Size = new System.Drawing.Size(131, 23);
            this.toPrevBut.TabIndex = 1;
            this.toPrevBut.Text = "Назад";
            this.toPrevBut.UseVisualStyleBackColor = true;
            this.toPrevBut.Click += new System.EventHandler(this.ToPrevBut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логин:";
            // 
            // passwordInp
            // 
            this.passwordInp.Location = new System.Drawing.Point(12, 93);
            this.passwordInp.Name = "passwordInp";
            this.passwordInp.Size = new System.Drawing.Size(267, 20);
            this.passwordInp.TabIndex = 6;
            // 
            // loginInp
            // 
            this.loginInp.Location = new System.Drawing.Point(12, 40);
            this.loginInp.Name = "loginInp";
            this.loginInp.Size = new System.Drawing.Size(267, 20);
            this.loginInp.TabIndex = 5;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(291, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordInp);
            this.Controls.Add(this.loginInp);
            this.Controls.Add(this.toPrevBut);
            this.Controls.Add(this.registerBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBut;
        private System.Windows.Forms.Button toPrevBut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordInp;
        private System.Windows.Forms.TextBox loginInp;
    }
}