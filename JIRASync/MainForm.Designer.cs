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
            this.JIRAServerURLLabel = new System.Windows.Forms.Label();
            this.JIRAServerUrlText = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Location = new System.Drawing.Point(203, 160);
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
            this.panel1.Controls.Add(this.JIRAServerURLLabel);
            this.panel1.Controls.Add(this.JIRAServerUrlText);
            this.panel1.Controls.Add(this.PassTextBox);
            this.panel1.Controls.Add(this.UserTextBox);
            this.panel1.Controls.Add(this.PassLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CeptahInstallPathTextBox);
            this.panel1.Controls.Add(this.SaveConfigButton);
            this.panel1.Controls.Add(this.JiraProjectKeyList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 193);
            this.panel1.TabIndex = 10;
            // 
            // JIRAServerURLLabel
            // 
            this.JIRAServerURLLabel.AutoSize = true;
            this.JIRAServerURLLabel.Location = new System.Drawing.Point(3, 114);
            this.JIRAServerURLLabel.Name = "JIRAServerURLLabel";
            this.JIRAServerURLLabel.Size = new System.Drawing.Size(55, 13);
            this.JIRAServerURLLabel.TabIndex = 15;
            this.JIRAServerURLLabel.Text = "JIRA URL";
            // 
            // JIRAServerUrlText
            // 
            this.JIRAServerUrlText.Location = new System.Drawing.Point(119, 111);
            this.JIRAServerUrlText.Name = "JIRAServerUrlText";
            this.JIRAServerUrlText.Size = new System.Drawing.Size(172, 20);
            this.JIRAServerUrlText.TabIndex = 14;
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(119, 84);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(172, 20);
            this.PassTextBox.TabIndex = 13;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(119, 57);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(172, 20);
            this.UserTextBox.TabIndex = 12;
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(3, 87);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(45, 13);
            this.PassLabel.TabIndex = 11;
            this.PassLabel.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Пользователь";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 217);
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
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox JIRAServerUrlText;
        private System.Windows.Forms.Label JIRAServerURLLabel;
    }
}