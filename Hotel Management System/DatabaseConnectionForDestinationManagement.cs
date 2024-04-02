using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForDestinationManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);

        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal bool RegisterDestinationDetails(string DestinationNo, string Destinationname, string Path01, string Path02, string Path03, string DestinationPrice, string DestinationStatus, string DestinationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertTravellingDetails = new SqlCeCommand("insert into traveling_detials (destination_no,destination_name,path_1,path_2,path_3,status,price,description) values (@destination_no,@destination_name,@path01,@path02,@path03,@status,@price,@description)", conn);
                InsertTravellingDetails.Parameters.Add("@destination_no", DestinationNo);
                InsertTravellingDetails.Parameters.Add("@destination_name", Destinationname);
                InsertTravellingDetails.Parameters.Add("@path01", Path01);
                InsertTravellingDetails.Parameters.Add("@path02", Path02);
                InsertTravellingDetails.Parameters.Add("@path03", Path03);
                InsertTravellingDetails.Parameters.Add("@status", DestinationStatus);
                InsertTravellingDetails.Parameters.Add("@price", DestinationPrice);
                InsertTravellingDetails.Parameters.Add("@description", DestinationDescription);

                InsertTravellingDetails.ExecuteNonQuery();
                InsertTravellingDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedTravellingDetails(string DestinationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] TravellingDetails = new string[20];
            SqlCeCommand GetSelectedTravellingDetails = new SqlCeCommand("select * from traveling_detials where destination_no = '" + DestinationNo + "'", conn);
            SqlCeDataReader SelectedTravellingDetails = GetSelectedTravellingDetails.ExecuteReader();

            while (SelectedTravellingDetails.Read())
            {
                TravellingDetails[0] = SelectedTravellingDetails[0].ToString();
                TravellingDetails[1] = SelectedTravellingDetails[1].ToString();
                TravellingDetails[2] = SelectedTravellingDetails[2].ToString();
                TravellingDetails[3] = SelectedTravellingDetails[3].ToString();
                TravellingDetails[4] = SelectedTravellingDetails[4].ToString();
                TravellingDetails[5] = SelectedTravellingDetails[5].ToString();
                TravellingDetails[6] = SelectedTravellingDetails[6].ToString();
                TravellingDetails[7] = SelectedTravellingDetails[7].ToString();
                TravellingDetails[8] = SelectedTravellingDetails[8].ToString();
            }

            return TravellingDetails;
        }

        internal bool UpdateDestinationDetails(string DestinationNo, string Destinationname, string Path01, string Path02, string Path03, string DestinationPrice, string DestinationStatus, string DestinationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedTravellingDetails = new SqlCeCommand("update traveling_detials set destination_name = '" + Destinationname + "', path_1 = '" + Path01 + "',path_2 = '" + Path02 + "',path_3 = '" + Path03 + "',status = '" + DestinationStatus + "',price = '" + DestinationPrice + "', description = '"+DestinationDescription+"' where destination_no ='"+DestinationNo+"'", conn);
                UpdateSelectedTravellingDetails.ExecuteNonQuery();
                UpdateSelectedTravellingDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedTravellingDetails(string DestinationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            try
            {
                SqlCeCommand DeleteSelectedTravellingDetails = new SqlCeCommand("delete from traveling_detials where destination_no = '" + DestinationNo + "'", conn);

                DeleteSelectedTravellingDetails.ExecuteNonQuery();
                DeleteSelectedTravellingDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string GetTravellingTableRecordCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string TravellingTableRecordCount = "";
            SqlCeCommand GetTableRecordCount = new SqlCeCommand("select count(*) from traveling_detials", conn);
            SqlCeDataReader SelectedTravellingTableRecordCount = GetTableRecordCount.ExecuteReader();

            while (SelectedTravellingTableRecordCount.Read())
            {
                TravellingTableRecordCount = SelectedTravellingTableRecordCount[0].ToString();
            }

            return TravellingTableRecordCount;
        }
    }
}
