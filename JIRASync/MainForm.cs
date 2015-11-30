using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JIRASync
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string p = Functions.ReadDocumentProperties(Params.JIRA_PROJECT_KEY);
            JiraProjectKeyList.Text = p != null ? p : "";
            p = Functions.ReadDocumentProperties(Params.USER_NAME_PROP);
            UserTextBox.Text = p != null ? p : "";
            p = Functions.ReadDocumentProperties(Params.USER_PASS_PROP);
            PassTextBox.Text = p != null ? p : "";
            string CIP = Functions.ReadDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP);
            CeptahInstallPathTextBox.Text = CIP != null ? CIP : Params.DEFAULT_CEPTAH_INSTALL_PATH;
            string jiraServerURL = Functions.GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl");
            JIRAServerUrlText.Text = jiraServerURL != null ? jiraServerURL : "";
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            string[] i = JiraProjectKeyList.SelectedItem != null ? JiraProjectKeyList.SelectedItem.ToString().Split(' ') : JiraProjectKeyList.Text.Split(' ');
            string ii = i[i.Length - 1].ToString();
            Functions.SetDocumentProperties(Params.JIRA_PROJECT_KEY, ii);
            Functions.SetDocumentProperties(Params.USER_NAME_PROP, UserTextBox.Text);
            Functions.SetDocumentProperties(Params.USER_PASS_PROP, PassTextBox.Text);
            Functions.SetDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP, CeptahInstallPathTextBox.Text);
            Functions.SetRegistryValue("HKEY_CURRENT_USER\\"+Params.CEPTAH_CONN_REG_KEY, "JiraURL", JIRAServerUrlText.Text, Microsoft.Win32.RegistryValueKind.DWord);
            Close();
        }

        private void JiraProjectKeyList_DropDown(object sender, EventArgs e)
        {
            string url = Functions.GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl");

            JiraProjectKeyList.Items.Clear();
            WebRequest request = WebRequest.Create(url+"/rest/api/2/project");
            string upass = Functions.Base64Encode(Functions.ReadDocumentProperties(Params.USER_NAME_PROP) + ":"+ Functions.ReadDocumentProperties(Params.USER_PASS_PROP));
            request.Headers.Add("Authorization", "Basic " + upass);
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = sr.ReadToEnd();
            object[] ob = (object[])(new JavaScriptSerializer().DeserializeObject(json));
            foreach (var o in ob)
            {
                ComboboxItem item = new ComboboxItem();
                Dictionary<string, object> l = (Dictionary<string, object>)o;
                item.Text = l["name"].ToString() + " - " + l["key"].ToString();
                item.Value = l["key"].ToString();
                JiraProjectKeyList.Items.Add(item);
            }
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}