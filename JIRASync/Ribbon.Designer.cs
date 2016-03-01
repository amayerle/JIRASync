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
            this.SyncJIRAButton = this.Factory.CreateRibbonButton();
            this.ExportRibbon = this.Factory.CreateRibbonButton();
            this.RibbonJIRAConfigButton = this.Factory.CreateRibbonButton();
            this.RibbonUserButtons = this.Factory.CreateRibbonGroup();
            this.ChooseUserButton = this.Factory.CreateRibbonButton();
            this.Подготовка = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.CreateProjectButtonRibbon = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.JIRASyncGroup.SuspendLayout();
            this.RibbonUserButtons.SuspendLayout();
            this.Подготовка.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.JIRASyncGroup);
            this.tab1.Groups.Add(this.RibbonUserButtons);
            this.tab1.Groups.Add(this.Подготовка);
            this.tab1.Label = "JIRA";
            this.tab1.Name = "tab1";
            // 
            // JIRASyncGroup
            // 
            this.JIRASyncGroup.Items.Add(this.SyncJIRAButton);
            this.JIRASyncGroup.Items.Add(this.ExportRibbon);
            this.JIRASyncGroup.Items.Add(this.RibbonJIRAConfigButton);
            this.JIRASyncGroup.Label = "Синхронизация";
            this.JIRASyncGroup.Name = "JIRASyncGroup";
            // 
            // SyncJIRAButton
            // 
            this.SyncJIRAButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SyncJIRAButton.Enabled = false;
            this.SyncJIRAButton.Image = ((System.Drawing.Image)(resources.GetObject("SyncJIRAButton.Image")));
            this.SyncJIRAButton.Label = "Синхронизировать";
            this.SyncJIRAButton.Name = "SyncJIRAButton";
            this.SyncJIRAButton.ShowImage = true;
            this.SyncJIRAButton.Visible = false;
            this.SyncJIRAButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SyncJIRAButton_Click);
            // 
            // ExportRibbon
            // 
            this.ExportRibbon.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportRibbon.Image = ((System.Drawing.Image)(resources.GetObject("ExportRibbon.Image")));
            this.ExportRibbon.Label = "Экспорт";
            this.ExportRibbon.Name = "ExportRibbon";
            this.ExportRibbon.ShowImage = true;
            this.ExportRibbon.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportRibbon_Click);
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
            // RibbonUserButtons
            // 
            this.RibbonUserButtons.Items.Add(this.ChooseUserButton);
            this.RibbonUserButtons.Label = "Пользователи";
            this.RibbonUserButtons.Name = "RibbonUserButtons";
            // 
            // ChooseUserButton
            // 
            this.ChooseUserButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ChooseUserButton.Label = "Выбор исполнителя";
            this.ChooseUserButton.Name = "ChooseUserButton";
            this.ChooseUserButton.ShowImage = true;
            this.ChooseUserButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ChooseUserButton_Click);
            // 
            // Подготовка
            // 
            this.Подготовка.Items.Add(this.button1);
            this.Подготовка.Items.Add(this.CreateProjectButtonRibbon);
            this.Подготовка.Label = "Подготовка";
            this.Подготовка.Name = "Подготовка";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Label = "Подготовить проект для JIRA";
            this.button1.Name = "button1";
            this.button1.Visible = false;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // CreateProjectButtonRibbon
            // 
            this.CreateProjectButtonRibbon.Label = "Создать проект";
            this.CreateProjectButtonRibbon.Name = "CreateProjectButtonRibbon";
            this.CreateProjectButtonRibbon.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CreateProjectButtonRibbon_Click);
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
            this.RibbonUserButtons.ResumeLayout(false);
            this.RibbonUserButtons.PerformLayout();
            this.Подготовка.ResumeLayout(false);
            this.Подготовка.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup JIRASyncGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RibbonJIRAConfigButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportRibbon;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup RibbonUserButtons;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ChooseUserButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Подготовка;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SyncJIRAButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CreateProjectButtonRibbon;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon1
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
