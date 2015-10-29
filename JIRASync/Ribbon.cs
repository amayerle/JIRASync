using Microsoft.Office.Interop.MSProject;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

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
            string PrFullName = Globals.ThisAddIn.Application.ActiveProject.FullName;
            Functions.RunCeptah("s " + PrFullName);
        }
    }
}
