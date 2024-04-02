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
    public partial class employee_details : UserControl
    {
        public employee_details()
        {
            InitializeComponent();
        }

        vehicle_details j = new vehicle_details();
        DatabaseConnectionForEmployeeManagement db_obj = new DatabaseConnectionForEmployeeManagement();

        private bool CheckValues(string value)
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

        private bool CheckIntegerValues(string value)
        {
            int GetIntVal;

            try
            {
                GetIntVal = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private int ReplaceNullIntegerValues(string value)
        {
            int GetInt;

            try
            {
                GetInt = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                GetInt = 0;
            }

            return GetInt;
        }

        private void GettingEmployeePersonalInfoAndWorkingExp()
        {
            //personal info
            string NicNumber = nic_txt.Text;

            string NameInitials = name_ini_cmb.Text;
            string Name = name_txt.Text;
            string FullName = fullname_txt.Text;
            DateTime BirthDate = Convert.ToDateTime(bdate_dtpick.Value);
            string PermenentAddress = permenentaddr_txt.Text;
            string CommunicationAddress = communicationaddr_txt.Text;
            string EmailAddress = emailaddr_txt.Text;
            string Telephone_1 = tel1_txt.Text;
            string Telephone_2 = tel2_txt.Text;

            //educational qualifications
            string OLSts = olsts_cmb.Text;
            string OlDesc = oldesc_txt.Text;
            string ALSts = alsts_cmb.Text;
            string ALDesc = aldesc_txt.Text;
            string OtherSts = othersts_cmb.Text;
            string OtherDesc = otherdesc_txt.Text;

            //job details
            string ETF_EPF_No = etf_epf_txt.Text;
            string Designation = designation_cmb.Text;
            string Department = department_cmb.Text;
            DateTime AppointmentDate = Convert.ToDateTime(appointmentDate_dtpick.Value);
            string EmpStatus = empsts_cmb.Text;

            //working details
            int Duration = ReplaceNullIntegerValues(duration_txt.Text);
            string Description = Description_txt.Text;

            if (CheckValues(NicNumber) == true && CheckValues(name_ini_cmb.Text) == true && CheckValues(Name) == true && CheckValues(PermenentAddress) == true && CheckValues(EmailAddress) == true && CheckValues(Telephone_1) == true)
            {
                if ((CheckValues(OLSts) == true || CheckValues(ALSts) == true || CheckValues(OtherSts) == true) && (NicNumber.Length == 12 || NicNumber.Length == 9))
                {
                    if (db_obj.RegisterEmployeePersonalInfoAndWorkingExp(NicNumber, NameInitials, Name, FullName, BirthDate, PermenentAddress, CommunicationAddress, EmailAddress, Telephone_1, Telephone_2, OLSts, OlDesc, ALSts, ALDesc, OtherSts, OtherDesc, ETF_EPF_No, Designation, Department, AppointmentDate, EmpStatus, Duration, Description,DriverAllocatedStatus) == true)
                    {
                        j.GetAvailableDriverDetails();
                        GetRecordCountFormTable();
                        MessageBox.Show("Employe Registration Sucessfully...", "Employee Registration...");
                    }
                    else
                    {
                        MessageBox.Show("Error Occured While Employee Registration....", "Connection Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please All Required Feilds Must be Filled...", "Empty Or Null Values....");
                }
            }
            else
            {
                MessageBox.Show("Please All Required Feilds Must be Filled...", "Empty Or Null Values....");
            }
        }

        private void RegiterEmployeeDetails_btn_Click(object sender, EventArgs e)
        {
            GettingEmployeePersonalInfoAndWorkingExp();
            clear();
        }

        private void SetSelectedEmployeeDetails(string[] SelectedEmployeeDetails)
        {
            nic_txt.Text = SelectedEmployeeDetails[2];
            name_ini_cmb.Text = SelectedEmployeeDetails[22];
            name_txt.Text = SelectedEmployeeDetails[23];
            fullname_txt.Text = SelectedEmployeeDetails[1];
            bdate_dtpick.Value = Convert.ToDateTime(SelectedEmployeeDetails[3]);
            permenentaddr_txt.Text = SelectedEmployeeDetails[4];
            communicationaddr_txt.Text = SelectedEmployeeDetails[5];
            emailaddr_txt.Text = SelectedEmployeeDetails[6];
            tel1_txt.Text = SelectedEmployeeDetails[7];
            tel2_txt.Text = SelectedEmployeeDetails[8];
            olsts_cmb.Text = SelectedEmployeeDetails[9];
            oldesc_txt.Text = SelectedEmployeeDetails[10];
            alsts_cmb.Text = SelectedEmployeeDetails[11];
            aldesc_txt.Text = SelectedEmployeeDetails[12];
            othersts_cmb.Text = SelectedEmployeeDetails[13];
            otherdesc_txt.Text = SelectedEmployeeDetails[14];
            etf_epf_txt.Text = SelectedEmployeeDetails[15];
            designation_cmb.Text = SelectedEmployeeDetails[16];
            department_cmb.Text = SelectedEmployeeDetails[17];
            appointmentDate_dtpick.Value = Convert.ToDateTime(SelectedEmployeeDetails[18]);
            empsts_cmb.Text = SelectedEmployeeDetails[19];
            duration_txt.Text = SelectedEmployeeDetails[20];
            Description_txt.Text = SelectedEmployeeDetails[21];

        }

        private void SearchEmployeeDetails_btn_Click(object sender, EventArgs e)
        {

             nic_txt.Enabled = false;
                string[] SelectedEmployeeDetails = new string[30];
                string NicNumber = nic_txt.Text;
                string ETF_EPF_NO = etf_epf_txt.Text;

                if (CheckValues(NicNumber) == true)
                {
                    SelectedEmployeeDetails = db_obj.GetSelectedEmployeeDetailsByNicNumber(NicNumber);
                }
                else if (CheckValues(ETF_EPF_NO) == true)
                {
                    SelectedEmployeeDetails = db_obj.GetSelectedEmployeeDetailsByETF_EPF_Number(ETF_EPF_NO);
                }
                else
                {
                    MessageBox.Show("Please Enter NIC Number Or ETF/EPF Number Before Searching...", "Empty Or Null Unique ID...");
                }

                if (SelectedEmployeeDetails[0] == null)
                {
                    MessageBox.Show("There Is No Employee Register For That Unique ID Number..", "Invalid Employee ID...");
                }
                else
                {
                    RegiterEmployeeDetails_btn.Enabled = false;
                    UpdateEmployeeDetails_btn.Enabled = true;
                    DeleteEmployeeDetails_btn.Enabled = true;
                    SetSelectedEmployeeDetails(SelectedEmployeeDetails);
                }
           
        }

        private void UpdateEmployeeDetails_btn_Click(object sender, EventArgs e)
        {
            string NicNumber = nic_txt.Text;

            string NameInitials = name_ini_cmb.Text;
            string Name = name_txt.Text;
            string FullName = fullname_txt.Text;
            DateTime BirthDate = Convert.ToDateTime(bdate_dtpick.Value);
            string PermenentAddress = permenentaddr_txt.Text;
            string CommunicationAddress = communicationaddr_txt.Text;
            string EmailAddress = emailaddr_txt.Text;
            string Telephone_1 = tel1_txt.Text;
            string Telephone_2 = tel2_txt.Text;

            //educational qualifications
            string OLSts = olsts_cmb.Text;
            string OlDesc = oldesc_txt.Text;
            string ALSts = alsts_cmb.Text;
            string ALDesc = aldesc_txt.Text;
            string OtherSts = othersts_cmb.Text;
            string OtherDesc = otherdesc_txt.Text;

            //job details
            string ETF_EPF_No = etf_epf_txt.Text;
            string Designation = designation_cmb.Text;
            string Department = department_cmb.Text;
            DateTime AppointmentDate = Convert.ToDateTime(appointmentDate_dtpick.Value);
            string EmpStatus = empsts_cmb.Text;

            //working details
            int Duration = Convert.ToInt32(duration_txt.Text);
            string Description = Description_txt.Text;

            if (db_obj.UpdatingEmployeePersonalInfoAndWorkingExp(NicNumber, NameInitials, Name, FullName, BirthDate, PermenentAddress, CommunicationAddress, EmailAddress, Telephone_1, Telephone_2, OLSts, OlDesc, ALSts, ALDesc, OtherSts, OtherDesc, ETF_EPF_No, Designation, Department, AppointmentDate, EmpStatus, Duration, Description,DriverAllocatedStatus) == true)
            {
                MessageBox.Show("Employee Details Update Sucessfully...", "Employee Details Update...");
            }
            else
            {
                MessageBox.Show("There Is Some Error Occured While Employee Details Update", "Database Or SQL Error...");
            }
        }

        private void DeleteEmployeeDetails_btn_Click(object sender, EventArgs e)
        {
            string NicNumber = nic_txt.Text;

            DialogResult DeleteEmployee = MessageBox.Show("Are You Sure Want To Delete This Employee From The System ? ", "Employee Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DeleteEmployee == DialogResult.Yes)
            {
                db_obj.DeletegEmployeePersonalInfoAndWorkingExp(NicNumber);
            }
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            RegiterEmployeeDetails_btn.Enabled = true;
            UpdateEmployeeDetails_btn.Enabled = false;
            DeleteEmployeeDetails_btn.Enabled = false;
            nic_txt.Enabled = true;

            clear();
        }

        void clear()
       {
           nic_txt.Text = "";
           name_ini_cmb.SelectedIndex = -1;
           name_txt.Text = " ";
           fullname_txt.Text = " ";
           //bdate_dtpick.Value = System.DateTime.Now;
           permenentaddr_txt.Text = " ";
           communicationaddr_txt.Text = " ";
           emailaddr_txt.Text = " ";
           tel1_txt.Text = " ";
           tel2_txt.Text = " ";
           olsts_cmb.SelectedIndex = -1;
           oldesc_txt.Text = " ";
           alsts_cmb.SelectedIndex = -1;
           aldesc_txt.Text = " ";
           othersts_cmb.SelectedIndex = -1;
           otherdesc_txt.Text = " ";
           etf_epf_txt.Text = " ";
           designation_cmb.SelectedIndex = -1;
           department_cmb.SelectedIndex = -1;
           appointmentDate_dtpick.Value = System.DateTime.Now;
           empsts_cmb.SelectedIndex = -1;
           duration_txt.Text = " ";
           Description_txt.Text = " ";
        }

        private void GetRecordCountFormTable()
        {
            int databaseTableRecordCount = db_obj.GetDatabaseTableRecordCount();
            record_count_txt.Text = databaseTableRecordCount.ToString();
        }

        private void employee_details_Load(object sender, EventArgs e)
        {
            d_allocatedSts_lab.Enabled = false;
            DriverAllocatedSts.Enabled = false;

            bdate_dtpick.MaxDate = System.DateTime.Now;
            record_count_txt.Enabled = false;
            UpdateEmployeeDetails_btn.Enabled = false;
            DeleteEmployeeDetails_btn.Enabled = false;

            GetRecordCountFormTable();
        }

        private void GetEmployeeDesignation()
        {
            designation_cmb.Items.Clear();

            string[] GetEmployeeDesignations = db_obj.GetEmployeeDesignations();

            for (int EachDesignation = 0; EachDesignation < GetEmployeeDesignations.Length; EachDesignation++)
            {
                if (GetEmployeeDesignations[EachDesignation] == null)
                {
                    break;
                }

                designation_cmb.Items.Add(GetEmployeeDesignations[EachDesignation]);
            }
        }

        private void EmployeeGoToNextPage_btn_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(1);
        }

        public string DriverAllocatedStatus = "";
        private void designation_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedDesignation = designation_cmb.Text;

            if (SelectedDesignation == "Driver")
            {
                d_allocatedSts_lab.Enabled = true;
                DriverAllocatedSts.Enabled = true;             
            }
            else
            {
                d_allocatedSts_lab.Enabled = false;
                DriverAllocatedSts.Enabled = false;
            }
        }

        private void DriverAllocatedSts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverAllocatedStatus = DriverAllocatedSts.Text;
        }

        private void designation_cmb_Click(object sender, EventArgs e)
        {
            GetEmployeeDesignation();
        }
    }
}
