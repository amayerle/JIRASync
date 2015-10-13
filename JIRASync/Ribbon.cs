using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace JIRASync
{
    public partial class Ribbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void RibbonImportButton_Click(object sender, RibbonControlEventArgs e)
        {
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            string CeptahProjectKey = Functions.ReadDocumentProperties(Params.CEPTAH_PROJECT_KEY_PROP);

            JIRASync.Functions.RunCeptah("i " + PrFullName + " /P:" + CeptahProjectKey);
        }

        private void RibbonJIRAConfigButton_Click(object sender, RibbonControlEventArgs e)
        {
            ConfigForm f = new ConfigForm();
            f.ShowDialog();
        }

        private void RibbonFromJIRAButton_Click(object sender, RibbonControlEventArgs e)
        {
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            string propName = Functions.FindpropNameByValue("ActualStart");
            if(propName == null)
            {
                MessageBox.Show("Некорректные настройки, свойство со значением ActualStart не найдено");
                return;
            }
            propName = propName.Replace("JiraField", "Direction");
            Functions.SetDocumentProperties(propName, "FromJira");
            propName = Functions.FindpropNameByValue("ActualFinish");
            if (propName == null)
            {
                MessageBox.Show("Некорректные настройки, свойство со значением ActualFinish не найдено");
                return;
            }
            propName = propName.Replace("JiraField", "Direction");
            Functions.SetDocumentProperties(propName, "FromJira");
            JIRASync.Functions.RunCeptah("s " + PrFullName);
        }

        private void RibbonToJIRAButton_Click(object sender, RibbonControlEventArgs e)
        {
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            string propName = Functions.FindpropNameByValue("ActualStart");
            if (propName == null)
            {
                MessageBox.Show("Некорректные настройки, свойство со значением ActualStart не найдено");
                return;
            }
            propName = propName.Replace("JiraField", "Direction");
            Functions.SetDocumentProperties(propName, "ToJira");
            propName = Functions.FindpropNameByValue("ActualFinish");
            if (propName == null)
            {
                MessageBox.Show("Некорректные настройки, свойство со значением ActualFinish не найдено");
                return;
            }
            propName = propName.Replace("JiraField", "Direction");
            Functions.SetDocumentProperties(propName, "ToJira");
            JIRASync.Functions.RunCeptah("s " + PrFullName);
        }
    }
}
