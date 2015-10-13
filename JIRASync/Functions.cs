using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JIRASync
{
    class Functions
    {
        public static string RunCeptah(string command)
        {
            string ExePath = ReadDocumentProperties("CeptahInstallPath");
            const string ex1 = @"C:\Program Files (x86)\Ceptah\Msp JIRA Bridge\";
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = ex1 + "mspjb.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = command;
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    //exeProcess.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
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
