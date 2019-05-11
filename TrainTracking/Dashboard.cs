using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TrainTracking
{
    public partial class Dashboard : Telerik.WinControls.UI.RadForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        

        public Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            firstControl1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void radPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            firstControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button2.Height;
            sidePanel.Top = button2.Top;
            secondControl1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            firstControl1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button6.Height;
            sidePanel.Top = button6.Top;
            trainPorfileControl1.BringToFront();
            radLabel1.Text = "Train Profile";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button5.Height;
            sidePanel.Top = button5.Top;
            destinationControl1.BringToFront();
            radLabel1.Text = "Train Station Managment";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button4.Height;
            sidePanel.Top = button4.Top;
            trackLaneManagmentControl1.BringToFront();
            radLabel1.Text = "Track / Lane Managment";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void secondControl1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button10.Height;
            sidePanel.Top = button10.Top;
            routeAndTripManagment1.BringToFront();
            radLabel1.Text = "Route And Trip Managment";
        }
    }
}
