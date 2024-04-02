using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class vehicle_details : UserControl
    {
        public vehicle_details()
        {
            InitializeComponent();
        }

        location_details LocationDetailsFormObj = new location_details();
        DatabaseConnectionForVehicleManagement db_obj = new DatabaseConnectionForVehicleManagement();

        private bool ChkValues(string value)
        {
            if (value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ChkInt(string value)
        {
            int GetVal;

            try
            {
                GetVal = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void RegisterVehicle_btn_Click(object sender, EventArgs e)
        {
            string VehicleNo = VehicleNo_txt.Text;
            string VehicleType = VehicleType_cmb.Text;
            string NoOfSetas = Seats_txt.Text;

            DateTime GetLishionExpDate = Convert.ToDateTime(LishionExp_dtpick.Value);
            DateTime LishionExpDate = GetLishionExpDate.Date;

            DateTime GetInsuaranceExpDate = Convert.ToDateTime(InsuarnceExp_dtpick.Value);
            DateTime InsuaranceExpDate = GetInsuaranceExpDate.Date;

            string VehicleStatus = Status_cmb.Text;

            string DriverNo = DriverNo_cmb.Text;
            string FullName = name_txt.Text;
            string Telephone01 = Tel_01_txt.Text;
            string Telephone02 = Tel_02_txt.Text;
            string Price = VehiclePrice_txt.Text;
            string Status = Status_cmb.Text;

            //maintai details
            string MaintainType = MaintainType_cmb.Text;

            DateTime GetAllocatedDate = Convert.ToDateTime(AllocatedDate_dtpick.Value);
            DateTime AllocatedDate = GetAllocatedDate.Date;

            DateTime GetDueDate = Convert.ToDateTime(DueDate_dtpick.Value);
            DateTime DueDate = GetDueDate.Date;

            string MainStatus = MaintainStatus_cmb.Text;
            string Description = Description_txt.Text;

            if (ChkValues(VehicleNo) == true && ChkValues(VehicleType) == true && ChkValues(NoOfSetas) == true && ChkValues(MaintainType) == true && ChkValues(Price) == true)
            {
                if (ChkInt(NoOfSetas) == true && ChkInt(Price))
                {
                    string AllocatedStatus = "yes";
                    if (db_obj.RegisterVehicleDetails(VehicleNo, VehicleType, NoOfSetas, LishionExpDate, InsuaranceExpDate, VehicleStatus, DriverNo, FullName, Telephone01, Telephone02, Price, MaintainType, AllocatedDate, DueDate, Status, MainStatus, Description,AllocatedStatus) == true)
                    {
                        GetTableRecordCount();
                        ResetVehicleDetails();
                        MessageBox.Show("Vehicle Details Registering Sucessfully...", "Vehicle Details Registering...");
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Registering Vehicle Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Numeric Values...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Required Feilds Before Registering Vehicle Details...", "Empty Or Null feilds Found...");
            }
        }

        private void SearchVehicle_btn_Click(object sender, EventArgs e)
        {
            string VehicleNo = VehicleNo_txt.Text;

            if (ChkValues(VehicleNo) == true)
            {
                string[] SelectedVehicleDetails = db_obj.GetSelectedVehicleDetails(VehicleNo);

                if (SelectedVehicleDetails[0] == null)
                {
                    MessageBox.Show("There Is No Vehicle Details For That Vehicle Number...", "Invalid Vehicle Number...");
                }
                else
                {
                    name_txt.Enabled = false;
                    Tel_01_txt.Enabled = false;
                    Tel_02_txt.Enabled = false;
                    VehicleNo_txt.Enabled = false;
                    RegisterVehicle_btn.Enabled = false;
                    UpdateVehicle_btn.Enabled = true;
                    DeleteVehicle_btn.Enabled = true;

                    VehicleType_cmb.Text = SelectedVehicleDetails[1];
                    Seats_txt.Text = SelectedVehicleDetails[2];

                    string h = Convert.ToDateTime(SelectedVehicleDetails[3]).ToString("dd/MM/yyyy");
                    LishionExp_dtpick.Text = h;

                    string u = Convert.ToDateTime(SelectedVehicleDetails[4]).ToString("dd/MM/yyyy");
                    InsuarnceExp_dtpick.Text = u;

                    Status_cmb.Text = SelectedVehicleDetails[5];

                    DriverNo_cmb.Items.Add(SelectedVehicleDetails[6]);
                    DriverNo_cmb.Text = SelectedVehicleDetails[6];
                    //name_txt.Text = SelectedVehicleDetails[7];
                    //Tel_01_txt.Text = SelectedVehicleDetails[8];
                    //Tel_02_txt.Text = SelectedVehicleDetails[9];

                    VehiclePrice_txt.Text = SelectedVehicleDetails[10];

                    MaintainType_cmb.Text = SelectedVehicleDetails[13];

                    string j = Convert.ToDateTime(SelectedVehicleDetails[14]).ToString("dd/MM/yyyy");
                    AllocatedDate_dtpick.Text = j;

                    string p = Convert.ToDateTime(SelectedVehicleDetails[15]).ToString("dd/MM/yyyy");
                    DueDate_dtpick.Text = p;

                    MaintainStatus_cmb.Text = SelectedVehicleDetails[16];
                    Description_txt.Text = SelectedVehicleDetails[17];
                }
            }
            else
            {
                MessageBox.Show("Please Enter Vehicle Number Before Search Vehicle Details...", "Empty Or Null Feilds...");
            }
        }

        private void UpdateVehicle_btn_Click(object sender, EventArgs e)
        {
            string VehicleNo = VehicleNo_txt.Text;
            string VehicleType = VehicleType_cmb.Text;
            string NoOfSetas = Seats_txt.Text;
            DateTime LishionExpDate = Convert.ToDateTime(LishionExp_dtpick.Value);
            DateTime InsuaranceExpDate = Convert.ToDateTime(InsuarnceExp_dtpick.Value);
            string VehicleStatus = Status_cmb.Text;

            string DriverNo = DriverNo_cmb.Text;
            string FullName = name_txt.Text;
            string Telephone01 = Tel_01_txt.Text;
            string Telephone02 = Tel_02_txt.Text;
            string Price = VehiclePrice_txt.Text;
            string Status = Status_cmb.Text;

            //maintai details
            string MaintainType = MaintainType_cmb.Text;
            DateTime AllocatedDate = Convert.ToDateTime(AllocatedDate_dtpick.Value);
            DateTime DueDate = Convert.ToDateTime(DueDate_dtpick.Value);
            string MainStatus = MaintainStatus_cmb.Text;
            string Description = Description_txt.Text;

            string DriverAllocatedStatus = "yes";

            if (ChkValues(VehicleType) == true && ChkValues(NoOfSetas) == true && ChkValues(MaintainType) == true && ChkValues(Price) == true)
            {
                if (ChkInt(NoOfSetas) == true && ChkInt(Price))
                {
                    if (db_obj.UpdateVehicleDetails(VehicleNo, VehicleType, NoOfSetas, LishionExpDate, InsuaranceExpDate, VehicleStatus, DriverNo, FullName, Telephone01, Telephone02, Price, MaintainType, AllocatedDate, DueDate, Status, MainStatus, Description, DriverAllocatedStatus) == true)
                    {
                        ResetVehicleDetails();
                        MessageBox.Show("Vehicle Details Update Sucessfully...", "Vehicle Details Update...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Numeric Values...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Required Feilds Before Registering Vehicle Details...", "Empty Or Null feilds Found...");
            }
        }

        private void DeleteVehicle_btn_Click(object sender, EventArgs e)
        {
            string VehicleNo = VehicleNo_txt.Text;

            DialogResult DeleteSelectedVehicleDetials = MessageBox.Show("Are You Sure Want To Delete This Details From The System ? ", "Delete Vehicle Details...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DeleteSelectedVehicleDetials == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedVehicleDetails(VehicleNo) == true)
                {
                    GetTableRecordCount();
                    ResetVehicleDetails();
                    MessageBox.Show("Vehicle Details Deletion Sucessfully...", "Vehicle Details Deletion...");
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Deletion...", "Database Or SQL Error...");
                }
            }
        }

        private void ResetVehicleDetails()
        {
            RegisterVehicle_btn.Enabled = true;
            SearchVehicle_btn.Enabled = true;
            UpdateVehicle_btn.Enabled = false;
            DeleteVehicle_btn.Enabled = false;

            VehicleNo_txt.Enabled = true;
            VehicleNo_txt.Text = "";
            VehicleType_cmb.Text = null;
            Seats_txt.Text = "";
            //LishionExp_dtpick.Value = System.DateTime.Now;
            //InsuarnceExp_dtpick.Value = System.DateTime.Now;
            Status_cmb.Text = null;

            DriverNo_cmb.Enabled = true;
            DriverNo_cmb.Text = null;
            name_txt.Text = "";
            Tel_01_txt.Text = "";
            Tel_02_txt.Text = "";
            VehiclePrice_txt.Text = "";

            MaintainType_cmb.Text = null;
            AllocatedDate_dtpick.Value = System.DateTime.Now;
            DueDate_dtpick.Value = System.DateTime.Now;
            MaintainStatus_cmb.Text = null;
            Description_txt.Text = "";
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            ResetVehicleDetails();
        }

        private void MaintainDays_txt_TextChanged(object sender, EventArgs e)
        {
            string Days = MaintainDays_txt.Text;
            DueDate_dtpick.Value = AllocatedDate_dtpick.Value.AddDays(LocationDetailsFormObj.ReplaceNullOrEmptyInteger(Days));
        }

        private void AllocatedDate_dtpick_ValueChanged(object sender, EventArgs e)
        {
            DueDate_dtpick.MinDate = AllocatedDate_dtpick.Value;
        }

        private void GetTableRecordCount()
        {
            record_no_txt.Enabled = false;
            record_no_txt.Text = db_obj.GetTableRecordCount();
        }

        public void GetAvailableDriverDetails()
        {
            DriverNo_cmb.Items.Clear();
            string[] AvailableDriverDetails = db_obj.GetAvailableDriverDetails();

            for (int driver_no = 0; driver_no < AvailableDriverDetails.Length; driver_no++)
            {
                if (AvailableDriverDetails[driver_no] == null)
                {
                    break;
                }

                DriverNo_cmb.Items.Add(AvailableDriverDetails[driver_no]);
            }
        }

        private void vehicle_details_Load(object sender, EventArgs e)
        {
            GetAvailableDriverDetails();
            GetTableRecordCount();
            UpdateVehicle_btn.Enabled = false;
            DeleteVehicle_btn.Enabled = false;
            name_txt.Enabled = false;
            Tel_01_txt.Enabled = false;
            Tel_02_txt.Enabled = false;

            MaintainType_cmb.Enabled = false;
            MaintainStatus_cmb.Enabled = false;
            AllocatedDate_dtpick.Enabled = false;
            DueDate_dtpick.Enabled = false;
            Description_txt.Enabled = false;
            MaintainDays_txt.Enabled = false;

            LishionExp_dtpick.MinDate = System.DateTime.Now.AddDays(30);
            InsuarnceExp_dtpick.MinDate = System.DateTime.Now.AddDays(30);

            AllocatedDate_dtpick.MinDate = System.DateTime.Now;
            DueDate_dtpick.MinDate = System.DateTime.Now;
           
        }

        private void Seats_txt_TextChanged(object sender, EventArgs e)
        {
            int NoOfSeats = LocationDetailsFormObj.ReplaceNullOrEmptyInteger(Seats_txt.Text);
            string SelectedVehicleType = VehicleType_cmb.Text;

            if (SelectedVehicleType == "Car")
            {
                if(NoOfSeats > 2)
                {
                    MessageBox.Show("Please Enter Less Than 3 Seats For That Vehicle Type...", "Invalid Number Of Seats...");
                }
            }
            else if (SelectedVehicleType == "Van")
            {
                if (NoOfSeats > 15)
                {
                    MessageBox.Show("Please Enter Less Than 16 Seats For That Vehicle Type...", "Invalid Number Of Seats...");
                }
            }
            else
            {
                if (NoOfSeats > 10)
                {
                    MessageBox.Show("Please Enter Less Than 11 Seats For That Vehicle Type...", "Invalid Number Of Seats...");
                }
            }
        }

        private void Status_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string GetSelectedVecStatus = Status_cmb.Text;

            if (GetSelectedVecStatus == "Inactive")
            {
                MaintainType_cmb.Items.Remove("None");
                MaintainType_cmb.Enabled = true;
                MaintainStatus_cmb.SelectedIndex = 0;

                AllocatedDate_dtpick.Enabled = true;
                MaintainDays_txt.Enabled = true;
                DueDate_dtpick.Enabled = true;
                Description_txt.Enabled = true;
            }
            else
            {
                MaintainType_cmb.Items.Add("None");
                MaintainType_cmb.Text = "None";
                MaintainType_cmb.Enabled = false;
                AllocatedDate_dtpick.Enabled = false;
                MaintainDays_txt.Enabled = false;
                DueDate_dtpick.Enabled = false;
                Description_txt.Enabled = false;

                MaintainStatus_cmb.SelectedIndex = 1;
            }
        }

        private void MaintainDays_txt_TextChanged_1(object sender, EventArgs e)
        {
            int MaintainDaysCount = LocationDetailsFormObj.ReplaceNullOrEmptyInteger(MaintainDays_txt.Text);

            DueDate_dtpick.Value = AllocatedDate_dtpick.Value.AddDays(MaintainDaysCount);
        }

        private void DriverNo_cmb_Click(object sender, EventArgs e)
        {
            GetAvailableDriverDetails();
        }

        private void DriverNo_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string GetSelectedDriverNumber = DriverNo_cmb.Text;
            string[] GetSelectedDriverDetails = db_obj.GetSelectedDriverDetails(GetSelectedDriverNumber);

            name_txt.Text = GetSelectedDriverDetails[0];
            Tel_01_txt.Text = GetSelectedDriverDetails[1];
            Tel_02_txt.Text = GetSelectedDriverDetails[2];
        }
    }
}
