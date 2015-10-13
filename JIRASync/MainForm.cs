using Microsoft.Win32;
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
            string p = Functions.ReadDocumentProperties(Params.CEPTAH_PROJECT_KEY_PROP);
            JiraProjectKeyList.Text = p != null ? p : "";

            string CIP = Functions.ReadDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP);
            CeptahInstallPathTextBox.Text = CIP != null ? CIP : Params.DEFAULT_CEPTAH_INSTALL_PATH;
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            string[] i = JiraProjectKeyList.SelectedItem != null ? JiraProjectKeyList.SelectedItem.ToString().Split(' ') : JiraProjectKeyList.Text.Split(' ');
            string ii = i[i.Length - 1].ToString();
            Functions.SetDocumentProperties(Params.CEPTAH_PROJECT_KEY_PROP, ii);
            
            Functions.SetDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP, CeptahInstallPathTextBox.Text);

            this.Close();
        }

        private void JiraProjectKeyList_DropDown(object sender, EventArgs e)
        {
            string url = "";
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Ceptah\\MspJiraBridge"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("JiraUrl");
                        if (o != null)
                        {
                            url = o.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            JiraProjectKeyList.Items.Clear();
            WebRequest request = WebRequest.Create(url);
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