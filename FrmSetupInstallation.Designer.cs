namespace KasraMobileMiddleware
{
    partial class FrmSetupInstallation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetupInstallation));
            this.GroupBxSQLServer = new System.Windows.Forms.GroupBox();
            this.BtnVerification = new System.Windows.Forms.Button();
            this.TxtBxDatabasePassword = new System.Windows.Forms.TextBox();
            this.TxtBxDatabaseInstanceName = new System.Windows.Forms.TextBox();
            this.TxtBxDatabaseUsername = new System.Windows.Forms.TextBox();
            this.TxtBxDatabaseName = new System.Windows.Forms.TextBox();
            this.LbDatabaseName = new System.Windows.Forms.Label();
            this.LbInstanceName = new System.Windows.Forms.Label();
            this.LbDatabaseUsername = new System.Windows.Forms.Label();
            this.LbDatabasePassword = new System.Windows.Forms.Label();
            this.GroupBxApplication = new System.Windows.Forms.GroupBox();
            this.LbNote = new System.Windows.Forms.Label();
            this.BtnBrowseProjectPath = new System.Windows.Forms.Button();
            this.TxtBxProjectPath = new System.Windows.Forms.TextBox();
            this.BtnBrowsePublishPath = new System.Windows.Forms.Button();
            this.TxtBxPublishPath = new System.Windows.Forms.TextBox();
            this.TxtBxPortNumber = new System.Windows.Forms.TextBox();
            this.TxtBxWebsiteName = new System.Windows.Forms.TextBox();
            this.LbPublishPath = new System.Windows.Forms.Label();
            this.LbWebsiteName = new System.Windows.Forms.Label();
            this.LbPortNumber = new System.Windows.Forms.Label();
            this.LbProjectPath = new System.Windows.Forms.Label();
            this.FolderBrowserDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnInstallSoftware = new System.Windows.Forms.Button();
            this.GroupBxSQLServer.SuspendLayout();
            this.GroupBxApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBxSQLServer
            // 
            this.GroupBxSQLServer.Controls.Add(this.BtnVerification);
            this.GroupBxSQLServer.Controls.Add(this.TxtBxDatabasePassword);
            this.GroupBxSQLServer.Controls.Add(this.TxtBxDatabaseInstanceName);
            this.GroupBxSQLServer.Controls.Add(this.TxtBxDatabaseUsername);
            this.GroupBxSQLServer.Controls.Add(this.TxtBxDatabaseName);
            this.GroupBxSQLServer.Controls.Add(this.LbDatabaseName);
            this.GroupBxSQLServer.Controls.Add(this.LbInstanceName);
            this.GroupBxSQLServer.Controls.Add(this.LbDatabaseUsername);
            this.GroupBxSQLServer.Controls.Add(this.LbDatabasePassword);
            this.GroupBxSQLServer.Location = new System.Drawing.Point(12, 194);
            this.GroupBxSQLServer.Name = "GroupBxSQLServer";
            this.GroupBxSQLServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GroupBxSQLServer.Size = new System.Drawing.Size(895, 104);
            this.GroupBxSQLServer.TabIndex = 1;
            this.GroupBxSQLServer.TabStop = false;
            this.GroupBxSQLServer.Text = "SQL Server";
            // 
            // BtnVerification
            // 
            this.BtnVerification.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnVerification.BackColor = System.Drawing.Color.Transparent;
            this.BtnVerification.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnVerification.BackgroundImage")));
            this.BtnVerification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnVerification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnVerification.FlatAppearance.BorderSize = 0;
            this.BtnVerification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerification.ForeColor = System.Drawing.Color.White;
            this.BtnVerification.Location = new System.Drawing.Point(328, 57);
            this.BtnVerification.Name = "BtnVerification";
            this.BtnVerification.Size = new System.Drawing.Size(80, 35);
            this.BtnVerification.TabIndex = 4;
            this.BtnVerification.Text = "بررسی";
            this.BtnVerification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnVerification.UseVisualStyleBackColor = false;
            this.BtnVerification.Click += new System.EventHandler(this.BtnVerification_Click);
            // 
            // TxtBxDatabasePassword
            // 
            this.TxtBxDatabasePassword.Location = new System.Drawing.Point(414, 59);
            this.TxtBxDatabasePassword.Name = "TxtBxDatabasePassword";
            this.TxtBxDatabasePassword.PasswordChar = '*';
            this.TxtBxDatabasePassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxDatabasePassword.Size = new System.Drawing.Size(136, 26);
            this.TxtBxDatabasePassword.TabIndex = 3;
            // 
            // TxtBxDatabaseInstanceName
            // 
            this.TxtBxDatabaseInstanceName.Location = new System.Drawing.Point(328, 19);
            this.TxtBxDatabaseInstanceName.Name = "TxtBxDatabaseInstanceName";
            this.TxtBxDatabaseInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxDatabaseInstanceName.Size = new System.Drawing.Size(222, 26);
            this.TxtBxDatabaseInstanceName.TabIndex = 1;
            // 
            // TxtBxDatabaseUsername
            // 
            this.TxtBxDatabaseUsername.Location = new System.Drawing.Point(654, 59);
            this.TxtBxDatabaseUsername.Name = "TxtBxDatabaseUsername";
            this.TxtBxDatabaseUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxDatabaseUsername.Size = new System.Drawing.Size(136, 26);
            this.TxtBxDatabaseUsername.TabIndex = 2;
            this.TxtBxDatabaseUsername.Text = "sa";
            // 
            // TxtBxDatabaseName
            // 
            this.TxtBxDatabaseName.Location = new System.Drawing.Point(654, 19);
            this.TxtBxDatabaseName.Name = "TxtBxDatabaseName";
            this.TxtBxDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxDatabaseName.Size = new System.Drawing.Size(136, 26);
            this.TxtBxDatabaseName.TabIndex = 0;
            this.TxtBxDatabaseName.Text = "KasraMobileDb";
            this.TxtBxDatabaseName.TextChanged += new System.EventHandler(this.TxtBxDatabaseName_TextChanged);
            // 
            // LbDatabaseName
            // 
            this.LbDatabaseName.AutoSize = true;
            this.LbDatabaseName.Location = new System.Drawing.Point(796, 22);
            this.LbDatabaseName.Name = "LbDatabaseName";
            this.LbDatabaseName.Size = new System.Drawing.Size(48, 19);
            this.LbDatabaseName.TabIndex = 6;
            this.LbDatabaseName.Text = "نام بانک";
            // 
            // LbInstanceName
            // 
            this.LbInstanceName.AutoSize = true;
            this.LbInstanceName.Location = new System.Drawing.Point(556, 22);
            this.LbInstanceName.Name = "LbInstanceName";
            this.LbInstanceName.Size = new System.Drawing.Size(70, 19);
            this.LbInstanceName.TabIndex = 5;
            this.LbInstanceName.Text = "نام اینستنس";
            // 
            // LbDatabaseUsername
            // 
            this.LbDatabaseUsername.AutoSize = true;
            this.LbDatabaseUsername.Location = new System.Drawing.Point(796, 62);
            this.LbDatabaseUsername.Name = "LbDatabaseUsername";
            this.LbDatabaseUsername.Size = new System.Drawing.Size(58, 19);
            this.LbDatabaseUsername.TabIndex = 4;
            this.LbDatabaseUsername.Text = "نام کاربری";
            // 
            // LbDatabasePassword
            // 
            this.LbDatabasePassword.AutoSize = true;
            this.LbDatabasePassword.Location = new System.Drawing.Point(556, 62);
            this.LbDatabasePassword.Name = "LbDatabasePassword";
            this.LbDatabasePassword.Size = new System.Drawing.Size(47, 19);
            this.LbDatabasePassword.TabIndex = 3;
            this.LbDatabasePassword.Text = "رمز عبور";
            // 
            // GroupBxApplication
            // 
            this.GroupBxApplication.Controls.Add(this.LbNote);
            this.GroupBxApplication.Controls.Add(this.BtnBrowseProjectPath);
            this.GroupBxApplication.Controls.Add(this.TxtBxProjectPath);
            this.GroupBxApplication.Controls.Add(this.BtnBrowsePublishPath);
            this.GroupBxApplication.Controls.Add(this.TxtBxPublishPath);
            this.GroupBxApplication.Controls.Add(this.TxtBxPortNumber);
            this.GroupBxApplication.Controls.Add(this.TxtBxWebsiteName);
            this.GroupBxApplication.Controls.Add(this.LbPublishPath);
            this.GroupBxApplication.Controls.Add(this.LbWebsiteName);
            this.GroupBxApplication.Controls.Add(this.LbPortNumber);
            this.GroupBxApplication.Controls.Add(this.LbProjectPath);
            this.GroupBxApplication.Location = new System.Drawing.Point(12, 12);
            this.GroupBxApplication.Name = "GroupBxApplication";
            this.GroupBxApplication.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GroupBxApplication.Size = new System.Drawing.Size(895, 176);
            this.GroupBxApplication.TabIndex = 0;
            this.GroupBxApplication.TabStop = false;
            this.GroupBxApplication.Text = "Application";
            // 
            // LbNote
            // 
            this.LbNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LbNote.AutoSize = true;
            this.LbNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LbNote.Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.LbNote.ForeColor = System.Drawing.Color.Gray;
            this.LbNote.Location = new System.Drawing.Point(539, 136);
            this.LbNote.Name = "LbNote";
            this.LbNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LbNote.Size = new System.Drawing.Size(259, 15);
            this.LbNote.TabIndex = 11;
            this.LbNote.Text = ".را انتخاب نمایید C در این قسمت نام درایو مورد نظر به جز درایو ";
            // 
            // BtnBrowseProjectPath
            // 
            this.BtnBrowseProjectPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBrowseProjectPath.BackColor = System.Drawing.Color.Transparent;
            this.BtnBrowseProjectPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBrowseProjectPath.BackgroundImage")));
            this.BtnBrowseProjectPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBrowseProjectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBrowseProjectPath.FlatAppearance.BorderSize = 0;
            this.BtnBrowseProjectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrowseProjectPath.ForeColor = System.Drawing.Color.White;
            this.BtnBrowseProjectPath.Location = new System.Drawing.Point(456, 105);
            this.BtnBrowseProjectPath.Name = "BtnBrowseProjectPath";
            this.BtnBrowseProjectPath.Size = new System.Drawing.Size(80, 35);
            this.BtnBrowseProjectPath.TabIndex = 3;
            this.BtnBrowseProjectPath.Text = "انتخاب";
            this.BtnBrowseProjectPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBrowseProjectPath.UseVisualStyleBackColor = false;
            this.BtnBrowseProjectPath.Click += new System.EventHandler(this.BtnBrowseProjectPath_Click);
            // 
            // TxtBxProjectPath
            // 
            this.TxtBxProjectPath.Location = new System.Drawing.Point(542, 107);
            this.TxtBxProjectPath.Name = "TxtBxProjectPath";
            this.TxtBxProjectPath.ReadOnly = true;
            this.TxtBxProjectPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxProjectPath.Size = new System.Drawing.Size(248, 26);
            this.TxtBxProjectPath.TabIndex = 3;
            // 
            // BtnBrowsePublishPath
            // 
            this.BtnBrowsePublishPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBrowsePublishPath.BackColor = System.Drawing.Color.Transparent;
            this.BtnBrowsePublishPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBrowsePublishPath.BackgroundImage")));
            this.BtnBrowsePublishPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBrowsePublishPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBrowsePublishPath.FlatAppearance.BorderSize = 0;
            this.BtnBrowsePublishPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrowsePublishPath.ForeColor = System.Drawing.Color.White;
            this.BtnBrowsePublishPath.Location = new System.Drawing.Point(456, 58);
            this.BtnBrowsePublishPath.Name = "BtnBrowsePublishPath";
            this.BtnBrowsePublishPath.Size = new System.Drawing.Size(80, 35);
            this.BtnBrowsePublishPath.TabIndex = 2;
            this.BtnBrowsePublishPath.Text = "انتخاب";
            this.BtnBrowsePublishPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBrowsePublishPath.UseVisualStyleBackColor = false;
            this.BtnBrowsePublishPath.Click += new System.EventHandler(this.BtnBrowsePublishPath_Click);
            // 
            // TxtBxPublishPath
            // 
            this.TxtBxPublishPath.Location = new System.Drawing.Point(542, 61);
            this.TxtBxPublishPath.Name = "TxtBxPublishPath";
            this.TxtBxPublishPath.ReadOnly = true;
            this.TxtBxPublishPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxPublishPath.Size = new System.Drawing.Size(248, 26);
            this.TxtBxPublishPath.TabIndex = 2;
            // 
            // TxtBxPortNumber
            // 
            this.TxtBxPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtBxPortNumber.Location = new System.Drawing.Point(456, 19);
            this.TxtBxPortNumber.Name = "TxtBxPortNumber";
            this.TxtBxPortNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxPortNumber.Size = new System.Drawing.Size(131, 26);
            this.TxtBxPortNumber.TabIndex = 1;
            this.TxtBxPortNumber.Text = "80";
            // 
            // TxtBxWebsiteName
            // 
            this.TxtBxWebsiteName.Location = new System.Drawing.Point(654, 19);
            this.TxtBxWebsiteName.Name = "TxtBxWebsiteName";
            this.TxtBxWebsiteName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBxWebsiteName.Size = new System.Drawing.Size(136, 26);
            this.TxtBxWebsiteName.TabIndex = 0;
            this.TxtBxWebsiteName.Text = "KasraMobile";
            // 
            // LbPublishPath
            // 
            this.LbPublishPath.AutoSize = true;
            this.LbPublishPath.Location = new System.Drawing.Point(796, 64);
            this.LbPublishPath.Name = "LbPublishPath";
            this.LbPublishPath.Size = new System.Drawing.Size(71, 19);
            this.LbPublishPath.TabIndex = 3;
            this.LbPublishPath.Text = "مسیر پابلیش";
            // 
            // LbWebsiteName
            // 
            this.LbWebsiteName.AutoSize = true;
            this.LbWebsiteName.Location = new System.Drawing.Point(796, 22);
            this.LbWebsiteName.Name = "LbWebsiteName";
            this.LbWebsiteName.Size = new System.Drawing.Size(53, 19);
            this.LbWebsiteName.TabIndex = 2;
            this.LbWebsiteName.Text = "نام سایت";
            // 
            // LbPortNumber
            // 
            this.LbPortNumber.AutoSize = true;
            this.LbPortNumber.Location = new System.Drawing.Point(593, 22);
            this.LbPortNumber.Name = "LbPortNumber";
            this.LbPortNumber.Size = new System.Drawing.Size(33, 19);
            this.LbPortNumber.TabIndex = 1;
            this.LbPortNumber.Text = "پورت";
            // 
            // LbProjectPath
            // 
            this.LbProjectPath.AutoSize = true;
            this.LbProjectPath.Location = new System.Drawing.Point(796, 110);
            this.LbProjectPath.Name = "LbProjectPath";
            this.LbProjectPath.Size = new System.Drawing.Size(86, 19);
            this.LbProjectPath.TabIndex = 0;
            this.LbProjectPath.Text = "مسیر درایو پروژه";
            // 
            // BtnInstallSoftware
            // 
            this.BtnInstallSoftware.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnInstallSoftware.BackColor = System.Drawing.Color.Transparent;
            this.BtnInstallSoftware.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnInstallSoftware.BackgroundImage")));
            this.BtnInstallSoftware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnInstallSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInstallSoftware.Enabled = false;
            this.BtnInstallSoftware.FlatAppearance.BorderSize = 0;
            this.BtnInstallSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInstallSoftware.ForeColor = System.Drawing.Color.White;
            this.BtnInstallSoftware.Location = new System.Drawing.Point(12, 304);
            this.BtnInstallSoftware.Name = "BtnInstallSoftware";
            this.BtnInstallSoftware.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnInstallSoftware.Size = new System.Drawing.Size(89, 35);
            this.BtnInstallSoftware.TabIndex = 2;
            this.BtnInstallSoftware.Text = "نصب نرم افزار";
            this.BtnInstallSoftware.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnInstallSoftware.UseVisualStyleBackColor = false;
            this.BtnInstallSoftware.Click += new System.EventHandler(this.BtnInstallSoftware_Click);
            // 
            // FrmSetupInstallation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 346);
            this.Controls.Add(this.BtnInstallSoftware);
            this.Controls.Add(this.GroupBxApplication);
            this.Controls.Add(this.GroupBxSQLServer);
            this.Font = new System.Drawing.Font("Vazir", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmSetupInstallation";
            this.Text = "Form1";
            this.GroupBxSQLServer.ResumeLayout(false);
            this.GroupBxSQLServer.PerformLayout();
            this.GroupBxApplication.ResumeLayout(false);
            this.GroupBxApplication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBxSQLServer;
        private System.Windows.Forms.GroupBox GroupBxApplication;
        private System.Windows.Forms.Label LbNote;
        private System.Windows.Forms.Button BtnBrowseProjectPath;
        private System.Windows.Forms.TextBox TxtBxProjectPath;
        private System.Windows.Forms.Button BtnBrowsePublishPath;
        private System.Windows.Forms.TextBox TxtBxPublishPath;
        private System.Windows.Forms.TextBox TxtBxPortNumber;
        private System.Windows.Forms.TextBox TxtBxWebsiteName;
        private System.Windows.Forms.Label LbPublishPath;
        private System.Windows.Forms.Label LbWebsiteName;
        private System.Windows.Forms.Label LbPortNumber;
        private System.Windows.Forms.Label LbProjectPath;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogPath;
        private System.Windows.Forms.Button BtnVerification;
        private System.Windows.Forms.TextBox TxtBxDatabasePassword;
        private System.Windows.Forms.TextBox TxtBxDatabaseInstanceName;
        private System.Windows.Forms.TextBox TxtBxDatabaseUsername;
        private System.Windows.Forms.TextBox TxtBxDatabaseName;
        private System.Windows.Forms.Label LbDatabaseName;
        private System.Windows.Forms.Label LbInstanceName;
        private System.Windows.Forms.Label LbDatabaseUsername;
        private System.Windows.Forms.Label LbDatabasePassword;
        private System.Windows.Forms.Button BtnInstallSoftware;
    }
}

