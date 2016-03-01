using Microsoft.Office.Interop.MSProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace JIRASync
{
    public partial class SyncResults : Form
    {
        public static string CeptahOutput { get; private set; }
        public static BackgroundWorker bw;
        public static ProcessStartInfo startInfo;
        public static Process pp;
        public static SyncResults f;
        public static string SyncType;
        public SyncResults()
        {
            InitializeComponent();
        }

        private void SyncResults_Load(object sender, EventArgs e)
        {
            f = this;
            string User = Functions.ReadDocumentProperties(Params.USER_NAME_PROP);
            if (User == "")
            {
                MessageBox.Show("Не заполнен пользователь во вкладке \"JIRA\"->\"Настройки\"");
                return;
            }
            Functions.UpdatePass();

            if (Functions.TempPass == "")
            {
                Close();
                return;
            }
            string CK = "";
            string Kod = "";
            string JiraKey = "";
            string title = Globals.ThisAddIn.Application.ActiveProject.Name;
            string NewPrName = "";
            try
            {
                PjField CKF;
                PjField KodF;
                try
                {
                    CKF = Globals.ThisAddIn.Application.FieldNameToFieldConstant("Центр цомпетенций");
                    CK = Globals.ThisAddIn.Application.ActiveProject.ProjectSummaryTask.GetField(CKF);
                }
                catch (System.Exception ex)
                {

                }
                try
                {
                    KodF = Globals.ThisAddIn.Application.FieldNameToFieldConstant("Шифр");
                    Kod = Globals.ThisAddIn.Application.ActiveProject.ProjectSummaryTask.GetField(KodF);
                }
                catch (System.Exception ex)
                {

                }
                NewPrName = CK != "" ? CK + " " : CK;
                NewPrName += Kod != "" ? Kod + " " : Kod;
                NewPrName += title;

                //MessageBox.Show(NewPrName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            JiraKey = Functions.Translit(Kod).Replace("-", "");
            string JiraKeyFromSettings = Functions.ReadDocumentProperties(Params.CEPTAH_PROJECT_KEY_PROP);
            if (JiraKeyFromSettings == null || JiraKeyFromSettings == "")
            {
                Dictionary<string, object> CreateProjectResult = Functions.CreateProject(JiraKey, NewPrName);
                if (CreateProjectResult == null)
                {
                    //MessageBox.Show("Не удаллось создать проект");
                    return;
                }
                else
                {
                    Dictionary<string, object> dict = CreateProjectResult;
                    if (CreateProjectResult["status"].ToString() == "error")
                    {

                        MessageBox.Show(CreateProjectResult["message"].ToString());
                        Close();
                        return;
                    }
                    Functions.SetDocumentProperties(Params.JIRA_PROJECT_KEY, JiraKey.ToUpper());
                    MessageBox.Show("Проект " + NewPrName + " создан");
                }
            }

            foreach (Task t in Globals.ThisAddIn.Application.ActiveProject.Tasks)
            {
                if (HasAssignedSubTask(t) && t.HyperlinkHREF != "")
                {
                    t.Text10 = "SKIP";
                }
                else
                {
                    if (HasAssignedSubTask(t)
                        && t.HyperlinkHREF == ""
                        && t.Text11 != "Проект"
                        && t.Text11 != "Заявка на развитие"
                        && t.Text11 != "Заявка на расширенное сопровождение")
                    {

                        t.Text11 = "Задача-группировка";
                        //MessageBox.Show("Не заполнено поле Тип задачи (Текст11)");
                        t.Text12 = User;
                    }
                    else
                    {
                        t.Text12 = User;
                    }
                }
            }
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;


            foreach (Task t in Globals.ThisAddIn.Application.ActiveProject.Tasks)
            {
                if (t.Text10 == "SKIP" || t.Text10 == "")
                {
                    string[] key = t.HyperlinkHREF.Split('/');
                    t.Text10 = key[key.Length - 1];
                }
            }
            if (Functions.ReadDocumentProperties(Params.JIRA_PROJECT_KEY) == null)
            {
                MessageBox.Show("Не указан код проекта");
                Close();
                return;
            }
            Functions.UpdateXml("C:\\Ceptah\\Export.xml", Params.JIRA_PROJECT_KEY);

            string ExePath = Functions.ReadDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP);
            if (ExePath == null)
            {
                ExePath = Params.DEFAULT_CEPTAH_INSTALL_PATH;
            }

            //Functions.RunCeptah("s \"" + PrFullName + "\" /S:C:\\Ceptah\\Export.xml");
            string command = "s \"" + PrFullName + "\" /S:C:\\Ceptah\\Export.xml";
            if (ExePath == null)
            {
                ExePath = Params.DEFAULT_CEPTAH_INSTALL_PATH;
            }
            startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = ExePath + "mspjb.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            startInfo.Arguments = command + " /U:" + Functions.ReadDocumentProperties(Params.USER_NAME_PROP) + " /PW:" + Functions.TempPass;
            pp = new Process();
            SyncJIRATable.View = System.Windows.Forms.View.Details;
            pp.StartInfo = startInfo;
            pp.Start();
            pp.BeginOutputReadLine();
            pp.OutputDataReceived += P_OutputDataReceived;
            CurrentStatusLabel.Text = "";
        }
        private bool HasAssignedSubTask(Task t)
        {
            bool r = false;
            foreach (Task subTask in t.OutlineChildren)
            {
                if (subTask.Text12 != "")
                {
                    r = true;
                    return r;
                }
                else
                {
                    r = HasAssignedSubTask(subTask);
                }
            }
            return r;
        }
        private static void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CeptahOutput += e.Data + "\r\n";

            if (e.Data != null)
            {
                string data = "";
                ListViewItem i = new ListViewItem("1");
                i.SubItems.Add(e.Data);
                string[] d = e.Data.Split('|');
                if (e.Data.Contains("Command-line tool started"))
                {
                    data = "Синхронизация начата";
                }
                if (e.Data.Contains("Identifying differences"))
                {
                    data = "Поиск различий";
                }
                if (e.Data.Contains("Applying changes"))
                {
                    data = "Применение изменений";
                }
                if (e.Data.Contains("No changes to apply."))
                {
                    data = "Нет изменений для применения";
                }
                if (f != null)
                {
                    f.CurrentStatusLabel.Text = data != null ? data : "";
                    f.SyncJIRATable.BeginInvoke((MethodInvoker)(() => f.SyncJIRATable.Items.Add(i)));
                }
                if (e.Data.Contains("Command-line tool finished"))
                {
                    //MessageBox.Show(CeptahOutput);
                    Ribbon.RenewTasks();
                }
                else
                {
                    //MessageBox.Show(CeptahOutput);
                }
            }
        }
    }
}
