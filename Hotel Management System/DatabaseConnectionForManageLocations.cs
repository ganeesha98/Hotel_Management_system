using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForManageLocations
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");

        custormer_details CustormerFormObj = new custormer_details();

        internal bool RegisterLocationDetails(string LocationNo, string LocationCategory, string CategoryType, string MaxPersons, string LocationPrice, string LocationStatus, string MaintainaceType, DateTime AllocatedDate, DateTime DueDate, string MaintainStatus,string Description,string MaintainDays)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            try
            {
                SqlCeCommand RegisterLocationDetails = new SqlCeCommand("insert into location_details (no,category,category_type,max_per,status,price) values (@no,@category,@category_type,@max_per,@status,@price)", conn);
                RegisterLocationDetails.Parameters.Add("@no", LocationNo);
                RegisterLocationDetails.Parameters.Add("@category", LocationCategory);
                RegisterLocationDetails.Parameters.Add("@category_type", CategoryType);
                RegisterLocationDetails.Parameters.Add("@max_per", MaxPersons);
                RegisterLocationDetails.Parameters.Add("@status", LocationStatus);
                RegisterLocationDetails.Parameters.Add("@price", LocationPrice);

                RegisterLocationDetails.ExecuteNonQuery();
                RegisterLocationDetails.Dispose();

                SqlCeCommand MakeMaintainanceDetailsForLocation = new SqlCeCommand("insert into maintain_details (no,type,allocated_date,due_date,status,description,days) values (@no,@type,@allocated_date,@due_date,@status,@desc,@days)", conn);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@no", LocationNo);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@type", MaintainaceType);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@allocated_date", AllocatedDate);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@due_date", DueDate);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@status", MaintainStatus);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@desc", Description);
                MakeMaintainanceDetailsForLocation.Parameters.Add("@days", MaintainDays);

                MakeMaintainanceDetailsForLocation.ExecuteNonQuery();
                MakeMaintainanceDetailsForLocation.Dispose();

                CustormerFormObj.AccessLocationCategories();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedLocationDetails(string LocationNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] RecivedLocationDetails = new string[20];
            SqlCeCommand GetSelectedLocationDetails = new SqlCeCommand("select * from location_details where no = '" + LocationNumber + "'" ,conn);
            SqlCeDataReader SelectedLocationDetails = GetSelectedLocationDetails.ExecuteReader();

            while (SelectedLocationDetails.Read())
            {
                RecivedLocationDetails[0] = SelectedLocationDetails[0].ToString();
                RecivedLocationDetails[1] = SelectedLocationDetails[1].ToString();
                RecivedLocationDetails[2] = SelectedLocationDetails[2].ToString();
                RecivedLocationDetails[3] = SelectedLocationDetails[3].ToString();
                RecivedLocationDetails[4] = SelectedLocationDetails[4].ToString();
                RecivedLocationDetails[5] = SelectedLocationDetails[5].ToString();
                RecivedLocationDetails[6] = SelectedLocationDetails[6].ToString();
            }

            GetSelectedLocationDetails.Dispose();
            SelectedLocationDetails.Dispose();

            SqlCeCommand GetSelectedLocationMaintainanceDetails = new SqlCeCommand("select * from maintain_details where no = '" + LocationNumber + "'" ,conn);
            SqlCeDataReader SelectedLocationMaintainDetails = GetSelectedLocationMaintainanceDetails.ExecuteReader();

            while (SelectedLocationMaintainDetails.Read())
            {
                RecivedLocationDetails[7] = SelectedLocationMaintainDetails[1].ToString();
                RecivedLocationDetails[8] = SelectedLocationMaintainDetails[2].ToString();
                RecivedLocationDetails[9] = SelectedLocationMaintainDetails[3].ToString();
                RecivedLocationDetails[10] = SelectedLocationMaintainDetails[4].ToString();
                RecivedLocationDetails[11] = SelectedLocationMaintainDetails[5].ToString();
                RecivedLocationDetails[12] = SelectedLocationMaintainDetails[6].ToString();
            }

            GetSelectedLocationMaintainanceDetails.Dispose();
            SelectedLocationMaintainDetails.Dispose();

            return RecivedLocationDetails;
        }

        internal bool UpdateLocationDetails(string LocationNumber, string LocationCategory, string CategoryType, string MaxPersons, string LocationPrice, string LocationStatus, string MaintainaceType, DateTime AllocatedDate, DateTime DueDate, string MaintainStatus, string Description,string MaintainDays)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedLocationDetails = new SqlCeCommand("update location_details set category = '" + LocationCategory + "',category_type = '" + CategoryType + "',max_per = '" + MaxPersons + "',status = '" + LocationStatus + "',price = '" + LocationPrice + "' where no = '" + LocationNumber + "'", conn);
                UpdateSelectedLocationDetails.ExecuteNonQuery();
                UpdateSelectedLocationDetails.Dispose();

                SqlCeCommand UpdateMakeMaintainanceDetailsForLocation = new SqlCeCommand("update maintain_details set type = '" + MaintainaceType + "',allocated_date = '" + AllocatedDate + "',due_date = '" + DueDate + "',status = '" + MaintainStatus + "',description = '" + Description + "',days = '" + MaintainDays + "' where no = '" + LocationNumber + "'", conn);
                UpdateMakeMaintainanceDetailsForLocation.ExecuteNonQuery();
                UpdateMakeMaintainanceDetailsForLocation.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedLocationDetails(string LocationNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedLocationDetails = new SqlCeCommand("delete from location_details where no = '" + LocationNumber + "'", conn);
                DeleteSelectedLocationDetails.ExecuteNonQuery();
                DeleteSelectedLocationDetails.Dispose();

                SqlCeCommand DeleteSelectedLocationMaintainDetails = new SqlCeCommand("delete from maintain_details where no = '" + LocationNumber + "'", conn);
                DeleteSelectedLocationMaintainDetails.ExecuteNonQuery();
                DeleteSelectedLocationMaintainDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal int GetTableRecordNumbersCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int Record_count = 0;
            SqlCeCommand GetTableRecordNumbers = new SqlCeCommand("select count(*) from location_details" ,conn);
            SqlCeDataReader SelectedRecordCount = GetTableRecordNumbers.ExecuteReader();

            while (SelectedRecordCount.Read())
            {
                Record_count = Convert.ToInt32(SelectedRecordCount[0].ToString());
            }

            return Record_count;
        }
    }
}
