using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace KasraMobileMiddleware
{
    class DataVerification
    {
        FrmSetupInstallation FrmSetupInstallationObj { set; get; }

        public DataVerification(FrmSetupInstallation frmSetupInstallation)
        {
            FrmSetupInstallationObj = frmSetupInstallation;
        }

        public void ProjectPathVerification()
        {
            if (FrmSetupInstallationObj.FolderBrowserSelectedPath.StartsWith("C"))
                MessageBox.Show("!" + "باشد " + "C " + "درایو انتخاب شده نباید درایو ");
            else if (FrmSetupInstallationObj.FolderBrowserSelectedPath.Length != 3)
                MessageBox.Show("." + "را انتخاب کنید " + "C " + "در این قسمت فقط باید نام یک درایو به غیر از درایو ");
            else
                FrmSetupInstallationObj.ProjectPath = FrmSetupInstallationObj.FolderBrowserSelectedPath;
        }

        public void PublishPathVerification()
        {
            if (FrmSetupInstallationObj.FolderBrowserSelectedPath.StartsWith("C"))
                MessageBox.Show("!" + "باشد" + " C " + "مسیر پابلیش نباید در درایو ");
            else
                FrmSetupInstallationObj.PublishPath = FrmSetupInstallationObj.FolderBrowserSelectedPath;
        }

        // This method connects to the IIS and checks the website names available in it
        // to find out if the 'websiteName' string is equal to any one of them or not. It does so for app pools.
        // If it finds equality, the field related to the website name will get cleared.
        private string WebsiteNameVerification()
        {
            if (FrmSetupInstallationObj.WebsiteName == string.Empty)
                return "!" + "نام سایت انتخاب نشده";
            else
            {
                bool websiteNameExists = false;
                ApplicationPool appPool;

                using (ServerManager manager = new ServerManager())
                {
                    websiteNameExists = manager.Sites.Any(t => t.Name == FrmSetupInstallationObj.WebsiteName);
                    appPool = manager.ApplicationPools[FrmSetupInstallationObj.WebsiteName];
                }
                string message = "";
                if (websiteNameExists)
                {
                    FrmSetupInstallationObj.WebsiteName = string.Empty;
                    message = "!" + "وبسایتی با این نام در سرور موجود است";
                }
                if (appPool != null)
                {
                    FrmSetupInstallationObj.WebsiteName = string.Empty;
                    message += "\n!" + "با این نام در سرور موجود است" + " pool";
                    return message;
                }
                return string.Empty;
            }
        }

        // This method checks if the port number is valid integer and then checks for its availability.
        private string PortNumberVerification()
        {
            int portNumber = 0;
            if (FrmSetupInstallationObj.PortNumber == string.Empty)
                return "!" + "پورت انتخاب نشده";

            else if (!int.TryParse(FrmSetupInstallationObj.PortNumber, out portNumber))
            {
                FrmSetupInstallationObj.PortNumber = string.Empty;
                return "!" + "عدد پورت اشتباه است";
            }
            else
            {
                IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
                bool result = ipEndPoints.ToList().Any(x => x.Port == portNumber);
                if (result)
                {
                    FrmSetupInstallationObj.PortNumber = string.Empty;
                    return "!" + "این پورت در دسترس نیست لطفا شماره ی دیگری انتخاب کنید";
                }
                return string.Empty;
            }
        }

        // This method checks the connectability to the database.
        public void DatabaseConnectabilityVerification()
        {
            try
            {
                // Try to open the SQL server using the connection string.
                string connectionString = "Password=" + FrmSetupInstallationObj.DatabasePassword + ";Persist Security Info=True;User ID=" + FrmSetupInstallationObj.DatabaseUsername + ";Initial Catalog=master" + ";Data Source=" + FrmSetupInstallationObj.DatabaseInstanceName;
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();

                // Get the list of the databases in the server and check whether the given name is contained or not.
                List<string> list = GetDatabaseList(cnn);

                // This valriable turns to true if a database with the same name exists.
                bool databaseExists = false;
                // This variable will hold the database name which is equivalent to the given name.
                string databaseName = "";
                // The database names musn't be the same even if their characters differ in being lower or upper case.
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToLower() == FrmSetupInstallationObj.DatabaseName.ToLower())
                    {
                        databaseExists = true;
                        databaseName = list[i];
                        break;
                    }
                }
                if (databaseExists)
                {
                    
                    MessageBox.Show("!" + "دیتابیس در سرور موجود است" + "." + "لطفا نام دیگری انتخاب کنید");
                    //
                    FrmSetupInstallationObj.DatabaseName = string.Empty;
                }
                else
                    MessageBox.Show("." + "اتصال تایید شد");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static List<string> GetDatabaseList(SqlConnection cnn)
        {
            List<string> list = new List<string>();
            using (SqlCommand cmd = new SqlCommand("SELECT name from master.sys.databases", cnn))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr[0].ToString());
                    }
                }
            }
            return list;
        }
        public string FinalVerification()
        {
            // Create the final verification string.
            string finalMessage = string.Empty;

            // Add the port number verification message if it is not empty.
            string portNumberMessage = PortNumberVerification();
            if (portNumberMessage != string.Empty)
                finalMessage += portNumberMessage + "\n";

            // Add the website name verification message if it is not empty.
            string websiteNameMessage = WebsiteNameVerification();
            if (websiteNameMessage != string.Empty)
                finalMessage += websiteNameMessage + "\n";

            // Add the publish path verification message if it is not empty.
            string publishPathMessage = (FrmSetupInstallationObj.PublishPath == string.Empty) ? "!" + "مسیر پابلیش انتخاب نشده\n" : string.Empty;
            if (publishPathMessage != string.Empty)
                finalMessage += publishPathMessage;

            // Add the project path verification message if it is not empty.
            string projectPathMessage = (FrmSetupInstallationObj.ProjectPath == string.Empty) ? "!" + "مسیر پروژه انتخاب نشده\n" : string.Empty;
            if (projectPathMessage != string.Empty)
                finalMessage += projectPathMessage;

            // If the final verification message is not enmty, return it.
            if (finalMessage != string.Empty)
                return finalMessage;

            // Otherwise an empty string is returned.
            return string.Empty;
        }
    }
}
