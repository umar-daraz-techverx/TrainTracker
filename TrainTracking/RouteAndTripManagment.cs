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
using GemBox.Spreadsheet.WinFormsUtilities;
using GemBox.Spreadsheet;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Documents;
namespace TrainTracking
{
    public partial class RouteAndTripManagment : UserControl
    {
     //   private static int visitCounter = 0;
        public static DataTable dt = new DataTable();
        public RouteAndTripManagment()
        {
            InitializeComponent();

        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {

            IdMaker();
            StopPointInsertion();
            dt.Clear();
            
            AddUser();
            //  addSetAdjoint();
                 ClearAll();

            LoadUser();

            while (checkedAdjoin.CheckedItems.Count > 0)
            {
                checkedAdjoin.SetItemChecked(checkedAdjoin.CheckedIndices[0], false);
            }
            
          //  checkedAdjoin.Items.Clear();
            ConnectDb.setadjoin = null;
        }

        private void StopPointInsertion()
        {
            foreach (object item in checkedAdjoin.CheckedItems)
            {
                DataRowView row = item as DataRowView;


                //  MessageBox.Show(row["StationName"].ToString() + "||" + row["DestinationStationId"].ToString());
                
               

                

                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into StopPoints(RouteId,StopId,StopName)Values(@RouteId,@StopId,@StopName) ", con);
                cmd.Parameters.AddWithValue("@RouteId", ConnectDb.routeIdNew.ToString());
                cmd.Parameters.AddWithValue("@StopId", row["DestinationStationId"].ToString());
                cmd.Parameters.AddWithValue("@StopName", row["StationName"].ToString());

                cmd.ExecuteNonQuery();

                
            }
        }
        private void IdMaker()
        {
           int a;
           SqlConnection con = new SqlConnection(ConnectDb.connectionString);
           con.Open();
           SqlCommand cmd = new SqlCommand("Select Max(RouteId) from RouteManagmentSystem", con);
           
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtId.Text = "1";
                    ConnectDb.routeIdNew = 1;
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtId.Text = a.ToString();
                    ConnectDb.routeIdNew = Convert.ToInt32(a.ToString());
                }
            }
        }
        private void addSetAdjoint()
        {
            //// Display in a message box all the items that are checked.

            //// First show the index and check state of all selected items.
            foreach (int indexChecked in checkedAdjoin.CheckedIndices)
            {
                //// The indexChecked variable contains the index of the item.
                //MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
                //                checkedAdjoin.GetItemCheckState(indexChecked).ToString() + ".");

                SqlConnection con3 = new SqlConnection(ConnectDb.connectionString);
                con3.Open();
                SqlCommand cmd = new SqlCommand("insert into RouteManagmentSystem SET SetAdjoint=@SetAdjoint where RouteId='" + ConnectDb.routeId + "'", con3);
                cmd.Parameters.AddWithValue("@SetAdjoint", indexChecked.ToString());
                cmd.ExecuteNonQuery();
                //object result = cmd.ExecuteScalar();
                //txtTotalDistance.Text = Convert.ToString(result);


                con3.Close();
            }
        }

        private void IdIncreament()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(RouteId) FROM  RouteManagmentSystem", con);


            // object result = cmd.ExecuteScalar();
            //txtTotalDistance.Text = Convert.ToString(result);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            result++;
            ConnectDb.routeId = result;


