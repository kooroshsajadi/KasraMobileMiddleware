using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasraMobileMiddleware
{
    public partial class FrmInstallationProcess : Form
    {
        public string PublishPath { set; get; }
        public string WebsiteName { set; get; }
        public string PortNumber { set; get; }
        public string ProjectPath { set; get; }
        public string MobileDatabaseName { set; get; }
        public string MobileDatabaseAddress { set; get; }
        public string MobileDatabaseUsername { set; get; }
        public string MobileDatabasePassword { set; get; }
        public string KasraWebsiteDatabaseName { set; get; }
        public string KasraWebsiteDatabaseAddress { set; get; }
        public string KasraWebsiteDatabaseUsername { set; get; }
        public string KasraWebsiteDatabasePassword { set; get; }

        private SynchronizationContext synchronizationContext;
        public FrmInstallationProcess(string websiteName, string portNumber, string publishPath, string projectPath, string mobileDatabaseName, string mobileDatabaseAddress, string mobileDatabaseUsername, string mobileDatabasePassword, string kasraDatabaseName, string kasraDatabaseAddress, string kasraDatabaseUsername, string kasraDatabasePassword)
        {
            WebsiteName = websiteName;
            PortNumber = portNumber;
            PublishPath = publishPath;
            ProjectPath = projectPath;
            MobileDatabaseName = mobileDatabaseName;
            MobileDatabaseAddress = mobileDatabaseAddress;
            MobileDatabaseUsername = mobileDatabaseUsername;
            MobileDatabasePassword = mobileDatabasePassword;
            KasraWebsiteDatabaseName = kasraDatabaseName;
            KasraWebsiteDatabaseAddress = kasraDatabaseAddress;
            KasraWebsiteDatabaseUsername = kasraDatabaseUsername;
            KasraWebsiteDatabasePassword = kasraDatabasePassword;
            InitializeComponent();
        }
        public int ProgressBarValue
        {
            get { return ProgressBarInstallation.Value; }
            set
            {
                synchronizationContext.Post(o =>
                {
                    ProgressBarInstallation.Value = int.Parse(o.ToString());
                }, value);
            }
        }
        public string TextAppend
        {
            get { return TextBxLog.Text; }
            set
            {
                synchronizationContext.Post(o =>
                {
                    TextBxLog.AppendText(o.ToString());
                }, value);
            }
        }

        private void FrmInstallationProcess_Load(object sender, EventArgs e)
        {
            try
            {
                synchronizationContext = SynchronizationContext.Current;
                Task.Run(() => 
                {
                    // Create the flag in order not to continue the process if there is an error.
                    bool flag = true;

                    // Create the root destination directory.
                    Directory.CreateDirectory($"{ProjectPath}\\{WebsiteName}");

                    // Create the destination directory.
                    string dir = $"{ProjectPath}\\{WebsiteName}\\Project";

                    FileManager fileManager = new FileManager(this);
                    flag = fileManager.CopyAndLog($"{PublishPath}\\App", dir);
                    Installation installation = new Installation(this);
                    if (flag)
                        flag = installation.ConfigureWebsiteAndLog();
                    if (flag)
                    {
                        // Create the MDF and LDF files directory.
                        dir = $"{ProjectPath}\\{WebsiteName}\\Data";
                        Directory.CreateDirectory(dir);

                        flag = fileManager.RestoreDatabaseAndLog(PortNumber, PublishPath, MobileDatabaseName, MobileDatabaseAddress, MobileDatabaseUsername, MobileDatabasePassword, dir);
                    }
                    if (flag)
                        flag = fileManager.SaveTheLogAndLog();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}