namespace WindowsService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.ServiceNotifyBookNearlyOOS = new System.ServiceProcess.ServiceInstaller();
            this.ServiceReportInvoice = new System.ServiceProcess.ServiceInstaller();
            this.ServiceHappyBirthday = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // ServiceNotifyBookNearlyOOS
            // 
            this.ServiceNotifyBookNearlyOOS.ServiceName = "ServiceNotifyOutOfStockBook";
            // 
            // ServiceReportInvoice
            // 
            this.ServiceReportInvoice.ServiceName = "ServiceReport";
            // 
            // ServiceHappyBirthday
            // 
            this.ServiceHappyBirthday.ServiceName = "ServiceHappyBirthday";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.ServiceNotifyBookNearlyOOS,
            this.ServiceReportInvoice,
            this.ServiceHappyBirthday});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller ServiceNotifyBookNearlyOOS;
        private System.ServiceProcess.ServiceInstaller ServiceReportInvoice;
        private System.ServiceProcess.ServiceInstaller ServiceHappyBirthday;
    }
}