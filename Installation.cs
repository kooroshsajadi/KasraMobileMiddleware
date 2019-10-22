using Microsoft.Web.Administration;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KasraMobileMiddleware
{
    class Installation
    {
        FrmInstallationProcess FrmInstallationProcessObj { set; get; }
        public Installation(FrmInstallationProcess frmInstallationProcessObj)
        {
            FrmInstallationProcessObj = frmInstallationProcessObj;
        }
        public bool ConfigureMobileWebsiteAndLog()
        {
            try
            {
                // We make a sever manager to get access to the IIS.
                ServerManager serverManager = new ServerManager();

                // Create a pool in order to add the upcoming application to it. The pool's name is the same as the website name.
                ApplicationPool appPool = serverManager.ApplicationPools.Add(FrmInstallationProcessObj.WebsiteName);

                // Enable 32-bit applications.
                appPool.Enable32BitAppOnWin64 = true;

                // Create the customized website where the app files are stored(in the 'websitePhysicalPath').
                string websitePhysicalPath = FrmInstallationProcessObj.ProjectPath + FrmInstallationProcessObj.WebsiteName + "\\Project";
                Site mySite = serverManager.Sites.Add(FrmInstallationProcessObj.WebsiteName, "http", "*:" + FrmInstallationProcessObj.PortNumber + ":", websitePhysicalPath);

                // Add the website and its applications to the pool.
                mySite.ApplicationDefaults.ApplicationPoolName = FrmInstallationProcessObj.WebsiteName;

                // Add the 'WebServices' app.
                string appPhysicalPath = websitePhysicalPath + "\\KasraWebService";
                mySite.Applications.Add("/KasraWebService", appPhysicalPath);
                // Change its web config file.
                ChangeWebServiceWebConfig(appPhysicalPath + "\\Web.config", FrmInstallationProcessObj.KasraWebsiteDatabaseName, FrmInstallationProcessObj.KasraWebsiteDatabasePassword);

                // Add the 'MobileMiddleWare' app.
                appPhysicalPath = websitePhysicalPath + "\\MobileMiddleWare";
                mySite.Applications.Add("/MobileMiddleWare", appPhysicalPath);
                // Change its web config file.
                string connectionString = "Data Source=" + FrmInstallationProcessObj.MobileDatabaseAddress + ";" + FrmInstallationProcessObj.MobileDatabaseName + ";MultipleActiveResultSets=true;persist security info=True;User ID=" + FrmInstallationProcessObj.MobileDatabaseUsername + ";Password=" + FrmInstallationProcessObj.MobileDatabasePassword + ";Max Pool Size=300;";
                string pathToWebConfiog = appPhysicalPath + "\\Web.config";
                ChangeMobileMiddlewareWebConfig(connectionString, pathToWebConfiog);

                serverManager.CommitChanges();

                // Log that the website creation was a success.
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nسایت با موفقیت بارگزاری شد.\r\n\r\n";
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داد");
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nتوقف برنامه. خطای زیر رخ داده است:\r\n";
                FrmInstallationProcessObj.TextAppend = $"{ex.Message}\r\n\r\n";
                FileManager fileManager = new FileManager();
                fileManager.SaveTheLogAndLog();
                return false;
            }
        }
        private void ChangeWebServiceWebConfig(string PathToWebConfig, string databseName, string databaseAddress)
        {
            try
            {
                XDocument config = XDocument.Load(PathToWebConfig);
                XElement targetNode = config.Root.Element("appSettings").Elements("add").SingleOrDefault(x => x.FirstAttribute.Value == "DataSource");
                targetNode.LastAttribute.Value = databaseAddress;
                XElement targetNodePw = config.Root.Element("appSettings").Elements("add").SingleOrDefault(x => x.FirstAttribute.Value == "InitialCatalog");
                targetNodePw.LastAttribute.Value = databseName;
                var targetNodeAddress = config.Root.Element("appSettings").Elements("add").SingleOrDefault(x => x.FirstAttribute.Value == "BaseCatalog");
                targetNodeAddress.LastAttribute.Value = databseName;

                config.Save(PathToWebConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ChangeMobileMiddlewareWebConfig(string connectionString, string pathToWebConfig)
        {
            XDocument config = XDocument.Load(pathToWebConfig);

            // Find the 'connectionStringGeneral' in the connectionStrings section.
            XElement targetNode = config.Root.Element("connectionStrings").Elements("add").SingleOrDefault(x => x.FirstAttribute.Value == "connectionStringGeneral");
            
            // Change the targeted connectionString
            targetNode.LastAttribute.Value = connectionString;

            config.Save(pathToWebConfig);
            
        }
    }
}