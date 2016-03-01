using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace JIRASync
{
    
    class Functions
    {
        public static string TempPass = "";
        public static string CeptahOutput = "";
        public static string RunCeptah(string command)
        {
            CeptahOutput = "";

            string ExePath = ReadDocumentProperties(Params.CEPTAH_INSTALL_PATH_PROP);
            if (ExePath == null)
            {
                ExePath = Params.DEFAULT_CEPTAH_INSTALL_PATH;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = ExePath + "mspjb.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            UpdatePass();
            startInfo.Arguments = command + " /U:" + ReadDocumentProperties(Params.USER_NAME_PROP) + " /PW:" + TempPass;
            
            using (Process pp = new Process())
            {
                pp.StartInfo = startInfo;
                pp.Start();
                pp.BeginOutputReadLine();
                pp.OutputDataReceived += P_OutputDataReceived;
            }
            return "";
        }

        internal static string GetRegistryValue(string path, string prop)
        {
            string v = "";
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path))
                {
                    if (key != null)
                    {
                        object o = key.GetValue(prop);
                        if (o != null)
                        {
                            v = o.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return v;
        }
        internal static void SetRegistryValue(string path, string name, string value, RegistryValueKind type)
        {
            Registry.SetValue(path, name, value);
        }

        private static void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CeptahOutput += e.Data + "\r\n";
            if (e.Data != null)
            {
                if (e.Data.Contains("Command-line tool finished"))
                {
                    MessageBox.Show(CeptahOutput);
                    Ribbon.RenewTasks();
                }
                else
                {
                    //MessageBox.Show(CeptahOutput);
                }
            }
        }

        public static string ReadDocumentProperties(string propName)
        {
            Microsoft.Office.Core.DocumentProperties properties;
            properties = Globals.ThisAddIn.Application.ActiveProject.CustomDocumentProperties;

            foreach (Microsoft.Office.Core.DocumentProperty prop in properties)
            {
                if (prop.Name == propName)
                {
                    return prop.Value.ToString();
                }
            }
            return null;
        }
        public static string ReadDocumentProperties(string propName, Microsoft.Office.Core.DocumentProperties p)
        {
            Microsoft.Office.Core.DocumentProperties properties;
            properties = p;

            foreach (Microsoft.Office.Core.DocumentProperty prop in properties)
            {
                if (prop.Name == propName)
                {
                    return prop.Value.ToString();
                }
            }
            return null;
        }
        public static void UpdateXml(string file, string pr)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode root = doc.DocumentElement;
            XmlNode map = root.FirstChild;
            XmlNode prNode = null;
            foreach (XmlNode p in map.ChildNodes)
            {
                if (p.Name == "DefaultProjectKey")
                {
                    prNode = p;
                    break;
                }
            }
            prNode.InnerText = ReadDocumentProperties(pr);
            doc.Save(file);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string SetDocumentProperties(string PropName, string PropValue)
        {
            Microsoft.Office.Core.DocumentProperties prop;
            prop = Globals.ThisAddIn.Application.ActiveProject.CustomDocumentProperties;
            if (ReadDocumentProperties(PropName) != null)
            {
                prop[PropName].Delete();
            }
            prop.Add(PropName
                , false
                , Microsoft.Office.Core.MsoDocProperties.msoPropertyTypeString
                , PropValue);
            return ReadDocumentProperties(PropName);
        }
        public static string FindpropNameByValue(string PropValue)
        {
            Microsoft.Office.Core.DocumentProperties properties;
            properties = Globals.ThisAddIn.Application.ActiveProject.CustomDocumentProperties;
            foreach (Microsoft.Office.Core.DocumentProperty prop in properties)
            {
                if (prop.Value.ToString() == PropValue)
                {
                    return prop.Name.ToString();
                }
            }
            return null;
        }
        public static bool UpdatePass()
        {
            string result = "";
            if (TempPass == "")
            {
                if (InputBox.Show("Введите пароль", "Пароль:", ref result) == DialogResult.OK)
                {
                    if (result != "")
                    {
                        try
                        {
                            string url = GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl");
                            string user = ReadDocumentProperties(Params.USER_NAME_PROP);
                            string pass = result;
                            WebRequest request = WebRequest.Create(url + "/rest/api/2/project");
                            string upass = Base64Encode(user + ":" + pass);
                            request.Headers.Add("Authorization", "Basic " + upass);
                            request.ContentType = "application/json";
                            WebResponse response = request.GetResponse();
                            TempPass = result;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                    }
                }
            }
            if(result!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Dictionary<string, object> CreateProject(string Key, string Name)
        {
            try
            {
                string url = GetRegistryValue(Params.CEPTAH_CONN_REG_KEY, "JiraUrl");
                string user = ReadDocumentProperties(Params.USER_NAME_PROP);
                Microsoft.Office.Core.DocumentProperty p = (Microsoft.Office.Core.DocumentProperty)Globals.ThisAddIn.Application.ActiveProject.BuiltinDocumentProperties["Manager"];
                
                string pass = TempPass;

                string urlParameters = "projectname=" + HttpUtility.UrlEncode(Name.Replace(".mpp", ""))
                    + "&projectkey=" + Key.ToUpper()
                    + "&projectlead=" + user;
                    //+ "&projectdesc=" + HttpUtility.UrlEncode("Описание проекта");
                string FinishURL = url + "/rest/scriptrunner/latest/custom/createProject1?" + urlParameters;
                WebRequest request = WebRequest.Create(FinishURL);
                string upass = Base64Encode(user + ":" + pass);
                request.Headers.Add("Authorization", "Basic " + upass);
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Deserialize<Dictionary<string, object>>(sr.ReadToEnd());
                //MessageBox.Show(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                return null;
            }
        }
        public static string Translit(string str)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "C", "CH", "SH", "SHH", "\"", "Y", "'", "E", "Yu", "Ya" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "H", "C", "ch", "sh", "shh", "\"", "y", "'", "e", "yu", "ya" };
            string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (int i = 0; i <= 32; i++)
            {
                str = str.Replace(rus_up[i], lat_up[i]);
                str = str.Replace(rus_low[i], lat_low[i]);
            }
            return str;
        }
    }
    class InputBox
    {
        /// <summary>
        /// Displays a dialog with a prompt and textbox where the user can enter information
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="promptText">Dialog prompt</param>
        /// <param name="value">Sets the initial value and returns the result</param>
        /// <returns>Dialog result</returns>
        public static DialogResult Show(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            textBox.UseSystemPasswordChar = true;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 18, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
