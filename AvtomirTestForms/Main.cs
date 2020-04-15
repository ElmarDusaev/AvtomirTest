using AVtomirTestLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvtomirTestForms
{
    public partial class Main : Form
    {
        BackgroundWorker worker;
        DateTime selectedDateTeme;
        public Main()
        {
            InitializeComponent();
            selectedDateTeme = DateTime.Now;

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLoad.Enabled = true;

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Cbr reader = new Cbr(selectedDateTeme);
                reader.Start();
                MessageBox.Show("Загрузка данных завершена", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            selectedDateTeme = dtPicker.Value;
            btnLoad.Enabled = false;
            worker.RunWorkerAsync(); 
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
