using Microsoft.Office.Interop.MSProject;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Xml;

namespace JIRASync
{
    public partial class Ribbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void RibbonJIRAConfigButton_Click(object sender, RibbonControlEventArgs e)
        {
            ConfigForm f = new ConfigForm();
            f.ShowDialog();
        }

        private void SyncJIRAButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (Functions.ReadDocumentProperties(Params.JIRA_PROJECT_KEY) == null)
            {
                MessageBox.Show("Не указан код проекта");
                return;
            }
            Functions.UpdateXml("C:\\Ceptah\\Sync.xml", Params.JIRA_PROJECT_KEY);
            string User = Functions.GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "User");
            
            foreach (Task t in Globals.ThisAddIn.Application.ActiveProject.Tasks)
            {
                if (HasAssignedSubTask(t) && t.HyperlinkHREF != "")
                {
                    t.Text10 = "SKIP";
                }
                else
                {
                    if (HasAssignedSubTask(t) && t.HyperlinkHREF == "" && t.Text11 != "Проект")
                    {
                        t.Text10 = "";
                        t.Text11 = "Задача-группировка";
                        t.Text12 = User;
                    }
                }
            }
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            Functions.RunCeptah("s \"" + PrFullName + "\" /S:C:\\Ceptah\\Sync.xml");
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
        public static void RenewTasks()
        {
            foreach (Task t in Globals.ThisAddIn.Application.ActiveProject.Tasks)
            {
                if (t.Text10 == "SKIP" && t.Text12 != "")
                {
                    string[] key = t.HyperlinkHREF.Split('/');
                    t.Text10 = key[key.Length - 1];
                }
            }
        }

        private void ExportRibbon_Click(object sender, RibbonControlEventArgs e)
        {
            foreach (Task t in Globals.ThisAddIn.Application.ActiveProject.Tasks)
            {
                if (t.Text10 == "SKIP" || t.Text10 == "")
                {
                    string[] key = t.HyperlinkHREF.Split('/');
                    t.Text10 = key[key.Length - 1];
                }
            }
            if (Functions.ReadDocumentProperties(Params.JIRA_PROJECT_KEY)==null)
            {
                MessageBox.Show("Не указан код проекта");
                return;
            }
            Functions.UpdateXml("C:\\Ceptah\\Export.xml", Params.JIRA_PROJECT_KEY);
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            Functions.RunCeptah("s \"" + PrFullName + "\" /S:C:\\Ceptah\\Export.xml");
        }
    }
}
