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

namespace TrainTracking
{
    public partial class DestinationControl : UserControl
    {
        public static DataTable dt = new DataTable();
        public DestinationControl()
        {
            InitializeComponent();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            AddUser();
            ClearAll();
            LoadUser();
        }
        private void ClearAll()
        {
            txtId.Text = "";
            txtStationName.Text = "";
            txtNumberofTracks.Text = "";
            txtDistanceOnTrack.Text = "";
            txtGradient.Text = "";
            txtSlop.Text = "";
            txtApprochingDistance.Text = "";
            
            radioActive.IsChecked = false;
            radioInActive.IsChecked = false;
            btnSelectPreviousStation.Visible = true;
            cmbSelectPreviousStation.Visible = false;
            radLabel1.Visible = false;

        }
        private void AddUser()
        {
            dt.Clear();
            try
            {
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtId.Text == "" && txtStationName.Text != "" && txtNumberofTracks.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into TrainStationManagment(StationName,NumberOfTracks,DistanceOnTrack,Gradient,Slop,ApprochingDistance,Status) Values(@StationName,@NumberOfTracks,@DistanceOnTrack,@Gradient,@Slop,@ApprochingDistance,@Status)", con);
                    cmd.Parameters.AddWithValue("@StationName", txtStationName.Text.ToString());
                    cmd.Parameters.AddWithValue("@NumberOfTracks", txtNumberofTracks.Text.ToString());
                    cmd.Parameters.AddWithValue("@DistanceOnTrack", txtDistanceOnTrack.Text.ToString());
                    cmd.Parameters.AddWithValue("@Gradient", txtGradient.Text.ToString());
                    cmd.Parameters.AddWithValue("@Slop", txtSlop.Text.ToString());
                    cmd.Parameters.AddWithValue("@ApprochingDistance", txtApprochingDistance.Text.ToString());
                   

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
            catch
            {
                MessageBox.Show("Error Failed Insertion");
            }
        }

        private void DestinationControl_Load(object sender, EventArgs e)
        {
            LoadUser();
            
            cmbSelectPreviousStation.Visible = false;
            radLabel1.Visible = false;
        }
        private void loadSelectPrevious()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainStationManagment");

            cmbSelectPreviousStation.DisplayMember = "StationName";
            cmbSelectPreviousStation.ValueMember = "DestinationStationId";
            cmbSelectPreviousStation.DataSource = ds.Tables["TrainStationManagment"];
         //   cmbSelectPreviousStation.SelectedIndex = -1;

        }
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           // this.DGV.Columns["DestinationStationId"].Visible = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dt.Clear();
            update();
            ClearAll();
            LoadUser();
        }

        private void update()
        {
            try
            {

                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtId.Text != "")
                {

                    SqlCommand cmd = new SqlCommand("update TrainStationManagment SET StationName=@StationName, NumberOfTracks=@NumberOfTracks,DistanceOnTrack=@DistanceOnTrack, Gradient=@Gradient,Slop=@Slop, ApprochingDistance=@ApprochingDistance, Status=@Status  where DestinationStationId='" + txtId.Text.ToString() + "'", con);
                    cmd.Parameters.AddWithValue("@StationName", txtStationName.Text.ToString());
                    cmd.Parameters.AddWithValue("@NumberOfTracks", txtNumberofTracks.Text.ToString());
                    cmd.Parameters.AddWithValue("@DistanceOnTrack", txtDistanceOnTrack.Text.ToString());
                    cmd.Parameters.AddWithValue("@Gradient", txtGradient.Text.ToString());
                    cmd.Parameters.AddWithValue("@Slop", txtSlop.Text.ToString());
                    cmd.Parameters.AddWithValue("@ApprochingDistance", txtApprochingDistance.Text.ToString());
                    
                   
                    if (radioActive.IsChecked == true)
                    {
                        cmd.Parameters.AddWithValue("@Status", "Active".ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", "InActive".ToString());
                    }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated");

                }
                else
                {
                    MessageBox.Show("Please select any row from Grid View");
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM TrainStationManagment WHERE DestinationStationId = '" + txtId.Text.ToString() + "'", con);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            search();
        }
        private void search()
        {

            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment Where StationName Like'%" + txtSearch.Text.ToString() + "%'", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            con.Close();
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

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var DestinationStationId = DGV.Rows[e.RowIndex].Cells["DestinationStationId"].Value;
                var StationName = DGV.Rows[e.RowIndex].Cells["StationName"].Value;
                var NumberOfTracks = DGV.Rows[e.RowIndex].Cells["NumberOfTracks"].Value;
                var DistanceOnTrack = DGV.Rows[e.RowIndex].Cells["DistanceOnTrack"].Value;
                var Gradient = DGV.Rows[e.RowIndex].Cells["Gradient"].Value;
                var Slop = DGV.Rows[e.RowIndex].Cells["Slop"].Value;
                var ApprochingDistance = DGV.Rows[e.RowIndex].Cells["ApprochingDistance"].Value;
                var Status = DGV.Rows[e.RowIndex].Cells["Status"].Value;
                


                txtId.Text = DestinationStationId.ToString();
                txtStationName.Text = StationName.ToString();
                txtNumberofTracks.Text = NumberOfTracks.ToString();
                txtDistanceOnTrack.Text = DistanceOnTrack.ToString();
                txtGradient.Text = Gradient.ToString();
                txtSlop.Text = Slop.ToString();
                txtApprochingDistance.Text = ApprochingDistance.ToString();
               
                
               

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGV.FirstDisplayedScrollingRowIndex = DGV.RowCount - 1;
        }

        private void cmbSelectPreviousStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                SqlCommand cmd = new SqlCommand("SELECT  DistanceOnTrack FROM TrainStationManagment Where DestinationStationId='" + cmbSelectPreviousStation.SelectedValue.ToString() + "'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if ((sdr.Read() == true))
                {
                    ConnectDb.distanceOnTrack = Convert.ToInt32(sdr["DistanceOnTrack"]);
                }
                else
                {

                }
                      
        }

        private void cmbSelectPreviousStation_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDistanceOnTrack_TextChanged(object sender, EventArgs e)
        {
            if (cmbSelectPreviousStation.Visible == true) {

                if (txtDistanceOnTrack.Text == "")
                {

                    txtDistanceOnTrack.Text = "0";
                }
                else
                {
                    int a = Convert.ToInt16(txtDistanceOnTrack.Text);
                    int b = ConnectDb.distanceOnTrack;
                    int c = a - b;
                    txtApprochingDistance.Text = c.ToString();
                }
            }
            else {
                txtApprochingDistance.Text = "0";
            }
        }

        private void btnSelectPreviousStation_Click(object sender, EventArgs e)
        {
            loadSelectPrevious();
            btnSelectPreviousStation.Visible = false;
            cmbSelectPreviousStation.Visible = true;
            radLabel1.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

    }

}
