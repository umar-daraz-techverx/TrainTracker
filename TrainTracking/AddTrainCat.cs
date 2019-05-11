using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TrainTracking
{
    public partial class AddTrainCat : Telerik.WinControls.UI.RadForm
    {

       
        public AddTrainCat()
        {
            InitializeComponent();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            AddUser();
           
        }

        private void AddUser()
        {
            
            try
            {
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtId.Text == "" && txtName.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into TrainCategory(TranCatName) Values(@TranCatName)", con);
                    cmd.Parameters.AddWithValue("@TranCatName", txtName.Text.ToString());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Added");
                    txtName.Text = "";

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddTrainCat_Load(object sender, EventArgs e)
        {

        }
    }
}
