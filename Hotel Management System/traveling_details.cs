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
    public partial class traveling_details : UserControl
    {
        public traveling_details()
        {
            InitializeComponent();
        }

        DatabaseConnectionForDestinationManagement db_obj = new DatabaseConnectionForDestinationManagement();

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

        private void registerLocation_btn_Click(object sender, EventArgs e)
        {
            string DestinationNo = destination_no_txt.Text;
            string Destinationname = DestinationName_txt.Text;
            string Path01 = path01_txt.Text;
            string Path02 = path02_txt.Text;
            string Path03 = path03_txt.Text;
            string DestinationPrice = price_txt.Text;
            string DestinationStatus = status_cmb.Text;
            string DestinationDescription = description_txt.Text;

            if (ChkValues(DestinationNo) == true && ChkValues(Destinationname) == true && ChkValues(DestinationPrice) == true)
            {
                if (ChkInt(DestinationPrice) == true)
                {
                    if (db_obj.RegisterDestinationDetails(DestinationNo, Destinationname, Path01, Path02, Path03, DestinationPrice, DestinationStatus, DestinationDescription) == true)
                    {
                        GetTravellingTableRecordCount();
                        ResetAllFeilds();
                        MessageBox.Show("Travelling Details Appling Sucessfully...", "Travelling Details Registering...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Destination Price...", "Invalid Destination Price...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Required Feilds...", "Empty Or Null Feilds...");
            }
        }

        private void searchLocation_btn_Click(object sender, EventArgs e)
        {
            string DestinationNo = destination_no_txt.Text;

            if (DestinationNo == "")
            {
                MessageBox.Show("Please Enter Destination Numer Before Search Destination Details...", "Empty Or Null Destination Number...");
            }
            else
            {
                string[] TravellingDetails = db_obj.GetSelectedTravellingDetails(DestinationNo);

                if (TravellingDetails[0] == null)
                {
                    MessageBox.Show("There Is No Destination details For That Destination Number...", "Invalid Destination Number...");
                }
                else
                {
                    destination_no_txt.Enabled = false;
                    registerLocation_btn.Enabled = false;
                    UpdateLocatopn_btn.Enabled = true;
                    DeleteLocation_btn.Enabled = true;

                    DestinationName_txt.Text = TravellingDetails[1];
                    path01_txt.Text = TravellingDetails[2];
                    path02_txt.Text = TravellingDetails[3];
                    path03_txt.Text = TravellingDetails[4];

                    status_cmb.Text = TravellingDetails[5];
                    price_txt.Text = TravellingDetails[6];
                    description_txt.Text = TravellingDetails[8];
                }
            }
        }

        private void UpdateLocatopn_btn_Click(object sender, EventArgs e)
        {
            string DestinationNo = destination_no_txt.Text;
            string Destinationname = DestinationName_txt.Text;
            string Path01 = path01_txt.Text;
            string Path02 = path02_txt.Text;
            string Path03 = path03_txt.Text;
            string DestinationPrice = price_txt.Text;
            string DestinationStatus = status_cmb.Text;
            string DestinationDescription = description_txt.Text;

            if (ChkValues(Destinationname) == true && ChkValues(DestinationPrice) == true)
            {
                if (ChkInt(DestinationPrice) == true)
                {
                    if (db_obj.UpdateDestinationDetails(DestinationNo, Destinationname, Path01, Path02, Path03, DestinationPrice, DestinationStatus, DestinationDescription) == true)
                    {
                        ResetAllFeilds();
                        MessageBox.Show("Travelling Details Updating Sucessfully...", "Travelling Details Updating...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Destination Price...", "Invalid Destination Price...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Required Feilds...", "Empty Or Null Feilds...");
            }
        }

        private void DeleteLocation_btn_Click(object sender, EventArgs e)
        {
            string DestinationNo = destination_no_txt.Text;

            DialogResult DeleteSelectedTrevallingDetails = MessageBox.Show("Are You Sure Want To Delete This Travelling Details ? ", "Delete Traveling Details...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DeleteSelectedTrevallingDetails == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedTravellingDetails(DestinationNo) == true)
                {
                    ResetAllFeilds();
                    MessageBox.Show("Travelling Details Deleted Successfully...", "Delete Travelling Details...");
                }
                else
                {
                    MessageBox.Show("There Is some Error Occured While Delete Travelling Details...");
                }
            }
        }

        private void GetTravellingTableRecordCount()
        {
            record_count_txt.Enabled = false;
            record_count_txt.Text = db_obj.GetTravellingTableRecordCount();
        }

        private void traveling_details_Load(object sender, EventArgs e)
        {
            UpdateLocatopn_btn.Enabled = false;
            DeleteLocation_btn.Enabled = false;

            GetTravellingTableRecordCount();
        }

        private void ResetAllFeilds()
        {
            destination_no_txt.Enabled = true;
            registerLocation_btn.Enabled = true;
            UpdateLocatopn_btn.Enabled = false;
            DeleteLocation_btn.Enabled = false;

            destination_no_txt.Text = "";
            DestinationName_txt.Text = "";
            path01_txt.Text = "";
            path02_txt.Text = "";
            path03_txt.Text = "";

            status_cmb.Text = null;
            price_txt.Text = "";
            description_txt.Text = "";
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            ResetAllFeilds();
        }


    }
}
