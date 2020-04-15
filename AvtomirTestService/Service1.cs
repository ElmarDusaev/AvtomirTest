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
using System.Configuration;
using AVtomirTestLibrary;
using System.IO;

namespace AvtomirTestService
{
    public partial class Service1 : ServiceBase
    {
        Timer myTimer = new Timer();
        Cbr cbr = new Cbr();
        
        int timeInterval;
        string ConnectionString;
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timeInterval = int.Parse(ConfigurationManager.AppSettings["Timer"]);
            ConnectionString = ConfigurationManager.ConnectionStrings["AvtomirTestDB"].ToString();

            myTimer.Enabled = true;
            myTimer.Interval = timeInterval;
            myTimer.Elapsed += MyTimer_Elapsed;
        }

        protected override void OnStop()
        {
            myTimer.Enabled = false;
        }


        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                cbr.Start();
            }
            catch (Exception ex)
            {
                if (!File.Exists(@"C:\log.txt")) File.Create(@"C:\log.txt");
                WriteLogMessage(ex.ToString());
            }

        }

        private void WriteLogMessage(string log)
        {
            StringBuilder message = new StringBuilder();
            message.Append(new string('*', 25));
            message.Append(Environment.NewLine);
            message.Append(DateTime.Now.ToString());
            message.Append(Environment.NewLine);
            message.Append(log);
            message.Append(Environment.NewLine);
            message.Append(new string('*', 25));
            message.Append(Environment.NewLine);

            File.WriteAllText(@"C:\log.txt", message.ToString());

        }


    }
}
