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
    public partial class meal_details : UserControl
    {
        public meal_details()
        {
            InitializeComponent();
        }

        DatabaseConnectionForMealManagement db_obj = new DatabaseConnectionForMealManagement();

        private string GetMealTime(Guna.UI.WinForms.GunaCheckBox MealTime)
        {
            string MealTimeStatus = "";

            if (MealTime.Checked == true)
            {
                MealTimeStatus = "Yes";
            }

            return MealTimeStatus;
        }

        private bool CheckEmptyValues(string value)
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
            int GetInt;

            try
            {
                GetInt = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void RegisterMealDetails_btn_Click(object sender, EventArgs e)
        {
            string BreakfastStatus = GetMealTime(breakfast_chk);
            string LunchStatus = GetMealTime(lunch_chk);
            string DinnerStatus = GetMealTime(dinner_chk);
            string MealNo = mealno_txt.Text;
            string MealType = mealtype_txt.Text;
            string MealName = mealName_txt.Text;
            string MealQuentity = mealquentity_txt.Text;
            string MealPrice = mealprice_txt.Text;
            string MealStatus = mealSts_cmb.Text;
            string MealDescription = mealDescription_txt.Text;

            if (CheckEmptyValues(MealNo) == true && CheckEmptyValues(MealType) == true && CheckEmptyValues(MealName) == true && CheckEmptyValues(MealPrice) == true)
            {
                if (CheckIntegerValues(MealPrice) == true && CheckIntegerValues(MealQuentity) == true)
                {
                    if (BreakfastStatus == "Yes" || LunchStatus == "Yes" || DinnerStatus == "Yes")
                    {
                        if (db_obj.RegisterMealDetails(MealNo, MealType, MealName, MealQuentity, MealPrice, MealStatus, MealDescription, BreakfastStatus, LunchStatus, DinnerStatus) == true)
                        {
                            GetDatabaseTableRecordCount();
                            ResetMealDetails();
                            MessageBox.Show("Meal Registration Sucessfully....", "Meal Registration...");
                        }
                        else
                        {
                            MessageBox.Show("There Is Some Error Occured While Meal Registration...", "Database Or SQL Error...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter At Least One Meal Time...", "Invalid Meal Time...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Numeric Feilds...", "Invalid Number Format...");
                }               
            }
            else
            {
                MessageBox.Show("Please Enter Required Feilds Before Register Meal...", "Empty Or Null Feilds...");
            }
        }

        private void SearchMealDetails_btn_Click(object sender, EventArgs e)
        {
            string MealNo = mealno_txt.Text;
            string[] SelectedMealDetails = db_obj.GetRequiredMealDetails(MealNo);

            if (SelectedMealDetails[0] == null)
            {
                MessageBox.Show("There Is No Meal details For That Meal Number...", "Invalid Meal Number...");
            }
            else
            {
                mealno_txt.Enabled = false;
                RegisterMealDetails_btn.Enabled = false;
                UpdateMealDetails_btn.Enabled = true;
                DeleteMealDetails_btn.Enabled = true;

                if (SelectedMealDetails[7] == "Yes")
                {
                    breakfast_chk.Checked = true;
                }
                if (SelectedMealDetails[8] == "Yes")
                {
                    lunch_chk.Checked = true;
                }
                if (SelectedMealDetails[9] == "Yes")
                {
                    dinner_chk.Checked = true;
                }

                mealtype_txt.Text = SelectedMealDetails[1];
                mealName_txt.Text = SelectedMealDetails[2];
                mealquentity_txt.Text = SelectedMealDetails[3];
                mealprice_txt.Text = SelectedMealDetails[4];
                mealSts_cmb.Text = SelectedMealDetails[5];
                mealDescription_txt.Text = SelectedMealDetails[6];
            }
        }

        private void UpdateMealDetails_btn_Click(object sender, EventArgs e)
        {
            string BreakfastStatus = GetMealTime(breakfast_chk);
            string LunchStatus = GetMealTime(lunch_chk);
            string DinnerStatus = GetMealTime(dinner_chk);
            string MealNo = mealno_txt.Text;
            string MealType = mealtype_txt.Text;
            string MealName = mealName_txt.Text;
            string MealQuentity = mealquentity_txt.Text;
            string MealPrice = mealprice_txt.Text;
            string MealStatus = mealSts_cmb.Text;
            string MealDescription = mealDescription_txt.Text;

            if (CheckEmptyValues(MealNo) == true && CheckEmptyValues(MealType) == true && CheckEmptyValues(MealName) == true && CheckEmptyValues(MealPrice) == true)
            {
                if (CheckIntegerValues(MealPrice) == true && CheckIntegerValues(MealQuentity) == true)
                {
                    if (BreakfastStatus == "Yes" || LunchStatus == "Yes" || DinnerStatus == "Yes")
                    {
                        if (db_obj.UpdateMealDetails(MealNo, MealType, MealName, MealQuentity, MealPrice, MealStatus, MealDescription, BreakfastStatus, LunchStatus, DinnerStatus) == true)
                        {
                            GetDatabaseTableRecordCount();
                            ResetMealDetails();
                            MessageBox.Show("Meal Registration Sucessfully....", "Meal Registration...");
                        }
                        else
                        {
                            MessageBox.Show("There Is Some Error Occured While Meal Registration...", "Database Or SQL Error...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter At Least One Meal Time...", "Invalid Meal Time...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Numeric Feilds...", "Invalid Number Format...");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Required Feilds Before Register Meal...", "Empty Or Null Feilds...");
            }
        }

        private void DeleteMealDetails_btn_Click(object sender, EventArgs e)
        {
            string MealNo = mealno_txt.Text;

            if (CheckEmptyValues(MealNo) == true)
            {
                DialogResult DeleteMealDetails = MessageBox.Show("Are You Sure Want To Delete This details From The System ? ", "Mea; Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DeleteMealDetails == DialogResult.Yes)
                {
                    if (db_obj.DeleteMealDetails(MealNo) == true)
                    {
                        GetDatabaseTableRecordCount();
                        ResetMealDetails();
                        MessageBox.Show("Meal Details Update Sucessfully....", "Meal Details Updating...");
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Meal Details Deletion...", "Database Or SQL Error...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Meal Number Before Delete Meal Details...", "Empty Or Null Meal Number...");
            }
        }

        private void GetDatabaseTableRecordCount()
        {
            int DatabaseRecordCount = db_obj.GetDatabaseTableRecordCount();
            record_count_txt.Text = DatabaseRecordCount.ToString();
        }

        private void meal_details_Load(object sender, EventArgs e)
        {
            record_count_txt.Enabled = false;
            UpdateMealDetails_btn.Enabled = false;
            DeleteMealDetails_btn.Enabled = false;

            GetDatabaseTableRecordCount();
        }

        private void ResetMealDetails()
        {
            mealno_txt.Text = "";
            mealno_txt.Enabled = true;
            RegisterMealDetails_btn.Enabled = true;
            UpdateMealDetails_btn.Enabled = false;
            DeleteMealDetails_btn.Enabled = false;

            breakfast_chk.Checked = false;
            lunch_chk.Checked = false;
            dinner_chk.Checked = false;

            mealtype_txt.Text = "";
            mealName_txt.Text = "";
            mealquentity_txt.Text = "";
            mealprice_txt.Text = "";
            mealSts_cmb.Text = null;
            mealDescription_txt.Text = "";
        }

        private void ResetAllFeilds_btn_Click(object sender, EventArgs e)
        {
            ResetMealDetails();
        }

    }
}
