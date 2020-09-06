using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService
{
    //Service se thong bao nhung sach co so luong duoi 20 de quan ly co the biet duoc sach nao sap het hang bang notepad
    partial class ServiceNotifyBookNearlyOOS : ServiceBase
    {
        private Timer timer;
        private const int TIMER_INTERVAL = 24 * 60 * 60 * 1000; //moi 1 ngay service se chay 1 lan 
        public ServiceNotifyBookNearlyOOS()
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
            Utilities.WriteText();
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
