using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTracking
{
    public partial class ScheduleViwer : Form
    {
        public ScheduleViwer()
        {
            InitializeComponent();
        }

        private void ScheduleViwer_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM schedule ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            ScheduleReport c = new ScheduleReport();
            c.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = c;
            crystalReportViewer1.Refresh();
        }
    }
}
