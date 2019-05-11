using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TrainTracking
{
    public partial class Schedule : UserControl
    {
        public static DataTable dt = new DataTable();
        public Schedule()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Schedule_Load(object sender, EventArgs e)
        {

            
            FixedDwellTime.Format = DateTimePickerFormat.Time;
            FixedDwellTime.CustomFormat = "HH:mm";
            //TimePickerOnly2.Format = DateTimePickerFormat.Time;
            VariableDwellTime.Format = DateTimePickerFormat.Time;
            VariableDwellTime.CustomFormat = "HH:mm";
            PreferenceTime.Format = DateTimePickerFormat.Time;
            PreferenceTime.CustomFormat = "HH:mm";
            

            loadSelectTrain();
           loadSelectRoute();
           switchStation.OnText = "Active";
           switchStation.OffText = "In Active";
           LoadUser();
            
        }
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from schedule", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void IdMaker()
        {
            int a;
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Max(Id) from schedule", con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtId.Text = "1";
                    ConnectDb.ScheduleIdMaker = 1;
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtId.Text = a.ToString();
                    ConnectDb.ScheduleIdMaker = Convert.ToInt32(a.ToString());
                }
            }
        }
        private void loadSelectTrain()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainProfile ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainProfile");

            cmbSelectTrain.DisplayMember = "TrainName";
            cmbSelectTrain.ValueMember = "TrainId";
            cmbSelectTrain.DataSource = ds.Tables["TrainProfile"];
            //   cmbFinaldestinations.SelectedIndex = -1;

        }

        private void loadSelectRoute()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from RouteManagmentSystem ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "RouteManagmentSystem");

            CmbSelectRoute.DisplayMember = "RouteName";
            CmbSelectRoute.ValueMember = "RouteId";
            CmbSelectRoute.DataSource = ds.Tables["RouteManagmentSystem"];
           // CmbSelectRoute.SelectedIndex = -1;

        }

        private void CmbSelectRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from StopPoints Where RouteId='" + CmbSelectRoute.SelectedValue.ToString()+ "'", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "StopPoints");
            cmbAdjoint.DisplayMember = "StopName";
            cmbAdjoint.ValueMember = "StopId";
            cmbAdjoint.DataSource = ds.Tables["StopPoints"];
          
                   
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chkRepeat.Text = "Daily";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chkRepeat.Text = "weekly";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            chkRepeat.Text = "Monthly";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            chkRepeat.Text = "yearly";
        }

        private void cmbAdjoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStation.Text = cmbAdjoint.Text.ToString();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            dt.Clear();
            IdMaker();
            AddUser();
            insertDays();
            LoadUser();

        }
        private void insertDays()
        {
            foreach (object item in chkDays.CheckedItems)
            {
                DataRowView row = item as DataRowView;


                //  MessageBox.Show(row["StationName"].ToString() + "||" + row["DestinationStationId"].ToString());





                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into scheduleDays(SchduleId,Days)Values(@SchduleId,@Days) ", con);
                cmd.Parameters.AddWithValue("@SchduleId", ConnectDb.ScheduleIdMaker.ToString());
                cmd.Parameters.AddWithValue("@Days", item.ToString());
               
                
                cmd.ExecuteNonQuery();


            }
        }
        private void AddUser()
        {

            try
            {
                SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
                con2.Open();
                if (txtId.Text != "" && cmbAdjoint.Text != "" && CmbSelectRoute.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into schedule(Id,TrainName,RouteName,SelectedTime,PreferenceDate,PreferenceTime,PreferenceRepeat,RangeOfRecurrence,Status) Values(@Id,@TrainName,@RouteName,@SelectedTime,@PreferenceDate,@PreferenceTime,@PreferenceRepeat,@RangeOfRecurrence,@Status)", con2);
                    cmd.Parameters.AddWithValue("@Id", ConnectDb.ScheduleIdMaker);
                    cmd.Parameters.AddWithValue("@TrainName", cmbSelectTrain.Text.ToString());
                    cmd.Parameters.AddWithValue("@RouteName", CmbSelectRoute.Text.ToString());
                    if (radioFixed.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@SelectedTime", "Fixed".ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SelectedTime", "Recurring".ToString());
                    }

                    cmd.Parameters.AddWithValue("@PreferenceDate", PreferenceDate.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PreferenceTime", PreferenceTime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@PreferenceRepeat", chkRepeat.Text.ToString());
                    if (radioRangeNoEnd.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@RangeOfRecurrence", "No End Date".ToString());
                    }
                    if (radioRangeAfter.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@RangeOfRecurrence", txtRangeAfter.Text.ToString());
                    }
                    if (radioRangeEndBy.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@RangeOfRecurrence", RangeDateEndBy.Value.ToShortDateString());
                    }
                    
                   
                   
                    
                    if (radioActive.IsChecked == true)
                    {
                        cmd.Parameters.AddWithValue("@Status", "Active".ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", "InActive".ToString());
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Added");

                }
                else
                {

                    MessageBox.Show("Please insert all fileds Data!");

                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void radioFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFixed.Checked==true)
            {
                groupBox2.Enabled = false;
                panel3.Enabled = false;
            }
        }

        private void radioRecurring_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRecurring.Checked == true)
            {
                groupBox2.Enabled = true;
                panel3.Enabled = true;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            AddStations();
        }
        private void AddStations()
        {

            try
            {
                SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
                con2.Open();
                if (txtId.Text != "") { 
                if ( CmbSelectRoute.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into ScheduleStaions(scheduleId,StationName,FixedDwellTime,variableDwellTime,SelectLane,Status) Values(@scheduleId,@StationName,@FixedDwellTime,@variableDwellTime,@SelectLane,@Status)", con2);
                    cmd.Parameters.AddWithValue("@scheduleId", ConnectDb.ScheduleIdMaker);
                    cmd.Parameters.AddWithValue("@StationName", cmbAdjoint.Text.ToString());
                    cmd.Parameters.AddWithValue("@FixedDwellTime", FixedDwellTime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@variableDwellTime", VariableDwellTime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@SelectLane", cmbSelectLane.Text.ToString());
                   
                   
                   

                    if (switchStation.Value == true)
                    {
                        cmd.Parameters.AddWithValue("@Status", switchStation.OnText.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", switchStation.OffText.ToString());
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Added");

                }
                else
                {

                    MessageBox.Show("Please insert all fileds Data!");

                }
                }
                else
                {
                    MessageBox.Show("Make a schedule before Please!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
