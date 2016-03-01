namespace JIRASync
{
    partial class CreateProject
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
            this.CPKey = new System.Windows.Forms.TextBox();
            this.CPName = new System.Windows.Forms.TextBox();
            this.CPCode = new System.Windows.Forms.TextBox();
            this.CPCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CPKey
            // 
            this.CPKey.AcceptsTab = true;
            this.CPKey.Location = new System.Drawing.Point(12, 33);
            this.CPKey.Name = "CPKey";
            this.CPKey.Size = new System.Drawing.Size(260, 20);
            this.CPKey.TabIndex = 1;
            // 
            // CPName
            // 
            this.CPName.AcceptsTab = true;
            this.CPName.Location = new System.Drawing.Point(12, 80);
            this.CPName.Name = "CPName";
            this.CPName.Size = new System.Drawing.Size(260, 20);
            this.CPName.TabIndex = 2;
            // 
            // CPCode
            // 
            this.CPCode.AcceptsTab = true;
            this.CPCode.Location = new System.Drawing.Point(12, 127);
            this.CPCode.Name = "CPCode";
            this.CPCode.Size = new System.Drawing.Size(260, 20);
            this.CPCode.TabIndex = 3;
            // 
            // CPCreate
            // 
            this.CPCreate.Location = new System.Drawing.Point(12, 153);
            this.CPCreate.Name = "CPCreate";
            this.CPCreate.Size = new System.Drawing.Size(260, 26);
            this.CPCreate.TabIndex = 4;
            this.CPCreate.Text = "Создать";
            this.CPCreate.UseVisualStyleBackColor = true;
            this.CPCreate.Click += new System.EventHandler(this.CPCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Код проекта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Название проекта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Шифр проекта";
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CPCreate);
            this.Controls.Add(this.CPCode);
            this.Controls.Add(this.CPName);
            this.Controls.Add(this.CPKey);
            this.Name = "CreateProject";
            this.Text = "CreateProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CPKey;
        private System.Windows.Forms.TextBox CPName;
        private System.Windows.Forms.TextBox CPCode;
        private System.Windows.Forms.Button CPCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}