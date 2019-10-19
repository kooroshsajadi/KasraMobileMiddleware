using System;
using System.Windows.Forms;

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

        public string MobileDatabaseName
        {
            set { TxtBxMobileDatabaseName.Text = value; }
            get { return TxtBxMobileDatabaseName.Text; }
        }

        public string MobileDatabaseAddress
        {
            get { return TxtBxMobileDatabseAddress.Text; }
        }

        public string MobileDatabaseUsername
        {
            get { return TxtBxMobileDatabaseUsername.Text; }
        }

        public string MobileDatabsePassword
        {
            get { return TxtBxMobileDatabasePassword.Text; }
        }

        // Create two flags in order to check each database properties are verified or not.
        bool KasraMobileDatabaseFlag = false, KasraWebsiteDatabaseFlag = false;

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

        private void BtnMobileDatabaseVerification_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                KasraMobileDatabaseFlag = dataVerification.DatabaseConnectabilityVerification(TxtBxMobileDatabaseName.Text, TxtBxMobileDatabseAddress.Text, TxtBxMobileDatabaseUsername.Text, TxtBxMobileDatabasePassword.Text, true);
                if (KasraMobileDatabaseFlag && KasraWebsiteDatabaseFlag)
                {
                    BtnInstallSoftware.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TxtBxMobileDatabaseName.Text = string.Empty;
                TxtBxMobileDatabseAddress.Text = string.Empty;
                TxtBxMobileDatabaseUsername.Text = string.Empty;
                TxtBxMobileDatabasePassword.Text = string.Empty;
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
                    FrmInstallationProcess frmInstallationProcess = new FrmInstallationProcess(TxtBxWebsiteName.Text, TxtBxPortNumber.Text, TxtBxPublishPath.Text, TxtBxProjectPath.Text, TxtBxMobileDatabaseName.Text, TxtBxMobileDatabseAddress.Text, TxtBxMobileDatabaseUsername.Text, TxtBxMobileDatabasePassword.Text, TxtBxKasraWebsiteDatabaseName.Text, TxtBxKasraWebsiteDatabaseAddress.Text, TxtBxKasraWebsiteDatabaseUsername.Text, TxtBxKasraWebsiteDatabasePassword.Text);
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

        private void BtnKasraWebsiteDatabaseVerification_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                KasraWebsiteDatabaseFlag = dataVerification.DatabaseConnectabilityVerification(TxtBxKasraWebsiteDatabaseName.Text, TxtBxKasraWebsiteDatabaseAddress.Text, TxtBxKasraWebsiteDatabaseUsername.Text, TxtBxKasraWebsiteDatabasePassword.Text, false);
                if (KasraWebsiteDatabaseFlag && KasraMobileDatabaseFlag)
                {
                    BtnInstallSoftware.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TxtBxMobileDatabaseName.Text = string.Empty;
                TxtBxMobileDatabseAddress.Text = string.Empty;
                TxtBxMobileDatabaseUsername.Text = string.Empty;
                TxtBxMobileDatabasePassword.Text = string.Empty;
            }
        }

        private void FrmSetupInstallation_Load(object sender, EventArgs e)
        {

        }
    }
}