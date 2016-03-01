namespace JIRASync
{
    partial class ChooseUser
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
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchUserWorker = new System.ComponentModel.BackgroundWorker();
            this.UserList = new System.Windows.Forms.ListBox();
            this.ChooseUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 12);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(404, 20);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchUserWorker
            // 
            this.SearchUserWorker.WorkerSupportsCancellation = true;
            this.SearchUserWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchUserWorker_DoWork);
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(12, 38);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(404, 173);
            this.UserList.TabIndex = 1;
            // 
            // ChooseUserButton
            // 
            this.ChooseUserButton.Location = new System.Drawing.Point(248, 218);
            this.ChooseUserButton.Name = "ChooseUserButton";
            this.ChooseUserButton.Size = new System.Drawing.Size(168, 31);
            this.ChooseUserButton.TabIndex = 2;
            this.ChooseUserButton.Text = "Выбрать";
            this.ChooseUserButton.UseVisualStyleBackColor = true;
            this.ChooseUserButton.Click += new System.EventHandler(this.ChooseUserButton_Click);
            // 
            // ChooseUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 261);
            this.Controls.Add(this.ChooseUserButton);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.SearchBox);
            this.Name = "ChooseUser";
            this.Text = "Выбор исполнителя";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Activated += new System.EventHandler(this.ChooseUser_Activated);
            this.Deactivate += new System.EventHandler(this.ChooseUser_Deactivate);
            this.Load += new System.EventHandler(this.ChooseUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBox;
        private System.ComponentModel.BackgroundWorker SearchUserWorker;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Button ChooseUserButton;
    }
}