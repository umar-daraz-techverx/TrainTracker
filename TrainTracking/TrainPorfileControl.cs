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
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;

namespace TrainTracking
{
    public partial class TrainPorfileControl : UserControl
    {
        public static DataTable dt = new DataTable();
        public TrainPorfileControl()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            AddUser();
            ClearAll();
        }
        private void ClearAll(){
            txtName.Text="";
            txtSpeed.Text = "";
            txtLength.Text = "";
            txtCoach.Text = "";
            cmbCategory.Text = "";
            radioActive.IsChecked = false;
            radioInActive.IsChecked = false;
            radioMultipleSitter.IsChecked = false;
            radioSameSitter.IsChecked = false;
            txtId.Text = "";
            txtTotalWagon.Text = "";

        }
        private void AddUser()
        {
            dt.Clear();
            try
            {SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if(txtId.Text == ""&& txtName.Text!=""&&txtSpeed.Text!=""&&txtLength.Text!=""&&cmbCategory.Text!="")
            {
                SqlCommand cmd = new SqlCommand("Insert into TrainProfile(TrainName,TrainCategory,Speed,TrainLength,TotalCoach,TotalWagon,CoachSetType,Status) Values(@TrainName,@TrainCategory,@Speed,@TrainLength,@TotalCoach,@TotalWagon,@CoachSetType,@Status)", con);
                cmd.Parameters.AddWithValue("@TrainName", txtName.Text.ToString());
                cmd.Parameters.AddWithValue("@TrainCategory", cmbCategory.Text.ToString());
                cmd.Parameters.AddWithValue("@Speed", txtSpeed.Text.ToString());
                cmd.Parameters.AddWithValue("@TrainLength", txtLength.Text.ToString());
                cmd.Parameters.AddWithValue("@TotalCoach", txtCoach.Text.ToString());
                cmd.Parameters.AddWithValue("@TotalWagon", txtTotalWagon.Text.ToString());
                if (radioMultipleSitter.IsChecked == true)
                {
                    cmd.Parameters.AddWithValue("@CoachSetType", "Multiple Sitter".ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CoachSetType", "Same Sitter".ToString());
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
                LoadUser();
                MessageBox.Show("Successfully Added");

            }else{

                MessageBox.Show("Please insert all fileds Data!");
                
            }
               
            }
            catch
            {
                MessageBox.Show("Error Failed Insertion");
            }
        }

        private void TrainPorfileControl_Load(object sender, EventArgs e)
        {
            LoadUser();
            loadTrainCat();
        }

        private void loadTrainCat()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainCategory ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainCategory");

            cmbCategory.DisplayMember = "TranCatName";
            cmbCategory.ValueMember = "TrainCatId";
            cmbCategory.DataSource = ds.Tables["TrainCategory"];
            cmbCategory.SelectedIndex = -1;

        }
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainProfile", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            var Id = DGV.Rows[e.RowIndex].Cells["TrainId"].Value;
            var Name = DGV.Rows[e.RowIndex].Cells["TrainName"].Value;
            var Category = DGV.Rows[e.RowIndex].Cells["TrainCategory"].Value;
            var Speed = DGV.Rows[e.RowIndex].Cells["Speed"].Value;
            var Length = DGV.Rows[e.RowIndex].Cells["TrainLength"].Value;
            var TotalCoach = DGV.Rows[e.RowIndex].Cells["TotalCoach"].Value;
            var CoachSetType = DGV.Rows[e.RowIndex].Cells["CoachSetType"].Value;
            var Status = DGV.Rows[e.RowIndex].Cells["Status"].Value;
            var TotalWagon = DGV.Rows[e.RowIndex].Cells["TotalWagon"].Value;
            txtId.Text = Id.ToString();
            txtName.Text = Name.ToString();
            cmbCategory.Text = Category.ToString();
            txtSpeed.Text = Speed.ToString();
            txtLength.Text = Length.ToString();
            txtCoach.Text = TotalCoach.ToString();
            txtTotalWagon.Text = TotalWagon.ToString();
            if (CoachSetType.ToString() == "Same Sitter")
            {
                radioSameSitter.IsChecked = true;
            }
            else
            {
                radioMultipleSitter.IsChecked = true;
            }


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
                if (txtId.Text !="")
                {

                    SqlCommand cmd = new SqlCommand("update TrainProfile SET TrainName=@TrainName, TrainCategory=@TrainCategory, Speed=@Speed, TrainLength=@TrainLength,TotalCoach=@TotalCoach,TotalWagon=@TotalWagon, CoachSetType=@CoachSetType,Status=@Status where TrainId='" + txtId.Text.ToString() + "'", con);
                    cmd.Parameters.AddWithValue("@TrainName", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrainCategory", cmbCategory.Text.ToString());
                    cmd.Parameters.AddWithValue("@Speed", txtSpeed.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrainLength", txtLength.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalCoach", txtCoach.Text.ToString());
                    cmd.Parameters.AddWithValue("@TotalWagon", txtTotalWagon.Text.ToString());
                    if (radioMultipleSitter.IsChecked == true)
                    {
                        cmd.Parameters.AddWithValue("@CoachSetType", "Multiple Sitter".ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CoachSetType", "Same Sitter".ToString());
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM TrainProfile WHERE TrainId = '" + txtId.Text.ToString() + "'", con);
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

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            search();
        }
        private void search()
        {
            
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainProfile Where TrainName Like'%" + txtSearch.Text.ToString() + "%'", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            con.Close();
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            AddTrainCat c = new AddTrainCat();
            c.ShowDialog();
            loadTrainCat();
        }

        private void radioSameSitter_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
