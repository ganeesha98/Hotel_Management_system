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
    public partial class payment_details : UserControl
    {
        public payment_details()
        {
            InitializeComponent();
        }

        location_details LocationFormObj = new location_details();
        DatabaseConnectionForPaymentManagement db_obj = new DatabaseConnectionForPaymentManagement();

        private int ReplaceIntegerForNullOrEmptyValues(string value)
        {
            int GetVal;

            try
            {
                GetVal = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                GetVal = 0;
            }

            return GetVal;
        }

        public static int FinalPaymentAmt;

        private void searchBill_btn_Click(object sender, EventArgs e)
        {
            string BillNo = searchBill_txt.Text;

            if (LocationFormObj.CheckValues(BillNo) == true && LocationFormObj.CheckIntegerVal(BillNo) == true)
            {
                string[] SelectedCustormerDetails = db_obj.GetSearchCustormerPersonalDetailsAndReservationDetails(BillNo);

                if (SelectedCustormerDetails[0] == null)
                {
                    MessageBox.Show("There Is No Bill Details For That Custormer ID Number...", "Invalid Custormer ID Number...");
                }
                else
                {
                    SettlePayment_btn.Enabled = true;
                    string[] SelectedCustormerBillDetails = db_obj.GetSelectedCustormerBillDetails(BillNo);

                    NameWithIni_txt.Text = SelectedCustormerDetails[2];
                    Nic_txt.Text = SelectedCustormerDetails[14];
                    Days_txt.Text = SelectedCustormerDetails[12];
                    ReservedDate_dtpick.Value = Convert.ToDateTime(SelectedCustormerDetails[10]);
                    CheckInDate_dtpick.Value = Convert.ToDateTime(SelectedCustormerDetails[11]);
                    CheckOut_dtpick.Value = Convert.ToDateTime(SelectedCustormerDetails[13]);

                    AdvanceAmountSts_cmb.Text = SelectedCustormerBillDetails[3];
                    FinalPayment_txt.Text = SelectedCustormerBillDetails[2];
                    FinalPaymentAmt = Convert.ToInt32(SelectedCustormerBillDetails[2]);
                    FinalPaymentSts_cmb.Text = SelectedCustormerBillDetails[4];
                    AdvanceAmountDueDate_dtpick.Value = Convert.ToDateTime(SelectedCustormerBillDetails[7]);
                    FinalPaymentDueDate_dtpick.Value = Convert.ToDateTime(SelectedCustormerBillDetails[8]);
                    CompleteStatus_cmb.Text = SelectedCustormerBillDetails[5];

                    if (SelectedCustormerBillDetails[5] != "Complete")
                    {
                        GetBalanceAmt();
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Or Null Bill Number....", "Empty Or Null Primary Key...");
                
            }
        }

        private void GetBalanceAmt()
        {
            string GetAdvanceAmtSts = AdvanceAmountSts_cmb.Text;

            if (GetAdvanceAmtSts == "Payed")
            {
                FinalPaymentSts_cmb.Enabled = true;
                int BalanceAmt = ReplaceIntegerForNullOrEmptyValues(FinalPayment_txt.Text);
                Balance_txt.Text = BalanceAmt.ToString();
            }
            else
            {
                FinalPaymentSts_cmb.Enabled = false;
                Balance_txt.Text = (ReplaceIntegerForNullOrEmptyValues(FinalPaymentAmt.ToString()) * (ReplaceIntegerForNullOrEmptyValues(AdvanceAmount_txt.Text) + 100) / 100 ).ToString();
            }
        }

        private void GetAdvancePaymentAmount()
        {
            FinalPaymentDueDate_dtpick.Value = System.DateTime.Now;
            AdvanceAmountDueDate_dtpick.Value = System.DateTime.Now;
            int AdvanceAmount = db_obj.GetAdvanceAmountDetails();
            AdvanceAmount_txt.Text = AdvanceAmount.ToString();
        }

        private void payment_details_Load(object sender, EventArgs e)
        {
            //AdvanceAmountDueDate_dtpick.MinDate = System.DateTime.Now;
            //FinalPaymentDueDate_dtpick.MinDate = System.DateTime.Now;

            SettlePayment_btn.Enabled = false;
            FinalPaymentSts_cmb.Enabled = false;
            CompleteStatus_cmb.Enabled = false;
            GetAdvancePaymentAmount();
        }

        private void AdvanceAmountSts_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBalanceAmt();
        }

        private void FinalPaymentSts_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FinalPaymentSts_cmb.Text == "Payed")
            {
                int BalanceAmt = ReplaceIntegerForNullOrEmptyValues(FinalPayment_txt.Text) - ReplaceIntegerForNullOrEmptyValues(FinalPayment_txt.Text);
                Balance_txt.Text = BalanceAmt.ToString();
            }
            else
            {
                Balance_txt.Text = (ReplaceIntegerForNullOrEmptyValues(FinalPayment_txt.Text) - ReplaceIntegerForNullOrEmptyValues(AdvanceAmount_txt.Text)).ToString();
            }
        }

        private void SettlePayment_btn_Click(object sender, EventArgs e)
        {
            string BillNo = searchBill_txt.Text;

            string AdvancePaymentSts = AdvanceAmountSts_cmb.Text;
            string FinalPaymentSts = FinalPaymentSts_cmb.Text;
            string CompletePaymentSts = CompleteStatus_cmb.Text;

            if (db_obj.UpdateCustormerPaymentStatus(BillNo, AdvancePaymentSts, FinalPaymentSts, CompletePaymentSts) == true)
            {
                MessageBox.Show("Custormer Payment Updating Sucessfully...", "Custormer Payment...");
            }
            else
            {
                MessageBox.Show("There Is Some Error Ocuured While Updating Payment...", "Database Or SQL Error...");
            }
        }

        private void Balance_txt_TextChanged(object sender, EventArgs e)
        {
            if (Balance_txt.Text.Equals("0"))
            {
                CompleteStatus_cmb.Text = "Complete";
            }
            else
            {
                CompleteStatus_cmb.Text = "Pending";
            }
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            NameWithIni_txt.Text = "";
            Nic_txt.Text = "";
            Days_txt.Text = "";
            ReservedDate_dtpick.Value = System.DateTime.Now;
            CheckInDate_dtpick.Value = System.DateTime.Now;
            CheckOut_dtpick.Value = System.DateTime.Now;

            AdvanceAmountSts_cmb.Text = null;
            FinalPayment_txt.Text = "";
            FinalPaymentAmt = 0;
            FinalPaymentSts_cmb.Text = null;
            AdvanceAmountDueDate_dtpick.Value = System.DateTime.Now;
            FinalPaymentDueDate_dtpick.Value = System.DateTime.Now;
            CompleteStatus_cmb.Text = null;
        }
    }
}
