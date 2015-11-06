using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace JIRASync
{
    class Functions
    {
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
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = ExePath + "mspjb.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = command + " /U:" + Functions.ReadDocumentProperties(Params.USER_NAME_PROP) + " /PW:"+ Functions.ReadDocumentProperties(Params.USER_PASS_PROP);
            
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
                        Object o = key.GetValue(prop);
                        if (o != null)
                        {
                            v = o.ToString();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return v;
        }

        private static void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CeptahOutput += e.Data + "\r\n";
            if (e.Data!=null)
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
            prNode.InnerText = Functions.ReadDocumentProperties(pr);
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
            if (Functions.ReadDocumentProperties(PropName) != null)
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
    }
}
