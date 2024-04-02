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
    public partial class settings_form : UserControl
    {
        public settings_form()
        {
            InitializeComponent();
        }

        DatabaseConnectionForSettingsManagement db_obj = new DatabaseConnectionForSettingsManagement();
        location_details LocationDetailsFormObj = new location_details();

        public static string OfferDays;
        public static DateTime OfferEndDate;

        private void OfferApply_btn_Click(object sender, EventArgs e)
        {
            string OfferNo = offerno_txt.Text;
            string OfferName = offerName_txt.Text;
            DateTime OfferStartDate = Convert.ToDateTime(offerStartDate_dtpick.Value);
            //string OfferDays = offerDays_txt.Text;
            //offerEndDate_dtpick.Value = (offerEndDate_dtpick.Value.AddDays(Convert.ToInt32(OfferDays)));
            //DateTime OfferEndDate = Convert.ToDateTime(offerEndDate_dtpick.Value.AddDays(Convert.ToInt32(OfferDays)));
            string OfferValue = offerValue_txt.Text;
            string OfferStatus = offerStatus_cmb.Text;

            if (LocationDetailsFormObj.CheckValues(OfferNo) == true && LocationDetailsFormObj.CheckValues(OfferName) == true && LocationDetailsFormObj.CheckValues(OfferValue) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(OfferValue) == true)
                {
                    if (db_obj.RegisterOfferDetails(OfferNo, OfferName, OfferStartDate, OfferDays, OfferEndDate, OfferValue, OfferStatus) == true)
                    {
                        MessageBox.Show("Offer Details Apply Sucessfully......", "Apply Offer Details...");
                        ResetOfferDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Appling Offer Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Offer Value...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Offer Number...", "Empty Or Null Primary Key...");
            }
        }

        private int ReplaceNullValuesOrEmptyValues(string value)
        {
            int GetValue;

            try
            {
                GetValue = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                GetValue = 0;
            }

            return GetValue;
        }

        private void offerDays_txt_TextChanged(object sender, EventArgs e)
        {
            offerEndDate_dtpick.Value = offerStartDate_dtpick.Value;
            OfferDays = offerDays_txt.Text;
            offerEndDate_dtpick.Value = (offerEndDate_dtpick.Value.AddDays(ReplaceNullValuesOrEmptyValues(OfferDays)));
            OfferEndDate = offerEndDate_dtpick.Value;
        }

        private void OfferSearch_btn_Click(object sender, EventArgs e)
        {
            string OfferNo = offerno_txt.Text;

            if (LocationDetailsFormObj.CheckValues(OfferNo) == true)
            {
                string[] SelectedOfferDetails = db_obj.GetSelectedOfferDetails(OfferNo);

                if (SelectedOfferDetails[0] == null)
                {
                    MessageBox.Show("There Is No Offer Details For That Offer ID Number...", "Invalid Offer ID Number...");
                }
                else
                {
                    offerno_txt.Enabled = false;
                    OfferApply_btn.Enabled = false;
                    OfferUpdate_btn.Enabled = true;
                    OfferDelete_btn.Enabled = true;

                    offerName_txt.Text = SelectedOfferDetails[1];
                    offerStartDate_dtpick.Value = Convert.ToDateTime(SelectedOfferDetails[2]);
                    offerDays_txt.Text = SelectedOfferDetails[3];
                    offerValue_txt.Text = SelectedOfferDetails[5];
                    offerStatus_cmb.Text = SelectedOfferDetails[6];
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Offer Number...", "Empty Or Null Primary Key...");
            }
        }

        private void OfferUpdate_btn_Click(object sender, EventArgs e)
        {
            string OfferNo = offerno_txt.Text;
            string OfferName = offerName_txt.Text;
            DateTime OfferStartDate = Convert.ToDateTime(offerStartDate_dtpick.Value);
            //string OfferDays = offerDays_txt.Text;
            //offerEndDate_dtpick.Value = (offerEndDate_dtpick.Value.AddDays(Convert.ToInt32(OfferDays)));
            //DateTime OfferEndDate = Convert.ToDateTime(offerEndDate_dtpick.Value.AddDays(Convert.ToInt32(OfferDays)));
            string OfferValue = offerValue_txt.Text;
            string OfferStatus = offerStatus_cmb.Text;

            if (LocationDetailsFormObj.CheckValues(OfferName) == true && LocationDetailsFormObj.CheckValues(OfferValue) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(OfferValue) == true)
                {
                    if (db_obj.UpdateOfferDetails(OfferNo, OfferName, OfferStartDate, OfferDays, OfferEndDate, OfferValue, OfferStatus) == true)
                    {
                        MessageBox.Show("Offer Details Update Sucessfully...", "Offer Details Update...");
                        ResetOfferDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Updating Offer Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Offer Value...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Offer Number...", "Empty Or Null Primary Key...");
            }
        }

        private void OfferDelete_btn_Click(object sender, EventArgs e)
        {
            string OfferNo = offerno_txt.Text;

            DialogResult DeleteSelectedOfferDetails = MessageBox.Show("Are You Sure Wnat To Delete This Offer Details From The System ? ", "Offer Deltails Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeleteSelectedOfferDetails == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedOfferDetails(OfferNo) == true)
                {
                    MessageBox.Show("Offer Details Deletion Sucessfully...", "Offer Details Deletion...");
                    ResetOfferDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Deletion...", "Database Or SQL Error...");
                }
            }
        }

        private void ResetOfferDetails()
        {
            OfferApply_btn.Enabled = true;
            OfferUpdate_btn.Enabled = false;
            OfferDelete_btn.Enabled = false;

            offerno_txt.Enabled = true;

            offerName_txt.Text = "";
            offerStartDate_dtpick.Value = System.DateTime.Now;
            offerEndDate_dtpick.Value = System.DateTime.Now;
            offerDays_txt.Text = "";
            offerValue_txt.Text = "";
            offerStatus_cmb.Text = null;
        }

        private void OfferReset_btn_Click(object sender, EventArgs e)
        {
            ResetOfferDetails();
        }

        private void DecorationApply_btn_Click(object sender, EventArgs e)
        {
            string DecorationNo = DecorationNo_txt.Text;
            string DecorationName = DecorationName_txt.Text;

            string BaloonsSts = GetResultOfChkBoxes(baloon_chkbox);
            string CandlesStatus = GetResultOfChkBoxes(candles_chkbox);
            string RossesStats = GetResultOfChkBoxes(rooses_chkbox);
            string RibbonsStatus = GetResultOfChkBoxes(ribbons_chkbox);

            string DecorationPrice = Decorationprice_txt.Text;
            string DecorationStatus = DecorationStatus_cmb.Text;
            string DecorationDescription = DecorationDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DecorationNo) == true && LocationDetailsFormObj.CheckValues(DecorationName) == true && LocationDetailsFormObj.CheckValues(DecorationPrice) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(DecorationPrice) == true)
                {
                    if (db_obj.InsertDecorationDetails(DecorationNo, DecorationName, BaloonsSts, CandlesStatus, RossesStats, RibbonsStatus, DecorationPrice, DecorationStatus, DecorationDescription) == true)
                    {
                        MessageBox.Show("Decoration Details Appling Sucessfully...", "Decoration Details Apply...");
                        ResetDecorationDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Appling Decoration Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Decoration Price...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Decoration Number...", "Empty Or Null Primary Key...");
            }
        }

        private string GetResultOfChkBoxes(Guna.UI.WinForms.GunaCheckBox chkbox)
        {
            string Status = "No";

            if (chkbox.Checked == true)
            {
                Status = "Yes";
            }
            else
            {
                Status = "No";
            }

            return Status;
        }

        private void DecorationSdearch_btn_Click(object sender, EventArgs e)
        {
            string DecorationNo = DecorationNo_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DecorationNo) == true)
            {
                string[] SelectedDecorationdetails = db_obj.GetSelectedDecorationDetails(DecorationNo);

                if (SelectedDecorationdetails[0] == null)
                {
                    MessageBox.Show("There Is No Decoration Details For That Decoration Number...", "Invalid Decoration Number");
                }
                else
                {
                    DecorationNo_txt.Enabled = false;
                    DecorationApply_btn.Enabled = false;
                    DecorationUpdate_btn.Enabled = true;
                    DecorationDelete_btn.Enabled = true;

                    DecorationName_txt.Text = SelectedDecorationdetails[1];
                    CheckedIfCheckBoxIsTrue(2, SelectedDecorationdetails[2]);
                    CheckedIfCheckBoxIsTrue(3, SelectedDecorationdetails[3]);
                    CheckedIfCheckBoxIsTrue(4, SelectedDecorationdetails[4]);
                    CheckedIfCheckBoxIsTrue(5, SelectedDecorationdetails[5]);
                    Decorationprice_txt.Text = SelectedDecorationdetails[6];
                    DecorationStatus_cmb.Text = SelectedDecorationdetails[7];
                    DecorationDescription_txt.Text = SelectedDecorationdetails[8];
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Decoration Number...", "Empty Or Null Primary Key...");
            }
        }

        private void CheckedIfCheckBoxIsTrue(int indx, string p)
        {
            if (indx == 2 && p == "Yes")
            {
                baloon_chkbox.Checked = true;
            }
            if (indx == 3 && p == "Yes")
            {
                rooses_chkbox.Checked = true;
            }
            if (indx == 4 && p == "Yes")
            {
                candles_chkbox.Checked = true;
            }
            if (indx == 5 && p == "Yes")
            {
                ribbons_chkbox.Checked = true;
            }
        }

        private void DecorationUpdate_btn_Click(object sender, EventArgs e)
        {
            string DecorationNo = DecorationNo_txt.Text;
            string DecorationName = DecorationName_txt.Text;

            string BaloonsSts = GetResultOfChkBoxes(baloon_chkbox);
            string CandlesStatus = GetResultOfChkBoxes(candles_chkbox);
            string RossesStats = GetResultOfChkBoxes(rooses_chkbox);
            string RibbonsStatus = GetResultOfChkBoxes(ribbons_chkbox);

            string DecorationPrice = Decorationprice_txt.Text;
            string DecorationStatus = DecorationStatus_cmb.Text;
            string DecorationDescription = DecorationDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DecorationName) == true && LocationDetailsFormObj.CheckValues(DecorationPrice) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(DecorationPrice) == true)
                {
                    if (db_obj.UpdateDecorationDetails(DecorationNo, DecorationName, BaloonsSts, CandlesStatus, RossesStats, RibbonsStatus, DecorationPrice, DecorationStatus, DecorationDescription) == true)
                    {
                        MessageBox.Show("Decoration details Updated Succesfully...", "Decoration Details Update...");
                        ResetDecorationDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Updating Decoration Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Decoration Price...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Decoration Number...", "Empty Or Null Primary Key...");
            }

        }

        private void DecorationDelete_btn_Click(object sender, EventArgs e)
        {
            string DecorationNo = DecorationNo_txt.Text;

            DialogResult DeleteSelectedDecorationdetails = MessageBox.Show("Are You Sure Want To delete This Decoration Package Details From The System ? ", "Delete decoration Details...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeleteSelectedDecorationdetails == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedDecorationdetails(DecorationNo) == true)
                {
                    MessageBox.Show("Decoration Package Delete Sucessfully...", "Decoration Pakage Deletion...");
                    ResetDecorationDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Deleting Decoration Details...", "Database Or SQL Error...");
                }
            }
        }

        private void ResetDecorationDetails()
        {
            DecorationApply_btn.Enabled = true;
            DecorationUpdate_btn.Enabled = false;
            DecorationDelete_btn.Enabled = false;

            DecorationNo_txt.Enabled = true;

            DecorationNo_txt.Text = "";
            DecorationNo_txt.Text = "";
            DecorationName_txt.Text = "";
            baloon_chkbox.Checked = false;
            candles_chkbox.Checked = false;
            rooses_chkbox.Checked = false;
            ribbons_chkbox.Checked = false;
            Decorationprice_txt.Text = "";
            DecorationStatus_cmb.Text = null;
            DecorationDescription_txt.Text = "";
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            ResetDecorationDetails();
        }

        private void DesignationApply_btn_Click(object sender, EventArgs e)
        {
            string DesignationNo = DesignationNo_txt.Text;
            string DesignationName = DesignationName_txt.Text;
            string DesignationStatus = DesignationStatus_cmb.Text;
            string DesignationDescription = DesignationDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DesignationNo) == true && LocationDetailsFormObj.CheckValues(DesignationName) == true)
            {
                if (db_obj.InsertDesignationDetails(DesignationNo, DesignationName, DesignationStatus, DesignationDescription) == true)
                {
                    MessageBox.Show("Designation Details Appling Succesfully...", "Designation Details Appling...");
                    ResetDesignationDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Appling Designation Details...", "Database Or SQL Error...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Designation Number...", "Empty Or Null Primary Key...");
            }
        }

        private void DesignationSearch_btn_Click(object sender, EventArgs e)
        {
            string DesignationNo = DesignationNo_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DesignationNo) == true)
            {
                string[] SelectedDesignationDetails = db_obj.GetSelectedDesignationdetails(DesignationNo);

                if (SelectedDesignationDetails[0] == null)
                {
                    MessageBox.Show("There Is No Designation Details For That Designation Number...", "Invalid Designation Number...");
                }
                else
                {
                    DesignationNo_txt.Enabled = false;
                    DesignationNo_txt.Enabled = false;
                    DesignationApply_btn.Enabled = false;
                    DesignationUpdate_btn.Enabled = true;
                    DesignationDelete_btn.Enabled = true;

                    DesignationName_txt.Text = SelectedDesignationDetails[1];
                    DesignationStatus_cmb.Text = SelectedDesignationDetails[2];
                    DesignationDescription_txt.Text = SelectedDesignationDetails[3];
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Designation Number...", "Empty Or Null Primary Key...");
            }
        }

        private void DesignationUpdate_btn_Click(object sender, EventArgs e)
        {
            string DesignationNo = DesignationNo_txt.Text;
            string DesignationName = DesignationName_txt.Text;
            string DesignationStatus = DesignationStatus_cmb.Text;
            string DesignationDescription = DesignationDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(DesignationNo) == true && LocationDetailsFormObj.CheckValues(DesignationName) == true)
            {
                if (db_obj.UpdateDesignationDetails(DesignationNo, DesignationName, DesignationStatus, DesignationDescription) == true)
                {
                    MessageBox.Show("Designation Details Update Succesfully...", "Designation Details Update...");
                    ResetDesignationDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Designation Details Updating...", "Database Or SQL Error...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Designation Number...", "Empty Or Null Primary Key...");
            }
        }

        private void DesignationDelete_btn_Click(object sender, EventArgs e)
        {
            string DesignationNo = DesignationNo_txt.Text;

            DialogResult DeleteSelectedDesignationdetails = MessageBox.Show("Are You Sure Want To delete This Designation Details From The System ? ", "Designation Details Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeleteSelectedDesignationdetails == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedDesignationdetails(DesignationNo) == true)
                {
                    MessageBox.Show("Designation Details Delete Sucessfully..", "Designation Details Deletion...");
                    ResetDesignationDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Designation Delete Deletion...", "Database Error Or SQL Error...");
                }
            }
        }

        private void ResetDesignationDetails()
        {
            DesignationApply_btn.Enabled = true;
            DesignationUpdate_btn.Enabled = false;
            DesignationDelete_btn.Enabled = false;

            DesignationNo_txt.Enabled = true;

            DesignationNo_txt.Text = "";
            DesignationName_txt.Text = "";
            DesignationStatus_cmb.Text = null;
            DesignationDescription_txt.Text = "";
        }

        private void DesignationResetFeilds_btn_Click(object sender, EventArgs e)
        {
            ResetDesignationDetails();
        }

        private void AdvanceAmountApply_btn_Click(object sender, EventArgs e)
        {
            string AdvanceAmtNo = AdvanceAmtNo_txt.Text;
            string AdvanceAmtPrice = AdvanceAmtPrice_txt.Text;
            string AdvanceAmtDescription = AdvanceAmtDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(AdvanceAmtNo) == true && LocationDetailsFormObj.CheckValues(AdvanceAmtPrice) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(AdvanceAmtPrice) == true)
                {
                    if (db_obj.InsertAdvanceAmtDetails(AdvanceAmtNo, AdvanceAmtPrice, AdvanceAmtDescription) == true)
                    {
                        MessageBox.Show("Advance Amount Details Apply Sucessfully...", "Advance Amount Details Appling...");
                        ResetAdvanceAmountDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Appling Advance Amunt Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Advance Amount Price Feild...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Advance Amount Number...", "Empty Or Null Primary Key...");
            }
        }

        private void AdvanceAmountSearch_btn_Click(object sender, EventArgs e)
        {
            string AdvanceAmtNo = AdvanceAmtNo_txt.Text;

            if (LocationDetailsFormObj.CheckValues(AdvanceAmtNo) == true)
            {
                string[] SelectedAdvanceAmtDetails = db_obj.GetSelectedAdvanceAmtDetails(AdvanceAmtNo);

                if (SelectedAdvanceAmtDetails[0] == null)
                {
                    MessageBox.Show("There Is No Advance Amount Details For That Advance Amount Number...", "Invalid Advance Amount Details Number...");
                }
                else
                {
                    AdvanceAmtNo_txt.Enabled = false;
                    AdvanceAmountApply_btn.Enabled = false;
                    AdvanceAmountUpdate_btn.Enabled = true;
                    AdvanceAmountDelete_btn.Enabled = true;

                    AdvanceAmtPrice_txt.Text = SelectedAdvanceAmtDetails[1];
                    AdvanceAmtDescription_txt.Text = SelectedAdvanceAmtDetails[2];
                }
            }
            else
            {
                MessageBox.Show("Please Enter Advance Amount Number Before Search Advance Amount Details...", "Empty Or Null Advance Amount Number...");
            }
        }

        private void AdvanceAmountUpdate_btn_Click(object sender, EventArgs e)
        {
            string AdvanceAmtNo = AdvanceAmtNo_txt.Text;
            string AdvanceAmtPrice = AdvanceAmtPrice_txt.Text;
            string AdvanceAmtDescription = AdvanceAmtDescription_txt.Text;

            if (LocationDetailsFormObj.CheckValues(AdvanceAmtPrice) == true)
            {
                if (LocationDetailsFormObj.CheckIntegerVal(AdvanceAmtPrice) == true)
                {
                    if (db_obj.UpdateAdvanceAmtDetails(AdvanceAmtNo, AdvanceAmtPrice, AdvanceAmtDescription) == true)
                    {
                        MessageBox.Show("Advance Amount Details Updating Sucessfully...", "Advance Amount Details Updating...");
                        ResetAdvanceAmountDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Appling Advance Amunt Details...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Advance Amount Price Feild...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Advance Amount Price...", "Empty Or Null Primary Key...");
            }
        }

        private void AdvanceAmountDelete_btn_Click(object sender, EventArgs e)
        {
            string AdvanceAmtNo = AdvanceAmtNo_txt.Text;

            DialogResult DeleteSelectedAdvanceAmtDetails = MessageBox.Show("Are You Sure Want To Delete This Advance Amount Details From The System ? ", "Advance Amount Details Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeleteSelectedAdvanceAmtDetails == DialogResult.Yes)
            {
                if (db_obj.DeleteSelectedAdvanceAmtDetails(AdvanceAmtNo) == true)
                {
                    MessageBox.Show("Advance Amount Deletion Sucessfuylly...", "Advance Amount Deletion...");
                    ResetAdvanceAmountDetails();
                }
                else
                {
                    MessageBox.Show("There is Some Error Occured While Advance Amount Details Deletion...");
                }
            }
        }

        private void ResetAdvanceAmountDetails()
        {
            AdvanceAmountApply_btn.Enabled = true;
            AdvanceAmountUpdate_btn.Enabled = false;
            AdvanceAmountDelete_btn.Enabled = false;

            AdvanceAmtNo_txt.Enabled = true;

            AdvanceAmtNo_txt.Text = "";
            AdvanceAmtPrice_txt.Text = "";
            AdvanceAmtDescription_txt.Text = "";
        }

        private void AdvanceAmountReset_btn_Click(object sender, EventArgs e)
        {
            ResetAdvanceAmountDetails();
        }

        private void settings_form_Load(object sender, EventArgs e)
        {
            offerEndDate_dtpick.Enabled = false;
        }

        private void settings_form_Load_1(object sender, EventArgs e)
        {
            OfferUpdate_btn.Enabled = false;
            OfferDelete_btn.Enabled = false;

            DesignationUpdate_btn.Enabled = false;
            DesignationDelete_btn.Enabled = false;

            AdvanceAmountUpdate_btn.Enabled = false;
            AdvanceAmountDelete_btn.Enabled = false;

            DecorationUpdate_btn.Enabled = false;
            DecorationDelete_btn.Enabled = false;
        }

        private void offerDays_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("This Field Allows Only Numeric Values", "Invalid Number Format...");
            }
        }
    }
}
