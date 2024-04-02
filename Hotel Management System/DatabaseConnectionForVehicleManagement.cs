using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForVehicleManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);
        //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\exam.NITC\Desktop\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");
        
        internal bool RegisterVehicleDetails(string VehicleNo, string VehicleType, string NoOfSetas, DateTime LishionExpDate, DateTime InsuaranceExpDate, string VehicleStatus, string DriverNo, string FullName, string Telephone01, string Telephone02, string Price, string MaintainType, DateTime AllocatedDate, DateTime DueDate, string Status,string MainStatus, string Description,string DriverAllocatedStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand InsertVehicleDetailsAndDriverDetails = new SqlCeCommand("insert into vehicle_details (vec_no,type,no_of_seats,lision_exp_date,insuarance_exp_date,vec_status,driver_no,name_with_ini,tel_1,tel_2,price) values (@vec_no,@type,@no_of_seats,@lision_exp_date,@insuarance_exp_date,@vec_status,@driver_no,@name_with_ini,@tel_1,@tel_2,@price)", conn);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@vec_no", VehicleNo);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@type", VehicleType);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@no_of_seats", NoOfSetas);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@lision_exp_date", LishionExpDate);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@insuarance_exp_date", InsuaranceExpDate);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@vec_status", Status);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@driver_no", DriverNo);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@name_with_ini", FullName);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@tel_1", Telephone01);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@tel_2", Telephone02);
                InsertVehicleDetailsAndDriverDetails.Parameters.Add("@price", Price);

                InsertVehicleDetailsAndDriverDetails.ExecuteNonQuery();
                InsertVehicleDetailsAndDriverDetails.Dispose();

                SqlCeCommand InsertMaintainDetails = new SqlCeCommand("insert into maintain_details (no,type,allocated_date,due_date,status,description) values (@no,@type,@allocated_date,@due_date,@status,@description)", conn);
                InsertMaintainDetails.Parameters.Add("@no", VehicleNo);
                InsertMaintainDetails.Parameters.Add("@type", MaintainType);
                InsertMaintainDetails.Parameters.Add("@allocated_date", AllocatedDate);
                InsertMaintainDetails.Parameters.Add("@due_date", DueDate);
                InsertMaintainDetails.Parameters.Add("@status", MainStatus);
                InsertMaintainDetails.Parameters.Add("@description", Description);

                InsertMaintainDetails.ExecuteNonQuery();
                InsertMaintainDetails.Dispose();

                SqlCeCommand UpdateDriverAllocatedStatus = new SqlCeCommand("update employee_deetails set driver_allocated_sts = '" + DriverAllocatedStatus+ "' where etf_epf_no = '" + DriverNo + "'", conn);
                UpdateDriverAllocatedStatus.ExecuteNonQuery();
                UpdateDriverAllocatedStatus.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string[] GetSelectedVehicleDetails(string VehicleNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] VehicleDetails = new string[30];
            SqlCeCommand GetSelectedVehicleDetails = new SqlCeCommand("select * from vehicle_details where vec_no = '" + VehicleNo + "'", conn);
            SqlCeDataReader SelectedVehicleDetails = GetSelectedVehicleDetails.ExecuteReader();

            while (SelectedVehicleDetails.Read())
            {
                VehicleDetails[0] = SelectedVehicleDetails[0].ToString();
                VehicleDetails[1] = SelectedVehicleDetails[1].ToString();
                VehicleDetails[2] = SelectedVehicleDetails[2].ToString();
                VehicleDetails[3] = SelectedVehicleDetails[3].ToString();
                VehicleDetails[4] = SelectedVehicleDetails[4].ToString();
                VehicleDetails[5] = SelectedVehicleDetails[5].ToString();
                VehicleDetails[6] = SelectedVehicleDetails[6].ToString();
                VehicleDetails[7] = SelectedVehicleDetails[7].ToString();
                VehicleDetails[8] = SelectedVehicleDetails[8].ToString();
                VehicleDetails[9] = SelectedVehicleDetails[9].ToString();
                VehicleDetails[10] = SelectedVehicleDetails[10].ToString();
                VehicleDetails[11] = SelectedVehicleDetails[11].ToString();
            }

            GetSelectedVehicleDetails.Dispose();
            SelectedVehicleDetails.Dispose();

            SqlCeCommand GetSelectedVehicleMaintainDetails = new SqlCeCommand("select * from maintain_details where no = '" + VehicleNo + "'", conn);
            SqlCeDataReader SelectedVehicleMaintaindetails = GetSelectedVehicleMaintainDetails.ExecuteReader();

            while (SelectedVehicleMaintaindetails.Read())
            {
                VehicleDetails[12] = SelectedVehicleMaintaindetails[0].ToString();
                VehicleDetails[13] = SelectedVehicleMaintaindetails[1].ToString();
                VehicleDetails[14] = SelectedVehicleMaintaindetails[2].ToString();
                VehicleDetails[15] = SelectedVehicleMaintaindetails[3].ToString();
                VehicleDetails[16] = SelectedVehicleMaintaindetails[4].ToString();
                VehicleDetails[17] = SelectedVehicleMaintaindetails[5].ToString();
            }

            return VehicleDetails;
        }

        internal bool UpdateVehicleDetails(string VehicleNo, string VehicleType, string NoOfSetas, DateTime LishionExpDate, DateTime InsuaranceExpDate, string VehicleStatus, string DriverNo, string FullName, string Telephone01, string Telephone02, string Price, string MaintainType, DateTime AllocatedDate, DateTime DueDate, string Status, string MainStatus, string Description,string DriverAllocatedStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedVehicleDetails = new SqlCeCommand("update vehicle_details set type = '" + VehicleType + "',no_of_seats = '" + NoOfSetas + "',lision_exp_date = '" + LishionExpDate + "',insuarance_exp_date = '" + InsuaranceExpDate + "',vec_status = '" + VehicleStatus + "',driver_no = '" + DriverNo + "',name_with_ini = '" + FullName + "',tel_1 = '" + Telephone01 + "',tel_2 = '" + Telephone02 + "',price = '" + Price + "' where vec_no = '" + VehicleNo + "'", conn);
                UpdateSelectedVehicleDetails.ExecuteNonQuery();
                UpdateSelectedVehicleDetails.Dispose();

                SqlCeCommand UpdateMaintainDetails = new SqlCeCommand("update maintain_details set type = '" + MaintainType + "',allocated_date = '" + AllocatedDate + "',due_date = '" + DueDate + "',status = '" + MainStatus + "',description = '" + Description + "' where no = '" + VehicleNo + "'", conn);
                UpdateMaintainDetails.ExecuteNonQuery();
                UpdateMaintainDetails.Dispose();

                SqlCeCommand UpdateDriverAllocatedStatus = new SqlCeCommand("update employee_deetails set driver_allocated_sts = '" + DriverAllocatedStatus + "' where etf_epf_no = '" + DriverNo + "'", conn);
                UpdateDriverAllocatedStatus.ExecuteNonQuery();
                UpdateDriverAllocatedStatus.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool DeleteSelectedVehicleDetails(string VehicleNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedVehicleDetails = new SqlCeCommand("delete from vehicle_details where vec_no = '" + VehicleNo + "'", conn);
                DeleteSelectedVehicleDetails.ExecuteNonQuery();
                DeleteSelectedVehicleDetails.Dispose();

                SqlCeCommand DeleteSelectedVehicleMaintainDetails = new SqlCeCommand("delete from maintain_details where no = '" + VehicleNo + "'", conn);
                DeleteSelectedVehicleMaintainDetails.ExecuteNonQuery();
                DeleteSelectedVehicleMaintainDetails.Dispose();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string GetTableRecordCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string TableRecordCount = "";
            SqlCeCommand GetTableRecordCount = new SqlCeCommand("select count(*) from vehicle_details", conn);
            SqlCeDataReader SelectedTableRecordCount = GetTableRecordCount.ExecuteReader();

            while (SelectedTableRecordCount.Read())
            {
                TableRecordCount = SelectedTableRecordCount[0].ToString();
            }

            return TableRecordCount;
        }

        internal string[] GetAvailableDriverDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableDriverDetails = new string[20];
            SqlCeCommand GetAvailableDriverDetails = new SqlCeCommand("select etf_epf_no from employee_deetails where driver_allocated_sts = 'no'", conn);
            SqlCeDataReader SelectedAvailableDriverDetails = GetAvailableDriverDetails.ExecuteReader();

            int x=0;
            while (SelectedAvailableDriverDetails.Read())
            {
                AvailableDriverDetails[x] = SelectedAvailableDriverDetails[0].ToString();
                x++;
            }

            return AvailableDriverDetails;
        }

        internal string[] GetSelectedDriverDetails(string GetSelectedDriverNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] DriverDetails = new string[50];
            SqlCeCommand GetSelectedDriverDetails = new SqlCeCommand("select full_name,tel_1,tel_2 from employee_deetails where etf_epf_no = '" + GetSelectedDriverNumber + "'", conn);
            SqlCeDataReader SelectedDriverDetails = GetSelectedDriverDetails.ExecuteReader();

            while (SelectedDriverDetails.Read())
            {
                DriverDetails[0] = SelectedDriverDetails[0].ToString();
                DriverDetails[1] = SelectedDriverDetails[1].ToString();
                DriverDetails[2] = SelectedDriverDetails[2].ToString();
            }

            return DriverDetails;
        }
    }
}
