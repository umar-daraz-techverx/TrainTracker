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
using Telerik.WinControls.UI;
using System.Windows.Forms.DataVisualization.Charting;
using GemBox.Spreadsheet.WinFormsUtilities;
using GemBox.Spreadsheet;

namespace TrainTracking
{
    public partial  class TrackLaneManagmentControl : UserControl
    {
        public static DataTable dt = new DataTable();
       
        public TrackLaneManagmentControl()
        {
            InitializeComponent();
            
            
        }
        

        private void radButton1_Click(object sender, EventArgs e)
        {
            DGV.Visible = true;
        }

        private void radCheckedDropDownList1_ItemCheckedChanged(object sender, Telerik.WinControls.UI.RadCheckedListDataItemEventArgs e)
        {
           
        }

       
        private void loadcmbStartPoint()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainStationManagment");

            cmbStartPoint.DisplayMember = "StationName";
            cmbStartPoint.ValueMember = "DestinationStationId";
            cmbStartPoint.DataSource = ds.Tables["TrainStationManagment"];
            cmbStartPoint.SelectedIndex = -1;

        }

        private void loadcmbEndPoint()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainStationManagment ", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TrainStationManagment");

            cmbEndPoint.DisplayMember = "StationName";
            cmbEndPoint.ValueMember = "DestinationStationId";
            cmbEndPoint.DataSource = ds.Tables["TrainStationManagment"];
           cmbEndPoint.SelectedIndex = -1;

        }
       
       

        private void TrackLaneManagmentControl_Load(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = false;
            //GLane1.Visible = false;
            //DGVLane2.Visible = false;
           
            loadcmbStartPoint();
            loadcmbEndPoint();
           // DataTable dataTable = new DataTable();
           // DGVLane.DataSource = AutoNumberedTable(dataTable);
            
           // DGVLane.SelectAll();
            LoadUser();
         //  LoadChart1();
         // LoadChart2();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }
      
        private void LoadChart1()
        {
           // chart1.Legends.Clear();
           // chart1.Series.Clear();
            //lane1
            if (ConnectDb.a1o != 0 && ConnectDb.a1d != 0)
            {
            chart1.Series["Distance On X"].Points.AddXY( ConnectDb.a1d,ConnectDb.a1o);
                
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

            //lane2
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


            //lane3
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


            //lane4
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

            //lane5
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


           
            //chart title  
           // chart1.Titles.Add("Track Chart");  

        }
        private void LoadChart2()
        {
          //  chart1.Legends.Clear();
//chart1.Series.Clear();
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
           
          
            

        
           // //chart title  
           //// chart1.Titles.Add("Salary Chart");

        }
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection(ConnectDb.connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainLaneManagment", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.Columns["a1d"].Visible = false;
            this.DGV.Columns["a2d"].Visible = false;
            this.DGV.Columns["a3d"].Visible = false;
            this.DGV.Columns["a4d"].Visible = false;
            this.DGV.Columns["a5d"].Visible = false;
            this.DGV.Columns["a6d"].Visible = false;
            this.DGV.Columns["a7d"].Visible = false;
            this.DGV.Columns["a8d"].Visible = false;
            this.DGV.Columns["a9d"].Visible = false;
            this.DGV.Columns["a10d"].Visible = false;
            this.DGV.Columns["a1o"].Visible = false;
            this.DGV.Columns["a2o"].Visible = false;
            this.DGV.Columns["a3o"].Visible = false;
            this.DGV.Columns["a4o"].Visible = false;
            this.DGV.Columns["a5o"].Visible = false;
            this.DGV.Columns["a6o"].Visible = false;
            this.DGV.Columns["a7o"].Visible = false;
            this.DGV.Columns["a8o"].Visible = false;
            this.DGV.Columns["a9o"].Visible = false;
            this.DGV.Columns["a10o"].Visible = false;

            this.DGV.Columns["b1d"].Visible = false;
            this.DGV.Columns["b2d"].Visible = false;
            this.DGV.Columns["b3d"].Visible = false;
            this.DGV.Columns["b4d"].Visible = false;
            this.DGV.Columns["b5d"].Visible = false;
            this.DGV.Columns["b6d"].Visible = false;
            this.DGV.Columns["b7d"].Visible = false;
            this.DGV.Columns["b8d"].Visible = false;
            this.DGV.Columns["b9d"].Visible = false;
            this.DGV.Columns["b10d"].Visible = false;
            this.DGV.Columns["b1o"].Visible = false;
            this.DGV.Columns["b2o"].Visible = false;
            this.DGV.Columns["b3o"].Visible = false;
            this.DGV.Columns["b4o"].Visible = false;
            this.DGV.Columns["b5o"].Visible = false;
            this.DGV.Columns["b6o"].Visible = false;
            this.DGV.Columns["b7o"].Visible = false;
            this.DGV.Columns["b8o"].Visible = false;
            this.DGV.Columns["b9o"].Visible = false;
            this.DGV.Columns["b10o"].Visible = false;

            this.DGV.Columns["c1d"].Visible = false;
            this.DGV.Columns["c2d"].Visible = false;
            this.DGV.Columns["c3d"].Visible = false;
            this.DGV.Columns["c4d"].Visible = false;
            this.DGV.Columns["c5d"].Visible = false;
            this.DGV.Columns["c6d"].Visible = false;
            this.DGV.Columns["c7d"].Visible = false;
            this.DGV.Columns["c8d"].Visible = false;
            this.DGV.Columns["c9d"].Visible = false;
            this.DGV.Columns["c10d"].Visible = false;
            this.DGV.Columns["c1o"].Visible = false;
            this.DGV.Columns["c2o"].Visible = false;
            this.DGV.Columns["c3o"].Visible = false;
            this.DGV.Columns["c4o"].Visible = false;
            this.DGV.Columns["c5o"].Visible = false;
            this.DGV.Columns["c6o"].Visible = false;
            this.DGV.Columns["c7o"].Visible = false;
            this.DGV.Columns["c8o"].Visible = false;
            this.DGV.Columns["c9o"].Visible = false;
            this.DGV.Columns["c10o"].Visible = false;

            this.DGV.Columns["d1d"].Visible = false;
            this.DGV.Columns["d2d"].Visible = false;
            this.DGV.Columns["d3d"].Visible = false;
            this.DGV.Columns["d4d"].Visible = false;
            this.DGV.Columns["d5d"].Visible = false;
            this.DGV.Columns["d6d"].Visible = false;
            this.DGV.Columns["d7d"].Visible = false;
            this.DGV.Columns["d8d"].Visible = false;
            this.DGV.Columns["d9d"].Visible = false;
            this.DGV.Columns["d10d"].Visible = false;
            this.DGV.Columns["d1o"].Visible = false;
            this.DGV.Columns["d2o"].Visible = false;
            this.DGV.Columns["d3o"].Visible = false;
            this.DGV.Columns["d4o"].Visible = false;
            this.DGV.Columns["d5o"].Visible = false;
            this.DGV.Columns["d6o"].Visible = false;
            this.DGV.Columns["d7o"].Visible = false;
            this.DGV.Columns["d8o"].Visible = false;
            this.DGV.Columns["d9o"].Visible = false;
            this.DGV.Columns["d10o"].Visible = false;

            this.DGV.Columns["e1d"].Visible = false;
            this.DGV.Columns["e2d"].Visible = false;
            this.DGV.Columns["e3d"].Visible = false;
            this.DGV.Columns["e4d"].Visible = false;
            this.DGV.Columns["e5d"].Visible = false;
            this.DGV.Columns["e6d"].Visible = false;
            this.DGV.Columns["e7d"].Visible = false;
            this.DGV.Columns["e8d"].Visible = false;
            this.DGV.Columns["e9d"].Visible = false;
            this.DGV.Columns["e10d"].Visible = false;
            this.DGV.Columns["e1o"].Visible = false;
            this.DGV.Columns["e2o"].Visible = false;
            this.DGV.Columns["e3o"].Visible = false;
            this.DGV.Columns["e4o"].Visible = false;
            this.DGV.Columns["e5o"].Visible = false;
            this.DGV.Columns["e6o"].Visible = false;
            this.DGV.Columns["e7o"].Visible = false;
            this.DGV.Columns["e8o"].Visible = false;
            this.DGV.Columns["e9o"].Visible = false;
            this.DGV.Columns["e10o"].Visible = false;
        }
        

        


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void cmbStartPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loadstopcmb()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                SqlDataAdapter sda3 = new SqlDataAdapter("select * from TrackStopPoint ", con);
                DataSet ds3 = new DataSet();
                sda3.Fill(ds3, "TrackStopPoint");
                cmbStartPoint.DisplayMember = "TrackStopPointName";
                cmbStartPoint.ValueMember = "TrackStopPointId";
                cmbStartPoint.DataSource = ds3.Tables["TrackStopPoint"];
                cmbStartPoint.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void chkedListBox_SelectedItemChanged(object sender, EventArgs e)
        {
        //    foreach (object itemChecked in chkedListBox.CheckedItems)
        //    {
        //        DataRowView castedItem = itemChecked as DataRowView;
                
        //        string Name = castedItem["TrackStopPointName"].ToString();
        //        int? id = Convert.ToInt32(castedItem["TrackStopPointId"]);
               
        //        DGV2.DataSource = castedItem;
        //    }
            
        }

        private void radLabel19_Click(object sender, EventArgs e)
        {

        }
        private DataTable AutoNumberedTable(DataTable SourceTable)
        {

            DataTable ResultTable = new DataTable();

            DataColumn AutoNumberColumn = new DataColumn();

           // AutoNumberColumn.ColumnName = "Lane1";

            AutoNumberColumn.DataType = typeof(int);

            AutoNumberColumn.AutoIncrement = true;

            AutoNumberColumn.AutoIncrementSeed = 1;

            AutoNumberColumn.AutoIncrementStep = 1;

        //    ResultTable.Columns.Add(AutoNumberColumn);

            ResultTable.Merge(SourceTable);

            return ResultTable;

        }
        private void DGVLane_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
          //  DGVLane2.Visible = true;
           // btnAddLane.Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dt.Clear();
            AddUser();
            ClearAll();
            LoadUser();
            DGV.Visible = true;
        }
        private void ClearAll()
        {
            txtId.Text = "";
            txtTrackName.Text = "";
            clrTrack.Text = "";
            cmbStartPoint.Text = "";
            cmbEndPoint.Text = "";
            clrTrack.Text = "Pick Color";
            clrTrack.BackColor=default(Color);
            txtDA1.Text = "";
            txtDA2.Text = "";
            txtDA3.Text = "";
            txtDA4.Text = "";
            txtDA5.Text = "";
            txtDA6.Text = "";
            txtDA7.Text = "";
            txtDA8.Text = "";
            txtDA9.Text = "";
            txtDA10.Text = "";
            txtOA1.Text = "";
            txtOA2.Text = "";
            txtOA3.Text = "";
            txtOA4.Text = "";
            txtOA5.Text = "";
            txtOA6.Text = "";
            txtOA7.Text = "";
            txtOA8.Text = "";
            txtOA9.Text = "";
            txtOA10.Text = "";


            txtDB1.Text = "";
            txtDB2.Text = "";
            txtDB3.Text = "";
            txtDB4.Text = "";
            txtDB5.Text = "";
            txtDB6.Text = "";
            txtDB7.Text = "";
            txtDB8.Text = "";
            txtDB9.Text = "";
            txtDB10.Text = "";
            txtOB1.Text = "";
            txtOB2.Text = "";
            txtOB3.Text = "";
            txtOB4.Text = "";
            txtOB5.Text = "";
            txtOB6.Text = "";
            txtOB7.Text = "";
            txtOB8.Text = "";
            txtOB9.Text = "";
            txtOB10.Text = "";

            txtDC1.Text = "";
            txtDC2.Text = "";
            txtDC3.Text = "";
            txtDC4.Text = "";
            txtDC5.Text = "";
            txtDC6.Text = "";
            txtDC7.Text = "";
            txtDC8.Text = "";
            txtDC9.Text = "";
            txtDC10.Text = "";
            txtOC1.Text = "";
            txtOC2.Text = "";
            txtOC3.Text = "";
            txtOC4.Text = "";
            txtOC5.Text = "";
            txtOC6.Text = "";
            txtOC7.Text = "";
            txtOC8.Text = "";
            txtOC9.Text = "";
            txtOC10.Text = "";

            txtDD1.Text = "";
            txtDD2.Text = "";
            txtDD3.Text = "";
            txtDD4.Text = "";
            txtDD5.Text = "";
            txtDD6.Text = "";
            txtDD7.Text = "";
            txtDD8.Text = "";
            txtDD9.Text = "";
            txtDD10.Text = "";
            txtOD1.Text = "";
            txtOD2.Text = "";
            txtOD3.Text = "";
            txtOD4.Text = "";
            txtOD5.Text = "";
            txtOD6.Text = "";
            txtOD7.Text = "";
            txtOD8.Text = "";
            txtOD9.Text = "";
            txtOD10.Text = "";

            txtDE1.Text = "";
            txtDE2.Text = "";
            txtDE3.Text = "";
            txtDE4.Text = "";
            txtDE5.Text = "";
            txtDE6.Text = "";
            txtDE7.Text = "";
            txtDE8.Text = "";
            txtDE9.Text = "";
            txtDE10.Text = "";
            txtOE1.Text = "";
            txtOE2.Text = "";
            txtOE3.Text = "";
            txtOE4.Text = "";
            txtOE5.Text = "";
            txtOE6.Text = "";
            txtOE7.Text = "";
            txtOE8.Text = "";
            txtOE9.Text = "";
            txtOE10.Text = "";
            

        }
     
        private void AddUser()
        {
            
            dt.Clear();
            try
            {
              //  DGVLane.SelectAll();
              //  DataGridViewSelectedRowCollection rows = DGVLane.SelectedRows;
                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtTrackName.Text != "" && cmbStartPoint.Text != "" && cmbEndPoint.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Insert into TrainLaneManagment(TrackName,TrackColor,TrackStartPoint,TrackEndPoint,a1d,a1o,a2d,a2o,a3d,a3o,a4d,a4o,a5d,a5o,a6d,a6o,a7d,a7o,a8d,a8o,a9d,a9o,a10d,a10o,b1d,b2d,b3d,b4d,b5d,b6d,b7d,b8d,b9d,b10d,b1o,b2o,b3o,b4o,b5o,b6o,b7o,b8o,b9o,b10o,c1d,c2d,c3d,c4d,c5d,c6d,c7d,c8d,c9d,c10d,c1o,c2o,c3o,c4o,c5o,c6o,c7o,c8o,c9o,c10o,d1d,d2d,d3d,d4d,d5d,d6d,d7d,d8d,d9d,d10d,d1o,d2o,d3o,d4o,d5o,d6o,d7o,d8o,d9o,d10o,e1d,e2d,e3d,e4d,e5d,e6d,e7d,e8d,e9d,e10d,e1o,e2o,e3o,e4o,e5o,e6o,e7o,e8o,e9o,e10o) Values(@TrackName,@TrackColor,@TrackStartPoint,@TrackEndPoint,@a1d,@a1o,@a2d,@a2o,@a3d,@a3o,@a4d,@a4o,@a5d,@a5o,@a6d,@a6o,@a7d,@a7o,@a8d,@a8o,@a9d,@a9o,@a10d,@a10o,@b1d,@b2d,@b3d,@b4d,@b5d,@b6d,@b7d,@b8d,@b9d,@b10d,@b1o,@b2o,@b3o,@b4o,@b5o,@b6o,@b7o,@b8o,@b9o,@b10o,@c1d,@c2d,@c3d,@c4d,@c5d,@c6d,@c7d,@c8d,@c9d,@c10d,@c1o,@c2o,@c3o,@c4o,@c5o,@c6o,@c7o,@c8o,@c9o,@c10o,@d1d,@d2d,@d3d,@d4d,@d5d,@d6d,@d7d,@d8d,@d9d,@d10d,@d1o,@d2o,@d3o,@d4o,@d5o,@d6o,@d7o,@d8o,@d9o,@d10o,@e1d,@e2d,@e3d,@e4d,@e5d,@e6d,@e7d,@e8d,@e9d,@e10d,@e1o,@e2o,@e3o,@e4o,@e5o,@e6o,@e7o,@e8o,@e9o,@e10o)", con);
                    cmd.Parameters.AddWithValue("@TrackName", txtTrackName.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackColor", colorDialog1.Color.ToArgb().ToString());
                    cmd.Parameters.AddWithValue("@TrackStartPoint", cmbStartPoint.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackEndPoint", cmbEndPoint.Text.ToString());
                    cmd.Parameters.AddWithValue("@a1d", txtDA1.Text.ToString());
                    cmd.Parameters.AddWithValue("@a1o", txtOA1.Text.ToString());
                    cmd.Parameters.AddWithValue("@a2d", txtDA2.Text.ToString());
                    cmd.Parameters.AddWithValue("@a2o", txtOA2.Text.ToString());
                    cmd.Parameters.AddWithValue("@a3d", txtDA3.Text.ToString());
                    cmd.Parameters.AddWithValue("@a3o", txtOA3.Text.ToString());
                    cmd.Parameters.AddWithValue("@a4d", txtDA4.Text.ToString());
                    cmd.Parameters.AddWithValue("@a4o", txtOA4.Text.ToString());
                    cmd.Parameters.AddWithValue("@a5d", txtDA5.Text.ToString());
                    cmd.Parameters.AddWithValue("@a5o", txtOA5.Text.ToString());
                    cmd.Parameters.AddWithValue("@a6d", txtDA6.Text.ToString());
                    cmd.Parameters.AddWithValue("@a6o", txtOA6.Text.ToString());
                    cmd.Parameters.AddWithValue("@a7d", txtDA7.Text.ToString());
                    cmd.Parameters.AddWithValue("@a7o", txtOA7.Text.ToString());
                    cmd.Parameters.AddWithValue("@a8d", txtDA8.Text.ToString());
                    cmd.Parameters.AddWithValue("@a8o", txtOA8.Text.ToString());
                    cmd.Parameters.AddWithValue("@a9d", txtDA9.Text.ToString());
                    cmd.Parameters.AddWithValue("@a9o", txtOA9.Text.ToString());
                    cmd.Parameters.AddWithValue("@a10d", txtDA10.Text.ToString());
                    cmd.Parameters.AddWithValue("@a10o", txtOA10.Text.ToString());

                    cmd.Parameters.AddWithValue("@b1d", txtDB1.Text.ToString());
                    cmd.Parameters.AddWithValue("@b2d", txtDB2.Text.ToString());
                    cmd.Parameters.AddWithValue("@b3d", txtDB3.Text.ToString());
                    cmd.Parameters.AddWithValue("@b4d", txtDB4.Text.ToString());
                    cmd.Parameters.AddWithValue("@b5d", txtDB5.Text.ToString());
                    cmd.Parameters.AddWithValue("@b6d", txtDB6.Text.ToString());
                    cmd.Parameters.AddWithValue("@b7d", txtDB7.Text.ToString());
                    cmd.Parameters.AddWithValue("@b8d", txtDB8.Text.ToString());
                    cmd.Parameters.AddWithValue("@b9d", txtDB9.Text.ToString());
                    cmd.Parameters.AddWithValue("@b10d", txtDB10.Text.ToString());
                    cmd.Parameters.AddWithValue("@b1o", txtOB1.Text.ToString());
                    cmd.Parameters.AddWithValue("@b2o", txtOB2.Text.ToString());
                    cmd.Parameters.AddWithValue("@b3o", txtOB3.Text.ToString());
                    cmd.Parameters.AddWithValue("@b4o", txtOB4.Text.ToString());
                    cmd.Parameters.AddWithValue("@b5o", txtOB5.Text.ToString());
                    cmd.Parameters.AddWithValue("@b6o", txtOB6.Text.ToString());
                    cmd.Parameters.AddWithValue("@b7o", txtOB7.Text.ToString());
                    cmd.Parameters.AddWithValue("@b8o", txtOB8.Text.ToString());
                    cmd.Parameters.AddWithValue("@b9o", txtOB9.Text.ToString());
                    cmd.Parameters.AddWithValue("@b10o", txtOB10.Text.ToString());

                    cmd.Parameters.AddWithValue("@c1d", txtDC1.Text.ToString());
                    cmd.Parameters.AddWithValue("@c2d", txtDC2.Text.ToString());
                    cmd.Parameters.AddWithValue("@c3d", txtDC3.Text.ToString());
                    cmd.Parameters.AddWithValue("@c4d", txtDC4.Text.ToString());
                    cmd.Parameters.AddWithValue("@c5d", txtDC5.Text.ToString());
                    cmd.Parameters.AddWithValue("@c6d", txtDC6.Text.ToString());
                    cmd.Parameters.AddWithValue("@c7d", txtDC7.Text.ToString());
                    cmd.Parameters.AddWithValue("@c8d", txtDC8.Text.ToString());
                    cmd.Parameters.AddWithValue("@c9d", txtDC9.Text.ToString());
                    cmd.Parameters.AddWithValue("@c10d", txtDC10.Text.ToString());
                    cmd.Parameters.AddWithValue("@c1o", txtOC1.Text.ToString());
                    cmd.Parameters.AddWithValue("@c2o", txtOC2.Text.ToString());
                    cmd.Parameters.AddWithValue("@c3o", txtOC3.Text.ToString());
                    cmd.Parameters.AddWithValue("@c4o", txtOC4.Text.ToString());
                    cmd.Parameters.AddWithValue("@c5o", txtOC5.Text.ToString());
                    cmd.Parameters.AddWithValue("@c6o", txtOC6.Text.ToString());
                    cmd.Parameters.AddWithValue("@c7o", txtOC7.Text.ToString());
                    cmd.Parameters.AddWithValue("@c8o", txtOC8.Text.ToString());
                    cmd.Parameters.AddWithValue("@c9o", txtOC9.Text.ToString());
                    cmd.Parameters.AddWithValue("@c10o", txtOC10.Text.ToString());

                    cmd.Parameters.AddWithValue("@d1d", txtDD1.Text.ToString());
                    cmd.Parameters.AddWithValue("@d2d", txtDD2.Text.ToString());
                    cmd.Parameters.AddWithValue("@d3d", txtDD3.Text.ToString());
                    cmd.Parameters.AddWithValue("@d4d", txtDD4.Text.ToString());
                    cmd.Parameters.AddWithValue("@d5d", txtDD5.Text.ToString());
                    cmd.Parameters.AddWithValue("@d6d", txtDD6.Text.ToString());
                    cmd.Parameters.AddWithValue("@d7d", txtDD7.Text.ToString());
                    cmd.Parameters.AddWithValue("@d8d", txtDD8.Text.ToString());
                    cmd.Parameters.AddWithValue("@d9d", txtDD9.Text.ToString());
                    cmd.Parameters.AddWithValue("@d10d", txtDD10.Text.ToString());
                    cmd.Parameters.AddWithValue("@d1o", txtOD1.Text.ToString());
                    cmd.Parameters.AddWithValue("@d2o", txtOD2.Text.ToString());
                    cmd.Parameters.AddWithValue("@d3o", txtOD3.Text.ToString());
                    cmd.Parameters.AddWithValue("@d4o", txtOD4.Text.ToString());
                    cmd.Parameters.AddWithValue("@d5o", txtOD5.Text.ToString());
                    cmd.Parameters.AddWithValue("@d6o", txtOD6.Text.ToString());
                    cmd.Parameters.AddWithValue("@d7o", txtOD7.Text.ToString());
                    cmd.Parameters.AddWithValue("@d8o", txtOD8.Text.ToString());
                    cmd.Parameters.AddWithValue("@d9o", txtOD9.Text.ToString());
                    cmd.Parameters.AddWithValue("@d10o", txtOD10.Text.ToString());

                    cmd.Parameters.AddWithValue("@e1d", txtDE1.Text.ToString());
                    cmd.Parameters.AddWithValue("@e2d", txtDE2.Text.ToString());
                    cmd.Parameters.AddWithValue("@e3d", txtDE3.Text.ToString());
                    cmd.Parameters.AddWithValue("@e4d", txtDE4.Text.ToString());
                    cmd.Parameters.AddWithValue("@e5d", txtDE5.Text.ToString());
                    cmd.Parameters.AddWithValue("@e6d", txtDE6.Text.ToString());
                    cmd.Parameters.AddWithValue("@e7d", txtDE7.Text.ToString());
                    cmd.Parameters.AddWithValue("@e8d", txtDE8.Text.ToString());
                    cmd.Parameters.AddWithValue("@e9d", txtDE9.Text.ToString());
                    cmd.Parameters.AddWithValue("@e10d", txtDE10.Text.ToString());
                    cmd.Parameters.AddWithValue("@e1o", txtOE1.Text.ToString());
                    cmd.Parameters.AddWithValue("@e2o", txtOE2.Text.ToString());
                    cmd.Parameters.AddWithValue("@e3o", txtOE3.Text.ToString());
                    cmd.Parameters.AddWithValue("@e4o", txtOE4.Text.ToString());
                    cmd.Parameters.AddWithValue("@e5o", txtOE5.Text.ToString());
                    cmd.Parameters.AddWithValue("@e6o", txtOE6.Text.ToString());
                    cmd.Parameters.AddWithValue("@e7o", txtOE7.Text.ToString());
                    cmd.Parameters.AddWithValue("@e8o", txtOE8.Text.ToString());
                    cmd.Parameters.AddWithValue("@e9o", txtOE9.Text.ToString());
                    cmd.Parameters.AddWithValue("@e10o", txtOE10.Text.ToString());



                    



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

        private void btnGridView_Click(object sender, EventArgs e)
        {
            DGV.Visible = true;
            GLane1.Visible = false;
            
        }

        private void btnLane1_Click(object sender, EventArgs e)
        {
            DGV.Visible = false;
            GLane1.Visible = true;
        }

        private void btnLane2_Click(object sender, EventArgs e)
        {

        }

        private void btnLane3_Click(object sender, EventArgs e)
        {

        }

        private void btnLane4_Click(object sender, EventArgs e)
        {

        }

        private void btnLane5_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lane1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLane1.Visible = true;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = true;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = true;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = true;
            PLane5.Visible = false;
        }

        private void lane5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = true;
        }

        private void lane1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            PLane1.Visible = true;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane2ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = true;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = true;
            PLane4.Visible = false;
            PLane5.Visible = false;
        }

        private void lane4ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = true;
            PLane5.Visible = false;
        }

        private void lane5ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PLane1.Visible = false;
            PLane2.Visible = false;
            PLane3.Visible = false;
            PLane4.Visible = false;
            PLane5.Visible = true;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            chart1.Series["Distance On X"].Points.Clear();
            chart1.Series["Origin On Y"].Points.Clear();
                var TrackId = DGV.Rows[e.RowIndex].Cells["TrackId"].Value;
                var TrackName = DGV.Rows[e.RowIndex].Cells["TrackName"].Value;
                var TrackColor = DGV.Rows[e.RowIndex].Cells["TrackColor"].Value;
                var TrackStartPoint = DGV.Rows[e.RowIndex].Cells["TrackStartPoint"].Value;
                var TrackEndPoint = DGV.Rows[e.RowIndex].Cells["TrackEndPoint"].Value;
                var a1d = DGV.Rows[e.RowIndex].Cells["a1d"].Value;
                var a1o = DGV.Rows[e.RowIndex].Cells["a1o"].Value;
                var a2d = DGV.Rows[e.RowIndex].Cells["a2d"].Value;
                var a2o = DGV.Rows[e.RowIndex].Cells["a2o"].Value;
                var a3d = DGV.Rows[e.RowIndex].Cells["a3d"].Value;
                var a3o = DGV.Rows[e.RowIndex].Cells["a3o"].Value;
                var a4d = DGV.Rows[e.RowIndex].Cells["a4d"].Value;
                var a4o = DGV.Rows[e.RowIndex].Cells["a4o"].Value;
                var a5d = DGV.Rows[e.RowIndex].Cells["a5d"].Value;
                var a5o = DGV.Rows[e.RowIndex].Cells["a5o"].Value;
                var a6d = DGV.Rows[e.RowIndex].Cells["a6d"].Value;
                var a6o = DGV.Rows[e.RowIndex].Cells["a6o"].Value;
                var a7d = DGV.Rows[e.RowIndex].Cells["a7d"].Value;
                var a7o = DGV.Rows[e.RowIndex].Cells["a7o"].Value;
                var a8d = DGV.Rows[e.RowIndex].Cells["a8d"].Value;
                var a8o = DGV.Rows[e.RowIndex].Cells["a8o"].Value;
                var a9d = DGV.Rows[e.RowIndex].Cells["a9d"].Value;
                var a9o = DGV.Rows[e.RowIndex].Cells["a9o"].Value;
                var a10d = DGV.Rows[e.RowIndex].Cells["a10d"].Value;
                var a10o = DGV.Rows[e.RowIndex].Cells["a10o"].Value;

                var b1d = DGV.Rows[e.RowIndex].Cells["b1d"].Value;
                var b2d = DGV.Rows[e.RowIndex].Cells["b2d"].Value;
                var b3d = DGV.Rows[e.RowIndex].Cells["b3d"].Value;
                var b4d = DGV.Rows[e.RowIndex].Cells["b4d"].Value;
                var b5d = DGV.Rows[e.RowIndex].Cells["b5d"].Value;
                var b6d = DGV.Rows[e.RowIndex].Cells["b6d"].Value;
                var b7d = DGV.Rows[e.RowIndex].Cells["b7d"].Value;
                var b8d = DGV.Rows[e.RowIndex].Cells["b8d"].Value;
                var b9d = DGV.Rows[e.RowIndex].Cells["b9d"].Value;
                var b10d = DGV.Rows[e.RowIndex].Cells["b10d"].Value;
                var b1o = DGV.Rows[e.RowIndex].Cells["b1o"].Value;
                var b2o = DGV.Rows[e.RowIndex].Cells["b2o"].Value;
                var b3o = DGV.Rows[e.RowIndex].Cells["b3o"].Value;
                var b4o = DGV.Rows[e.RowIndex].Cells["b4o"].Value;
                var b5o = DGV.Rows[e.RowIndex].Cells["b5o"].Value;
                var b6o = DGV.Rows[e.RowIndex].Cells["b6o"].Value;
                var b7o = DGV.Rows[e.RowIndex].Cells["b7o"].Value;
                var b8o = DGV.Rows[e.RowIndex].Cells["b8o"].Value;
                var b9o = DGV.Rows[e.RowIndex].Cells["b9o"].Value;
                var b10o = DGV.Rows[e.RowIndex].Cells["b10o"].Value;

                var c1d = DGV.Rows[e.RowIndex].Cells["c1d"].Value;
                var c2d = DGV.Rows[e.RowIndex].Cells["c2d"].Value;
                var c3d = DGV.Rows[e.RowIndex].Cells["c3d"].Value;
                var c4d = DGV.Rows[e.RowIndex].Cells["c4d"].Value;
                var c5d = DGV.Rows[e.RowIndex].Cells["c5d"].Value;
                var c6d = DGV.Rows[e.RowIndex].Cells["c6d"].Value;
                var c7d = DGV.Rows[e.RowIndex].Cells["c7d"].Value;
                var c8d = DGV.Rows[e.RowIndex].Cells["c8d"].Value;
                var c9d = DGV.Rows[e.RowIndex].Cells["c9d"].Value;
                var c10d = DGV.Rows[e.RowIndex].Cells["c10d"].Value;
                var c1o = DGV.Rows[e.RowIndex].Cells["c1o"].Value;
                var c2o = DGV.Rows[e.RowIndex].Cells["c2o"].Value;
                var c3o = DGV.Rows[e.RowIndex].Cells["c3o"].Value;
                var c4o = DGV.Rows[e.RowIndex].Cells["c4o"].Value;
                var c5o = DGV.Rows[e.RowIndex].Cells["c5o"].Value;
                var c6o = DGV.Rows[e.RowIndex].Cells["c6o"].Value;
                var c7o = DGV.Rows[e.RowIndex].Cells["c7o"].Value;
                var c8o = DGV.Rows[e.RowIndex].Cells["c8o"].Value;
                var c9o = DGV.Rows[e.RowIndex].Cells["c9o"].Value;
                var c10o = DGV.Rows[e.RowIndex].Cells["c10o"].Value;

                var d1d = DGV.Rows[e.RowIndex].Cells["d1d"].Value;
                var d2d = DGV.Rows[e.RowIndex].Cells["d2d"].Value;
                var d3d = DGV.Rows[e.RowIndex].Cells["d3d"].Value;
                var d4d = DGV.Rows[e.RowIndex].Cells["d4d"].Value;
                var d5d = DGV.Rows[e.RowIndex].Cells["d5d"].Value;
                var d6d = DGV.Rows[e.RowIndex].Cells["d6d"].Value;
                var d7d = DGV.Rows[e.RowIndex].Cells["d7d"].Value;
                var d8d = DGV.Rows[e.RowIndex].Cells["d8d"].Value;
                var d9d = DGV.Rows[e.RowIndex].Cells["d9d"].Value;
                var d10d = DGV.Rows[e.RowIndex].Cells["d10d"].Value;
                var d1o = DGV.Rows[e.RowIndex].Cells["d1o"].Value;
                var d2o = DGV.Rows[e.RowIndex].Cells["d2o"].Value;
                var d3o = DGV.Rows[e.RowIndex].Cells["d3o"].Value;
                var d4o = DGV.Rows[e.RowIndex].Cells["d4o"].Value;
                var d5o = DGV.Rows[e.RowIndex].Cells["d5o"].Value;
                var d6o = DGV.Rows[e.RowIndex].Cells["d6o"].Value;
                var d7o = DGV.Rows[e.RowIndex].Cells["d7o"].Value;
                var d8o = DGV.Rows[e.RowIndex].Cells["d8o"].Value;
                var d9o = DGV.Rows[e.RowIndex].Cells["d9o"].Value;
                var d10o = DGV.Rows[e.RowIndex].Cells["d10o"].Value;

                var e1d = DGV.Rows[e.RowIndex].Cells["e1d"].Value;
                var e2d = DGV.Rows[e.RowIndex].Cells["e2d"].Value;
                var e3d = DGV.Rows[e.RowIndex].Cells["e3d"].Value;
                var e4d = DGV.Rows[e.RowIndex].Cells["e4d"].Value;
                var e5d = DGV.Rows[e.RowIndex].Cells["e5d"].Value;
                var e6d = DGV.Rows[e.RowIndex].Cells["e6d"].Value;
                var e7d = DGV.Rows[e.RowIndex].Cells["e7d"].Value;
                var e8d = DGV.Rows[e.RowIndex].Cells["e8d"].Value;
                var e9d = DGV.Rows[e.RowIndex].Cells["e9d"].Value;
                var e10d = DGV.Rows[e.RowIndex].Cells["e10d"].Value;
                var e1o = DGV.Rows[e.RowIndex].Cells["e1o"].Value;
                var e2o = DGV.Rows[e.RowIndex].Cells["e2o"].Value;
                var e3o = DGV.Rows[e.RowIndex].Cells["e3o"].Value;
                var e4o = DGV.Rows[e.RowIndex].Cells["e4o"].Value;
                var e5o = DGV.Rows[e.RowIndex].Cells["e5o"].Value;
                var e6o = DGV.Rows[e.RowIndex].Cells["e6o"].Value;
                var e7o = DGV.Rows[e.RowIndex].Cells["e7o"].Value;
                var e8o = DGV.Rows[e.RowIndex].Cells["e8o"].Value;
                var e9o = DGV.Rows[e.RowIndex].Cells["e9o"].Value;
                var e10o = DGV.Rows[e.RowIndex].Cells["e10o"].Value;


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
                   ConnectDb.a6d=0;
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
                //ConnectDb.a7d = Convert.ToInt16(a7d.ToString());
                //ConnectDb.a8d = Convert.ToInt16(a8d.ToString());
                //ConnectDb.a9d = Convert.ToInt16(a9d.ToString());
                //ConnectDb.a10d = Convert.ToInt16(a10d.ToString());
                //ConnectDb.a1o = Convert.ToInt16(a1o.ToString());
                //ConnectDb.a2o = Convert.ToInt16(a2o.ToString());
                //ConnectDb.a3o = Convert.ToInt16(a3o.ToString());
                //ConnectDb.a4o = Convert.ToInt16(a4o.ToString());
                //ConnectDb.a5o = Convert.ToInt16(a5o.ToString());
                //ConnectDb.a6o = Convert.ToInt16(a6o.ToString());
                //ConnectDb.a7o = Convert.ToInt16(a7o.ToString());
                //ConnectDb.a8o = Convert.ToInt16(a8o.ToString());
                //ConnectDb.a9o = Convert.ToInt16(a9o.ToString());
                //ConnectDb.a10o = Convert.ToInt16(a10o.ToString());

                //ConnectDb.b1d = Convert.ToInt16(b1d.ToString());
                //ConnectDb.b2d = Convert.ToInt16(b2d.ToString());
                //ConnectDb.b3d = Convert.ToInt16(b3d.ToString());
                //ConnectDb.b4d = Convert.ToInt16(b4d.ToString());
                //ConnectDb.b5d = Convert.ToInt16(b5d.ToString());
                //ConnectDb.b6d = Convert.ToInt16(b6d.ToString());
                //ConnectDb.b7d = Convert.ToInt16(b7d.ToString());
                //ConnectDb.b8d = Convert.ToInt16(b8d.ToString());
                //ConnectDb.b9d = Convert.ToInt16(b9d.ToString());
                //ConnectDb.b10d = Convert.ToInt16(b10d.ToString());
                //ConnectDb.b1o = Convert.ToInt16(b1o.ToString());
                //ConnectDb.b2o = Convert.ToInt16(b2o.ToString());
                //ConnectDb.b3o = Convert.ToInt16(b3o.ToString());
                //ConnectDb.b4o = Convert.ToInt16(b4o.ToString());
                //ConnectDb.b5o = Convert.ToInt16(b5o.ToString());
                //ConnectDb.b6o = Convert.ToInt16(b6o.ToString());
                //ConnectDb.b7o = Convert.ToInt16(b7o.ToString());
                //ConnectDb.b8o = Convert.ToInt16(b8o.ToString());
                //ConnectDb.b9o = Convert.ToInt16(b9o.ToString());
                //ConnectDb.b10o = Convert.ToInt16(b10o.ToString());


                //ConnectDb.c1d = Convert.ToInt16(c1d.ToString());
                //ConnectDb.c2d = Convert.ToInt16(c2d.ToString());
                //ConnectDb.c3d = Convert.ToInt16(c3d.ToString());
                //ConnectDb.c4d = Convert.ToInt16(c4d.ToString());
                //ConnectDb.c5d = Convert.ToInt16(c5d.ToString());
                //ConnectDb.c6d = Convert.ToInt16(c6d.ToString());
                //ConnectDb.c7d = Convert.ToInt16(c7d.ToString());
                //ConnectDb.c8d = Convert.ToInt16(c8d.ToString());
                //ConnectDb.c9d = Convert.ToInt16(c9d.ToString());
                //ConnectDb.c10d = Convert.ToInt16(c10d.ToString());
                //ConnectDb.c1o = Convert.ToInt16(c1o.ToString());
                //ConnectDb.c2o = Convert.ToInt16(c2o.ToString());
                //ConnectDb.c3o = Convert.ToInt16(c3o.ToString());
                //ConnectDb.c4o = Convert.ToInt16(c4o.ToString());
                //ConnectDb.c5o = Convert.ToInt16(c5o.ToString());
                //ConnectDb.c6o = Convert.ToInt16(c6o.ToString());
                //ConnectDb.c7o = Convert.ToInt16(c7o.ToString());
                //ConnectDb.c8o = Convert.ToInt16(c8o.ToString());
                //ConnectDb.c9o = Convert.ToInt16(c9o.ToString());
                //ConnectDb.c10o = Convert.ToInt16(c10o.ToString());

                //ConnectDb.d1d = Convert.ToInt16(d1d.ToString());
                //ConnectDb.d2d = Convert.ToInt16(d2d.ToString());
                //ConnectDb.d3d = Convert.ToInt16(d3d.ToString());
                //ConnectDb.d4d = Convert.ToInt16(d4d.ToString());
                //ConnectDb.d5d = Convert.ToInt16(d5d.ToString());
                //ConnectDb.d6d = Convert.ToInt16(d6d.ToString());
                //ConnectDb.d7d = Convert.ToInt16(d7d.ToString());
                //ConnectDb.d8d = Convert.ToInt16(d8d.ToString());
                //ConnectDb.d9d = Convert.ToInt16(d9d.ToString());
                //ConnectDb.d10d = Convert.ToInt16(d10d.ToString());
                //ConnectDb.d1o = Convert.ToInt16(d1o.ToString());
                //ConnectDb.d2o = Convert.ToInt16(d2o.ToString());
                //ConnectDb.d3o = Convert.ToInt16(d3o.ToString());
                //ConnectDb.d4o = Convert.ToInt16(d4o.ToString());
                //ConnectDb.d5o = Convert.ToInt16(d5o.ToString());
                //ConnectDb.d6o = Convert.ToInt16(d6o.ToString());
                //ConnectDb.d7o = Convert.ToInt16(d7o.ToString());
                //ConnectDb.d8o = Convert.ToInt16(d8o.ToString());
                //ConnectDb.d9o = Convert.ToInt16(d9o.ToString());
                //ConnectDb.d10o = Convert.ToInt16(d10o.ToString());

                //ConnectDb.e1d = Convert.ToInt16(e1d.ToString());
                //ConnectDb.e2d = Convert.ToInt16(e2d.ToString());
                //ConnectDb.e3d = Convert.ToInt16(e3d.ToString());
                //ConnectDb.e4d = Convert.ToInt16(e4d.ToString());
                //ConnectDb.e5d = Convert.ToInt16(e5d.ToString());
                //ConnectDb.e6d = Convert.ToInt16(e6d.ToString());
                //ConnectDb.e7d = Convert.ToInt16(e7d.ToString());
                //ConnectDb.e8d = Convert.ToInt16(e8d.ToString());
                //ConnectDb.e9d = Convert.ToInt16(e9d.ToString());
                //ConnectDb.e10d = Convert.ToInt16(10d.ToString());
                //ConnectDb.e1o = Convert.ToInt16(e1o.ToString());
                //ConnectDb.e2o = Convert.ToInt16(e2o.ToString());
                //ConnectDb.e3o = Convert.ToInt16(e3o.ToString());
                //ConnectDb.e4o = Convert.ToInt16(e4o.ToString());
                //ConnectDb.e5o = Convert.ToInt16(e5o.ToString());
                //ConnectDb.e6o = Convert.ToInt16(e6o.ToString());
                //ConnectDb.e7o = Convert.ToInt16(e7o.ToString());
                //ConnectDb.e8o = Convert.ToInt16(e8o.ToString());
                //ConnectDb.e9o = Convert.ToInt16(e9o.ToString());
                //ConnectDb.e10o = Convert.ToInt16(e10o.ToString());

                clrTrack.BackColor = colorDialog1.Color;
                cmbEndPoint.Text = colorDialog1.Color.ToString();

                txtId.Text = TrackId.ToString();
                txtTrackName.Text = TrackName.ToString();
                clrTrack.BackColor = Color.FromArgb(Convert.ToInt32(TrackColor.ToString()));
                clrTrack.Text = TrackColor.ToString();
                cmbStartPoint.Text = TrackStartPoint.ToString();   
                cmbEndPoint.Text = TrackEndPoint.ToString();

                txtDA1.Text = a1d.ToString();
                txtDA2.Text = a2d.ToString();
                txtDA3.Text = a3d.ToString();
                txtDA4.Text = a4d.ToString();
                txtDA5.Text = a5d.ToString();
                txtDA6.Text = a6d.ToString();
                txtDA7.Text = a7d.ToString();
                txtDA8.Text = a8d.ToString();
                txtDA9.Text = a9d.ToString();
                txtDA10.Text = a10d.ToString();
                txtOA1.Text = a1o.ToString();
                txtOA2.Text = a2o.ToString();
                txtOA3.Text = a3o.ToString();
                txtOA4.Text = a4o.ToString();
                txtOA5.Text = a5o.ToString();
                txtOA6.Text = a6o.ToString();
                txtOA7.Text = a7o.ToString();
                txtOA8.Text = a8o.ToString();
                txtOA9.Text = a9o.ToString();
                txtOA10.Text = a10o.ToString();


                txtDB1.Text = b1d.ToString();
                txtDB2.Text = b2d.ToString();
                txtDB3.Text = b3d.ToString();
                txtDB4.Text = b4d.ToString();
                txtDB5.Text = b5d.ToString();
                txtDB6.Text = b6d.ToString();
                txtDB7.Text = b7d.ToString();
                txtDB8.Text = b8d.ToString();
                txtDB9.Text = b9d.ToString();
                txtDB10.Text = b10d.ToString();
                txtOB1.Text = b1o.ToString();
                txtOB2.Text = b2o.ToString();
                txtOB3.Text = b3o.ToString();
                txtOB4.Text = b4o.ToString();
                txtOB5.Text = b5o.ToString();
                txtOB6.Text = b6o.ToString();
                txtOB7.Text = b7o.ToString();
                txtOB8.Text = b8o.ToString();
                txtOB9.Text = b9o.ToString();
                txtOB10.Text = b10o.ToString();

                txtDC1.Text = c1d.ToString();
                txtDC2.Text = c2d.ToString();
                txtDC3.Text = c3d.ToString();
                txtDC4.Text = c4d.ToString();
                txtDC5.Text = c5d.ToString();
                txtDC6.Text = c6d.ToString();
                txtDC7.Text = c7d.ToString();
                txtDC8.Text = c8d.ToString();
                txtDC9.Text = c9d.ToString();
                txtDC10.Text = c10d.ToString();
                txtOC1.Text = c1o.ToString();
                txtOC2.Text = c2o.ToString();
                txtOC3.Text = c3o.ToString();
                txtOC4.Text = c4o.ToString();
                txtOC5.Text = c5o.ToString();
                txtOC6.Text = c6o.ToString();
                txtOC7.Text = c7o.ToString();
                txtOC8.Text = c8o.ToString();
                txtOC9.Text = c9o.ToString();
                txtOC10.Text = c10o.ToString();

                txtDD1.Text = d1d.ToString();
                txtDD2.Text = d2d.ToString();
                txtDD3.Text = d3d.ToString();
                txtDD4.Text = d4d.ToString();
                txtDD5.Text = d5d.ToString();
                txtDD6.Text = d6d.ToString();
                txtDD7.Text = d7d.ToString();
                txtDD8.Text = d8d.ToString();
                txtDD9.Text = d9d.ToString();
                txtDD10.Text = d10d.ToString();
                txtOD1.Text = d1o.ToString();
                txtOD2.Text = d2o.ToString();
                txtOD3.Text = d3o.ToString();
                txtOD4.Text = d4o.ToString();
                txtOD5.Text = d5o.ToString();
                txtOD6.Text = d6o.ToString();
                txtOD7.Text = d7o.ToString();
                txtOD8.Text = d8o.ToString();
                txtOD9.Text = d9o.ToString();
                txtOD10.Text = d10o.ToString();

                txtDE1.Text = e1d.ToString();
                txtDE2.Text = e2d.ToString();
                txtDE3.Text = e3d.ToString();
                txtDE4.Text = e4d.ToString();
                txtDE5.Text = e5d.ToString();
                txtDE6.Text = e6d.ToString();
                txtDE7.Text = e7d.ToString();
                txtDE8.Text = e8d.ToString();
                txtDE9.Text = e9d.ToString();
                txtDE10.Text = e10d.ToString();
                txtOE1.Text = e1o.ToString();
                txtOE2.Text = e2o.ToString();
                txtOE3.Text = e3o.ToString();
                txtOE4.Text = e4o.ToString();
                txtOE5.Text = e5o.ToString();
                txtOE6.Text = e6o.ToString();
                txtOE7.Text = e7o.ToString();
                txtOE8.Text = e8o.ToString();
                txtOE9.Text = e9o.ToString();
                txtOE10.Text = e10o.ToString();
                
                LoadChart1();
                LoadChart2();
                
               
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dt.Clear();
            update();
            ClearAll();
            LoadUser();
            chart1.ResetAutoValues();
        }
        private void update()
        {
            try
            {

                SqlConnection con = new SqlConnection(ConnectDb.connectionString);
                con.Open();
                if (txtId.Text != "")
                {

                    SqlCommand cmd = new SqlCommand("update TrainLaneManagment SET TrackName=@TrackName, TrackColor=@TrackColor, TrackStartPoint=@TrackStartPoint, TrackEndPoint=@TrackEndPoint,a1d=@a1d, a1o=@a1o,a2d=@a2d,a2o=@a2o, a3d=@a3d,a3o=@a3o,a4d=@a4d, a4o=@a4o,a5d=@a5d,a5o=@a5o, a6d=@a6d,a6o=@a6o,a7d=@a7d, a7o=@a7o,a8d=@a8d,a8o=@a8o, a9d=@a9d,a9o=@a9o,a10d=@a10d, a10o=@a10o,b1d=@b1d,b2d=@b2d, b3d=@b3d,b4d=@b4d,b5d=@b5d, b6d=@b6d,b7d=@b7d,b8d=@b8d, b9d=@b9d,b10d=@b10d,b1o=@b1o, b2o=@b2o,b3o=@b3o,b4o=@b4o, b5o=@b5o,b6o=@b6o,b7o=@b7o, b8o=@b8o,b9o=@b9o,b10o=@b10o, c1d=@c1d,c2d=@c2d,c3d=@c3d, c4d=@c4d,c5d=@c5d,c6d=@c6d, c7d=@c7d,c8d=@c8d,c9d=@c9d,c10d=@c10d,c1o=@c1o, c2o=@c2o,c3o=@c3o,c4o=@c4o, c5o=@c5o,c6o=@c6o,c7o=@c7o, c8o=@c8o,c9o=@c9o,c10o=@c10o, d1d=@d1d,d2d=@d2d,d3d=@d3d, d4d=@d4d,d5d=@d5d,d6d=@d6d, d7d=@d7d,d8d=@d8d,d9d=@d9d, d10d=@d10d,d1o=@d1o,d2o=@d2o, d3o=@d3o,d4o=@d4o,d5o=@d5o, d6o=@d6o,d7o=@d7o,d8o=@d8o, d9o=@d9o,d10o=@d10o,e1d=@e1d, e2d=@e2d,e3d=@e3d,e4d=@e4d, e5d=@e5d,e6d=@e6d,e7d=@e7d, e8d=@e8d,e9d=@e9d,e10d=@e10d, e1o=@e1o,e2o=@e2o,e3o=@e3o, e4o=@e4o,e5o=@e5o,e6o=@e6o, e7o=@e7o,e8o=@e8o,e9o=@e9o,e10o=@e10o where TrackId='" + txtId.Text.ToString() + "'", con);
                    cmd.Parameters.AddWithValue("@TrackName", txtTrackName.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackColor", colorDialog1.Color.ToArgb().ToString());
                    cmd.Parameters.AddWithValue("@TrackStartPoint", cmbStartPoint.Text.ToString());
                    cmd.Parameters.AddWithValue("@TrackEndPoint", cmbEndPoint.Text.ToString());
                    cmd.Parameters.AddWithValue("@a1d", txtDA1.Text.ToString());
                    cmd.Parameters.AddWithValue("@a1o", txtOA1.Text.ToString());
                    cmd.Parameters.AddWithValue("@a2d", txtDA2.Text.ToString());
                    cmd.Parameters.AddWithValue("@a2o", txtOA2.Text.ToString());
                    cmd.Parameters.AddWithValue("@a3d", txtDA3.Text.ToString());
                    cmd.Parameters.AddWithValue("@a3o", txtOA3.Text.ToString());
                    cmd.Parameters.AddWithValue("@a4d", txtDA4.Text.ToString());
                    cmd.Parameters.AddWithValue("@a4o", txtOA4.Text.ToString());
                    cmd.Parameters.AddWithValue("@a5d", txtDA5.Text.ToString());
                    cmd.Parameters.AddWithValue("@a5o", txtOA5.Text.ToString());
                    cmd.Parameters.AddWithValue("@a6d", txtDA6.Text.ToString());
                    cmd.Parameters.AddWithValue("@a6o", txtOA6.Text.ToString());
                    cmd.Parameters.AddWithValue("@a7d", txtDA7.Text.ToString());
                    cmd.Parameters.AddWithValue("@a7o", txtOA7.Text.ToString());
                    cmd.Parameters.AddWithValue("@a8d", txtDA8.Text.ToString());
                    cmd.Parameters.AddWithValue("@a8o", txtOA8.Text.ToString());
                    cmd.Parameters.AddWithValue("@a9d", txtDA9.Text.ToString());
                    cmd.Parameters.AddWithValue("@a9o", txtOA9.Text.ToString());
                    cmd.Parameters.AddWithValue("@a10d", txtDA10.Text.ToString());
                    cmd.Parameters.AddWithValue("@a10o", txtOA10.Text.ToString());

                    cmd.Parameters.AddWithValue("@b1d", txtDB1.Text.ToString());
                    cmd.Parameters.AddWithValue("@b2d", txtDB2.Text.ToString());
                    cmd.Parameters.AddWithValue("@b3d", txtDB3.Text.ToString());
                    cmd.Parameters.AddWithValue("@b4d", txtDB4.Text.ToString());
                    cmd.Parameters.AddWithValue("@b5d", txtDB5.Text.ToString());
                    cmd.Parameters.AddWithValue("@b6d", txtDB6.Text.ToString());
                    cmd.Parameters.AddWithValue("@b7d", txtDB7.Text.ToString());
                    cmd.Parameters.AddWithValue("@b8d", txtDB8.Text.ToString());
                    cmd.Parameters.AddWithValue("@b9d", txtDB9.Text.ToString());
                    cmd.Parameters.AddWithValue("@b10d", txtDB10.Text.ToString());
                    cmd.Parameters.AddWithValue("@b1o", txtOB1.Text.ToString());
                    cmd.Parameters.AddWithValue("@b2o", txtOB2.Text.ToString());
                    cmd.Parameters.AddWithValue("@b3o", txtOB3.Text.ToString());
                    cmd.Parameters.AddWithValue("@b4o", txtOB4.Text.ToString());
                    cmd.Parameters.AddWithValue("@b5o", txtOB5.Text.ToString());
                    cmd.Parameters.AddWithValue("@b6o", txtOB6.Text.ToString());
                    cmd.Parameters.AddWithValue("@b7o", txtOB7.Text.ToString());
                    cmd.Parameters.AddWithValue("@b8o", txtOB8.Text.ToString());
                    cmd.Parameters.AddWithValue("@b9o", txtOB9.Text.ToString());
                    cmd.Parameters.AddWithValue("@b10o", txtOB10.Text.ToString());

                    cmd.Parameters.AddWithValue("@c1d", txtDC1.Text.ToString());
                    cmd.Parameters.AddWithValue("@c2d", txtDC2.Text.ToString());
                    cmd.Parameters.AddWithValue("@c3d", txtDC3.Text.ToString());
                    cmd.Parameters.AddWithValue("@c4d", txtDC4.Text.ToString());
                    cmd.Parameters.AddWithValue("@c5d", txtDC5.Text.ToString());
                    cmd.Parameters.AddWithValue("@c6d", txtDC6.Text.ToString());
                    cmd.Parameters.AddWithValue("@c7d", txtDC7.Text.ToString());
                    cmd.Parameters.AddWithValue("@c8d", txtDC8.Text.ToString());
                    cmd.Parameters.AddWithValue("@c9d", txtDC9.Text.ToString());
                    cmd.Parameters.AddWithValue("@c10d", txtDC10.Text.ToString());
                    cmd.Parameters.AddWithValue("@c1o", txtOC1.Text.ToString());
                    cmd.Parameters.AddWithValue("@c2o", txtOC2.Text.ToString());
                    cmd.Parameters.AddWithValue("@c3o", txtOC3.Text.ToString());
                    cmd.Parameters.AddWithValue("@c4o", txtOC4.Text.ToString());
                    cmd.Parameters.AddWithValue("@c5o", txtOC5.Text.ToString());
                    cmd.Parameters.AddWithValue("@c6o", txtOC6.Text.ToString());
                    cmd.Parameters.AddWithValue("@c7o", txtOC7.Text.ToString());
                    cmd.Parameters.AddWithValue("@c8o", txtOC8.Text.ToString());
                    cmd.Parameters.AddWithValue("@c9o", txtOC9.Text.ToString());
                    cmd.Parameters.AddWithValue("@c10o", txtOC10.Text.ToString());

                    cmd.Parameters.AddWithValue("@d1d", txtDD1.Text.ToString());
                    cmd.Parameters.AddWithValue("@d2d", txtDD2.Text.ToString());
                    cmd.Parameters.AddWithValue("@d3d", txtDD3.Text.ToString());
                    cmd.Parameters.AddWithValue("@d4d", txtDD4.Text.ToString());
                    cmd.Parameters.AddWithValue("@d5d", txtDD5.Text.ToString());
                    cmd.Parameters.AddWithValue("@d6d", txtDD6.Text.ToString());
                    cmd.Parameters.AddWithValue("@d7d", txtDD7.Text.ToString());
                    cmd.Parameters.AddWithValue("@d8d", txtDD8.Text.ToString());
                    cmd.Parameters.AddWithValue("@d9d", txtDD9.Text.ToString());
                    cmd.Parameters.AddWithValue("@d10d", txtDD10.Text.ToString());
                    cmd.Parameters.AddWithValue("@d1o", txtOD1.Text.ToString());
                    cmd.Parameters.AddWithValue("@d2o", txtOD2.Text.ToString());
                    cmd.Parameters.AddWithValue("@d3o", txtOD3.Text.ToString());
                    cmd.Parameters.AddWithValue("@d4o", txtOD4.Text.ToString());
                    cmd.Parameters.AddWithValue("@d5o", txtOD5.Text.ToString());
                    cmd.Parameters.AddWithValue("@d6o", txtOD6.Text.ToString());
                    cmd.Parameters.AddWithValue("@d7o", txtOD7.Text.ToString());
                    cmd.Parameters.AddWithValue("@d8o", txtOD8.Text.ToString());
                    cmd.Parameters.AddWithValue("@d9o", txtOD9.Text.ToString());
                    cmd.Parameters.AddWithValue("@d10o", txtOD10.Text.ToString());

                    cmd.Parameters.AddWithValue("@e1d", txtDE1.Text.ToString());
                    cmd.Parameters.AddWithValue("@e2d", txtDE2.Text.ToString());
                    cmd.Parameters.AddWithValue("@e3d", txtDE3.Text.ToString());
                    cmd.Parameters.AddWithValue("@e4d", txtDE4.Text.ToString());
                    cmd.Parameters.AddWithValue("@e5d", txtDE5.Text.ToString());
                    cmd.Parameters.AddWithValue("@e6d", txtDE6.Text.ToString());
                    cmd.Parameters.AddWithValue("@e7d", txtDE7.Text.ToString());
                    cmd.Parameters.AddWithValue("@e8d", txtDE8.Text.ToString());
                    cmd.Parameters.AddWithValue("@e9d", txtDE9.Text.ToString());
                    cmd.Parameters.AddWithValue("@e10d", txtDE10.Text.ToString());
                    cmd.Parameters.AddWithValue("@e1o", txtOE1.Text.ToString());
                    cmd.Parameters.AddWithValue("@e2o", txtOE2.Text.ToString());
                    cmd.Parameters.AddWithValue("@e3o", txtOE3.Text.ToString());
                    cmd.Parameters.AddWithValue("@e4o", txtOE4.Text.ToString());
                    cmd.Parameters.AddWithValue("@e5o", txtOE5.Text.ToString());
                    cmd.Parameters.AddWithValue("@e6o", txtOE6.Text.ToString());
                    cmd.Parameters.AddWithValue("@e7o", txtOE7.Text.ToString());
                    cmd.Parameters.AddWithValue("@e8o", txtOE8.Text.ToString());
                    cmd.Parameters.AddWithValue("@e9o", txtOE9.Text.ToString());
                    cmd.Parameters.AddWithValue("@e10o", txtOE10.Text.ToString());

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

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                clrTrack.BackColor = colorDialog1.Color;
                clrTrack.Text = colorDialog1.Color.ToArgb().ToString();
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM TrainLaneManagment WHERE TrackId = '" + txtId.Text.ToString() + "'", con);
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
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from TrainLaneManagment Where TrackName Like'%" + txtSearch.Text.ToString() + "%'", con);
            adapt.Fill(dt);
            DGV.DataSource = dt;
            this.DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            con.Close();
        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void chart1_MouseMove(object sender, MouseEventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
