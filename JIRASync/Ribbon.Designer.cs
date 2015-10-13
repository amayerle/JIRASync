namespace JIRASync
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.JIRASyncGroup = this.Factory.CreateRibbonGroup();
            this.RibbonImportButton = this.Factory.CreateRibbonButton();
            this.RibbonFromJIRAButton = this.Factory.CreateRibbonButton();
            this.RibbonToJIRAButton = this.Factory.CreateRibbonButton();
            this.RibbonJIRAConfigButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.JIRASyncGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.JIRASyncGroup);
            this.tab1.Label = "JIRA";
            this.tab1.Name = "tab1";
            // 
            // JIRASyncGroup
            // 
            this.JIRASyncGroup.Items.Add(this.RibbonImportButton);
            this.JIRASyncGroup.Items.Add(this.RibbonFromJIRAButton);
            this.JIRASyncGroup.Items.Add(this.RibbonToJIRAButton);
            this.JIRASyncGroup.Items.Add(this.RibbonJIRAConfigButton);
            this.JIRASyncGroup.Label = "Синхронизация";
            this.JIRASyncGroup.Name = "JIRASyncGroup";
            // 
            // RibbonImportButton
            // 
            this.RibbonImportButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RibbonImportButton.Image = ((System.Drawing.Image)(resources.GetObject("RibbonImportButton.Image")));
            this.RibbonImportButton.Label = "Импорт";
            this.RibbonImportButton.Name = "RibbonImportButton";
            this.RibbonImportButton.ShowImage = true;
            this.RibbonImportButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RibbonImportButton_Click);
            // 
            // RibbonFromJIRAButton
            // 
            this.RibbonFromJIRAButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RibbonFromJIRAButton.Image = ((System.Drawing.Image)(resources.GetObject("RibbonFromJIRAButton.Image")));
            this.RibbonFromJIRAButton.Label = "Из JIRA";
            this.RibbonFromJIRAButton.Name = "RibbonFromJIRAButton";
            this.RibbonFromJIRAButton.ShowImage = true;
            this.RibbonFromJIRAButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RibbonFromJIRAButton_Click);
            // 
            // RibbonToJIRAButton
            // 
            this.RibbonToJIRAButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RibbonToJIRAButton.Image = ((System.Drawing.Image)(resources.GetObject("RibbonToJIRAButton.Image")));
            this.RibbonToJIRAButton.Label = "В JIRA";
            this.RibbonToJIRAButton.Name = "RibbonToJIRAButton";
            this.RibbonToJIRAButton.ShowImage = true;
            this.RibbonToJIRAButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RibbonToJIRAButton_Click);
            // 
            // RibbonJIRAConfigButton
            // 
            this.RibbonJIRAConfigButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RibbonJIRAConfigButton.Image = ((System.Drawing.Image)(resources.GetObject("RibbonJIRAConfigButton.Image")));
            this.RibbonJIRAConfigButton.Label = "Настройки";
            this.RibbonJIRAConfigButton.Name = "RibbonJIRAConfigButton";
            this.RibbonJIRAConfigButton.ShowImage = true;
            this.RibbonJIRAConfigButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RibbonJIRAConfigButton_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Project.Project";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.JIRASyncGroup.ResumeLayout(false);
            this.JIRASyncGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup JIRASyncGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonJIRAConfigButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonImportButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonFromJIRAButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonToJIRAButton;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon1
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
