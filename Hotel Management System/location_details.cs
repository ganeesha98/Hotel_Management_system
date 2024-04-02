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
    public partial class location_details : UserControl
    {
        public location_details()
        {
            InitializeComponent();
        }

        custormer_details CustormerFormObj = new custormer_details();
        DatabaseConnectionForManageLocations db_obj = new DatabaseConnectionForManageLocations();

        private void SelectCategoryType(string LocationCategory)
        {
            if (LocationCategory == "Room")
            {
                categoryType_cmb.Items.Clear();

                categoryType_cmb.Items.Add("Single");
                categoryType_cmb.Items.Add("Double");
            }
            else if (LocationCategory == "Swimpool" || LocationCategory == "Playground")
            {
                categoryType_cmb.Items.Clear();

                categoryType_cmb.Items.Add("Adults");
                categoryType_cmb.Items.Add("Kids");
            }
            else
            {
                categoryType_cmb.Items.Clear();

                categoryType_cmb.Items.Add("None");
            }
        }

        public bool CheckValues(string value)
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

        public bool CheckIntegerVal(string value)
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

        private void RegisterLocationDetails_btn_Click(object sender, EventArgs e)
        {
            //LocationDetails
            string LocationNo = LocationNo_txt.Text;
            string LocationCategory = LocationCategory_cmb.Text;
            string CategoryType = categoryType_cmb.Text;
            string MaxPersons = MaxPersonsForLocation_txt.Text;
            string LocationPrice = priceForLocation_txt.Text;
            string LocationStatus = LocationSts_cmb.Text;

            //LocationMaintainance Details
            string MaintainaceType = maintain_type.Text;
            DateTime AllocatedDate = allocatedDate_dtpick.Value;
            DateTime DueDate = dueDate_dtpick.Value;
            string MaintainDays = DaysCount_txt.Text;
            string Description = Description_txt.Text;
            string MaintainStatus = maintainSts_cmb.Text;

            if (CheckValues(LocationNo) == true && CheckValues(LocationCategory) == true && CheckValues(CategoryType) == true && CheckValues(MaxPersons) == true && CheckValues(LocationPrice) == true && CheckValues(LocationStatus) == true)
            {
                if (CheckIntegerVal(MaxPersons) == true && CheckIntegerVal(LocationPrice) == true)
                {
                    if (db_obj.RegisterLocationDetails(LocationNo, LocationCategory, CategoryType, MaxPersons, LocationPrice, LocationStatus, MaintainaceType, AllocatedDate, DueDate, MaintainStatus, Description,MaintainDays) == true)
                    {
                        GetTableRecordNumbers();
                        ResetAllFeilds();
                        MessageBox.Show("Location Register Sucessfully...", "Register New Location...");
                    }
                    else
                    {
                        MessageBox.Show("Error Occured While Registering Location...", "Connection Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Number Format...Please Check Your Numeric Values...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Feilds Found...Please Check Your Feilds...", "Empty Or Null Values...");
            }
        }

        private void SearchLocationDetails_btn_Click(object sender, EventArgs e)
        {
            //LocationCategory_cmb.Enabled = false;
            //categoryType_cmb.Enabled = false;

            string LocationNumber = LocationNo_txt.Text;

            if (CheckValues(LocationNumber) == true)
            {
                string[] LocationDetails = db_obj.GetSelectedLocationDetails(LocationNumber);

                if (LocationDetails[0] == null)
                {
                    MessageBox.Show("There Are No Location Registred For That LocationID", "Invalid Location Number");
                }
                else
                {
                    LocationNo_txt.Enabled = false;
                    RegisterLocationDetails_btn.Enabled = false;
                    UpdateLocationdetails_btn.Enabled = true;
                    DeleteLocationDetails_btn.Enabled = true;

                    LocationCategory_cmb.Text = LocationDetails[2];
                    categoryType_cmb.Text = LocationDetails[3];
                    MaxPersonsForLocation_txt.Text = LocationDetails[4];
                    priceForLocation_txt.Text = LocationDetails[6];
                    LocationSts_cmb.Text = LocationDetails[5];

                    maintain_type.Text = LocationDetails[7];
                    allocatedDate_dtpick.Value = Convert.ToDateTime(LocationDetails[8]);
                    dueDate_dtpick.Value = Convert.ToDateTime(LocationDetails[9]);
                    Description_txt.Text = LocationDetails[11];
                    DaysCount_txt.Text = LocationDetails[12];
                    maintainSts_cmb.Text = LocationDetails[10];
                }
            }
            else
            {
                MessageBox.Show("Plase Enter LocationNumber Before Search Location Details....", "Empty Or Null Location Number");
            }
        }

        private void UpdateLocationdetails_btn_Click(object sender, EventArgs e)
        {
            string LocationNumber = LocationNo_txt.Text;
            string LocationCategory = LocationCategory_cmb.Text;
            string CategoryType = categoryType_cmb.Text;
            string MaxPersons = MaxPersonsForLocation_txt.Text;
            string LocationPrice = priceForLocation_txt.Text;
            string LocationStatus = LocationSts_cmb.Text;

            //LocationMaintainance Details
            string MaintainaceType = maintain_type.Text;
            DateTime AllocatedDate = allocatedDate_dtpick.Value;
            DateTime DueDate = dueDate_dtpick.Value;
            string Description = Description_txt.Text;
            string MaintainDays = DaysCount_txt.Text;
            string MaintainStatus = maintainSts_cmb.Text;

            if (db_obj.UpdateLocationDetails(LocationNumber, LocationCategory, CategoryType, MaxPersons, LocationPrice, LocationStatus, MaintainaceType, AllocatedDate, DueDate, MaintainStatus, Description,MaintainDays) == true)
            {
                ResetAllFeilds();
                MessageBox.Show("Location Details Updated Sucessfully...", "Location Details Update...");
            }
            else
            {
                MessageBox.Show("There Is Some Error Occured While Location Details Update....", "Database Or SQL Error...");
            }
        }

        private void DeleteLocationDetails_btn_Click(object sender, EventArgs e)
        {
            string LocationNumber = LocationNo_txt.Text;
            DialogResult DeleteLocation = MessageBox.Show("Are You Sure Want To delete This Location From The System ? ", "Location Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DeleteLocation == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedLocationDetails(LocationNumber) == true)
                {
                    MessageBox.Show("Location Details Deleted Sucessfully...", "Location Details Deletion...");
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Location Details Deletion....", "Database Or SQL Error...");
                }
            }
        }

        private void ResetAllFeilds()
        {
            LocationNo_txt.Enabled = true;
            UpdateLocationdetails_btn.Enabled = false;
            DeleteLocationDetails_btn.Enabled = false;
            RegisterLocationDetails_btn.Enabled = true;

            LocationNo_txt.Text = "";
            DaysCount_txt.Text = "";
            LocationCategory_cmb.SelectedIndex = -1;
            categoryType_cmb.Text = "";
            MaxPersonsForLocation_txt.Text = "";
            priceForLocation_txt.Text = "";
            LocationSts_cmb.SelectedIndex = -1;

            maintain_type.SelectedIndex = -1;
            allocatedDate_dtpick.Value = System.DateTime.Now;
            dueDate_dtpick.Value = System.DateTime.Now;
            Description_txt.Text = "";
            maintainSts_cmb.SelectedIndex = -1;
        }

        private void ResetFields_btn_Click(object sender, EventArgs e)
        {
            ResetAllFeilds();
        }

        private void LocationCategory_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCategoryType(LocationCategory_cmb.Text);
        }

        public int ReplaceNullOrEmptyInteger(string value)
        {
            int IntVal;

            try
            {
                IntVal = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                IntVal = 0;
            }

            return IntVal;
        }

        private void DaysCount_txt_TextChanged(object sender, EventArgs e)
        {
            string Days = DaysCount_txt.Text;
            dueDate_dtpick.Value = allocatedDate_dtpick.Value.AddDays(ReplaceNullOrEmptyInteger(Days));
        }

        private void allocatedDate_dtpick_ValueChanged(object sender, EventArgs e)
        {
            dueDate_dtpick.MinDate = allocatedDate_dtpick.Value;
        }

        private void GetTableRecordNumbers()
        {
            record_number_txt.Enabled = false;
            int TableRecordNumbersCount = db_obj.GetTableRecordNumbersCount();

            record_number_txt.Text = Convert.ToString(TableRecordNumbersCount);
        }

        private void location_details_Load(object sender, EventArgs e)
        {
            allocatedDate_dtpick.Value = System.DateTime.Now;
            dueDate_dtpick.Value = System.DateTime.Now;
            UpdateLocationdetails_btn.Enabled = false;
            DeleteLocationDetails_btn.Enabled = false;
            GetTableRecordNumbers();
        }

        private void MaxPersonsForLocation_txt_TextChanged(object sender, EventArgs e)
        {
            int GetMaxPersonsTxt = ReplaceNullOrEmptyInteger(MaxPersonsForLocation_txt.Text);
            string SelectedLocationCategory = LocationCategory_cmb.Text;
            string SelectedLocationType = categoryType_cmb.Text;

            if (SelectedLocationCategory == "Room" && SelectedLocationType == "Single")
            {
                if (GetMaxPersonsTxt > 2)
                {
                    MessageBox.Show("This Location Has Less Than 2 Maximum Persons...", "Invalid Maximum Pesons...");
                    MaxPersonsForLocation_txt.Text = "";
                }
            }
            else
            {
                if (GetMaxPersonsTxt > 20)
                {
                    MessageBox.Show("This Location Has Less Than 20 Maximum Persons...", "Invalid Maximum Pesons...");
                    MaxPersonsForLocation_txt.Text = "";
                }
            }
        }

        private void maintain_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string GetSelectedMaintainType = maintain_type.Text;

            if (GetSelectedMaintainType == "None")
            {
                DaysCount_txt.Text = "";
                allocatedDate_dtpick.Enabled = false;
                dueDate_dtpick.Enabled = false;
                DaysCount_txt.Enabled = false;
                Description_txt.Enabled = false;

                maintainSts_cmb.SelectedIndex = 1;
                LocationSts_cmb.SelectedIndex = 0;
            }
            else
            {
                LocationSts_cmb.SelectedIndex = 1;
                maintainSts_cmb.SelectedIndex = 0;

                allocatedDate_dtpick.Enabled = true;
                dueDate_dtpick.Enabled = true;
                DaysCount_txt.Enabled = true;
                Description_txt.Enabled = true;
            }
        }
    }
}
