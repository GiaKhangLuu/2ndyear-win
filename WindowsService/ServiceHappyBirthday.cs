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

namespace WindowsService
{
    partial class ServiceHappyBirthday : ServiceBase
    {
        private Timer timer;
        private const int TIMER_INTERVAL = 24 * 60 * 60 * 1000; //set interval la 1 ngay
        public ServiceHappyBirthday()
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
            Utilities.SendMail();
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
