using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForSettingsManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal bool RegisterOfferDetails(string OfferNo, string OfferName, DateTime OfferStartDate, string OfferDays, DateTime OfferEndDate, string OfferValue, string OfferStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertOfferDetails = new SqlCeCommand("insert into offer_details values (@offer_no,@offer_name,@start_date,@days,@end_date,@value,@status)", conn);
                InsertOfferDetails.Parameters.Add("@offer_no", OfferNo);
                InsertOfferDetails.Parameters.Add("@offer_name", OfferName);
                InsertOfferDetails.Parameters.Add("@start_date", OfferStartDate);
                InsertOfferDetails.Parameters.Add("@days", OfferDays);
                InsertOfferDetails.Parameters.Add("@end_date", OfferEndDate);
                InsertOfferDetails.Parameters.Add("@value", OfferValue);
                InsertOfferDetails.Parameters.Add("@status", OfferStatus);

                InsertOfferDetails.ExecuteNonQuery();
                InsertOfferDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedOfferDetails(string OfferNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] OfferDetails = new string[20];
            SqlCeCommand GetSelectedOfferDetails = new SqlCeCommand("select * from offer_details where offer_no = '" + OfferNo + "'", conn);
            SqlCeDataReader SelectedOfferDetails = GetSelectedOfferDetails.ExecuteReader();

            while (SelectedOfferDetails.Read())
            {
                OfferDetails[0] = SelectedOfferDetails[0].ToString();
                OfferDetails[1] = SelectedOfferDetails[1].ToString();
                OfferDetails[2] = SelectedOfferDetails[2].ToString();
                OfferDetails[3] = SelectedOfferDetails[3].ToString();
                OfferDetails[4] = SelectedOfferDetails[4].ToString();
                OfferDetails[5] = SelectedOfferDetails[5].ToString();
                OfferDetails[6] = SelectedOfferDetails[6].ToString();
            }

            return OfferDetails;
        }

        internal bool UpdateOfferDetails(string OfferNo, string OfferName, DateTime OfferStartDate, string OfferDays, DateTime OfferEndDate, string OfferValue, string OfferStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateOfferDetails = new SqlCeCommand("update offer_details set name = '" + OfferName + "',start_date = '" + OfferStartDate + "',days = '" + OfferDays + "',end_date = '" + OfferEndDate + "',value = '" + OfferValue + "',status = '" + OfferStatus + "' where offer_no = '" + OfferNo + "'", conn);
                UpdateOfferDetails.ExecuteNonQuery();
                UpdateOfferDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedOfferDetails(string OfferNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedOfferDetails = new SqlCeCommand("delete from offer_details where offer_no = '" + OfferNo + "'", conn);
                DeleteSelectedOfferDetails.ExecuteNonQuery();
                DeleteSelectedOfferDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool InsertDecorationDetails(string DecorationNo, string DecorationName, string BaloonsSts, string CandlesStatus, string RossesStats, string RibbonsStatus, string DecorationPrice, string DecorationStatus, string DecorationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertDecorationDetails = new SqlCeCommand("insert into decoration_details values (@decoration_no,@decoration_name,@baloon_sts,@candle_sts,@rooses_sts,@ribbon_sts,@price,@status,@description)", conn);
                InsertDecorationDetails.Parameters.Add("@decoration_no", DecorationNo);
                InsertDecorationDetails.Parameters.Add("@decoration_name", DecorationName);
                InsertDecorationDetails.Parameters.Add("@baloon_sts", BaloonsSts);
                InsertDecorationDetails.Parameters.Add("@candle_sts", CandlesStatus);
                InsertDecorationDetails.Parameters.Add("@rooses_sts", RossesStats);
                InsertDecorationDetails.Parameters.Add("@ribbon_sts", RibbonsStatus);
                InsertDecorationDetails.Parameters.Add("@price", DecorationPrice);
                InsertDecorationDetails.Parameters.Add("@status", DecorationStatus);
                InsertDecorationDetails.Parameters.Add("@description", DecorationDescription);

                InsertDecorationDetails.ExecuteNonQuery();
                InsertDecorationDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedDecorationDetails(string DecorationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] DecorationDetails = new string[20];
            SqlCeCommand GetSelectedDecorationDetails = new SqlCeCommand("select * from decoration_details where decoration_no = '" + DecorationNo + "'", conn);
            SqlCeDataReader SelectedDecorationDetails = GetSelectedDecorationDetails.ExecuteReader();

            while (SelectedDecorationDetails.Read())
            {
                DecorationDetails[0] = SelectedDecorationDetails[0].ToString();
                DecorationDetails[1] = SelectedDecorationDetails[1].ToString();
                DecorationDetails[2] = SelectedDecorationDetails[2].ToString();
                DecorationDetails[3] = SelectedDecorationDetails[3].ToString();
                DecorationDetails[4] = SelectedDecorationDetails[4].ToString();
                DecorationDetails[5] = SelectedDecorationDetails[5].ToString();
                DecorationDetails[6] = SelectedDecorationDetails[6].ToString();
                DecorationDetails[7] = SelectedDecorationDetails[7].ToString();
                DecorationDetails[8] = SelectedDecorationDetails[8].ToString();
            }

            return DecorationDetails;
        }

        internal bool UpdateDecorationDetails(string DecorationNo, string DecorationName, string BaloonsSts, string CandlesStatus, string RossesStats, string RibbonsStatus, string DecorationPrice, string DecorationStatus, string DecorationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateDecorationDetails = new SqlCeCommand("update decoration_details set name = '" + DecorationName + "',balloons = '" + BaloonsSts + "',candles = '" + CandlesStatus + "',rosses = '" + RossesStats + "',ribbons = '" + RibbonsStatus + "',price = '" + DecorationPrice + "',status = '" + DecorationStatus + "',description = '" + DecorationDescription + "' where decoration_no = '" + DecorationNo + "'", conn);
                UpdateDecorationDetails.ExecuteNonQuery();
                UpdateDecorationDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedDecorationdetails(string DecorationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedDecorationDetails = new SqlCeCommand("delete from decoration_details where decoration_no = '" + DecorationNo + "'", conn);
                DeleteSelectedDecorationDetails.ExecuteNonQuery();
                DeleteSelectedDecorationDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool InsertDesignationDetails(string DesignationNo, string DesignationName, string DesignationStatus, string DesignationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertDesignationDetails = new SqlCeCommand("insert into designation_details values (@designation_no,@designation_name,@status,@description)", conn);
                InsertDesignationDetails.Parameters.Add("@designation_no", DesignationNo);
                InsertDesignationDetails.Parameters.Add("@designation_name", DesignationName);
                InsertDesignationDetails.Parameters.Add("@status", DesignationStatus);
                InsertDesignationDetails.Parameters.Add("@description", DesignationDescription);

                InsertDesignationDetails.ExecuteNonQuery();
                InsertDesignationDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedDesignationdetails(string DesignationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] Designationdetails = new string[20];
            SqlCeCommand GetSelectedDesignationdetails = new SqlCeCommand("select * from designation_details where no = '" + DesignationNo + "'", conn);
            SqlCeDataReader SelectedDesignationdetails = GetSelectedDesignationdetails.ExecuteReader();

            while (SelectedDesignationdetails.Read())
            {
                Designationdetails[0] = SelectedDesignationdetails[0].ToString();
                Designationdetails[1] = SelectedDesignationdetails[1].ToString();
                Designationdetails[2] = SelectedDesignationdetails[2].ToString();
                Designationdetails[3] = SelectedDesignationdetails[3].ToString();
            }

            return Designationdetails;
        }

        internal bool UpdateDesignationDetails(string DesignationNo, string DesignationName, string DesignationStatus, string DesignationDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedDesignationdetails = new SqlCeCommand("update designation_details set name = '" + DesignationName + "',status = '" + DesignationStatus + "',description = '" + DesignationDescription + "' where no = '" + DesignationNo + "'", conn);
                UpdateSelectedDesignationdetails.ExecuteNonQuery();
                UpdateSelectedDesignationdetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedDesignationdetails(string DesignationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedDesignationdetails = new SqlCeCommand("delete from designation_details where no = '" + DesignationNo + "'", conn);
                DeleteSelectedDesignationdetails.ExecuteNonQuery();
                DeleteSelectedDesignationdetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool InsertAdvanceAmtDetails(string AdvanceAmtNo, string AdvanceAmtPrice, string AdvanceAmtDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertAdvanceAmountDetails = new SqlCeCommand("insert into advance_amount_details values (@advanceamt_no,@advanceamt_price,@advanceamt_description)", conn);
                InsertAdvanceAmountDetails.Parameters.Add("@advanceamt_no", AdvanceAmtNo);
                InsertAdvanceAmountDetails.Parameters.Add("@advanceamt_price", AdvanceAmtPrice);
                InsertAdvanceAmountDetails.Parameters.Add("@advanceamt_description", AdvanceAmtDescription);

                InsertAdvanceAmountDetails.ExecuteNonQuery();
                InsertAdvanceAmountDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedAdvanceAmtDetails(string AdvanceAmtNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AdvanceAmountDetails = new string[20];
            SqlCeCommand GetSelectedAdvanceAmtDetails = new SqlCeCommand("select * from advance_amount_details where no = '" + AdvanceAmtNo + "'", conn);
            SqlCeDataReader SelectedAdvanceAmtDetails = GetSelectedAdvanceAmtDetails.ExecuteReader();

            while (SelectedAdvanceAmtDetails.Read())
            {
                AdvanceAmountDetails[0] = SelectedAdvanceAmtDetails[0].ToString();
                AdvanceAmountDetails[1] = SelectedAdvanceAmtDetails[1].ToString();
                AdvanceAmountDetails[2] = SelectedAdvanceAmtDetails[2].ToString();
            }

            return AdvanceAmountDetails;
        }

        internal bool UpdateAdvanceAmtDetails(string AdvanceAmtNo, string AdvanceAmtPrice, string AdvanceAmtDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedAdvanceAmoutDetails = new SqlCeCommand("update advance_amount_details set price = '" + AdvanceAmtPrice + "',description = '" + AdvanceAmtDescription + "' where no = '" + AdvanceAmtNo + "'", conn);
                UpdateSelectedAdvanceAmoutDetails.ExecuteNonQuery();
                UpdateSelectedAdvanceAmoutDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedAdvanceAmtDetails(string AdvanceAmtNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedAdvanceAmtDetails = new SqlCeCommand("delete from advance_amount_details where no = '" + AdvanceAmtNo + "'", conn);
                DeleteSelectedAdvanceAmtDetails.ExecuteNonQuery();
                DeleteSelectedAdvanceAmtDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
