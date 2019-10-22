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

        // Create three flags one for each group box in order to check each if those info have been verified or not.
        bool WebsiteInfoAndAddressFlag = false, KasraMobileDatabaseFlag = false, KasraWebsiteDatabaseFlag = false;

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
                {
                    // The following invoked method checks if the address meets the circumstances
                    // then puts it in the publish path text box.
                    if (dataVerification.PublishPathVerification(FolderBrowserDialogPath.SelectedPath))
                        TxtBxPublishPath.Text = FolderBrowserDialogPath.SelectedPath;
                }
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
                // The second condition checks whether the selected path meets the essential circumstances or not.
                if (result == DialogResult.OK && dataVerification.ProjectPathVerification(FolderBrowserDialogPath.SelectedPath))
                {
                    TxtBxProjectPath.Text = FolderBrowserDialogPath.SelectedPath;
                }
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
                KasraMobileDatabaseFlag = dataVerification.MobileDatabaseConnectabilityVerification(TxtBxMobileDatabaseName.Text, TxtBxMobileDatabseAddress.Text, TxtBxMobileDatabaseUsername.Text, TxtBxMobileDatabasePassword.Text, true);
                if (WebsiteInfoAndAddressFlag && KasraMobileDatabaseFlag && KasraWebsiteDatabaseFlag)
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
                FrmInstallationProcess frmInstallationProcess = new FrmInstallationProcess(TxtBxWebsiteName.Text, TxtBxPortNumber.Text, TxtBxPublishPath.Text, TxtBxProjectPath.Text, TxtBxMobileDatabaseName.Text, TxtBxMobileDatabseAddress.Text, TxtBxMobileDatabaseUsername.Text, TxtBxMobileDatabasePassword.Text, TxtBxKasraWebsiteDatabaseName.Text, TxtBxKasraWebsiteDatabaseAddress.Text, TxtBxKasraWebsiteDatabaseUsername.Text, TxtBxKasraWebsiteDatabasePassword.Text);
                frmInstallationProcess.Show();
                Hide();
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
                KasraWebsiteDatabaseFlag = dataVerification.MobileDatabaseConnectabilityVerification(TxtBxKasraWebsiteDatabaseName.Text, TxtBxKasraWebsiteDatabaseAddress.Text, TxtBxKasraWebsiteDatabaseUsername.Text, TxtBxKasraWebsiteDatabasePassword.Text, false);
                if (WebsiteInfoAndAddressFlag && KasraWebsiteDatabaseFlag && KasraMobileDatabaseFlag)
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

        private void BtnWebsiteAndInfoVerification_Click(object sender, EventArgs e)
        {
            try
            {
                DataVerification dataVerification = new DataVerification(this);
                // Create a string for adding the messages to it.
                string errorMessage = string.Empty;

                // Add the port number verification message if it is not empty.
                string portNumberMessage = dataVerification.PortNumberVerification();
                if (portNumberMessage != string.Empty)
                    errorMessage += portNumberMessage + "\n";

                // Add the website name verification message if it is not empty.
                string websiteNameMessage = dataVerification.MobileWebsiteAndAppPoolNameVerification();
                if (websiteNameMessage != string.Empty)
                    errorMessage += websiteNameMessage + "\n";

                // Add the publish path verification message if it is not empty.
                string publishPathMessage = (BtnBrowsePublishPath.Text == string.Empty) ? "!" + "مسیر پابلیش انتخاب نشده\n" : string.Empty;
                if (publishPathMessage != string.Empty)
                    errorMessage += publishPathMessage;

                // Add the project path verification message if it is not empty.
                string projectPathMessage = (BtnBrowseProjectPath.Text == string.Empty) ? "!" + "مسیر پروژه انتخاب نشده\n" : string.Empty;
                if (projectPathMessage != string.Empty)
                    errorMessage += projectPathMessage;

                if (errorMessage != string.Empty)
                    MessageBox.Show(errorMessage, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    MessageBox.Show("اطلاعات وارد شده معتبر است", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WebsiteInfoAndAddressFlag = true;
                    if (WebsiteInfoAndAddressFlag && KasraWebsiteDatabaseFlag && KasraMobileDatabaseFlag)
                    {
                        BtnInstallSoftware.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmSetupInstallation_Load(object sender, EventArgs e)
        {

        }
    }
}