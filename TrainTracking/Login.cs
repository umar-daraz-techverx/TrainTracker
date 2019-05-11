using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainTracking
{
    public partial class Login : Telerik.WinControls.UI.RadForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                SqlCommand cmd = new SqlCommand("SELECT  UserID,UserName , Admin FROM Users Where UserName='" + txtUserName.Text + "' AND Password='" + txtpassword.Text + "' AND IsActive ='" + true + "'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if ((sdr.Read() == true))
                {
                    int id = Convert.ToInt32(sdr["UserID"]);
                    string Name = (sdr["UserName"].ToString());
                    bool Admin = Convert.ToBoolean(sdr["Admin"]);
                    ConnectDb.USerID = id;
                    ConnectDb.USerName = Name;
                    ConnectDb.Admin = Admin;
                    if (Admin == true)
                    {
                        Dashboard frm2 = new Dashboard();
                        frm2.Show();
                    }
                    else
                    {
                        //pathLoad();
                        //UserBox frm = new UserBox();
                        //frm.Show();


                    }


                    this.Hide();
                    ClearAll();
                    txtUserName.Focus();
                }

                else
                {
                    MessageBox.Show("Incorrect UserName Or Password");
                    ClearAll();
                    txtUserName.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Incorrect UserName Or Password");
            }
        }
        private void ClearAll()
        {
            txtUserName.Text = "";
            txtpassword.Text = "";
        }
    }
}
