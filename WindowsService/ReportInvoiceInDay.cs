using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;

namespace WindowsService
{
    partial class ReportInvoiceInDay : ServiceBase
    {
        //Service se bao cao tat ca hoa don cua ngay hom qua va tong tien bang excel
        private Timer timer;
        private const int TIMER_INTERVAL = 24 * 60 * 60 * 1000; //moi 1 ngay service se chay 1 lan 
        public ReportInvoiceInDay()
        {
            InitializeComponent();
            timer = new Timer();
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = 30000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Utilities.WriteReport();
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
