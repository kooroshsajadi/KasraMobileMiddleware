using System;
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
        public string DatabaseName { set; get; }
        public string DatabaseInstanceName { set; get; }
        public string DatabaseUsername { set; get; }
        public string DatabasePassword { set; get; }

        private SynchronizationContext synchronizationContext;
        public FrmInstallationProcess(string websiteName, string portNumber, string publishPath, string projectPath, string databaseName, string databaseInstanceName, string databaseUsername, string databasePassword)
        {
            WebsiteName = websiteName;
            PortNumber = portNumber;
            PublishPath = publishPath;
            ProjectPath = projectPath;
            DatabaseName = databaseName;
            DatabaseInstanceName = databaseInstanceName;
            DatabaseUsername = databaseUsername;
            DatabasePassword = databasePassword;
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
                    FileManager fileManager = new FileManager(this);
                    fileManager.CopyAndLog();
                    Installation installation = new Installation(this);
                    installation.ConfigureWebsiteAndLog();
                    fileManager.RestoreDatabaseAndLog();
                    fileManager.SaveTheLogAndLog();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}