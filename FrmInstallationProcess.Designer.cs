namespace KasraMobileMiddleware
{
    partial class FrmInstallationProcess
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
            this.TextBxLog = new System.Windows.Forms.TextBox();
            this.ProgressBarInstallation = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TextBxLog
            // 
            this.TextBxLog.Font = new System.Drawing.Font("Vazir", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.TextBxLog.Location = new System.Drawing.Point(12, 81);
            this.TextBxLog.Multiline = true;
            this.TextBxLog.Name = "TextBxLog";
            this.TextBxLog.ReadOnly = true;
            this.TextBxLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBxLog.Size = new System.Drawing.Size(776, 357);
            this.TextBxLog.TabIndex = 1;
            // 
            // ProgressBarInstallation
            // 
            this.ProgressBarInstallation.Location = new System.Drawing.Point(12, 12);
            this.ProgressBarInstallation.Name = "ProgressBarInstallation";
            this.ProgressBarInstallation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProgressBarInstallation.RightToLeftLayout = true;
            this.ProgressBarInstallation.Size = new System.Drawing.Size(776, 63);
            this.ProgressBarInstallation.TabIndex = 0;
            // 
            // FrmInstallationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgressBarInstallation);
            this.Controls.Add(this.TextBxLog);
            this.MaximizeBox = false;
            this.Name = "FrmInstallationProcess";
            this.Text = "FrmInstallationProcess";
            this.Load += new System.EventHandler(this.FrmInstallationProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBxLog;
        private System.Windows.Forms.ProgressBar ProgressBarInstallation;
    }
}