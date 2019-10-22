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

        public bool ProjectPathVerification(string selectedPath)
        {
            if (selectedPath.StartsWith("C"))
            {
                MessageBox.Show("!" + "باشد " + "C " + "درایو انتخاب شده نباید درایو ");
                return false;
            }
            else if (selectedPath.Length != 3)
            {
                MessageBox.Show("." + "را انتخاب کنید " + "C " + "در این قسمت فقط باید نام یک درایو به غیر از درایو ");
                return false;
            }
            else
                return true;
        }

        public bool PublishPathVerification(string selectedPath)
        {
            if (selectedPath.StartsWith("C"))
            {
                MessageBox.Show("!" + "باشد" + " C " + "مسیر پابلیش نباید در درایو ");
                return false;
            }
            else
                return true;
        }

        // This method connects to the IIS and checks the website names available in it
        // to find out if the 'websiteName' string is equal to any one of them or not. It does so for app pools.
        // If it finds equality, the field related to the website name will get cleared.
        public string MobileWebsiteAndAppPoolNameVerification()
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
        public string PortNumberVerification()
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
        public bool MobileDatabaseConnectabilityVerification(string databaseName, string databaseAddress, string databaseUsername, string databasePassword, bool createDatabase)
        {
            try
            {
                // Try to open the SQL server using the connection string.
                string connectionString = "Password=" + databasePassword + ";Persist Security Info=True;User ID=" + databaseUsername + ";Initial Catalog=master" + ";Data Source=" + databaseAddress;
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();

                // Get the list of the databases in the server and check whether the given name is contained or not.
                List<string> list = GetDatabaseList(cnn);

                // This valriable turns to true if a database with the same name exists.
                bool databaseExists = false;
                // This variable will hold the database name which is equivalent to the given name.
                string existingDatabaseName = "";
                // The database names musn't be the same even if their characters differ in being lower or upper case.
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToLower() == databaseName.ToLower())
                    {
                        databaseExists = true;
                        existingDatabaseName = list[i];
                        break;
                    }
                }
                if (createDatabase && databaseExists)
                {
                    
                    MessageBox.Show("." + "در سرور موجود است" + "!" + " لطفا نام دیگری انتخاب کنید " + existingDatabaseName + " دیتابیس");
                    FrmSetupInstallationObj.MobileDatabaseName = string.Empty;
                    return false;
                }
                else if (!createDatabase && !databaseExists)
                {
                    MessageBox.Show("!" + "در سرور موجود نیست" + databaseName + " دیتابیس");
                    FrmSetupInstallationObj.MobileDatabaseName = string.Empty;
                    return false;
                }
                else
                {
                    MessageBox.Show("." + "اتصال تایید شد");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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
    }
}
