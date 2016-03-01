using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Functions.SetDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP, CeptahInstallPathTextBox.Text);
            Functions.SetRegistryValue("HKEY_CURRENT_USER\\" + Params.CEPTAH_CONN_REG_KEY, "JiraURL", JIRAServerUrlText.Text, Microsoft.Win32.RegistryValueKind.DWord);
            Close();
        }

        private void JiraProjectKeyList_DropDown(object sender, EventArgs e)
        {
            string username = "";
            string url = "";
            if (Functions.ReadDocumentProperties(Params.USER_NAME_PROP) == null)
            {
                if (UserTextBox.Text != null && UserTextBox.Text != "")
                {
                    username = UserTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Не заполнено поле \"Пользователь\"");
                    return;
                }
            }
            else
            {
                username = Functions.ReadDocumentProperties(Params.USER_NAME_PROP);
            }
            if (Functions.GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl") == "")
            {
                if (JIRAServerUrlText.Text != null && JIRAServerUrlText.Text != "")
                {
                    url = JIRAServerUrlText.Text;
                }
                else
                {
                    MessageBox.Show("Не заполнено поле \"Пользователь\"");
                    return;
                }
            }
            else
            {
                url = Functions.GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl");
            }
            Functions.SetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl", url, Microsoft.Win32.RegistryValueKind.String);
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("username", username);
            args.Add("url", url);
            Functions.UpdatePass();
            args.Add("pass", Functions.TempPass);
            RefreshProjectWorker.ProgressChanged += UpdateProjectList;
            RefreshProjectWorker.RunWorkerCompleted += WorkDone;
            RefreshProjectWorker.RunWorkerAsync(args);
        }

        private void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            JiraProjectKeyList.Items.Clear();
            List<ComboboxItem> items = (List<ComboboxItem>)e.Result;
            if (items != null)
            {
                foreach (ComboboxItem i in items)
                {
                    JiraProjectKeyList.Items.Add(i);
                }
            }
        }

        private void UpdateProjectList(object sender, ProgressChangedEventArgs e)
        {
        }

        private void RefreshProjectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Dictionary<string, string> args = (Dictionary<string, string>)e.Argument;
                string url = args["url"];
                string user = args["username"];
                string pass = args["pass"];

                WebRequest request = WebRequest.Create(url + "/rest/api/2/project");
                string upass = Functions.Base64Encode(user + ":" + pass);
                request.Headers.Add("Authorization", "Basic " + upass);
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = sr.ReadToEnd();
                object[] ob = (object[])(new JavaScriptSerializer().DeserializeObject(json));
                List<ComboboxItem> items = new List<ComboboxItem>();
                foreach (var o in ob)
                {
                    ComboboxItem item = new ComboboxItem();
                    Dictionary<string, object> l = (Dictionary<string, object>)o;
                    item.Text = l["name"].ToString() + " - " + l["key"].ToString();
                    item.Value = l["key"].ToString();
                    items.Add(item);
                }
                e.Result = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SaveConfigButton_Click(this, new EventArgs());
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