using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace KasraMobileMiddleware
{
    public partial class FrmSetupInstallation : Form
    {
        // This getter gets the selected path received by the 'FolderBrowserDialogPaths'.
        public string FolderBrowserSelectedPath
        {
            get { return FolderBrowserDialogPath.SelectedPath; }
        }

        public string ProjectPath
        {
            set { TxtBxProjectPath.Text = value; }

            get { return TxtBxProjectPath.Text; }
        }

        public string PublishPath
        {
            set { TxtBxPublishPath.Text = value; }

            get { return TxtBxPublishPath.Text; }
        }

        public string WebsiteName
        {
            get { return TxtBxWebsiteName.Text; }
            set { TxtBxWebsiteName.Text = value; }
        }

        public string PortNumber
        {
            set { TxtBxPortNumber.Text = value; }
            get { return TxtBxPortNumber.Text; }
        }

        public string DatabaseName
        {
            set { TxtBxDatabaseName.Text = value; }
            get { return TxtBxDatabaseName.Text; }
        }

        public string DatabaseInstanceName
        {
            get { return TxtBxDatabaseInstanceName.Text; }
        }

        public string DatabaseUsername
        {
            get { return TxtBxDatabaseUsername.Text; }
        }

        public string DatabasePassword
        {
            get { return TxtBxDatabasePassword.Text; }
        }
        public FrmSetupInstallation()
        {
            InitializeComponent();
        }

        private void BtnBrowsePublishPath_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                DialogResult result = FolderBrowserDialogPath.ShowDialog();
                if (result == DialogResult.OK)
                    // The following invoked method checks if the address meets the circumstances
                    // then puts it in the publish path text box.
                    dataVerification.PublishPathVerification();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBrowseProjectPath_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                DialogResult result = FolderBrowserDialogPath.ShowDialog();
                if (result == DialogResult.OK)
                    // The following invoked method checks if the address meets the circumstances
                    // then puts it in the publish path text box.
                    dataVerification.ProjectPathVerification();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnVerification_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                dataVerification.DatabaseConnectabilityVerification();
                BtnInstallSoftware.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TxtBxDatabaseName.Text = string.Empty;
                TxtBxDatabaseInstanceName.Text = string.Empty;
                TxtBxDatabaseUsername.Text = string.Empty;
                TxtBxDatabasePassword.Text = string.Empty;
            }
        }

        private void BtnInstallSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                string verificationMessage = dataVerification.FinalVerification();
                if (verificationMessage.Equals(string.Empty))
                {
                    FrmInstallationProcess frmInstallationProcess = new FrmInstallationProcess(TxtBxWebsiteName.Text, TxtBxPortNumber.Text, TxtBxPublishPath.Text, TxtBxProjectPath.Text, TxtBxDatabaseName.Text, TxtBxDatabaseInstanceName.Text, TxtBxDatabaseUsername.Text, TxtBxDatabasePassword.Text);
                    frmInstallationProcess.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show(verificationMessage);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {

        }

        private void TxtBxDatabaseName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}