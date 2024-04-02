using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForEmployeeManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal bool RegisterEmployeePersonalInfoAndWorkingExp(string NicNumber, string NameInitials,string Name, string FullName, DateTime BirthDate, string PermenentAddress, string CommunicationAddress, string EmailAddress, string Telephone_1, string Telephone_2, string OLSts, string OlDesc, string ALSts, string ALDesc, string OtherSts, string OtherDesc, string ETF_EPF_No, string Designation, string Department, DateTime AppointmentDate, string EmpStatus, int Duration, string Description,string DriverAllocatedStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            try
            {
                SqlCeCommand InsertEmployeePersonalInfoAndOtherDetails = new SqlCeCommand("insert into employee_deetails (nic_no,full_name,b_date,permenent_addr,communication_addr,email_addr,tel_1,tel_2,ol_cmb,ol_desc,al_cmb,al_desc,other_cmb,other_desc,etf_epf_no,designation,dep,appointment_date,status,duration,description,name_title,name,driver_allocated_sts) values (@nic_no,@full_name,@b_date,@permenent_addr,@communication_addr,@email_addr,@tel_1,@tel_2,@ol_cmb,@ol_desc,@al_cmb,@al_desc,@other_cmb,@other_desc,@etf_epf_no,@designation,@dep,@appointment_date,@status,@duration,@description,@name_title,@name,@driver_allocated_sts)", conn);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@nic_no", NicNumber);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@name", Name);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@full_name", FullName);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@name_title", NameInitials);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@b_date", BirthDate);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@permenent_addr", PermenentAddress);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@communication_addr", CommunicationAddress);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@email_addr", EmailAddress);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@tel_1", Telephone_1);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@tel_2", Telephone_2);

                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@ol_cmb", OLSts);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@ol_desc", OlDesc);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@al_cmb", ALSts);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@al_desc", ALDesc);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@other_cmb", OtherSts);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@other_desc", OtherDesc);

                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@etf_epf_no", ETF_EPF_No);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@designation", Designation);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@dep", Department);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@appointment_date", AppointmentDate);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@status", EmpStatus);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@duration", Duration);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@description", Description);
                InsertEmployeePersonalInfoAndOtherDetails.Parameters.Add("@driver_allocated_sts", DriverAllocatedStatus);

                InsertEmployeePersonalInfoAndOtherDetails.ExecuteNonQuery();
                InsertEmployeePersonalInfoAndOtherDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedEmployeeDetailsByNicNumber(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] selectedEmployeeDetails = new string[30];
            SqlCeCommand GetSelectedEmployeeDetails = new SqlCeCommand("select * from employee_deetails where nic_no = '" + NicNumber + "'" ,conn);
            SqlCeDataReader RecivedEmployeeDetails = GetSelectedEmployeeDetails.ExecuteReader();

            while (RecivedEmployeeDetails.Read())
            {
                selectedEmployeeDetails[0] = RecivedEmployeeDetails[0].ToString();
                selectedEmployeeDetails[1] = RecivedEmployeeDetails[1].ToString();
                selectedEmployeeDetails[2] = RecivedEmployeeDetails[2].ToString();
                selectedEmployeeDetails[3] = RecivedEmployeeDetails[3].ToString();
                selectedEmployeeDetails[4] = RecivedEmployeeDetails[4].ToString();
                selectedEmployeeDetails[5] = RecivedEmployeeDetails[5].ToString();
                selectedEmployeeDetails[6] = RecivedEmployeeDetails[6].ToString();
                selectedEmployeeDetails[7] = RecivedEmployeeDetails[7].ToString();
                selectedEmployeeDetails[8] = RecivedEmployeeDetails[8].ToString();
                selectedEmployeeDetails[9] = RecivedEmployeeDetails[9].ToString();
                selectedEmployeeDetails[10] = RecivedEmployeeDetails[10].ToString();
                selectedEmployeeDetails[11] = RecivedEmployeeDetails[11].ToString();
                selectedEmployeeDetails[12] = RecivedEmployeeDetails[12].ToString();
                selectedEmployeeDetails[13] = RecivedEmployeeDetails[13].ToString();
                selectedEmployeeDetails[14] = RecivedEmployeeDetails[14].ToString();
                selectedEmployeeDetails[15] = RecivedEmployeeDetails[15].ToString();
                selectedEmployeeDetails[16] = RecivedEmployeeDetails[16].ToString();
                selectedEmployeeDetails[17] = RecivedEmployeeDetails[17].ToString();
                selectedEmployeeDetails[18] = RecivedEmployeeDetails[18].ToString();
                selectedEmployeeDetails[19] = RecivedEmployeeDetails[19].ToString();
                selectedEmployeeDetails[20] = RecivedEmployeeDetails[20].ToString();
                selectedEmployeeDetails[21] = RecivedEmployeeDetails[21].ToString();
                selectedEmployeeDetails[22] = RecivedEmployeeDetails[22].ToString();
                selectedEmployeeDetails[23] = RecivedEmployeeDetails[23].ToString();
            }

            return selectedEmployeeDetails;
        }

        internal bool UpdatingEmployeePersonalInfoAndWorkingExp(string NicNumber, string NameInitials, string Name, string FullName, DateTime BirthDate, string PermenentAddress, string CommunicationAddress, string EmailAddress, string Telephone_1, string Telephone_2, string OLSts, string OlDesc, string ALSts, string ALDesc, string OtherSts, string OtherDesc, string ETF_EPF_No, string Designation, string Department, DateTime AppointmentDate, string EmpStatus, int Duration, string Description,string DriverAllocatedStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdatingEmployeeDetails = new SqlCeCommand("update employee_deetails set full_name = '" + FullName + "',b_date = '" + BirthDate + "',permenent_addr = '" + PermenentAddress + "',communication_addr = '" + CommunicationAddress + "',email_addr = '" + EmailAddress + "',tel_1 = '" + Telephone_1 + "',tel_2 = '" + Telephone_2 + "',ol_cmb = '" + OLSts + "',ol_desc = '" + OlDesc + "',al_cmb = '" + ALSts + "',al_desc = '" + ALDesc + "',other_cmb = '" + OtherSts + "',other_desc = '" + OtherDesc + "',etf_epf_no = '" + ETF_EPF_No + "',designation = '" + Designation + "',dep = '" + Department + "',appointment_date = '" + AppointmentDate + "',status = '" + EmpStatus + "',duration = '" + Duration + "',description = '" + Description + "',name = '" + Name + "',driver_allocated_sts = '" + DriverAllocatedStatus + "' where nic_no = '" + NicNumber + "'", conn);

                UpdatingEmployeeDetails.ExecuteNonQuery();
                UpdatingEmployeeDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal void DeletegEmployeePersonalInfoAndWorkingExp(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand DeleteEmployeeDetails = new SqlCeCommand("delete from employee_deetails where nic_no = '" + NicNumber + "'" ,conn);

            DeleteEmployeeDetails.ExecuteNonQuery();
            DeleteEmployeeDetails.Dispose();
        }

        internal int GetDatabaseTableRecordCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int RecordCount = 0;
            SqlCeCommand GetDatabaseTableRecordCount = new SqlCeCommand("select count(*) from employee_deetails", conn);
            SqlCeDataReader DatabaseTableRecordCount = GetDatabaseTableRecordCount.ExecuteReader();

            while (DatabaseTableRecordCount.Read())
            {
                RecordCount = Convert.ToInt32(DatabaseTableRecordCount[0].ToString());
            }

            return RecordCount;
        }

        internal string[] GetSelectedEmployeeDetailsByETF_EPF_Number(string ETF_EPF_NO)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] selectedEmployeeDetails = new string[30];
            SqlCeCommand GetSelectedEmployeeDetails = new SqlCeCommand("select * from employee_deetails where etf_epf_no = '" + ETF_EPF_NO + "'", conn);
            SqlCeDataReader RecivedEmployeeDetails = GetSelectedEmployeeDetails.ExecuteReader();

            while (RecivedEmployeeDetails.Read())
            {
                selectedEmployeeDetails[0] = RecivedEmployeeDetails[0].ToString();
                selectedEmployeeDetails[1] = RecivedEmployeeDetails[1].ToString();
                selectedEmployeeDetails[2] = RecivedEmployeeDetails[2].ToString();
                selectedEmployeeDetails[3] = RecivedEmployeeDetails[3].ToString();
                selectedEmployeeDetails[4] = RecivedEmployeeDetails[4].ToString();
                selectedEmployeeDetails[5] = RecivedEmployeeDetails[5].ToString();
                selectedEmployeeDetails[6] = RecivedEmployeeDetails[6].ToString();
                selectedEmployeeDetails[7] = RecivedEmployeeDetails[7].ToString();
                selectedEmployeeDetails[8] = RecivedEmployeeDetails[8].ToString();
                selectedEmployeeDetails[9] = RecivedEmployeeDetails[9].ToString();
                selectedEmployeeDetails[10] = RecivedEmployeeDetails[10].ToString();
                selectedEmployeeDetails[11] = RecivedEmployeeDetails[11].ToString();
                selectedEmployeeDetails[12] = RecivedEmployeeDetails[12].ToString();
                selectedEmployeeDetails[13] = RecivedEmployeeDetails[13].ToString();
                selectedEmployeeDetails[14] = RecivedEmployeeDetails[14].ToString();
                selectedEmployeeDetails[15] = RecivedEmployeeDetails[15].ToString();
                selectedEmployeeDetails[16] = RecivedEmployeeDetails[16].ToString();
                selectedEmployeeDetails[17] = RecivedEmployeeDetails[17].ToString();
                selectedEmployeeDetails[18] = RecivedEmployeeDetails[18].ToString();
                selectedEmployeeDetails[19] = RecivedEmployeeDetails[19].ToString();
                selectedEmployeeDetails[20] = RecivedEmployeeDetails[20].ToString();
                selectedEmployeeDetails[21] = RecivedEmployeeDetails[21].ToString();
                selectedEmployeeDetails[22] = RecivedEmployeeDetails[22].ToString();
                selectedEmployeeDetails[23] = RecivedEmployeeDetails[23].ToString();
            }

            return selectedEmployeeDetails;
        }

        internal string[] GetEmployeeDesignations()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableEmployeeDesignations = new string[20];
            SqlCeCommand GetAllEmployeeDesignations = new SqlCeCommand("select name from designation_details where status = 'Active'" ,conn);
            SqlCeDataReader GetAvailableDesignationDetails = GetAllEmployeeDesignations.ExecuteReader();

            int x = 0;
            while (GetAvailableDesignationDetails.Read())
            {
                AvailableEmployeeDesignations[x] = GetAvailableDesignationDetails[0].ToString();
                x++;
            }

            return AvailableEmployeeDesignations;
        }
    }
}
