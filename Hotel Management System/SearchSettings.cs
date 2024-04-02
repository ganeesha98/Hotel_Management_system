using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Hotel_Management_System
{
    public partial class SearchSettings : UserControl
    {
        public SearchSettings()
        {
            InitializeComponent();
        }

        public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        public static string DBName = "Hotel_Management_System.sdf";
        public static string FullPath = "Data Source = " + ProjPath + "\\" + DBName + ";" + "Password = 'root123'";
        SqlCeConnection conn = new SqlCeConnection(FullPath);
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal void GetSelectedSectionDetailsForEmployee()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from employee_deetails", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\EmployeeDetailsReport.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForLocation()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from location_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\LocationDetailsReport.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForCustormer()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from cus_personalDetails", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\CustormerPersonalDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForMealDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from meal_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\MealDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForTravelling()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from traveling_detials", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\TravelingDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForVehicle()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from vehicle_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\VehicleDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForOfferDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from offer_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\OfferDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForDecorations()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from decoration_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\DecorationDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        internal void GetSelectedSectionDetailsForMaintainDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DataTable SelectedDataTable = new DataTable();
            SqlCeCommand GetSelectedSectiondetails = new SqlCeCommand("select * from maintain_details", conn);
            SqlCeDataAdapter SelectedSectionDetails = new SqlCeDataAdapter(GetSelectedSectiondetails);
            SelectedSectionDetails.Fill(SelectedDataTable);

            ReportDataSource DataSource = new ReportDataSource("DataSet1", SelectedDataTable);
            ReportVeiwer.LocalReport.ReportPath = ProjPath + "\\MaintainDetails.rdlc";
            ReportVeiwer.LocalReport.DataSources.Clear();
            ReportVeiwer.LocalReport.DataSources.Add(DataSource);
            ReportVeiwer.RefreshReport();
        }

        private void LoadDetails_btn_Click(object sender, EventArgs e)
        {
            string GetSelectedSection = Sections_cmb.Text;

            if (GetSelectedSection == "Employee Details")
            {
                GetSelectedSectionDetailsForEmployee();
            }
            else if (GetSelectedSection == "Custormer Details")
            {
                GetSelectedSectionDetailsForCustormer();
            }
            else if (GetSelectedSection == "Meal Details")
            {
                GetSelectedSectionDetailsForMealDetails();
            }
            else if (GetSelectedSection == "Location Details")
            {
                GetSelectedSectionDetailsForLocation();
            }
            else if (GetSelectedSection == "Travelling Details")
            {
                GetSelectedSectionDetailsForTravelling();
            }
            else if (GetSelectedSection == "Vehicle Details")
            {
                GetSelectedSectionDetailsForVehicle();
            }
            else if (GetSelectedSection == "Offers Details")
            {
                GetSelectedSectionDetailsForOfferDetails();
            }
            else if (GetSelectedSection == "Decorations Details")
            {
                GetSelectedSectionDetailsForDecorations();
            }
            else if (GetSelectedSection == "Maintain Details")
            {
                GetSelectedSectionDetailsForMaintainDetails();
            }
        }
    }
}
