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
            string p = Functions.ReadDocumentProperties("MspJiraAddInProjectSettings.Mappings.DefaultProjectKey");
            JiraProjectKeyList.Text = p != null ? p : "";
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            string[] i = JiraProjectKeyList.SelectedItem != null ? JiraProjectKeyList.SelectedItem.ToString().Split(' ') : JiraProjectKeyList.Text.Split(' ');
            string ii = i[i.Length - 1].ToString();
            Functions.SetDocumentProperties("MspJiraAddInProjectSettings.Mappings.DefaultProjectKey", ii);
        }

        private void JiraProjectKeyList_DropDown(object sender, EventArgs e)
        {
            JiraProjectKeyList.Items.Clear();
            WebRequest request = WebRequest.Create(@"http://teststand01.bell-main.bellintegrator.ru:8080/rest/api/2/project");
            string upass = Functions.Base64Encode("pm:pm");
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