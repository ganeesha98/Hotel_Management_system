using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForMealManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);

        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");

        internal bool RegisterMealDetails(string MealNo, string MealType, string MealName, string MealQuentity, string MealPrice, string MealStatus, string MealDescription,string BreakfastStatus,string LunchStatus,string DinnerStstus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertNewMealDetails = new SqlCeCommand("insert into meal_details (no,type,name,quentity,price,status,description,breakfast,lunch,dinner) values (@no,@type,@name,@quentity,@price,@status,@description,@breakfast,@lunch,@dinner)", conn);
                InsertNewMealDetails.Parameters.Add("@no", MealNo);
                InsertNewMealDetails.Parameters.Add("@type", MealType);
                InsertNewMealDetails.Parameters.Add("@name", MealName);
                InsertNewMealDetails.Parameters.Add("@quentity", MealQuentity);
                InsertNewMealDetails.Parameters.Add("@price", MealPrice);
                InsertNewMealDetails.Parameters.Add("@status", MealStatus);
                InsertNewMealDetails.Parameters.Add("@description", MealDescription);
                InsertNewMealDetails.Parameters.Add("@breakfast", BreakfastStatus);
                InsertNewMealDetails.Parameters.Add("@lunch", LunchStatus);
                InsertNewMealDetails.Parameters.Add("@dinner", DinnerStstus);

                InsertNewMealDetails.ExecuteNonQuery();
                InsertNewMealDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetRequiredMealDetails(string MealNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] MealDetails = new string[20];
            SqlCeCommand GetSelectedMealDetails = new SqlCeCommand("select * from meal_details where no = '" + MealNo + "'" ,conn);
            SqlCeDataReader SelectedMealDetails = GetSelectedMealDetails.ExecuteReader();

            while (SelectedMealDetails.Read())
            {
                MealDetails[0] = SelectedMealDetails[0].ToString();
                MealDetails[1] = SelectedMealDetails[1].ToString();
                MealDetails[2] = SelectedMealDetails[2].ToString();
                MealDetails[3] = SelectedMealDetails[3].ToString();
                MealDetails[4] = SelectedMealDetails[4].ToString();
                MealDetails[5] = SelectedMealDetails[5].ToString();
                MealDetails[6] = SelectedMealDetails[6].ToString();
                MealDetails[7] = SelectedMealDetails[7].ToString();
                MealDetails[8] = SelectedMealDetails[8].ToString();
                MealDetails[9] = SelectedMealDetails[9].ToString();
            }

            return MealDetails;
        }

        internal bool UpdateMealDetails(string MealNo, string MealType, string MealName, string MealQuentity, string MealPrice, string MealStatus, string MealDescription,string BreakfastStatus,string LunchStatus,string DinnerStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateNewMealDetails = new SqlCeCommand("update meal_details set type = '" + MealType + "',name = '" + MealName + "',quentity = '" + MealQuentity + "',price = '" + MealPrice + "',status = '" + MealStatus + "',description = '" + MealDescription + "',breakfast = '" + BreakfastStatus + "',lunch = '" + LunchStatus + "',dinner = '" + DinnerStatus + "' where no = '" + MealNo + "'", conn);
                UpdateNewMealDetails.ExecuteNonQuery();
                UpdateNewMealDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteMealDetails(string MealNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteMealDetails = new SqlCeCommand("delete from meal_details where no = '" + MealNo + "'", conn);
                DeleteMealDetails.ExecuteNonQuery();
                DeleteMealDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal int GetDatabaseTableRecordCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int RecordCount = 0;
            SqlCeCommand GetDatabaseTableRecordCount = new SqlCeCommand("select count(*) from meal_details", conn);
            SqlCeDataReader DatabaseTableRecodCount = GetDatabaseTableRecordCount.ExecuteReader();

            while (DatabaseTableRecodCount.Read())
            {
                RecordCount = Convert.ToInt32(DatabaseTableRecodCount[0].ToString());
            }

            return RecordCount;
        }
    }
}