            con.Close();
        }
        private void ClearAll()
        {
            txtName.Text = "";
            cmbBoardingstations.Text = "";
            cmbFinaldestinations.Text = "";
            cmbChooseTrack.Text = "";
            txtTrackDistance.Text = "";
            txtTotalDistance.Text = "";
            //   txtApproximateTime.Text = "";
            txtId.Text = "";
            // OrderAndSelectStations2.SelectedIndex = -1;
            radioInActive.IsChecked = false;
            radioActive.IsChecked = false;
            //    OrderAndSelectStations.Text = "";

        }
        private void AddUser()
        {

            try
            {
                SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
                con2.Open();
                if (txtId.Text != "" && txtName.Text != "" && cmbBoardingstations.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into RouteManagmentSystem(RouteId,RouteName,BoardingStationId,BoardingStation,FinalDestinationId,FinalDestination,SetAdjoint,TotalDistance,ChooseTrackId,ChooseTrack,ChooseLane,TrackDistance,Status) Values(@RouteId,@RouteName,@BoardingStationId,@BoardingStation,@FinalDestinationId,@FinalDestination,@SetAdjoint,@TotalDistance,@ChooseTrackId,@ChooseTrack,@ChooseLane,@TrackDistance,@Status)", con2);
                    cmd.Parameters.AddWithValue("@RouteId", txtId.Text.ToString());
                    cmd.Parameters.AddWithValue("@RouteName", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@BoardingStationId", Convert.ToInt32(cmbBoardingstations.SelectedValue));
                    cmd.Parameters.AddWithValue("@BoardingStation", cmbBoardingstations.Text.ToString());
                    cmd.Parameters.AddWithValue("@FinalDestinationId", Convert.ToInt32(cmbFinaldestinations.SelectedValue));
                    cmd.Parameters.AddWithValue("@FinalDestination", cmbFinaldestinations.Text.ToString());
                    cmd.Parameters.AddWithValue("@SetAdjoint", ConnectDb.setadjoin);
                    cmd.Parameters.AddWithValue("@TotalDistance", Convert.ToDouble(txtTotalDistance.Text));
                    cmd.Parameters.AddWithValue("@ChooseTrackId", Convert.ToInt32(cmbChooseTrack.SelectedValue));
                    cmd.Parameters.AddWithValue("@ChooseTrack", cmbChooseTrack.Text.ToString());
                    cmd.Parameters.AddWithValue("@ChooseLane", cmbChooseLane.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackDistance", txtTrackDistance.Text.ToString());
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

        private void RouteAndTripManagment_Load(object sender, EventArgs e)
        {
            LoadUser();
            loadBoardingStation();
            loadFinalDestination();
            loadChooseTrack();
            //var items = checkedAdjoin.Items;
            //items.Add("Perls");
            //items.Add("lahore");
            //items.Add("karachi");
            
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;


        }
        private void loadTrack()
        {
            //SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            //con.Open();
            //SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainLaneManagment ", con);

            //DataTable dt = new DataTable();
            //adapt.Fill(dt);

            ////Assign DataTable as DataSource.
            //OrderAndSelectStations.DataSource = dt;
            //OrderAndSelectStations.DisplayMember = "TrackName";
            //OrderAndSelectStations.ValueMember = "TrackId";
        }



        private void loadBoardingStation()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainStationManagment");

            cmbBoardingstations.DisplayMember = "StationName";
            cmbBoardingstations.ValueMember = "DestinationStationId";
            cmbBoardingstations.DataSource = ds.Tables["TrainStationManagment"];
            //  cmbBoardingstations.SelectedIndex = -1;

        }
        private void loadFinalDestination()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainStationManagment");

            cmbFinaldestinations.DisplayMember = "StationName";
            cmbFinaldestinations.ValueMember = "DestinationStationId";
            cmbFinaldestinations.DataSource = ds.Tables["TrainStationManagment"];
            //   cmbFinaldestinations.SelectedIndex = -1;

        }
        private void loadChooseTrack()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainLaneManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainLaneManagment");

            cmbChooseTrack.DisplayMember = "TrackName";
            cmbChooseTrack.ValueMember = "TrackId";
            cmbChooseTrack.DataSource = ds.Tables["TrainLaneManagment"];
            cmbChooseTrack.SelectedIndex = -1;

        }
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from RouteManagmentSystem", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dt.Clear();
            
            update();
            ClearAll();
            LoadUser();
            
         //   checkedAdjoin.Items.Clear();
            while (checkedAdjoin.CheckedItems.Count > 0)
            {
                checkedAdjoin.SetItemChecked(checkedAdjoin.CheckedIndices[0], false);
            }
            ConnectDb.setadjoin = null;
        }
        private void update()
        {
            try
            {

                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtId.Text != "")
                {

                    SqlCommand cmd = new SqlCommand("update RouteManagmentSystem SET RouteName=@RouteName, BoardingStationId=@BoardingStationId, BoardingStation=@BoardingStation, FinalDestinationId=@FinalDestinationId,FinalDestination=@FinalDestination,SetAdjoint=@SetAdjoint, TotalDistance=@TotalDistance,ChooseTrackId=@ChooseTrackId,ChooseTrack=@ChooseTrack,ChooseLane=@ChooseLane,TrackDistance=@TrackDistance,Status=@Status where RouteId='" + txtId.Text.ToString() + "'", con);
                    cmd.Parameters.AddWithValue("@RouteName", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@BoardingStationId", Convert.ToInt32(cmbBoardingstations.SelectedValue));
                    cmd.Parameters.AddWithValue("@BoardingStation", cmbBoardingstations.Text.ToString());
                    cmd.Parameters.AddWithValue("@FinalDestinationId", Convert.ToInt32(cmbFinaldestinations.SelectedValue));
                    cmd.Parameters.AddWithValue("@FinalDestination", cmbFinaldestinations.Text.ToString());

                    if (ConnectDb.setadjoin == null)
                    {
                        cmd.Parameters.AddWithValue("@SetAdjoint", ConnectDb.setadjoinCellContentclick);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@SetAdjoint", ConnectDb.setadjoin);
                    }
                    cmd.Parameters.AddWithValue("@TotalDistance", Convert.ToDouble(txtTotalDistance.Text));
                    cmd.Parameters.AddWithValue("@ChooseTrackId", Convert.ToInt32(cmbChooseTrack.SelectedValue));
                    cmd.Parameters.AddWithValue("@ChooseTrack", cmbChooseTrack.Text.ToString());
                    cmd.Parameters.AddWithValue("@ChooseLane", cmbChooseLane.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackDistance", txtTrackDistance.Text.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dt.Clear();
            delete();
            ClearAll();
            LoadUser();
        }
        private void delete()
        {
            try
            {
                if (txtId.Text != "")
                {
                    SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM RouteManagmentSystem WHERE RouteId = '" + txtId.Text.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Please select any Row by Double clicking in Grid View!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm|XLTX (*.xltx)|*.xltx|XLTM (*.xltm)|*.xltm|ODS (*.ods)|*.ods|OTS (*.ots)|*.ots|CSV (*.csv)|*.csv|TSV (*.tsv)|*.tsv|HTML (*.html)|*.html|MHTML (.mhtml)|*.mhtml|PDF (*.pdf)|*.pdf|XPS (*.xps)|*.xps|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif|WMP (*.wdp)|*.wdp";
            saveFileDialog.FilterIndex = 3;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // From DataGridView to ExcelFile.
                DataGridViewConverter.ImportFromDataGridView(worksheet, this.DGV, new ImportFromDataGridViewOptions() { ColumnHeaders = true });

                workbook.Save(saveFileDialog.FileName);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            search();
        }
        private void search()
        {

            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from RouteManagmentSystem Where RouteName Like'%" + txtSearch.Text.ToString() + "%'", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            con.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var RouteId = DGV.Rows[e.RowIndex].Cells["RouteId"].Value;
                var RouteName = DGV.Rows[e.RowIndex].Cells["RouteName"].Value;
                var BoardingStationId = DGV.Rows[e.RowIndex].Cells["BoardingStationId"].Value;
                var BoardingStation = DGV.Rows[e.RowIndex].Cells["BoardingStation"].Value;
                var FinalDestinationId = DGV.Rows[e.RowIndex].Cells["FinalDestinationId"].Value;
                var FinalDestination = DGV.Rows[e.RowIndex].Cells["FinalDestination"].Value;
                var SetAdjoint = DGV.Rows[e.RowIndex].Cells["SetAdjoint"].Value;
                var TotalDistance = DGV.Rows[e.RowIndex].Cells["TotalDistance"].Value;
                var ChooseTrackId = DGV.Rows[e.RowIndex].Cells["ChooseTrackId"].Value;
                var ChooseTrack = DGV.Rows[e.RowIndex].Cells["ChooseTrack"].Value;
                var ChooseLane = DGV.Rows[e.RowIndex].Cells["ChooseLane"].Value;
                var TrackDistance = DGV.Rows[e.RowIndex].Cells["TrackDistance"].Value;
                var Status = DGV.Rows[e.RowIndex].Cells["Status"].Value;

                txtId.Text = RouteId.ToString();
                txtName.Text = RouteName.ToString();
                cmbBoardingstations.Text = BoardingStation.ToString();
                ConnectDb.BoardingStationId = Convert.ToInt32(BoardingStationId);
                ConnectDb.FinalDestinationId = Convert.ToInt32(FinalDestinationId);
                ConnectDb.setadjoinCellContentclick = SetAdjoint.ToString();
                ConnectDb.ChooseTrackId = Convert.ToInt32(ChooseTrackId);
                cmbFinaldestinations.Text = FinalDestination.ToString();
                txtTotalDistance.Text = TotalDistance.ToString();
                cmbChooseTrack.Text = ChooseTrack.ToString();
                cmbChooseLane.Text = ChooseLane.ToString();
                txtTrackDistance.Text = TrackDistance.ToString();
                //   txtApproximateTime.Text = ApproximateTime.ToString();
                //     OrderAndSelectStations.Text = SelectStation.ToString();

                if ((Status.ToString()) == "InActive")
                {
                    radioInActive.IsChecked = true;



                }
                else if (Status.ToString() == "Active")
                {
                    radioActive.IsChecked = true;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadcellcontentclickdata()
        {
            SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
            con2.Open();
            SqlDataAdapter adapt2 = new SqlDataAdapter("Select * from TrainStationManagment Where DestinationStationId Between'" + ConnectDb.BoardingStationId.ToString() + "'" + " and " + "'" + ConnectDb.FinalDestinationId.ToString() + "'", con2);

            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);

            //  Assign DataTable as DataSource.
            checkedAdjoin.DataSource = dt2;
            checkedAdjoin.DisplayMember = "StationName";
            checkedAdjoin.ValueMember = "DestinationStationId";



        }
        private void cmbFinaldestinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM (DistanceOnTrack)  FROM  TrainStationManagment Where DestinationStationId Between'" + cmbBoardingstations.SelectedValue.ToString() + "'" + " and " + "'" + cmbFinaldestinations.SelectedValue.ToString() + "'", con);

            cmd.ExecuteNonQuery();
            object result = cmd.ExecuteScalar();
            txtTotalDistance.Text = Convert.ToString(result);


            con.Close();

            loadStationchecked();

            //while (checkedAdjoin.CheckedItems.Count > 0)
            //{
            //    checkedAdjoin.SetItemChecked(checkedAdjoin.CheckedIndices[0], false);
            //}
        }
        private void loadStationchecked()
        {
            SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
            con2.Open();
            SqlDataAdapter adapt2 = new SqlDataAdapter("Select * from TrainStationManagment Where DestinationStationId Between'" + cmbBoardingstations.SelectedValue.ToString() + "'" + " and " + "'" + cmbFinaldestinations.SelectedValue.ToString() + "'", con2);

            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);

            //  Assign DataTable as DataSource.
            checkedAdjoin.DataSource = dt2;
            checkedAdjoin.DisplayMember = "StationName";
            checkedAdjoin.ValueMember = "DestinationStationId";



        }
        private void cmbBoardingstations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbChooseLane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChooseTrack.SelectedValue != null)
            {
                if (cmbChooseLane.Text == "Lane1")
                {
                    chart1.Series["Distance On X"].Points.Clear();
                    chart1.Series["Origin On Y"].Points.Clear();
                    SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                    SqlCommand cmd = new SqlCommand("SELECT  a1d,a1o,a2d,a2o,a3d,a3o,a4d,a4o,a5d,a5o,a6d,a6o,a7d,a7o,a8d,a8o,a9d,a9o,a10d,a10o FROM TrainLaneManagment Where TrackId='" + cmbChooseTrack.SelectedValue.ToString() + "'", con);

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if ((sdr.Read() == true))
                    {
                        var a1d = (sdr["a1d"]);
                        var a2d = (sdr["a2d"]);
                        var a3d = (sdr["a3d"]);
                        var a4d = (sdr["a4d"]);
                        var a5d = (sdr["a5d"]);
                        var a6d = (sdr["a6d"]);
                        var a7d = (sdr["a7d"]);
                        var a8d = (sdr["a8d"]);
                        var a9d = (sdr["a9d"]);
                        var a10d = (sdr["a10d"]);
                        var a1o = (sdr["a1o"]);
                        var a2o = (sdr["a2o"]);
                        var a3o = (sdr["a3o"]);
                        var a4o = (sdr["a4o"]);
                        var a5o = (sdr["a5o"]);
                        var a6o = (sdr["a6o"]);
                        var a7o = (sdr["a7o"]);
                        var a8o = (sdr["a8o"]);
                        var a9o = (sdr["a9o"]);
                        var a10o = (sdr["a10o"]);


                        //lane1 cell
                        if (a1d.ToString() != null && a1d.ToString() != "")
                        {
                            ConnectDb.a1d = Convert.ToInt16(a1d.ToString());
                        }
                        else
                        {
                            ConnectDb.a1d = 0;
                        }

                        if (a2d.ToString() != null && a2d.ToString() != "")
                        {
                            ConnectDb.a2d = Convert.ToInt16(a2d.ToString());
                        }
                        else
                        {
                            ConnectDb.a2d = 0;
                        }

                        if (a3d.ToString() != null && a3d.ToString() != "")
                        {
                            ConnectDb.a3d = Convert.ToInt16(a3d.ToString());
                        }
                        else
                        {
                            ConnectDb.a3d = 0;
                        }
                        if (a4d.ToString() != null && a4d.ToString() != "")
                        {
                            ConnectDb.a4d = Convert.ToInt16(a4d.ToString());
                        }
                        else
                        {
                            ConnectDb.a4d = 0;
                        }

                        if (a5d.ToString() != null && a5d.ToString() != "")
                        {
                            ConnectDb.a5d = Convert.ToInt16(a5d.ToString());
                        }
                        else
                        {
                            ConnectDb.a5d = 0;
                        }
                        if (a6d.ToString() != null && a6d.ToString() != "")
                        {
                            ConnectDb.a6d = Convert.ToInt16(a6d.ToString());
                        }
                        else
                        {
                            ConnectDb.a6d = 0;
                        }

                        if (a7d.ToString() != null && a7d.ToString() != "")
                        {
                            ConnectDb.a7d = Convert.ToInt16(a7d.ToString());
                        }
                        else
                        {
                            ConnectDb.a7d = 0;
                        }

                        if (a8d.ToString() != null && a8d.ToString() != "")
                        {
                            ConnectDb.a8d = Convert.ToInt16(a8d.ToString());
                        }
                        else
                        {
                            ConnectDb.a8d = 0;
                        }

                        if (a9d.ToString() != null && a9d.ToString() != "")
                        {
                            ConnectDb.a9d = Convert.ToInt16(a9d.ToString());
                        }
                        else
                        {
                            ConnectDb.a9d = 0;
                        }

                        if (a10d.ToString() != null && a10d.ToString() != "")
                        {
                            ConnectDb.a10d = Convert.ToInt16(a10d.ToString());
                        }
                        else
                        {
                            ConnectDb.a10d = 0;
                        }

                        if (a1o.ToString() != null && a1o.ToString() != "")
                        {
                            ConnectDb.a1o = Convert.ToInt16(a1o.ToString());
                        }
                        else
                        {
                            ConnectDb.a1o = 0;
                        }

                        if (a2o.ToString() != null && a2o.ToString() != "")
                        {
                            ConnectDb.a2o = Convert.ToInt16(a2o.ToString());
                        }
                        else
                        {
                            ConnectDb.a2o = 0;
                        }

                        if (a3o.ToString() != null && a3o.ToString() != "")
                        {
                            ConnectDb.a3o = Convert.ToInt16(a3o.ToString());
                        }
                        else
                        {
                            ConnectDb.a3o = 0;
                        }
                        if (a4o.ToString() != null && a4o.ToString() != "")
                        {
                            ConnectDb.a4o = Convert.ToInt16(a4o.ToString());
                        }
                        else
                        {
                            ConnectDb.a4o = 0;
                        }

                        if (a5o.ToString() != null && a5o.ToString() != "")
                        {
                            ConnectDb.a5o = Convert.ToInt16(a5o.ToString());
                        }
                        else
                        {
                            ConnectDb.a5o = 0;
                        }
                        if (a6o.ToString() != null && a6o.ToString() != "")
                        {
                            ConnectDb.a6o = Convert.ToInt16(a6o.ToString());
                        }
                        else
                        {
                            ConnectDb.a6o = 0;
                        }

                        if (a7o.ToString() != null && a7o.ToString() != "")
                        {
                            ConnectDb.a7o = Convert.ToInt16(a7o.ToString());
                        }
                        else
                        {
                            ConnectDb.a7o = 0;
                        }

                        if (a8o.ToString() != null && a8o.ToString() != "")
                        {
                            ConnectDb.a8o = Convert.ToInt16(a8o.ToString());
                        }
                        else
                        {
                            ConnectDb.a8o = 0;
                        }

                        if (a9o.ToString() != null && a9o.ToString() != "")
                        {
                            ConnectDb.a9o = Convert.ToInt16(a9o.ToString());
                        }
                        else
                        {
                            ConnectDb.a9o = 0;
                        }

                        if (a10o.ToString() != null && a10o.ToString() != "")
                        {
                            ConnectDb.a10o = Convert.ToInt16(a10o.ToString());
                        }
                        else
                        {
                            ConnectDb.a10o = 0;
                        }
                    }

                    int[] array1 = { ConnectDb.a1d, ConnectDb.a2d, ConnectDb.a3d, ConnectDb.a4d, ConnectDb.a5d, ConnectDb.a6d, ConnectDb.a7d, ConnectDb.a8d, ConnectDb.a9d, ConnectDb.a10d };
                    txtTrackDistance.Text = array1.Max().ToString();

                    if (ConnectDb.a1o != 0 && ConnectDb.a1d != 0)
                    {
                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a1d, ConnectDb.a1o);

                    }
                    if (ConnectDb.a2o != 0 && ConnectDb.a2d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a2d, ConnectDb.a2o);

                    }
                    if (ConnectDb.a3o != 0 && ConnectDb.a3d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a3d, ConnectDb.a3o);

                    }
                    if (ConnectDb.a4o != 0 && ConnectDb.a4d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a4d, ConnectDb.a4o);

                    }
                    if (ConnectDb.a5o != 0 && ConnectDb.a5d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a5d, ConnectDb.a5o);

                    }
                    if (ConnectDb.a6o != 0 && ConnectDb.a6d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a6d, ConnectDb.a6o);

                    }
                    if (ConnectDb.a7o != 0 && ConnectDb.a7d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a7d, ConnectDb.a7o);

                    }
                    if (ConnectDb.a8o != 0 && ConnectDb.a8d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a8d, ConnectDb.a8o);

                    }
                    if (ConnectDb.a9o != 0 && ConnectDb.a9d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a9d, ConnectDb.a9o);

                    }
                    if (ConnectDb.a10o != 0 && ConnectDb.a10d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.a10d, ConnectDb.a10o);

                    }

                    //..........................
                    //lane1
                    if (ConnectDb.a1o != 0 && ConnectDb.a1d != 0)
                    {
                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a1d, ConnectDb.a1o);

                    }
                    if (ConnectDb.a2o != 0 && ConnectDb.a2d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a2d, ConnectDb.a2o);

                    }
                    if (ConnectDb.a3o != 0 && ConnectDb.a3d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a3d, ConnectDb.a3o);

                    }
                    if (ConnectDb.a4o != 0 && ConnectDb.a4d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a4d, ConnectDb.a4o);

                    }
                    if (ConnectDb.a5o != 0 && ConnectDb.a5d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a5d, ConnectDb.a5o);

                    }
                    if (ConnectDb.a6o != 0 && ConnectDb.a6d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a6d, ConnectDb.a6o);

                    }
                    if (ConnectDb.a7o != 0 && ConnectDb.a7d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a7d, ConnectDb.a7o);

                    }
                    if (ConnectDb.a8o != 0 && ConnectDb.a8d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a8d, ConnectDb.a8o);

                    }
                    if (ConnectDb.a9o != 0 && ConnectDb.a9d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a9d, ConnectDb.a9o);

                    }
                    if (ConnectDb.a10o != 0 && ConnectDb.a10d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.a10d, ConnectDb.a10o);

                    }


                }



                if (cmbChooseLane.Text == "Lane2")
                {
                    chart1.Series["Distance On X"].Points.Clear();
                    chart1.Series["Origin On Y"].Points.Clear();
                    SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
                    SqlCommand cmd2 = new SqlCommand("SELECT  b1d,b2d,b3d,b4d,b5d,b6d,b7d,b8d,b9d,b10d,b1o,b2o,b3o,b4o,b5o,b6o,b7o,b8o,b9o,b10o FROM TrainLaneManagment Where TrackId='" + cmbChooseTrack.SelectedValue.ToString() + "'", con2);

                    con2.Open();
                    SqlDataReader sdr2 = cmd2.ExecuteReader();

                    if ((sdr2.Read() == true))
                    {
                        var b1d = (sdr2["b1d"]);
                        var b2d = (sdr2["b2d"]);
                        var b3d = (sdr2["b3d"]);
                        var b4d = (sdr2["b4d"]);
                        var b5d = (sdr2["b5d"]);
                        var b6d = (sdr2["b6d"]);
                        var b7d = (sdr2["b7d"]);
                        var b8d = (sdr2["b8d"]);
                        var b9d = (sdr2["b9d"]);
                        var b10d = (sdr2["b10d"]);
                        var b1o = (sdr2["b1o"]);
                        var b2o = (sdr2["b2o"]);
                        var b3o = (sdr2["b3o"]);
                        var b4o = (sdr2["b4o"]);
                        var b5o = (sdr2["b5o"]);
                        var b6o = (sdr2["b6o"]);
                        var b7o = (sdr2["b7o"]);
                        var b8o = (sdr2["b8o"]);
                        var b9o = (sdr2["b9o"]);
                        var b10o = (sdr2["b10o"]);

                        int[] array2 = { ConnectDb.b1d, ConnectDb.b2d, ConnectDb.b3d, ConnectDb.b4d, ConnectDb.b5d, ConnectDb.b6d, ConnectDb.b7d, ConnectDb.b8d, ConnectDb.b9d, ConnectDb.b10d };
                        txtTrackDistance.Text = array2.Max().ToString();
                        //lane2 cell
                        if (b1d.ToString() != null && b1d.ToString() != "")
                        {
                            ConnectDb.b1d = Convert.ToInt16(b1d.ToString());
                        }
                        else
                        {
                            ConnectDb.b1d = 0;
                        }

                        if (b2d.ToString() != null && b2d.ToString() != "")
                        {
                            ConnectDb.b2d = Convert.ToInt16(b2d.ToString());
                        }
                        else
                        {
                            ConnectDb.b2d = 0;
                        }

                        if (b3d.ToString() != null && b3d.ToString() != "")
                        {
                            ConnectDb.b3d = Convert.ToInt16(b3d.ToString());
                        }
                        else
                        {
                            ConnectDb.b3d = 0;
                        }
                        if (b4d.ToString() != null && b4d.ToString() != "")
                        {
                            ConnectDb.b4d = Convert.ToInt16(b4d.ToString());
                        }
                        else
                        {
                            ConnectDb.b4d = 0;
                        }

                        if (b5d.ToString() != null && b5d.ToString() != "")
                        {
                            ConnectDb.b5d = Convert.ToInt16(b5d.ToString());
                        }
                        else
                        {
                            ConnectDb.b5d = 0;
                        }
                        if (b6d.ToString() != null && b6d.ToString() != "")
                        {
                            ConnectDb.b6d = Convert.ToInt16(b6d.ToString());
                        }
                        else
                        {
                            ConnectDb.b6d = 0;
                        }

                        if (b7d.ToString() != null && b7d.ToString() != "")
                        {
                            ConnectDb.b7d = Convert.ToInt16(b7d.ToString());
                        }
                        else
                        {
                            ConnectDb.b7d = 0;
                        }

                        if (b8d.ToString() != null && b8d.ToString() != "")
                        {
                            ConnectDb.b8d = Convert.ToInt16(b8d.ToString());
                        }
                        else
                        {
                            ConnectDb.b8d = 0;
                        }

                        if (b9d.ToString() != null && b9d.ToString() != "")
                        {
                            ConnectDb.b9d = Convert.ToInt16(b9d.ToString());
                        }
                        else
                        {
                            ConnectDb.b9d = 0;
                        }

                        if (b10d.ToString() != null && b10d.ToString() != "")
                        {
                            ConnectDb.b10d = Convert.ToInt16(b10d.ToString());
                        }
                        else
                        {
                            ConnectDb.b10d = 0;
                        }

                        if (b1o.ToString() != null && b1o.ToString() != "")
                        {
                            ConnectDb.b1o = Convert.ToInt16(b1o.ToString());
                        }
                        else
                        {
                            ConnectDb.b1o = 0;
                        }

                        if (b2o.ToString() != null && b2o.ToString() != "")
                        {
                            ConnectDb.b2o = Convert.ToInt16(b2o.ToString());
                        }
                        else
                        {
                            ConnectDb.b2o = 0;
                        }

                        if (b3o.ToString() != null && b3o.ToString() != "")
                        {
                            ConnectDb.b3o = Convert.ToInt16(b3o.ToString());
                        }
                        else
                        {
                            ConnectDb.b3o = 0;
                        }
                        if (b4o.ToString() != null && b4o.ToString() != "")
                        {
                            ConnectDb.b4o = Convert.ToInt16(b4o.ToString());
                        }
                        else
                        {
                            ConnectDb.b4o = 0;
                        }

                        if (b5o.ToString() != null && b5o.ToString() != "")
                        {
                            ConnectDb.b5o = Convert.ToInt16(b5o.ToString());
                        }
                        else
                        {
                            ConnectDb.b5o = 0;
                        }
                        if (b6o.ToString() != null && b6o.ToString() != "")
                        {
                            ConnectDb.b6o = Convert.ToInt16(b6o.ToString());
                        }
                        else
                        {
                            ConnectDb.b6o = 0;
                        }

                        if (b7o.ToString() != null && b7o.ToString() != "")
                        {
                            ConnectDb.b7o = Convert.ToInt16(b7o.ToString());
                        }
                        else
                        {
                            ConnectDb.b7o = 0;
                        }

                        if (b8o.ToString() != null && b8o.ToString() != "")
                        {
                            ConnectDb.b8o = Convert.ToInt16(b8o.ToString());
                        }
                        else
                        {
                            ConnectDb.b8o = 0;
                        }

                        if (b9o.ToString() != null && b9o.ToString() != "")
                        {
                            ConnectDb.b9o = Convert.ToInt16(b9o.ToString());
                        }
                        else
                        {
                            ConnectDb.b9o = 0;
                        }

                        if (b10o.ToString() != null && b10o.ToString() != "")
                        {
                            ConnectDb.b10o = Convert.ToInt16(b10o.ToString());
                        }
                        else
                        {
                            ConnectDb.b10o = 0;
                        }

                    }


                    if (ConnectDb.b1o != 0 && ConnectDb.b1d != 0)
                    {
                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b1d, ConnectDb.b1o);

                    }
                    if (ConnectDb.b2o != 0 && ConnectDb.b2d != 0)
                    {


                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b2d, ConnectDb.b2o);


                    }
                    if (ConnectDb.b3o != 0 && ConnectDb.b3d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b3d, ConnectDb.b3o);

                    }
                    if (ConnectDb.b4o != 0 && ConnectDb.b4d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b4d, ConnectDb.b4o);

                    }
                    if (ConnectDb.b5o != 0 && ConnectDb.b5d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b5d, ConnectDb.b5o);

                    }
                    if (ConnectDb.b6o != 0 && ConnectDb.b6d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b6d, ConnectDb.b6o);

                    }
                    if (ConnectDb.b7o != 0 && ConnectDb.b7d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b7d, ConnectDb.b7o);

                    }
                    if (ConnectDb.b8o != 0 && ConnectDb.b8d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b8d, ConnectDb.b8o);

                    }
                    if (ConnectDb.b9o != 0 && ConnectDb.b9d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b9d, ConnectDb.b9o);

                    }
                    if (ConnectDb.b10o != 0 && ConnectDb.b10d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.b10d, ConnectDb.b10o);

                    }

                    //......................
                    //lane2
                    if (ConnectDb.b1o != 0 && ConnectDb.b1d != 0)
                    {
                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b1d, ConnectDb.b1o);

                    }
                    if (ConnectDb.b2o != 0 && ConnectDb.b2d != 0)
                    {


                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b2d, ConnectDb.b2o);


                    }
                    if (ConnectDb.b3o != 0 && ConnectDb.b3d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b3d, ConnectDb.b3o);

                    }
                    if (ConnectDb.b4o != 0 && ConnectDb.b4d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b4d, ConnectDb.b4o);

                    }
                    if (ConnectDb.b5o != 0 && ConnectDb.b5d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b5d, ConnectDb.b5o);

                    }
                    if (ConnectDb.b6o != 0 && ConnectDb.b6d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b6d, ConnectDb.b6o);

                    }
                    if (ConnectDb.b7o != 0 && ConnectDb.b7d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b7d, ConnectDb.b7o);

                    }
                    if (ConnectDb.b8o != 0 && ConnectDb.b8d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b8d, ConnectDb.b8o);

                    }
                    if (ConnectDb.b9o != 0 && ConnectDb.b9d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b9d, ConnectDb.b9o);

                    }
                    if (ConnectDb.b10o != 0 && ConnectDb.b10d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.b10d, ConnectDb.b10o);

                    }

                }
                if (cmbChooseLane.Text == "Lane3")
                {
                    chart1.Series["Distance On X"].Points.Clear();
                    chart1.Series["Origin On Y"].Points.Clear();
                    SqlConnection con3 = new SqlConnection(ConnectDb.connectionString);
                    SqlCommand cmd3 = new SqlCommand("SELECT  c1d,c2d,c3d,c4d,c5d,c6d,c7d,c8d,c9d,c10d,c1o,c2o,c3o,c4o,c5o,c6o,c7o,c8o,c9o,c10o FROM TrainLaneManagment Where TrackId='" + cmbChooseTrack.SelectedValue.ToString() + "'", con3);

                    con3.Open();
                    SqlDataReader sdr3 = cmd3.ExecuteReader();

                    if ((sdr3.Read() == true))
                    {
                        var c1d = (sdr3["c1d"]);
                        var c2d = (sdr3["c2d"]);
                        var c3d = (sdr3["c3d"]);
                        var c4d = (sdr3["c4d"]);
                        var c5d = (sdr3["c5d"]);
                        var c6d = (sdr3["c6d"]);
                        var c7d = (sdr3["c7d"]);
                        var c8d = (sdr3["c8d"]);
                        var c9d = (sdr3["c9d"]);
                        var c10d = (sdr3["c10d"]);
                        var c1o = (sdr3["c1o"]);
                        var c2o = (sdr3["c2o"]);
                        var c3o = (sdr3["c3o"]);
                        var c4o = (sdr3["c4o"]);
                        var c5o = (sdr3["c5o"]);
                        var c6o = (sdr3["c6o"]);
                        var c7o = (sdr3["c7o"]);
                        var c8o = (sdr3["c8o"]);
                        var c9o = (sdr3["c9o"]);
                        var c10o = (sdr3["c10o"]);

                        int[] array3 = { ConnectDb.c1d, ConnectDb.c2d, ConnectDb.c3d, ConnectDb.c4d, ConnectDb.c5d, ConnectDb.c6d, ConnectDb.c7d, ConnectDb.c8d, ConnectDb.c9d, ConnectDb.c10d };
                        txtTrackDistance.Text = array3.Max().ToString();
                        //lane3 cell
                        if (c1d.ToString() != null && c1d.ToString() != "")
                        {
                            ConnectDb.c1d = Convert.ToInt16(c1d.ToString());
                        }
                        else
                        {
                            ConnectDb.c1d = 0;
                        }

                        if (c2d.ToString() != null && c2d.ToString() != "")
                        {
                            ConnectDb.c2d = Convert.ToInt16(c2d.ToString());
                        }
                        else
                        {
                            ConnectDb.c2d = 0;
                        }

                        if (c3d.ToString() != null && c3d.ToString() != "")
                        {
                            ConnectDb.c3d = Convert.ToInt16(c3d.ToString());
                        }
                        else
                        {
                            ConnectDb.c3d = 0;
                        }
                        if (c4d.ToString() != null && c4d.ToString() != "")
                        {
                            ConnectDb.c4d = Convert.ToInt16(c4d.ToString());
                        }
                        else
                        {
                            ConnectDb.c4d = 0;
                        }

                        if (c5d.ToString() != null && c5d.ToString() != "")
                        {
                            ConnectDb.c5d = Convert.ToInt16(c5d.ToString());
                        }
                        else
                        {
                            ConnectDb.c5d = 0;
                        }
                        if (c6d.ToString() != null && c6d.ToString() != "")
                        {
                            ConnectDb.c6d = Convert.ToInt16(c6d.ToString());
                        }
                        else
                        {
                            ConnectDb.c6d = 0;
                        }

                        if (c7d.ToString() != null && c7d.ToString() != "")
                        {
                            ConnectDb.c7d = Convert.ToInt16(c7d.ToString());
                        }
                        else
                        {
                            ConnectDb.c7d = 0;
                        }

                        if (c8d.ToString() != null && c8d.ToString() != "")
                        {
                            ConnectDb.c8d = Convert.ToInt16(c8d.ToString());
                        }
                        else
                        {
                            ConnectDb.c8d = 0;
                        }

                        if (c9d.ToString() != null && c9d.ToString() != "")
                        {
                            ConnectDb.c9d = Convert.ToInt16(c9d.ToString());
                        }
                        else
                        {
                            ConnectDb.c9d = 0;
                        }

                        if (c10d.ToString() != null && c10d.ToString() != "")
                        {
                            ConnectDb.c10d = Convert.ToInt16(c10d.ToString());
                        }
                        else
                        {
                            ConnectDb.c10d = 0;
                        }

                        if (c1o.ToString() != null && c1o.ToString() != "")
                        {
                            ConnectDb.c1o = Convert.ToInt16(c1o.ToString());
                        }
                        else
                        {
                            ConnectDb.c1o = 0;
                        }

                        if (c2o.ToString() != null && c2o.ToString() != "")
                        {
                            ConnectDb.c2o = Convert.ToInt16(c2o.ToString());
                        }
                        else
                        {
                            ConnectDb.c2o = 0;
                        }

                        if (c3o.ToString() != null && c3o.ToString() != "")
                        {
                            ConnectDb.c3o = Convert.ToInt16(c3o.ToString());
                        }
                        else
                        {
                            ConnectDb.c3o = 0;
                        }
                        if (c4o.ToString() != null && c4o.ToString() != "")
                        {
                            ConnectDb.c4o = Convert.ToInt16(c4o.ToString());
                        }
                        else
                        {
                            ConnectDb.c4o = 0;
                        }

                        if (c5o.ToString() != null && c5o.ToString() != "")
                        {
                            ConnectDb.c5o = Convert.ToInt16(c5o.ToString());
                        }
                        else
                        {
                            ConnectDb.c5o = 0;
                        }
                        if (c6o.ToString() != null && c6o.ToString() != "")
                        {
                            ConnectDb.c6o = Convert.ToInt16(c6o.ToString());
                        }
                        else
                        {
                            ConnectDb.c6o = 0;
                        }

                        if (c7o.ToString() != null && c7o.ToString() != "")
                        {
                            ConnectDb.c7o = Convert.ToInt16(c7o.ToString());
                        }
                        else
                        {
                            ConnectDb.c7o = 0;
                        }

                        if (c8o.ToString() != null && c8o.ToString() != "")
                        {
                            ConnectDb.c8o = Convert.ToInt16(c8o.ToString());
                        }
                        else
                        {
                            ConnectDb.c8o = 0;
                        }

                        if (c9o.ToString() != null && c9o.ToString() != "")
                        {
                            ConnectDb.c9o = Convert.ToInt16(c9o.ToString());
                        }
                        else
                        {
                            ConnectDb.c9o = 0;
                        }

                        if (c10o.ToString() != null && c10o.ToString() != "")
                        {
                            ConnectDb.c10o = Convert.ToInt16(c10o.ToString());
                        }
                        else
                        {
                            ConnectDb.c10o = 0;
                        }

                    }

                    if (ConnectDb.c1o != 0 && ConnectDb.c1d != 0)
                    {
                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c1d, ConnectDb.c1o);

                    }
                    if (ConnectDb.c2o != 0 && ConnectDb.c2d != 0)
                    {


                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c2d, ConnectDb.c2o);


                    }
                    if (ConnectDb.c3o != 0 && ConnectDb.c3d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c3d, ConnectDb.c3o);

                    }
                    if (ConnectDb.c4o != 0 && ConnectDb.c4d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c4d, ConnectDb.c4o);

                    }
                    if (ConnectDb.c5o != 0 && ConnectDb.c5d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c5d, ConnectDb.c5o);

                    }
                    if (ConnectDb.c6o != 0 && ConnectDb.c6d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c6d, ConnectDb.c6o);

                    }
                    if (ConnectDb.c7o != 0 && ConnectDb.c7d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c7d, ConnectDb.c7o);

                    }
                    if (ConnectDb.c8o != 0 && ConnectDb.c8d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c8d, ConnectDb.c8o);

                    }
                    if (ConnectDb.c9o != 0 && ConnectDb.c9d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c9d, ConnectDb.c9o);

                    }
                    if (ConnectDb.c10o != 0 && ConnectDb.c10d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.c10d, ConnectDb.c10o);

                    }
                    //......................
                    //lane3
                    if (ConnectDb.c1o != 0 && ConnectDb.c1d != 0)
                    {
                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c1d, ConnectDb.c1o);

                    }
                    if (ConnectDb.c2o != 0 && ConnectDb.c2d != 0)
                    {


                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c2d, ConnectDb.c2o);


                    }
                    if (ConnectDb.c3o != 0 && ConnectDb.c3d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c3d, ConnectDb.c3o);

                    }
                    if (ConnectDb.c4o != 0 && ConnectDb.c4d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c4d, ConnectDb.c4o);

                    }
                    if (ConnectDb.c5o != 0 && ConnectDb.c5d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c5d, ConnectDb.c5o);

                    }
                    if (ConnectDb.c6o != 0 && ConnectDb.c6d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c6d, ConnectDb.c6o);

                    }
                    if (ConnectDb.c7o != 0 && ConnectDb.c7d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c7d, ConnectDb.c7o);

                    }
                    if (ConnectDb.c8o != 0 && ConnectDb.c8d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c8d, ConnectDb.c8o);

                    }
                    if (ConnectDb.c9o != 0 && ConnectDb.c9d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c9d, ConnectDb.c9o);

                    }
                    if (ConnectDb.c10o != 0 && ConnectDb.c10d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.c10d, ConnectDb.c10o);

                    }
                }
                if (cmbChooseLane.Text == "Lane4")
                {
                    chart1.Series["Distance On X"].Points.Clear();
                    chart1.Series["Origin On Y"].Points.Clear();
                    SqlConnection con4 = new SqlConnection(ConnectDb.connectionString);
                    SqlCommand cmd4 = new SqlCommand("SELECT  d1d,d2d,d3d,d4d,d5d,d6d,d7d,d8d,d9d,d10d,d1o,d2o,d3o,d4o,d5o,d6o,d7o,d8o,d9o,d10o FROM TrainLaneManagment Where TrackId='" + cmbChooseTrack.SelectedValue.ToString() + "'", con4);

                    con4.Open();
                    SqlDataReader sdr4 = cmd4.ExecuteReader();

                    if ((sdr4.Read() == true))
                    {
                        var d1d = (sdr4["d1d"]);
                        var d2d = (sdr4["d2d"]);
                        var d3d = (sdr4["d3d"]);
                        var d4d = (sdr4["d4d"]);
                        var d5d = (sdr4["d5d"]);
                        var d6d = (sdr4["d6d"]);
                        var d7d = (sdr4["d7d"]);
                        var d8d = (sdr4["d8d"]);
                        var d9d = (sdr4["d9d"]);
                        var d10d = (sdr4["d10d"]);
                        var d1o = (sdr4["d1o"]);
                        var d2o = (sdr4["d2o"]);
                        var d3o = (sdr4["d3o"]);
                        var d4o = (sdr4["d4o"]);
                        var d5o = (sdr4["d5o"]);
                        var d6o = (sdr4["d6o"]);
                        var d7o = (sdr4["d7o"]);
                        var d8o = (sdr4["d8o"]);
                        var d9o = (sdr4["d9o"]);
                        var d10o = (sdr4["d10o"]);

                        int[] array4 = { ConnectDb.d1d, ConnectDb.d2d, ConnectDb.d3d, ConnectDb.d4d, ConnectDb.d5d, ConnectDb.d6d, ConnectDb.d7d, ConnectDb.d8d, ConnectDb.d9d, ConnectDb.d10d };
                        txtTrackDistance.Text = array4.Max().ToString();
                        //lane4 cell
                        if (d1d.ToString() != null && d1d.ToString() != "")
                        {
                            ConnectDb.d1d = Convert.ToInt16(d1d.ToString());
                        }
                        else
                        {
                            ConnectDb.d1d = 0;
                        }

                        if (d2d.ToString() != null && d2d.ToString() != "")
                        {
                            ConnectDb.d2d = Convert.ToInt16(d2d.ToString());
                        }
                        else
                        {
                            ConnectDb.d2d = 0;
                        }

                        if (d3d.ToString() != null && d3d.ToString() != "")
                        {
                            ConnectDb.d3d = Convert.ToInt16(d3d.ToString());
                        }
                        else
                        {
                            ConnectDb.d3d = 0;
                        }
                        if (d4d.ToString() != null && d4d.ToString() != "")
                        {
                            ConnectDb.d4d = Convert.ToInt16(d4d.ToString());
                        }
                        else
                        {
                            ConnectDb.d4d = 0;
                        }

                        if (d5d.ToString() != null && d5d.ToString() != "")
                        {
                            ConnectDb.d5d = Convert.ToInt16(d5d.ToString());
                        }
                        else
                        {
                            ConnectDb.d5d = 0;
                        }
                        if (d6d.ToString() != null && d6d.ToString() != "")
                        {
                            ConnectDb.d6d = Convert.ToInt16(d6d.ToString());
                        }
                        else
                        {
                            ConnectDb.d6d = 0;
                        }

                        if (d7d.ToString() != null && d7d.ToString() != "")
                        {
                            ConnectDb.d7d = Convert.ToInt16(d7d.ToString());
                        }
                        else
                        {
                            ConnectDb.d7d = 0;
                        }

                        if (d8d.ToString() != null && d8d.ToString() != "")
                        {
                            ConnectDb.d8d = Convert.ToInt16(d8d.ToString());
                        }
                        else
                        {
                            ConnectDb.d8d = 0;
                        }

                        if (d9d.ToString() != null && d9d.ToString() != "")
                        {
                            ConnectDb.d9d = Convert.ToInt16(d9d.ToString());
                        }
                        else
                        {
                            ConnectDb.d9d = 0;
                        }

                        if (d10d.ToString() != null && d10d.ToString() != "")
                        {
                            ConnectDb.d10d = Convert.ToInt16(d10d.ToString());
                        }
                        else
                        {
                            ConnectDb.d10d = 0;
                        }

                        if (d1o.ToString() != null && d1o.ToString() != "")
                        {
                            ConnectDb.d1o = Convert.ToInt16(d1o.ToString());
                        }
                        else
                        {
                            ConnectDb.d1o = 0;
                        }

                        if (d2o.ToString() != null && d2o.ToString() != "")
                        {
                            ConnectDb.d2o = Convert.ToInt16(d2o.ToString());
                        }
                        else
                        {
                            ConnectDb.d2o = 0;
                        }

                        if (d3o.ToString() != null && d3o.ToString() != "")
                        {
                            ConnectDb.d3o = Convert.ToInt16(d3o.ToString());
                        }
                        else
                        {
                            ConnectDb.d3o = 0;
                        }
                        if (d4o.ToString() != null && d4o.ToString() != "")
                        {
                            ConnectDb.d4o = Convert.ToInt16(d4o.ToString());
                        }
                        else
                        {
                            ConnectDb.d4o = 0;
                        }

                        if (d5o.ToString() != null && d5o.ToString() != "")
                        {
                            ConnectDb.d5o = Convert.ToInt16(d5o.ToString());
                        }
                        else
                        {
                            ConnectDb.d5o = 0;
                        }
                        if (d6o.ToString() != null && d6o.ToString() != "")
                        {
                            ConnectDb.d6o = Convert.ToInt16(d6o.ToString());
                        }
                        else
                        {
                            ConnectDb.d6o = 0;
                        }

                        if (d7o.ToString() != null && d7o.ToString() != "")
                        {
                            ConnectDb.d7o = Convert.ToInt16(d7o.ToString());
                        }
                        else
                        {
                            ConnectDb.d7o = 0;
                        }

                        if (d8o.ToString() != null && d8o.ToString() != "")
                        {
                            ConnectDb.d8o = Convert.ToInt16(d8o.ToString());
                        }
                        else
                        {
                            ConnectDb.d8o = 0;
                        }

                        if (d9o.ToString() != null && d9o.ToString() != "")
                        {
                            ConnectDb.d9o = Convert.ToInt16(d9o.ToString());
                        }
                        else
                        {
                            ConnectDb.d9o = 0;
                        }

                        if (d10o.ToString() != null && d10o.ToString() != "")
                        {
                            ConnectDb.d10o = Convert.ToInt16(d10o.ToString());
                        }
                        else
                        {
                            ConnectDb.d10o = 0;
                        }
                    }

                    if (ConnectDb.d1o != 0 && ConnectDb.d1d != 0)
                    {
                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d1d, ConnectDb.d1o);

                    }
                    if (ConnectDb.d2o != 0 && ConnectDb.d2d != 0)
                    {


                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d2d, ConnectDb.d2o);


                    }
                    if (ConnectDb.d3o != 0 && ConnectDb.d3d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d3d, ConnectDb.d3o);

                    }
                    if (ConnectDb.d4o != 0 && ConnectDb.d4d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d4d, ConnectDb.d4o);

                    }
                    if (ConnectDb.d5o != 0 && ConnectDb.d5d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d5d, ConnectDb.d5o);

                    }
                    if (ConnectDb.d6o != 0 && ConnectDb.d6d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d6d, ConnectDb.d6o);

                    }
                    if (ConnectDb.d7o != 0 && ConnectDb.d7d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d7d, ConnectDb.d7o);

                    }
                    if (ConnectDb.d8o != 0 && ConnectDb.d8d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d8d, ConnectDb.d8o);

                    }
                    if (ConnectDb.d9o != 0 && ConnectDb.d9d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d9d, ConnectDb.d9o);

                    }
                    if (ConnectDb.d10o != 0 && ConnectDb.d10d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.d10d, ConnectDb.d10o);

                    }

                    //.....................
                    //lane4
                    if (ConnectDb.d1o != 0 && ConnectDb.d1d != 0)
                    {
                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d1d, ConnectDb.d1o);

                    }
                    if (ConnectDb.d2o != 0 && ConnectDb.d2d != 0)
                    {


                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d2d, ConnectDb.d2o);


                    }
                    if (ConnectDb.d3o != 0 && ConnectDb.d3d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d3d, ConnectDb.d3o);

                    }
                    if (ConnectDb.d4o != 0 && ConnectDb.d4d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d4d, ConnectDb.d4o);

                    }
                    if (ConnectDb.d5o != 0 && ConnectDb.d5d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d5d, ConnectDb.d5o);

                    }
                    if (ConnectDb.d6o != 0 && ConnectDb.d6d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d6d, ConnectDb.d6o);

                    }
                    if (ConnectDb.d7o != 0 && ConnectDb.d7d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d7d, ConnectDb.d7o);

                    }
                    if (ConnectDb.d8o != 0 && ConnectDb.d8d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d8d, ConnectDb.d8o);

                    }
                    if (ConnectDb.d9o != 0 && ConnectDb.d9d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d9d, ConnectDb.d9o);

                    }
                    if (ConnectDb.d10o != 0 && ConnectDb.d10d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.d10d, ConnectDb.d10o);

                    }
                }
                if (cmbChooseLane.Text == "Lane5")
                {
                    chart1.Series["Distance On X"].Points.Clear();
                    chart1.Series["Origin On Y"].Points.Clear();
                    SqlConnection con5 = new SqlConnection(ConnectDb.connectionString);
                    SqlCommand cmd5 = new SqlCommand("SELECT  e1d,e2d,e3d,e4d,e5d,e6d,e7d,e8d,e9d,e10d,e1o,e2o,e3o,e4o,e5o,e6o,e7o,e8o,e9o,e10o FROM TrainLaneManagment Where TrackId='" + cmbChooseTrack.SelectedValue.ToString() + "'", con5);

                    con5.Open();
                    SqlDataReader sdr5 = cmd5.ExecuteReader();

                    if ((sdr5.Read() == true))
                    {
                        var e1d = (sdr5["e1d"]);
                        var e2d = (sdr5["e2d"]);
                        var e3d = (sdr5["e3d"]);
                        var e4d = (sdr5["e4d"]);
                        var e5d = (sdr5["e5d"]);
                        var e6d = (sdr5["e6d"]);
                        var e7d = (sdr5["e7d"]);
                        var e8d = (sdr5["e8d"]);
                        var e9d = (sdr5["e9d"]);
                        var e10d = (sdr5["e10d"]);
                        var e1o = (sdr5["e1o"]);
                        var e2o = (sdr5["e2o"]);
                        var e3o = (sdr5["e3o"]);
                        var e4o = (sdr5["e4o"]);
                        var e5o = (sdr5["e5o"]);
                        var e6o = (sdr5["e6o"]);
                        var e7o = (sdr5["e7o"]);
                        var e8o = (sdr5["e8o"]);
                        var e9o = (sdr5["e9o"]);
                        var e10o = (sdr5["e10o"]);


                        int[] array5 = { ConnectDb.e1d, ConnectDb.e2d, ConnectDb.e3d, ConnectDb.e4d, ConnectDb.e5d, ConnectDb.e6d, ConnectDb.e7d, ConnectDb.e8d, ConnectDb.e9d, ConnectDb.e10d };
                        txtTrackDistance.Text = array5.Max().ToString();
                        //lane5 cell
                        if (e1d.ToString() != null && e1d.ToString() != "")
                        {
                            ConnectDb.e1d = Convert.ToInt16(e1d.ToString());
                        }
                        else
                        {
                            ConnectDb.e1d = 0;
                        }

                        if (e2d.ToString() != null && e2d.ToString() != "")
                        {
                            ConnectDb.e2d = Convert.ToInt16(e2d.ToString());
                        }
                        else
                        {
                            ConnectDb.e2d = 0;
                        }

                        if (e3d.ToString() != null && e3d.ToString() != "")
                        {
                            ConnectDb.e3d = Convert.ToInt16(e3d.ToString());
                        }
                        else
                        {
                            ConnectDb.e3d = 0;
                        }
                        if (e4d.ToString() != null && e4d.ToString() != "")
                        {
                            ConnectDb.e4d = Convert.ToInt16(e4d.ToString());
                        }
                        else
                        {
                            ConnectDb.e4d = 0;
                        }

                        if (e5d.ToString() != null && e5d.ToString() != "")
                        {
                            ConnectDb.e5d = Convert.ToInt16(e5d.ToString());
                        }
                        else
                        {
                            ConnectDb.e5d = 0;
                        }
                        if (e6d.ToString() != null && e6d.ToString() != "")
                        {
                            ConnectDb.e6d = Convert.ToInt16(e6d.ToString());
                        }
                        else
                        {
                            ConnectDb.e6d = 0;
                        }

                        if (e7d.ToString() != null && e7d.ToString() != "")
                        {
                            ConnectDb.e7d = Convert.ToInt16(e7d.ToString());
                        }
                        else
                        {
                            ConnectDb.e7d = 0;
                        }

                        if (e8d.ToString() != null && e8d.ToString() != "")
                        {
                            ConnectDb.e8d = Convert.ToInt16(e8d.ToString());
                        }
                        else
                        {
                            ConnectDb.e8d = 0;
                        }

                        if (e9d.ToString() != null && e9d.ToString() != "")
                        {
                            ConnectDb.e9d = Convert.ToInt16(e9d.ToString());
                        }
                        else
                        {
                            ConnectDb.e9d = 0;
                        }

                        if (e10d.ToString() != null && e10d.ToString() != "")
                        {
                            ConnectDb.e10d = Convert.ToInt16(e10d.ToString());
                        }
                        else
                        {
                            ConnectDb.e10d = 0;
                        }

                        if (e1o.ToString() != null && e1o.ToString() != "")
                        {
                            ConnectDb.e1o = Convert.ToInt16(e1o.ToString());
                        }
                        else
                        {
                            ConnectDb.e1o = 0;
                        }

                        if (e2o.ToString() != null && e2o.ToString() != "")
                        {
                            ConnectDb.e2o = Convert.ToInt16(e2o.ToString());
                        }
                        else
                        {
                            ConnectDb.e2o = 0;
                        }

                        if (e3o.ToString() != null && e3o.ToString() != "")
                        {
                            ConnectDb.e3o = Convert.ToInt16(e3o.ToString());
                        }
                        else
                        {
                            ConnectDb.e3o = 0;
                        }
                        if (e4o.ToString() != null && e4o.ToString() != "")
                        {
                            ConnectDb.e4o = Convert.ToInt16(e4o.ToString());
                        }
                        else
                        {
                            ConnectDb.e4o = 0;
                        }

                        if (e5o.ToString() != null && e5o.ToString() != "")
                        {
                            ConnectDb.e5o = Convert.ToInt16(e5o.ToString());
                        }
                        else
                        {
                            ConnectDb.e5o = 0;
                        }
                        if (e6o.ToString() != null && e6o.ToString() != "")
                        {
                            ConnectDb.e6o = Convert.ToInt16(e6o.ToString());
                        }
                        else
                        {
                            ConnectDb.e6o = 0;
                        }

                        if (e7o.ToString() != null && e7o.ToString() != "")
                        {
                            ConnectDb.e7o = Convert.ToInt16(e7o.ToString());
                        }
                        else
                        {
                            ConnectDb.e7o = 0;
                        }

                        if (e8o.ToString() != null && e8o.ToString() != "")
                        {
                            ConnectDb.e8o = Convert.ToInt16(e8o.ToString());
                        }
                        else
                        {
                            ConnectDb.e8o = 0;
                        }

                        if (e9o.ToString() != null && e9o.ToString() != "")
                        {
                            ConnectDb.e9o = Convert.ToInt16(e9o.ToString());
                        }
                        else
                        {
                            ConnectDb.e9o = 0;
                        }

                        if (e10o.ToString() != null && e10o.ToString() != "")
                        {
                            ConnectDb.e10o = Convert.ToInt16(e10o.ToString());
                        }
                        else
                        {
                            ConnectDb.e10o = 0;
                        }
                    }
                    if (ConnectDb.e1o != 0 && ConnectDb.e1d != 0)
                    {
                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e1d, ConnectDb.e1o);

                    }
                    if (ConnectDb.e2o != 0 && ConnectDb.e2d != 0)
                    {


                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e2d, ConnectDb.e2o);


                    }
                    if (ConnectDb.e3o != 0 && ConnectDb.e3d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e3d, ConnectDb.e3o);

                    }
                    if (ConnectDb.e4o != 0 && ConnectDb.e4d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e4d, ConnectDb.e4o);

                    }
                    if (ConnectDb.e5o != 0 && ConnectDb.e5d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e5d, ConnectDb.e5o);

                    }
                    if (ConnectDb.e6o != 0 && ConnectDb.e6d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e6d, ConnectDb.e6o);

                    }
                    if (ConnectDb.e7o != 0 && ConnectDb.e7d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e7d, ConnectDb.e7o);

                    }
                    if (ConnectDb.e8o != 0 && ConnectDb.e8d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e8d, ConnectDb.e8o);

                    }
                    if (ConnectDb.e9o != 0 && ConnectDb.e9d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e9d, ConnectDb.e9o);

                    }
                    if (ConnectDb.e10o != 0 && ConnectDb.e10d != 0)
                    {

                        chart1.Series["Distance On X"].Points.AddXY(ConnectDb.e10d, ConnectDb.e10o);

                    }

                    //....................
                    //lane5
                    if (ConnectDb.e1o != 0 && ConnectDb.e1d != 0)
                    {
                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e1d, ConnectDb.e1o);

                    }
                    if (ConnectDb.e2o != 0 && ConnectDb.e2d != 0)
                    {


                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e2d, ConnectDb.e2o);


                    }
                    if (ConnectDb.e3o != 0 && ConnectDb.e3d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e3d, ConnectDb.e3o);

                    }
                    if (ConnectDb.e4o != 0 && ConnectDb.e4d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e4d, ConnectDb.e4o);

                    }
                    if (ConnectDb.e5o != 0 && ConnectDb.e5d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e5d, ConnectDb.e5o);

                    }
                    if (ConnectDb.e6o != 0 && ConnectDb.e6d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e6d, ConnectDb.e6o);

                    }
                    if (ConnectDb.e7o != 0 && ConnectDb.e7d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e7d, ConnectDb.e7o);

                    }
                    if (ConnectDb.e8o != 0 && ConnectDb.e8d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e8d, ConnectDb.e8o);

                    }
                    if (ConnectDb.e9o != 0 && ConnectDb.e9d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e9d, ConnectDb.e9o);

                    }
                    if (ConnectDb.e10o != 0 && ConnectDb.e10d != 0)
                    {

                        chart1.Series["Origin On Y"].Points.AddXY(ConnectDb.e10d, ConnectDb.e10o);

                    }

                }
            }
            else
            {
                MessageBox.Show("Please select any value from Choose Track!");
            }
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);
                chart1.ChartAreas[0].CursorX.Interval = 0;
                chart1.ChartAreas[0].CursorY.Interval = 0;

                chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label2.Text = "Origin Pixel Position:" + chart1.ChartAreas[0].AxisX.ValueToPixelPosition(e.X).ToString();
                label3.Text = "Distance Pixel Position:" + chart1.ChartAreas[0].AxisX.ValueToPixelPosition(e.X).ToString();

                HitTestResult result2 = chart1.HitTest(e.X, e.Y);

                if (result2.PointIndex > -1 && result2.ChartArea != null)
                {
                    label4.Text = "Origin-Value:" + result2.Series.Points[result2.PointIndex].YValues[0].ToString();

                }



                var pos = e.Location;
                if (prevPosition.HasValue && pos == prevPosition.Value)
                    return;
                tooltip.RemoveAll();
                prevPosition = pos;
                var results = chart1.HitTest(pos.X, pos.Y, false,
                                                ChartElementType.DataPoint);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        if (prop != null)
                        {
                            var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                            var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                            // check if the cursor is really close to the point (2 pixels around the point)
                            if (Math.Abs(pos.X - pointXPixel) < 2 &&
                                Math.Abs(pos.Y - pointYPixel) < 2)
                            {
                                tooltip.Show("Distance=" + prop.XValue + ", Origin=" + prop.YValues[0], this.chart1,
                                                pos.X, pos.Y - 15);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void checkedAdjoin_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                chart1.Series["Destination Distance "].Points.Clear();
                double total = 0;
                  string SetAjoint = "";
                foreach (object item in checkedAdjoin.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                   

                    //  MessageBox.Show(row["StationName"].ToString() + "||" + row["DestinationStationId"].ToString());
                    chart1.Series["Destination Distance "].Points.AddY(row["DestinationStationId"].ToString());
                    SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT  (DistanceOnTrack)  FROM  TrainStationManagment Where DestinationStationId ='" + row["DestinationStationId"].ToString() + "'", con);

                    cmd.ExecuteNonQuery();
                    object result = cmd.ExecuteScalar();


                    total = total + Convert.ToDouble(result);

                    SqlConnection con2 = new SqlConnection(ConnectDb.connectionString);
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT  StationName  FROM  TrainStationManagment Where DestinationStationId ='" + row["DestinationStationId"].ToString() + "'", con2);
                    cmd2.ExecuteNonQuery();
                    object result2 = cmd2.ExecuteScalar();
                    SetAjoint += ","+result2;
                }
                txtTotalDistance.Text = Convert.ToString(total);
                ConnectDb.setadjoin = SetAjoint;

                //while (checkedAdjoin.CheckedItems.Count > 0)
                //{
                //    checkedAdjoin.SetItemChecked(checkedAdjoin.CheckedIndices[0], false);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void checkedAdjoin_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
