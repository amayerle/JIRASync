namespace JIRASync
{
    partial class SyncResults
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
            this.SyncJIRATable = new System.Windows.Forms.ListView();
            this.TaskNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentStatus = new System.Windows.Forms.StatusStrip();
            this.CurrentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // SyncJIRATable
            // 
            this.SyncJIRATable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TaskNumber,
            this.TaskName});
            this.SyncJIRATable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SyncJIRATable.Location = new System.Drawing.Point(0, 0);
            this.SyncJIRATable.Name = "SyncJIRATable";
            this.SyncJIRATable.Size = new System.Drawing.Size(812, 331);
            this.SyncJIRATable.TabIndex = 0;
            this.SyncJIRATable.UseCompatibleStateImageBehavior = false;
            // 
            // TaskNumber
            // 
            this.TaskNumber.Text = "Ключ задачи";
            // 
            // TaskName
            // 
            this.TaskName.Text = "Имя задачи";
            this.TaskName.Width = 600;
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentStatusLabel});
            this.CurrentStatus.Location = new System.Drawing.Point(0, 309);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(812, 22);
            this.CurrentStatus.TabIndex = 1;
            this.CurrentStatus.Text = "statusStrip11111111111111";
            // 
            // CurrentStatusLabel
            // 
            this.CurrentStatusLabel.Name = "CurrentStatusLabel";
            this.CurrentStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.CurrentStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // SyncResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 331);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.SyncJIRATable);
            this.Name = "SyncResults";
            this.Text = "Синхронизация";
            this.Load += new System.EventHandler(this.SyncResults_Load);
            this.CurrentStatus.ResumeLayout(false);
            this.CurrentStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView SyncJIRATable;
        private System.Windows.Forms.ColumnHeader TaskNumber;
        private System.Windows.Forms.ColumnHeader TaskName;
        private System.Windows.Forms.StatusStrip CurrentStatus;
        private System.Windows.Forms.ToolStripStatusLabel CurrentStatusLabel;
    }
}