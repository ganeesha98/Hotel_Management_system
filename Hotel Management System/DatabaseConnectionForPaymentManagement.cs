using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForPaymentManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal string[] GetSearchCustormerPersonalDetailsAndReservationDetails(string BillNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string SelectedNicNumber = "";
            string[] CustormerDetailsAndReservationDetails = new string[30];
            SqlCeCommand GetSelectedCustormerNicNumber= new SqlCeCommand("select nic_no from billDetails where bill_no = '" + BillNo + "'", conn);
            SqlCeDataReader SelectedCustormerNicNumber = GetSelectedCustormerNicNumber.ExecuteReader();

            while (SelectedCustormerNicNumber.Read())
            {
                SelectedNicNumber = SelectedCustormerNicNumber[0].ToString();
            }

            GetSelectedCustormerNicNumber.Dispose();
            SelectedCustormerNicNumber.Dispose();

            SqlCeCommand GetSelectedCustormerDetailsAndReservationDetails = new SqlCeCommand("select * from cus_personalDetails where nic_no = '" + SelectedNicNumber + "'", conn);
            SqlCeDataReader SelectedCustormerDetailsAndReservationDetails = GetSelectedCustormerDetailsAndReservationDetails.ExecuteReader();

            while (SelectedCustormerDetailsAndReservationDetails.Read())
            {
                CustormerDetailsAndReservationDetails[0] = SelectedCustormerDetailsAndReservationDetails[0].ToString();
                CustormerDetailsAndReservationDetails[1] = SelectedCustormerDetailsAndReservationDetails[1].ToString();
                CustormerDetailsAndReservationDetails[2] = SelectedCustormerDetailsAndReservationDetails[2].ToString();
                CustormerDetailsAndReservationDetails[3] = SelectedCustormerDetailsAndReservationDetails[3].ToString();
                CustormerDetailsAndReservationDetails[4] = SelectedCustormerDetailsAndReservationDetails[4].ToString();
                CustormerDetailsAndReservationDetails[5] = SelectedCustormerDetailsAndReservationDetails[5].ToString();
                CustormerDetailsAndReservationDetails[6] = SelectedCustormerDetailsAndReservationDetails[6].ToString();
                CustormerDetailsAndReservationDetails[7] = SelectedCustormerDetailsAndReservationDetails[7].ToString();
                CustormerDetailsAndReservationDetails[8] = SelectedCustormerDetailsAndReservationDetails[8].ToString();
                CustormerDetailsAndReservationDetails[9] = SelectedCustormerDetailsAndReservationDetails[9].ToString();
                CustormerDetailsAndReservationDetails[10] = SelectedCustormerDetailsAndReservationDetails[10].ToString();
                CustormerDetailsAndReservationDetails[11] = SelectedCustormerDetailsAndReservationDetails[11].ToString();
                CustormerDetailsAndReservationDetails[12] = SelectedCustormerDetailsAndReservationDetails[12].ToString();
                CustormerDetailsAndReservationDetails[13] = SelectedCustormerDetailsAndReservationDetails[13].ToString();
                CustormerDetailsAndReservationDetails[14] = SelectedCustormerDetailsAndReservationDetails[14].ToString();
            }

            return CustormerDetailsAndReservationDetails;
        }

        internal string[] GetSelectedCustormerBillDetails(string BillNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] CustormerBillDetails = new string[20];
            SqlCeCommand GetSelectedCustormerBillDetails = new SqlCeCommand("select * from billDetails where bill_no = '" + BillNo + "'", conn);
            SqlCeDataReader SelectedCustormerBillDetails = GetSelectedCustormerBillDetails.ExecuteReader();

            while (SelectedCustormerBillDetails.Read())
            {
                CustormerBillDetails[0] = SelectedCustormerBillDetails[0].ToString();
                CustormerBillDetails[1] = SelectedCustormerBillDetails[1].ToString();
                CustormerBillDetails[2] = SelectedCustormerBillDetails[2].ToString();
                CustormerBillDetails[3] = SelectedCustormerBillDetails[3].ToString();
                CustormerBillDetails[4] = SelectedCustormerBillDetails[4].ToString();
                CustormerBillDetails[5] = SelectedCustormerBillDetails[5].ToString();
                CustormerBillDetails[6] = SelectedCustormerBillDetails[6].ToString();
                CustormerBillDetails[7] = SelectedCustormerBillDetails[7].ToString();
                CustormerBillDetails[8] = SelectedCustormerBillDetails[8].ToString();
                CustormerBillDetails[9] = SelectedCustormerBillDetails[9].ToString();
            }

            return CustormerBillDetails;
        }

        internal int GetAdvanceAmountDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int AdvanceAmount = 0;
            SqlCeCommand GetAdvanceAmountDetails = new SqlCeCommand("select price from advance_amount_details", conn);
            SqlCeDataReader SelectAdvanceAmountDetails = GetAdvanceAmountDetails.ExecuteReader();

            while (SelectAdvanceAmountDetails.Read())
            {
                AdvanceAmount = Convert.ToInt32(SelectAdvanceAmountDetails[0].ToString());
            }

            return AdvanceAmount;
        }

        internal bool UpdateCustormerPaymentStatus(string BillNo,string AdvancePaymentStatus,string FinalPaymentStatus,string CompetePaymentStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateCustormerBillDetails = new SqlCeCommand("update billDetails set advance_amt_sts = '" + AdvancePaymentStatus + "',final_amt_sts = '" + FinalPaymentStatus + "',complete_sts = '" + CompetePaymentStatus + "' where bill_no = '" + BillNo + "'", conn);
                UpdateCustormerBillDetails.ExecuteReader();
                UpdateCustormerBillDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
