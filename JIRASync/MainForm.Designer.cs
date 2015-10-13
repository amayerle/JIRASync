namespace JIRASync
{
    partial class ConfigForm
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
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CeptahInstallPathTextBox = new System.Windows.Forms.TextBox();
            this.JiraProjectKeyList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Location = new System.Drawing.Point(203, 56);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(88, 30);
            this.SaveConfigButton.TabIndex = 0;
            this.SaveConfigButton.Text = "Сохранить";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код проекта";
            // 
            // CeptahInstallPathTextBox
            // 
            this.CeptahInstallPathTextBox.Location = new System.Drawing.Point(119, 30);
            this.CeptahInstallPathTextBox.Name = "CeptahInstallPathTextBox";
            this.CeptahInstallPathTextBox.Size = new System.Drawing.Size(172, 20);
            this.CeptahInstallPathTextBox.TabIndex = 6;
            // 
            // JiraProjectKeyList
            // 
            this.JiraProjectKeyList.FormattingEnabled = true;
            this.JiraProjectKeyList.Location = new System.Drawing.Point(119, 3);
            this.JiraProjectKeyList.Name = "JiraProjectKeyList";
            this.JiraProjectKeyList.Size = new System.Drawing.Size(172, 21);
            this.JiraProjectKeyList.TabIndex = 8;
            this.JiraProjectKeyList.DropDown += new System.EventHandler(this.JiraProjectKeyList_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Путь до Ceptah Bridge";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CeptahInstallPathTextBox);
            this.panel1.Controls.Add(this.SaveConfigButton);
            this.panel1.Controls.Add(this.JiraProjectKeyList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 89);
            this.panel1.TabIndex = 10;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 113);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveConfigButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CeptahInstallPathTextBox;
        private System.Windows.Forms.ComboBox JiraProjectKeyList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}