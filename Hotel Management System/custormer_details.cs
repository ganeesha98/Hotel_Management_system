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
    public partial class custormer_details : UserControl
    {
        public custormer_details()
        {
            InitializeComponent();
        }

        DatabaseConnectionForCustormerManagement db_obj = new DatabaseConnectionForCustormerManagement();

        public void AccessLocationCategories()
        {
            string[] GetLocationCategories = db_obj.GetLocationCategoriesAndTypes();

            for (int category = 0; category < GetLocationCategories.Length; category++)
            {
                if (GetLocationCategories[category] == null)
                {
                    break;
                }
                else
                {
                    f_Loc_category_cmb.Items.Add(GetLocationCategories[category]);
                    s_Loc_category_cmb.Items.Add(GetLocationCategories[category]);
                    t_Loc_category_cmb.Items.Add(GetLocationCategories[category]);
                }
            }
        }

        private void AccessEventsAndDecorations()
        {
            string[] GetEventNames = db_obj.GetEventNamesAndTypes();

            for (int EventName = 0; EventName < GetEventNames.Length; EventName++)
            {
                if (GetEventNames[EventName] == null)
                {
                    break;
                }
                else
                {
                    eventname_cmb.Items.Add(GetEventNames[EventName]);
                }
            }
        }

        private void AccessFirstDayMealNamesAndDetails()
        {
            string[] GetAvailableMealNames = db_obj.GetAvailableMealNames();

            for (int MealName = 0; MealName < GetAvailableMealNames.Length; MealName++)
            {
                if (GetAvailableMealNames[MealName] == null)
                {
                    break;
                }
                else
                {
                    f_f_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    f_s_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    f_f_lunch_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    f_s_lunch_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    f_f_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    f_s_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                }
            }
        }

        private void AccessSecondDayMealNamesAndDetails()
        {
            string[] GetAvailableMealNames = db_obj.GetAvailableMealNames();

            for (int MealName = 0; MealName < GetAvailableMealNames.Length; MealName++)
            {
                if (GetAvailableMealNames[MealName] == null)
                {
                    break;
                }
                else
                {
                    s_f_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    s_s_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    s_f_lunchName_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    s_s_lunch_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    s_f_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    s_s_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                }
            }
        }

        private void AccessThirdDayMealNamesAndDetails()
        {
            string[] GetAvailableMealNames = db_obj.GetAvailableMealNames();

            for (int MealName = 0; MealName < GetAvailableMealNames.Length; MealName++)
            {
                if (GetAvailableMealNames[MealName] == null)
                {
                    break;
                }
                else
                {
                    t_f_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    t_s_breakfast_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    t_f_lunch_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    t_s_lunch_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    t_f_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                    t_s_dinner_name_cmb.Items.Add(GetAvailableMealNames[MealName]);
                }
            }
        }

        private void AccessTravelingDetailsForVehicleDetails()
        {
            string[] GetAvailableVehicleCategories = db_obj.GetAvailableVehicleCategories();

            for (int VehicleType = 0; VehicleType < GetAvailableVehicleCategories.Length; VehicleType++)
            {
                if (GetAvailableVehicleCategories[VehicleType] == null)
                {
                    break;
                }
                else
                {
                 /*   f_vehicleType_cmb.Items.Add(GetAvailableVehicleCategories[VehicleType]);
                    s_vehicleType_cmb.Items.Add(GetAvailableVehicleCategories[VehicleType]);
                    t_vehicleType_cmb.Items.Add(GetAvailableVehicleCategories[VehicleType]);*/
                }
            }
        }

        public void AccessTravelingDetailsForPathDetails()
        {
            //f_DestinationName_cmb.Items.Clear();
            //s_DestinationName_cmb.Items.Clear();
            //t_DestinationName_cmb.Items.Clear();

            string[] GetAvailableDestinationNames = db_obj.GetAvailableDestinationNames();

            for (int DestinationName = 0; DestinationName < GetAvailableDestinationNames.Length; DestinationName++)
            {
                if (GetAvailableDestinationNames[DestinationName] == null)
                {
                    break;
                }
                else
                {
                    //f_DestinationName_cmb.Items.Add(GetAvailableDestinationNames[DestinationName]);
                    //s_DestinationName_cmb.Items.Add(GetAvailableDestinationNames[DestinationName]);
                    //t_DestinationName_cmb.Items.Add(GetAvailableDestinationNames[DestinationName]);
                }
            }
        }

        private void GetDatabaseTableRecordCount()
        {
            record_count_txt.Enabled = false;
            string DatabaseTableRecordCount = db_obj.GetDatabaseTableRecordCount().ToString();
            record_count_txt.Text = DatabaseTableRecordCount;
        }

        private void custormer_details_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
            metroTabControl1.SelectTab(0);
            GetDatabaseTableRecordCount();
            UpdateCustormerDetails_btn.Enabled = false;
            DeleteCustormerDetails_btn.Enabled = false;

            booking_dtpick.Value = System.DateTime.Now;
            checkin_dtpick.Value = System.DateTime.Now;
            checkout_dtpick.Value = System.DateTime.Now;

            offerstatus_cmb.SelectedIndex = -1;

            AccessLocationCategories();
            AccessEventsAndDecorations();
            AccessFirstDayMealNamesAndDetails();
            AccessSecondDayMealNamesAndDetails();
            AccessThirdDayMealNamesAndDetails();
            AccessTravelingDetailsForVehicleDetails();
            AccessTravelingDetailsForPathDetails();
        }

        private void f_Loc_category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Loc_type_cmb.Items.Clear();
            string GetLocationCategory = f_Loc_category_cmb.Text;

            string[] GetLocationTypes = db_obj.GetDistinctLocationTypes(GetLocationCategory);

            for (int LocTypes = 0; LocTypes < GetLocationTypes.Length; LocTypes++)
            {
                if (GetLocationTypes[LocTypes] == null)
                {
                    break;
                }
                else
                {
                    f_Loc_type_cmb.Items.Add(GetLocationTypes[LocTypes]);
                }
            }
        }

        private void s_Loc_category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_Loc_type_cmb.Items.Clear();
            string GetLocationCategory = s_Loc_category_cmb.Text;

            string[] GetLocationTypes = db_obj.GetDistinctLocationTypes(GetLocationCategory);

            for (int LocTypes = 0; LocTypes < GetLocationTypes.Length; LocTypes++)
            {
                if (GetLocationTypes[LocTypes] == null)
                {
                    break;
                }
                else
                {
                    s_Loc_type_cmb.Items.Add(GetLocationTypes[LocTypes]);
                }
            }
        }

        private void t_Loc_category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_Loc_type_cmb.Items.Clear();
            string GetLocationCategory = t_Loc_category_cmb.Text;

            string[] GetLocationTypes = db_obj.GetDistinctLocationTypes(GetLocationCategory);

            for (int LocTypes = 0; LocTypes < GetLocationTypes.Length; LocTypes++)
            {
                if (GetLocationTypes[LocTypes] == null)
                {
                    break;
                }
                else
                {
                    t_Loc_type_cmb.Items.Add(GetLocationTypes[LocTypes]);
                }
            }
        }

        private void f_Loc_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Loc_no_cmb.Items.Clear();
            string GetLocationCategory = f_Loc_category_cmb.Text;
            string GetLocationType = f_Loc_type_cmb.Text;

            string[] GetLocationNumbers = db_obj.GetSuatbleLocationNumbers(GetLocationCategory, GetLocationType);

            for (int LocationNo = 0; LocationNo < GetLocationNumbers.Length; LocationNo++)
            {
                if (GetLocationNumbers[LocationNo] == null)
                {
                    break;
                }
                else
                {
                    f_Loc_no_cmb.Items.Add(GetLocationNumbers[LocationNo]);
                }
            }
        }

        private void s_Loc_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_Loc_no_cmb.Items.Clear();
            string GetLocationCategory = s_Loc_category_cmb.Text;
            string GetLocationType = s_Loc_type_cmb.Text;

            string[] GetLocationNumbers = db_obj.GetSuatbleLocationNumbers(GetLocationCategory, GetLocationType);

            for (int LocationNo = 0; LocationNo < GetLocationNumbers.Length; LocationNo++)
            {
                if (GetLocationNumbers[LocationNo] == null)
                {
                    break;
                }
                else
                {
                    s_Loc_no_cmb.Items.Add(GetLocationNumbers[LocationNo]);
                }
            }
        }

        private void t_Loc_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_Loc_no_cmb.Items.Clear();
            string GetLocationCategory = t_Loc_category_cmb.Text;
            string GetLocationType = t_Loc_type_cmb.Text;

            string[] GetLocationNumbers = db_obj.GetSuatbleLocationNumbers(GetLocationCategory, GetLocationType);

            for (int LocationNo = 0; LocationNo < GetLocationNumbers.Length; LocationNo++)
            {
                if (GetLocationNumbers[LocationNo] == null)
                {
                    break;
                }
                else
                {
                    t_Loc_no_cmb.Items.Add(GetLocationNumbers[LocationNo]);
                }
            }
        }

        private void f_Loc_no_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Loc_guestquen_txt.Text = "";
            string GetLocationNo = f_Loc_no_cmb.Text;

            f_Loc_guestquen_txt.Text = db_obj.GetMaxPersonsOfLocation(GetLocationNo);
            f_Loc_price_txt.Text = db_obj.GetLocationPrice(GetLocationNo);
        }

        private void s_Loc_no_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_Loc_guestquen_txt.Text = "";
            string GetLocationNo = s_Loc_no_cmb.Text;

            s_Loc_guestquen_txt.Text = db_obj.GetMaxPersonsOfLocation(GetLocationNo);
            s_Loc_price_txt.Text = db_obj.GetLocationPrice(GetLocationNo);
        }

        private void t_Loc_no_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_Loc_guestquen_txt.Text = "";
            string GetLocationNo = t_Loc_no_cmb.Text;

            t_Loc_guestquen_txt.Text = db_obj.GetMaxPersonsOfLocation(GetLocationNo);
            t_Loc_price_txt.Text = db_obj.GetLocationPrice(GetLocationNo);
        }

        private void eventname_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            eventno_cmb.Items.Clear();
            string GetSelectedEventname = eventname_cmb.Text;

            string[] EventIDNumbers = db_obj.GetEventIDNumbers(GetSelectedEventname);

            for (int SelectedID = 0; SelectedID < EventIDNumbers.Length; SelectedID++)
            {
                if (EventIDNumbers[SelectedID] == null)
                {
                    break;
                }
                else
                {
                    eventno_cmb.Items.Add(EventIDNumbers[SelectedID]);
                }
            }
        }

        private void eventno_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            eventprice_txt.Text = "";
            string SelectedEventIDNumber = eventno_cmb.Text;

            eventprice_txt.Text = db_obj.GetSelectedEventPackagePrice(SelectedEventIDNumber);
        }

        private int ReplaceEmptyOrNullValues(string FeildValue)
        {
            int GetIntValue;

            try
            {
                GetIntValue = Convert.ToInt32(FeildValue);
            }
            catch (Exception)
            {
                GetIntValue = 0;
            }

            return GetIntValue;
        }

        private void CalculateTotalLocationPrice()
        {
            int FirstLocationPrice = ReplaceEmptyOrNullValues(f_Loc_price_txt.Text);
            int SecondLocationPrice = ReplaceEmptyOrNullValues(s_Loc_price_txt.Text);
            int ThirdLocationPrice = ReplaceEmptyOrNullValues(t_Loc_price_txt.Text);

            int EventPrice = ReplaceEmptyOrNullValues(eventprice_txt.Text);

            int TotalLocationOnlyPrice = FirstLocationPrice + SecondLocationPrice + ThirdLocationPrice;
            int TotalLocationPrice = FirstLocationPrice + SecondLocationPrice + ThirdLocationPrice + EventPrice;

            location_totalprice_txt.Text = TotalLocationPrice.ToString();
            DecorationPrice_txt.Text = EventPrice.ToString();
            LocationPrice_txt.Text = TotalLocationOnlyPrice.ToString();
            TotalLocationPrice_txt.Text = TotalLocationPrice.ToString();
        }

        private void eventprice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalLocationPrice();
        }

        private void booking_dtpick_ValueChanged(object sender, EventArgs e)
        {
            DateTime GetMinDate = booking_dtpick.Value;
            checkin_dtpick.MinDate = GetMinDate;
        }

        private void days_txt_TextChanged(object sender, EventArgs e)
        {
            DateTime GetCheckInDate = checkin_dtpick.Value;
            int GetNoOfDays = ReplaceEmptyOrNullValues(days_txt.Text);

            checkout_dtpick.Value = GetCheckInDate.AddDays(GetNoOfDays);
        }

        private void checkout_dtpick_ValueChanged(object sender, EventArgs e)
        {
            DateTime CheckInDate = checkin_dtpick.Value;
            DateTime CheckOutDate = checkout_dtpick.Value;
            string[] OfferStatus = db_obj.GetOfferStatusAvailability(CheckInDate, CheckOutDate);

            if (OfferStatus[1] != null)
            {
                offerstatus_cmb.SelectedItem = "Available";
            }
            else
            {
                offerstatus_cmb.SelectedItem = "Not Available";
            }
        }

        private void f_f_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = f_f_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_f_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_s_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = f_s_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_s_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_f_lunch_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = f_f_lunch_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_f_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_s_lunch_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = f_s_lunch_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_s_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_f_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = f_f_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_f_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_s_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = f_s_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    f_s_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void f_f_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_breakfast_price.Text = "";

            string GetSelectedMealName = f_f_breakfast_name_cmb.Text;
            string GetSelectedMealType = f_f_breakfastType_cmb.Text;
            f_f_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_f_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_s_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_breakfast_price.Text = "";

            string GetSelectedMealName = f_s_breakfast_name_cmb.Text;
            string GetSelectedMealType = f_s_breakfastType_cmb.Text;
            f_s_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_s_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_f_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_lunch_price.Text = "";

            string GetSelectedMealName = f_f_lunch_name_cmb.Text;
            string GetSelectedMealType = f_f_lunchType_cmb.Text;
            f_f_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_f_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_s_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_lunch_price.Text = "";

            string GetSelectedMealName = f_s_lunch_name_cmb.Text;
            string GetSelectedMealType = f_s_lunchType_cmb.Text;
            f_s_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_s_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_f_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_f_dinner_price.Text = "";

            string GetSelectedMealName = f_f_dinner_name_cmb.Text;
            string GetSelectedMealType = f_f_dinnerType_cmb.Text;
            f_f_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_f_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_s_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_s_dinner_price.Text = "";

            string GetSelectedMealName = f_s_dinner_name_cmb.Text;
            string GetSelectedMealType = f_s_dinnerType_cmb.Text;
            f_s_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            f_s_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void f_Loc_price_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalLocationPrice();
        }

        private void s_Loc_price_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalLocationPrice();
        }

        private void t_Loc_price_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalLocationPrice();
        }

        private void f_f_breakfastOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_f_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_f_breakfast_price.Text);

            f_f_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void f_s_breakfastOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_s_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_s_breakfast_price.Text);

            f_s_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void f_f_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_f_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_f_lunch_price.Text);

            f_f_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void f_s_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_s_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_s_lunch_price.Text);

            f_s_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void f_f_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_f_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_f_dinner_price.Text);

            f_f_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void f_s_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(f_s_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(f_s_dinner_price.Text);

            f_s_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void CalculateFirstDayTotalMealPrice()
        {
            int GetFirstBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(f_f_breakfastTotalPrice_txt.Text);
            int GetSecondBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(f_s_breakfastTotalPrice_txt.Text);

            int GetFirstLunchTotalMealPrice = ReplaceEmptyOrNullValues(f_f_lunchTotalPrice_txt.Text);
            int GetSecondLunchTotalMealPrice = ReplaceEmptyOrNullValues(f_s_lunchTotalPrice_txt.Text);

            int GetFirstDinnerTotalMealPrice = ReplaceEmptyOrNullValues(f_f_dinnerTotalPrice_txt.Text);
            int GetSecondDinnerTotalMealPrice = ReplaceEmptyOrNullValues(f_s_dinnerTotalPrice_txt.Text);

            int FirstDayTotalMealPrice = GetFirstBreakfastTotalMealPrice + GetSecondBreakfastTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstLunchTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstDinnerTotalMealPrice + GetSecondDinnerTotalMealPrice;

            FirstDayMealPrice_txt.Text = FirstDayTotalMealPrice.ToString();
            FirstDayTotalMealPrice_txt.Text = FirstDayTotalMealPrice.ToString();
        }

        private void CalculateSecondDayTotalMealPrice()
        {
            int GetFirstBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(s_f_breakfastTotalPrice_txt.Text);
            int GetSecondBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(s_s_breakfastTotalPrice_txt.Text);

            int GetFirstLunchTotalMealPrice = ReplaceEmptyOrNullValues(s_f_lunchTotalPrice_txt.Text);
            int GetSecondLunchTotalMealPrice = ReplaceEmptyOrNullValues(s_s_lunchTotalPrice_txt.Text);

            int GetFirstDinnerTotalMealPrice = ReplaceEmptyOrNullValues(s_f_dinnerTotalPrice_txt.Text);
            int GetSecondDinnerTotalMealPrice = ReplaceEmptyOrNullValues(s_s_dinnerTotalPrice_txt.Text);

            int SecondDayTotalMealPrice = GetFirstBreakfastTotalMealPrice + GetSecondBreakfastTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstLunchTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstDinnerTotalMealPrice + GetSecondDinnerTotalMealPrice;

            SecondDayMealPrice_txt.Text = SecondDayTotalMealPrice.ToString();
            SecondDayTotalMealPrice_txt.Text = SecondDayTotalMealPrice.ToString();
        }

        private void CalculateThirdDayTotalMealPrice()
        {
            int GetFirstBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(t_f_breakfastTotalPrice_txt.Text);
            int GetSecondBreakfastTotalMealPrice = ReplaceEmptyOrNullValues(t_s_breakfastTotalPrice_txt.Text);

            int GetFirstLunchTotalMealPrice = ReplaceEmptyOrNullValues(t_f_lunchTotalPrice_txt.Text);
            int GetSecondLunchTotalMealPrice = ReplaceEmptyOrNullValues(t_s_lunchTotalPrice_txt.Text);

            int GetFirstDinnerTotalMealPrice = ReplaceEmptyOrNullValues(t_f_dinnerTotalPrice_txt.Text);
            int GetSecondDinnerTotalMealPrice = ReplaceEmptyOrNullValues(t_s_dinnerTotalPrice_txt.Text);

            int ThirdDayTotalMealPrice = GetFirstBreakfastTotalMealPrice + GetSecondBreakfastTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstLunchTotalMealPrice + GetSecondLunchTotalMealPrice + GetFirstDinnerTotalMealPrice + GetSecondDinnerTotalMealPrice;

            ThirdDayMealPrice_txt.Text = ThirdDayTotalMealPrice.ToString();
            ThirdDayTotalMealPrice_txt.Text = ThirdDayTotalMealPrice.ToString();
        }

        private void f_f_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void f_s_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void f_f_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void f_s_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void f_f_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void f_s_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateFirstDayTotalMealPrice();
        }

        private void s_f_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = s_f_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_f_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_s_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = s_s_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_s_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_f_lunchName_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = s_f_lunchName_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_f_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_s_lunch_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = s_s_lunch_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_s_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_f_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = s_f_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_f_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_s_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = s_s_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    s_s_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void s_f_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_breakfast_price.Text = "";

            string GetSelectedMealName = s_f_breakfast_name_cmb.Text;
            string GetSelectedMealType = s_f_breakfastType_cmb.Text;
            s_f_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_f_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_s_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_breakfast_price.Text = "";

            string GetSelectedMealName = s_s_breakfast_name_cmb.Text;
            string GetSelectedMealType = s_s_breakfastType_cmb.Text;
            s_s_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_s_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_f_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_lunch_price.Text = "";

            string GetSelectedMealName = s_f_lunchName_cmb.Text;
            string GetSelectedMealType = s_f_lunchType_cmb.Text;
            s_f_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_f_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_s_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_lunch_price.Text = "";

            string GetSelectedMealName = s_s_lunch_name_cmb.Text;
            string GetSelectedMealType = s_s_lunchType_cmb.Text;
            s_s_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_s_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_f_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_f_dinner_price.Text = "";

            string GetSelectedMealName = s_f_dinner_name_cmb.Text;
            string GetSelectedMealType = s_f_dinnerType_cmb.Text;
            s_f_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_f_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_s_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_s_dinner_price.Text = "";

            string GetSelectedMealName = s_s_dinner_name_cmb.Text;
            string GetSelectedMealType = s_s_dinnerType_cmb.Text;
            s_s_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            s_s_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void s_f_breakfastOrderedQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_f_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_f_breakfast_price.Text);

            s_f_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_s_breakfastOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_s_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_s_breakfast_price.Text);

            s_s_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_f_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_f_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_f_lunch_price.Text);

            s_f_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_s_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_s_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_s_lunch_price.Text);

            s_s_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_f_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_f_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_f_dinner_price.Text);

            s_f_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_s_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(s_s_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(s_s_dinner_price.Text);

            s_s_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void s_f_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void s_s_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void s_f_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void s_s_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void s_f_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void s_s_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateSecondDayTotalMealPrice();
        }

        private void t_f_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = t_f_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_f_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_s_breakfast_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_breakfastType_cmb.Items.Clear();

            string GetSelectedMealName = t_s_breakfast_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_s_breakfastType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_f_lunch_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = t_f_lunch_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_f_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_s_lunch_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_lunchType_cmb.Items.Clear();

            string GetSelectedMealName = t_s_lunch_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_s_lunchType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_f_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = t_f_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_f_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_s_dinner_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_dinnerType_cmb.Items.Clear();

            string GetSelectedMealName = t_s_dinner_name_cmb.Text;
            string[] GetAvailableMealTypes = db_obj.GetAvailableMealTypes(GetSelectedMealName);

            for (int MealType = 0; MealType < GetAvailableMealTypes.Length; MealType++)
            {
                if (GetAvailableMealTypes[MealType] == null)
                {
                    break;
                }
                else
                {
                    t_s_dinnerType_cmb.Items.Add(GetAvailableMealTypes[MealType]);
                }
            }
        }

        private void t_f_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_breakfast_price.Text = "";

            string GetSelectedMealName = t_f_breakfast_name_cmb.Text;
            string GetSelectedMealType = t_f_breakfastType_cmb.Text;
            t_f_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_f_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_s_breakfastType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_breakfast_price.Text = "";

            string GetSelectedMealName = t_s_breakfast_name_cmb.Text;
            string GetSelectedMealType = t_s_breakfastType_cmb.Text;
            t_s_breakfast_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_s_breakfastQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_f_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_lunch_price.Text = "";

            string GetSelectedMealName = t_f_lunch_name_cmb.Text;
            string GetSelectedMealType = t_f_lunchType_cmb.Text;
            t_f_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_f_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_s_lunchType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_lunch_price.Text = "";

            string GetSelectedMealName = t_s_lunch_name_cmb.Text;
            string GetSelectedMealType = t_s_lunchType_cmb.Text;
            t_s_lunch_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_s_lunchQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_f_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_f_dinner_price.Text = "";

            string GetSelectedMealName = t_f_dinner_name_cmb.Text;
            string GetSelectedMealType = t_f_dinnerType_cmb.Text;
            t_f_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_f_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_s_dinnerType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_s_dinner_price.Text = "";

            string GetSelectedMealName = t_s_dinner_name_cmb.Text;
            string GetSelectedMealType = t_s_dinnerType_cmb.Text;
            t_s_dinner_price.Text = db_obj.GetAvailableMealPrice(GetSelectedMealName, GetSelectedMealType).ToString();
            t_s_dinnerQuentity_txt.Text = db_obj.GetAvailableMealQuentity(GetSelectedMealName, GetSelectedMealType);
        }

        private void t_f_breakfastOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_f_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_f_breakfast_price.Text);

            t_f_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_s_breakfastOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_s_breakfastOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_s_breakfast_price.Text);

            t_s_breakfastTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_f_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_f_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_f_lunch_price.Text);

            t_f_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_s_lunchOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_s_lunchOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_s_lunch_price.Text);

            t_s_lunchTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_f_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_f_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_f_dinner_price.Text);

            t_f_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_s_dinnerOrderQuentity_txt_TextChanged(object sender, EventArgs e)
        {
            int GetOrderdMealQuentity = ReplaceEmptyOrNullValues(t_s_dinnerOrderQuentity_txt.Text);
            int GetOrderedMealPrice = ReplaceEmptyOrNullValues(t_s_dinner_price.Text);

            t_s_dinnerTotalPrice_txt.Text = (GetOrderedMealPrice * GetOrderdMealQuentity).ToString();
        }

        private void t_f_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void t_s_breakfastTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void t_f_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void t_s_lunchTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void t_f_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void t_s_dinnerTotalPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateThirdDayTotalMealPrice();
        }

        private void f_vehicleType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //f_vehicleNo_cmb.Items.Clear();

            //string GetSelectedVehicleType = f_vehicleType_cmb.Text;
            //string[] GetSelectedVehicleNoS = db_obj.GetSelectedVehicleNos(GetSelectedVehicleType);

            //for (int VehicleNumber = 0; VehicleNumber < GetSelectedVehicleNoS.Length; VehicleNumber++)
            //{
            //    if (GetSelectedVehicleNoS[VehicleNumber] == null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        f_vehicleNo_cmb.Items.Add(GetSelectedVehicleNoS[VehicleNumber]);
            //    }
            //}
        }

        private void s_vehicleType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //s_vehicleNo_cmb.Items.Clear();

            //string GetSelectedVehicleType = s_vehicleType_cmb.Text;
            //string[] GetSelectedVehicleNoS = db_obj.GetSelectedVehicleNos(GetSelectedVehicleType);

            //for (int VehicleNumber = 0; VehicleNumber < GetSelectedVehicleNoS.Length; VehicleNumber++)
            //{
            //    if (GetSelectedVehicleNoS[VehicleNumber] == null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        s_vehicleNo_cmb.Items.Add(GetSelectedVehicleNoS[VehicleNumber]);
            //    }
            //}
        }

        private void t_vehicleType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t_vehicleNo_cmb.Items.Clear();

            //string GetSelectedVehicleType = t_vehicleType_cmb.Text;
            //string[] GetSelectedVehicleNoS = db_obj.GetSelectedVehicleNos(GetSelectedVehicleType);

            //for (int VehicleNumber = 0; VehicleNumber < GetSelectedVehicleNoS.Length; VehicleNumber++)
            //{
            //    if (GetSelectedVehicleNoS[VehicleNumber] == null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        t_vehicleNo_cmb.Items.Add(GetSelectedVehicleNoS[VehicleNumber]);
            //    }
            //}
        }

        private void f_vehicleNo_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //f_vehiclePassengers_txt.Text = "";

            //string GetSelectedVehicleNo = f_vehicleNo_cmb.Text;
            //string[] AvailablePassengersAndPrice = db_obj.GetAvailableNumberOfPassengers(GetSelectedVehicleNo);

            //f_vehiclePassengers_txt.Text = AvailablePassengersAndPrice[0];
            //f_VehiclePrice_txt.Text = AvailablePassengersAndPrice[1];
        }

        private void s_vehicleNo_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //s_vehiclePassengers_txt.Text = "";

            //string GetSelectedVehicleNo = s_vehicleNo_cmb.Text;
            //string[] AvailablePassengersAndPrice = db_obj.GetAvailableNumberOfPassengers(GetSelectedVehicleNo);

            //s_vehiclePassengers_txt.Text = AvailablePassengersAndPrice[0];
            //s_VehiclePrice_txt.Text = AvailablePassengersAndPrice[1];
        }

        private void t_vehicleNo_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t_vehiclePassengers_txt.Text = "";

            //string GetSelectedVehicleNo = t_vehicleNo_cmb.Text;
            //string[] AvailablePassengersAndPrice = db_obj.GetAvailableNumberOfPassengers(GetSelectedVehicleNo);

            //t_vehiclePassengers_txt.Text = AvailablePassengersAndPrice[0];
            //t_VehiclePrice_txt.Text = AvailablePassengersAndPrice[1];
        }

        private void CalculateTotalTravelingPrice()
        {
            //int GetFirstVehiclePrice = ReplaceEmptyOrNullValues(f_VehiclePrice_txt.Text);
            //int GetSecondVehiclePrice = ReplaceEmptyOrNullValues(s_VehiclePrice_txt.Text);
            //int GetThirdVehiclePrice = ReplaceEmptyOrNullValues(t_VehiclePrice_txt.Text);

            //int GetFirstDestinationPrice = ReplaceEmptyOrNullValues(f_PathPrice_txt.Text);
            //int GetSecondDestinationPrice = ReplaceEmptyOrNullValues(s_PathPrice_txt.Text);
            //int GetThirdDestinationPrice = ReplaceEmptyOrNullValues(t_PathPrice_txt.Text);

            //int GetVehicleOnlyPrice = GetFirstVehiclePrice + GetSecondVehiclePrice + GetThirdVehiclePrice;
            //int GetDestinationOnlyPrice = GetFirstDestinationPrice + GetSecondDestinationPrice + GetThirdDestinationPrice;

            //VehiclePrice_txt.Text = GetVehicleOnlyPrice.ToString();
            //DestinationPrice_txt.Text = GetDestinationOnlyPrice.ToString();
            //TotalTravelPrice_txt.Text = (GetVehicleOnlyPrice + GetDestinationOnlyPrice).ToString();
            //TotalTravelingPrice_txt.Text = (GetVehicleOnlyPrice + GetDestinationOnlyPrice).ToString();
        }

        private void f_VehiclePrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private void s_VehiclePrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private void t_VehiclePrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private bool CheckValueIsNumeric(string Value)
        {
            long GetValue;

            try
            {
                GetValue = long.Parse(Value);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void f_pathType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //f_pathNo_cmb.Items.Clear();

            //string GetSelectedDestinationName = f_DestinationName_cmb.Text;
            //string[] GetAvailablePathNames = db_obj.GetAvailableDestinationNo(GetSelectedDestinationName);

            //for (int PathName = 0; PathName < GetAvailablePathNames.Length; PathName++)
            //{
            //    if (GetAvailablePathNames[PathName] == null || CheckValueIsNumeric(GetAvailablePathNames[PathName]) == true)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        f_pathNo_cmb.Items.Add(GetAvailablePathNames[PathName]);
            //    }
            //}

            //f_PathPrice_txt.Text = GetAvailablePathNames[(GetAvailablePathNames.Length) - 1];
        }

        private void s_pathType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //s_pathNo_cmb.Items.Clear();

            //string GetSelectedDestinationName = s_DestinationName_cmb.Text;
            //string[] GetAvailablePathNames = db_obj.GetAvailableDestinationNo(GetSelectedDestinationName);

            //for (int PathName = 0; PathName < GetAvailablePathNames.Length; PathName++)
            //{
            //    if (GetAvailablePathNames[PathName] == null || CheckValueIsNumeric(GetAvailablePathNames[PathName]) == true)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        s_pathNo_cmb.Items.Add(GetAvailablePathNames[PathName]);
            //    }
            //}

            //s_PathPrice_txt.Text = GetAvailablePathNames[(GetAvailablePathNames.Length) - 1];
        }

        private void t_pathType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t_pathNo_cmb.Items.Clear();

            //string GetSelectedDestinationName = t_DestinationName_cmb.Text;
            //string[] GetAvailablePathNames = db_obj.GetAvailableDestinationNo(GetSelectedDestinationName);

            //for (int PathName = 0; PathName < GetAvailablePathNames.Length; PathName++)
            //{
            //    if (GetAvailablePathNames[PathName] == null || CheckValueIsNumeric(GetAvailablePathNames[PathName]) == true)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        t_pathNo_cmb.Items.Add(GetAvailablePathNames[PathName]);
            //    }
            //}

            //t_PathPrice_txt.Text = GetAvailablePathNames[(GetAvailablePathNames.Length) - 1];
        }

        private void f_PathPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private void s_PathPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private void t_PathPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalTravelingPrice();
        }

        private void CalculateAllDayMealTotalAmount()
        {
            int GetFistDayTotalMealAmount = ReplaceEmptyOrNullValues(FirstDayMealPrice_txt.Text);
            int GetSecondDayTotalMealAmount = ReplaceEmptyOrNullValues(SecondDayMealPrice_txt.Text);
            int GetThirdDayTotalMealAmount = ReplaceEmptyOrNullValues(ThirdDayMealPrice_txt.Text);

            int GetTotalMealAmount = GetFistDayTotalMealAmount + GetSecondDayTotalMealAmount + GetThirdDayTotalMealAmount;

            TotalMealPrice_txt.Text = GetTotalMealAmount.ToString();
        }

        private void FirstDayMealPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateAllDayMealTotalAmount();
        }

        private void SecondDayMealPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateAllDayMealTotalAmount();
        }

        private void ThirdDayMealPrice_txt_TextChanged(object sender, EventArgs e)
        {
            CalculateAllDayMealTotalAmount();
        }

        private void GetTotalBillAmount()
        {
            int TotalLocationPrice = ReplaceEmptyOrNullValues(TotalLocationPrice_txt.Text);
            int TotalMealPrice = ReplaceEmptyOrNullValues(TotalMealPrice_txt.Text);
            int TotalTravellingPrice = ReplaceEmptyOrNullValues(TotalTravelPrice_txt.Text);

            int GetTotalAmount = TotalLocationPrice + TotalMealPrice + TotalTravellingPrice;
            TotalBillAmount_txt.Text = GetTotalAmount.ToString();
        }

        private void TotalLocationPrice_txt_TextChanged(object sender, EventArgs e)
        {
            GetTotalBillAmount();
        }

        private void TotalMealPrice_txt_TextChanged(object sender, EventArgs e)
        {
            GetTotalBillAmount();
        }

        private void TotalTravelPrice_txt_TextChanged(object sender, EventArgs e)
        {
            GetTotalBillAmount();
        }

        private int GetOfferValueForCalculateNetAmount()
        {
            int SelectedOfferValue;
            string[] OfferValue = db_obj.GetOfferStatusAvailability(checkin_dtpick.Value, checkout_dtpick.Value);

            if (OfferValue[0] == null)
            {
                SelectedOfferValue = 0;
            }
            else
            {
                SelectedOfferValue = Convert.ToInt32(OfferValue[0]);
            }

            return SelectedOfferValue;
        }

        private void TotalBillAmount_txt_TextChanged(object sender, EventArgs e)
        {
            int OfferPercentage = (100 - GetOfferValueForCalculateNetAmount());
            float CalculatedTotalNetAmount = Convert.ToInt32(TotalBillAmount_txt.Text) * (OfferPercentage / 100f);

            TotalNetAmount_txt.Text = CalculatedTotalNetAmount.ToString();
        }

        private void CalculateTotalGuest_btn_Click(object sender, EventArgs e)
        {
            int ChildGuestQuentity = ReplaceEmptyOrNullValues(childguest_txt.Text);
            int ElderGuestQuentity = ReplaceEmptyOrNullValues(elderguest_txt.Text);

            totalguest_txt.Text = (ChildGuestQuentity + ElderGuestQuentity).ToString();
        }

        private bool GettingPersonalInfoAndReservationInfo()
        {
            try
            {
                //Personal Details Informations
                string NameTitle = nameini_cmb.Text;
                string NameWithInitials = nameini_txt.Text;
                string FullName = fullname_txt.Text;
                string Telephone_01 = tel1_txt.Text;
                string Telephone_02 = tel2_txt.Text;
                string EmailAddress = emailaddress_txt.Text;
                string NicNumber = nic_txt.Text;

                //Guest Quentity Informations
                int ChildGuestQuentity = ReplaceEmptyOrNullValues(childguest_txt.Text);
                int EldersGuestQuentity = ReplaceEmptyOrNullValues(elderguest_txt.Text);
                int TotalGuestQuentity = ReplaceEmptyOrNullValues(totalguest_txt.Text);

                //Reservation Details
                DateTime BookInDate = booking_dtpick.Value;
                DateTime CheckInDate = checkin_dtpick.Value;
                int No_Of_Days = ReplaceEmptyOrNullValues(days_txt.Text);
                DateTime CheckOutDate = checkout_dtpick.Value;
                string OfferAvailabilityStatus = offerstatus_cmb.Text;

                if ((CheckValueIsNumeric(NicNumber) == true) && (NicNumber.Length == 9 || NicNumber.Length == 12))
                {
                    db_obj.InitializingPersonalInfoAndReservationInfo(NameTitle, NameWithInitials, FullName, Telephone_01, Telephone_02, EmailAddress, NicNumber, ChildGuestQuentity, EldersGuestQuentity, TotalGuestQuentity, BookInDate, CheckInDate, No_Of_Days, CheckOutDate, OfferAvailabilityStatus);
                }
                else
                {
                    MessageBox.Show("Please Enter Your ID Number Correctly...", "Invalid Or Empty ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool GetingLocationDetailsForReservation()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Location Categories 
                string FirstLocationCategory = f_Loc_category_cmb.Text;
                string SecondLocationCategory = s_Loc_category_cmb.Text;
                string ThirdLocationCategory = t_Loc_category_cmb.Text;

                //Location Types
                string FirstLocationType = f_Loc_type_cmb.Text;
                string SecondLocationType = s_Loc_type_cmb.Text;
                string ThirdLocationType = t_Loc_type_cmb.Text;

                //Location Numbers
                string FirstLocationNumber = f_Loc_no_cmb.Text;
                string SecondLocationNumber = s_Loc_no_cmb.Text;
                string ThirdLocationNumber = t_Loc_no_cmb.Text;

                //Number Of Max Guests In The Locations
                string FirstLocationGuestQuentity = f_Loc_guestquen_txt.Text;
                string SecondLocationGuestQuentity = s_Loc_guestquen_txt.Text;
                string ThirdLocationGuestQuentity = t_Loc_guestquen_txt.Text;

                //Location Prices
                string FirstLocationPrice = f_Loc_price_txt.Text;
                string SecondLocationPrice = s_Loc_price_txt.Text;
                string ThirdLocationPrice = t_Loc_price_txt.Text;

                //Events Details
                string EventName = eventname_cmb.Text;
                string EventNumber = eventno_cmb.Text;
                string EventPrice = eventprice_txt.Text;

                //Total Location Price
                string TotalLocationPrice = TotalLocationPrice_txt.Text;

                db_obj.InitializeLocationInfoAndEventInfo(FirstLocationCategory, SecondLocationCategory, ThirdLocationCategory, FirstLocationType, SecondLocationType, ThirdLocationType, FirstLocationNumber, SecondLocationNumber, ThirdLocationNumber, FirstLocationGuestQuentity, SecondLocationGuestQuentity, ThirdLocationGuestQuentity, FirstLocationPrice, SecondLocationPrice, ThirdLocationPrice, EventName, EventNumber, EventPrice, TotalLocationPrice, NicNumber);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool GetingFirstDayMealDetailsForReservation()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //First Day Breakfast Details
                string FirstBreakfastName = f_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = f_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = f_f_breakfastType_cmb.Text;
                string SecondBreakfastType = f_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = f_f_breakfast_price.Text;
                string SecondBreakfastPrice = f_s_breakfast_price.Text;
                string FirstBreakfastQuentity = f_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = f_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = f_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = f_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = f_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = f_s_breakfastTotalPrice_txt.Text;

                //First Day Lunch Details
                string FirstLunchName = f_f_lunch_name_cmb.Text;
                string SecondLunchName = f_s_lunch_name_cmb.Text;
                string FirstLunchType = f_f_lunchType_cmb.Text;
                string SecondLunchType = f_s_lunchType_cmb.Text;
                string FirstLunchPrice = f_f_lunch_price.Text;
                string SecondLunchPrice = f_s_lunch_price.Text;
                string FirstLunchQuentity = f_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = f_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = f_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = f_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = f_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = f_s_lunchTotalPrice_txt.Text;

                //First Day Dinner Details
                string FirstDinnerName = f_f_dinner_name_cmb.Text;
                string SecondDinnerName = f_s_dinner_name_cmb.Text;
                string FirstDinnerType = f_f_dinnerType_cmb.Text;
                string SecondDinnerType = f_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = f_f_dinner_price.Text;
                string SecondDinnerPrice = f_s_dinner_price.Text;
                string FirstDinnerQuentity = f_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = f_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = f_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = f_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = f_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = f_s_dinnerTotalPrice_txt.Text;

                string FirstDayTotalMealPrice = FirstDayMealPrice_txt.Text;

                db_obj.InitializeFirstDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, FirstDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool GetingSecondDayMealDetailsForReservation()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Second Day Breakfast Details
                string FirstBreakfastName = s_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = s_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = s_f_breakfastType_cmb.Text;
                string SecondBreakfastType = s_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = s_f_breakfast_price.Text;
                string SecondBreakfastPrice = s_s_breakfast_price.Text;
                string FirstBreakfastQuentity = s_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = s_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = s_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = s_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = s_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = s_s_breakfastTotalPrice_txt.Text;

                //Second Day Lunch Details
                string FirstLunchName = s_f_lunchName_cmb.Text;
                string SecondLunchName = s_s_lunch_name_cmb.Text;
                string FirstLunchType = s_f_lunchType_cmb.Text;
                string SecondLunchType = s_s_lunchType_cmb.Text;
                string FirstLunchPrice = s_f_lunch_price.Text;
                string SecondLunchPrice = s_s_lunch_price.Text;
                string FirstLunchQuentity = s_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = s_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = s_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = s_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = s_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = s_s_lunchTotalPrice_txt.Text;

                //Second Day Dinner Details
                string FirstDinnerName = s_f_dinner_name_cmb.Text;
                string SecondDinnerName = s_s_dinner_name_cmb.Text;
                string FirstDinnerType = s_f_dinnerType_cmb.Text;
                string SecondDinnerType = s_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = s_f_dinner_price.Text;
                string SecondDinnerPrice = s_s_dinner_price.Text;
                string FirstDinnerQuentity = s_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = s_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = s_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = s_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = s_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = s_s_dinnerTotalPrice_txt.Text;

                string SecondDayTotalMealPrice = SecondDayMealPrice_txt.Text;

                db_obj.InitializeSecondDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, SecondDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool GetingThirdDayMealDetailsForReservation()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Third Day Breakfast Details
                string FirstBreakfastName = t_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = t_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = t_f_breakfastType_cmb.Text;
                string SecondBreakfastType = t_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = t_f_breakfast_price.Text;
                string SecondBreakfastPrice = t_s_breakfast_price.Text;
                string FirstBreakfastQuentity = t_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = t_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = t_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = t_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = t_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = t_s_breakfastTotalPrice_txt.Text;

                //Second Day Lunch Details
                string FirstLunchName = t_f_lunch_name_cmb.Text;
                string SecondLunchName = t_s_lunch_name_cmb.Text;
                string FirstLunchType = t_f_lunchType_cmb.Text;
                string SecondLunchType = t_s_lunchType_cmb.Text;
                string FirstLunchPrice = t_f_lunch_price.Text;
                string SecondLunchPrice = t_s_lunch_price.Text;
                string FirstLunchQuentity = t_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = t_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = t_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = t_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = t_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = t_s_lunchTotalPrice_txt.Text;

                //Second Day Dinner Details
                string FirstDinnerName = t_f_dinner_name_cmb.Text;
                string SecondDinnerName = t_s_dinner_name_cmb.Text;
                string FirstDinnerType = t_f_dinnerType_cmb.Text;
                string SecondDinnerType = t_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = t_f_dinner_price.Text;
                string SecondDinnerPrice = t_s_dinner_price.Text;
                string FirstDinnerQuentity = t_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = t_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = t_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = t_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = t_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = t_s_dinnerTotalPrice_txt.Text;

                string ThirdDayTotalMealPrice = ThirdDayMealPrice_txt.Text;

                db_obj.InitializeThirdDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, ThirdDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //private bool GettingTravelingInfoForReservation()
        //{
        //    //try
        //    //{
        //    //    string NicNumber = nic_txt.Text;

        //    //    string FirstVehicleType = f_vehicleType_cmb.Text;
        //    //    string SecondVehicleType = s_vehicleType_cmb.Text;
        //    //    string ThirdVehicleType = t_vehicleType_cmb.Text;

        //    //    string FirstVehicleNumber = f_vehicleNo_cmb.Text;
        //    //    string SecondVehicleNumber = s_vehicleNo_cmb.Text;
        //    //    string ThirdVehicleNumber = t_vehicleNo_cmb.Text;

        //    //    string FirstVehiclePassengers = f_vehiclePassengers_txt.Text;
        //    //    string SecondVehiclePassengers = s_vehiclePassengers_txt.Text;
        //    //    string ThirdVehiclePassengers = t_vehiclePassengers_txt.Text;

        //    //    string FirstVehiclePrice = f_VehiclePrice_txt.Text;
        //    //    string SecondVehiclePrice = s_VehiclePrice_txt.Text;
        //    //    string ThirdVehiclePrice = t_VehiclePrice_txt.Text;

        //    //    string FirstDestinationName = f_DestinationName_cmb.Text;
        //    //    string SecondDestinationName = s_DestinationName_cmb.Text;
        //    //    string ThirdDestinationName = t_DestinationName_cmb.Text;

        //    //    string FirstDestinationPathNumber = f_pathNo_cmb.Text;
        //    //    string SecondDestinationPathNumber = s_pathNo_cmb.Text;
        //    //    string ThirdDestinationPathNumber = t_pathNo_cmb.Text;

        //    //    string FirstDestinationPrice = f_PathPrice_txt.Text;
        //    //    string SecondDestinationPrice = s_PathPrice_txt.Text;
        //    //    string ThirdDestinationPrice = t_PathPrice_txt.Text;

        //    //    string TotalTravelingPrice = TotalTravelingPrice_txt.Text;

        //    //    db_obj.InitializeTravelingInfoForReservation(NicNumber, FirstVehicleType, SecondVehicleType, ThirdVehicleType, FirstVehicleNumber, SecondVehicleNumber, ThirdVehicleNumber, FirstVehiclePassengers, SecondVehiclePassengers, ThirdVehiclePassengers, FirstVehiclePrice, SecondVehiclePrice, ThirdVehiclePrice, FirstDestinationName, SecondDestinationName, ThirdDestinationName, FirstDestinationPathNumber, SecondDestinationPathNumber, ThirdDestinationPathNumber, FirstDestinationPrice, SecondDestinationPrice, ThirdDestinationPrice, TotalTravelingPrice);
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return false;
        //    //}

        //    //return true;
        //}

        private bool MakeBillForReservationDetails()
        {
            try
            {
                string BillNo = record_count_txt.Text;
                string NicNumber = nic_txt.Text;
                string BillAmount = TotalBillAmount_txt.Text;
                string NetAmount = TotalNetAmount_txt.Text;
                string AdvanceAmountSts = "Not Payed";
                string FinalAmountSts = "Not Payed";
                DateTime AdvanceAmountDueDate = System.DateTime.Now;
                DateTime FinalAmountDueDate = System.DateTime.Now;
                string CompleteAmountSts = BillStatus_cmb.Text;
                string OfferValue = Convert.ToString(GetOfferValueForCalculateNetAmount());

                db_obj.InitializeBillDetailsForReservation(BillNo,NicNumber, BillAmount, NetAmount, AdvanceAmountSts, FinalAmountSts, CompleteAmountSts, OfferValue, AdvanceAmountDueDate, FinalAmountDueDate);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void MakeReservation_btn_Click(object sender, EventArgs e)
        {
            //i have to add record number count for this posittion
            //but i have to check these function true

            if (GettingPersonalInfoAndReservationInfo() == true && GetingLocationDetailsForReservation() == true && GetingFirstDayMealDetailsForReservation() == true && GetingSecondDayMealDetailsForReservation() == true && GetingThirdDayMealDetailsForReservation() == true  && MakeBillForReservationDetails() == true)
            {
                GetDatabaseTableRecordCount();
                string DatabaseTableRecordCount = db_obj.GetDatabaseTableRecordCount().ToString();
                MessageBox.Show("Custormer Reservation Sucessfully.....", "Custormer Reservation....");
                MessageBox.Show("Custormer Bill No : ",  int.Parse((DatabaseTableRecordCount)) - 1);
            }
            else
            {
                MessageBox.Show("There Is Some Error Occured While Reservation...", "Database Or SQL Error...");
            }
        }

        private bool GettingDetailsOfPersonalInfoAndReservationInfo()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerDetails = db_obj.GetCustormerPersonalInfoAndReservationInfo(NicNumber);

            if (RecivedCustormerDetails[0] == null)
            {
                return false;
            }
            else
            {
                nameini_cmb.Text = RecivedCustormerDetails[0];
                nameini_txt.Text = RecivedCustormerDetails[1];
                fullname_txt.Text = RecivedCustormerDetails[2];
                tel1_txt.Text = RecivedCustormerDetails[3];
                tel2_txt.Text = RecivedCustormerDetails[4];
                emailaddress_txt.Text = RecivedCustormerDetails[5];
                childguest_txt.Text = RecivedCustormerDetails[6];
                elderguest_txt.Text = RecivedCustormerDetails[7];
                totalguest_txt.Text = RecivedCustormerDetails[8];
                booking_dtpick.Value = Convert.ToDateTime(RecivedCustormerDetails[9]);
                checkin_dtpick.Value = Convert.ToDateTime(RecivedCustormerDetails[10]);
                days_txt.Text = RecivedCustormerDetails[11];
                checkout_dtpick.Value = Convert.ToDateTime(RecivedCustormerDetails[12]);

                return true;
            }
        }

        private void GettingDetailsOfLocationInfoAndDecorationInfo()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerDetails = db_obj.GetCustormerLocationInfoAndDecorationInfo(NicNumber);

            f_Loc_category_cmb.Text = RecivedCustormerDetails[1];
            s_Loc_category_cmb.Text = RecivedCustormerDetails[2];
            t_Loc_category_cmb.Text = RecivedCustormerDetails[3];

            f_Loc_type_cmb.Text = RecivedCustormerDetails[4];
            s_Loc_type_cmb.Text = RecivedCustormerDetails[5];
            t_Loc_type_cmb.Text = RecivedCustormerDetails[6];

            f_Loc_no_cmb.Text = RecivedCustormerDetails[7];
            s_Loc_no_cmb.Text = RecivedCustormerDetails[8];
            t_Loc_no_cmb.Text = RecivedCustormerDetails[9];

            eventname_cmb.Text = RecivedCustormerDetails[16];
            eventno_cmb.Text = RecivedCustormerDetails[17];
        }

        private void GettingDetailsOfFirstMealInfo()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerDetails = db_obj.GetCustormerMealDetails(NicNumber);

            f_f_breakfast_name_cmb.Text = RecivedCustormerDetails[0];
            f_s_breakfast_name_cmb.Text = RecivedCustormerDetails[1];

            f_f_breakfastType_cmb.Text = RecivedCustormerDetails[2];
            f_s_breakfastType_cmb.Text = RecivedCustormerDetails[3];

            f_f_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[6];
            f_s_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[7];

            f_f_lunch_name_cmb.Text = RecivedCustormerDetails[10];
            f_s_lunch_name_cmb.Text = RecivedCustormerDetails[11];

            f_f_lunchType_cmb.Text = RecivedCustormerDetails[12];
            f_s_lunchType_cmb.Text = RecivedCustormerDetails[13];

            f_f_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[16];
            f_s_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[17];

            f_f_dinner_name_cmb.Text = RecivedCustormerDetails[20];
            f_s_dinner_name_cmb.Text = RecivedCustormerDetails[21];

            f_f_dinnerType_cmb.Text = RecivedCustormerDetails[22];
            f_s_dinnerType_cmb.Text = RecivedCustormerDetails[23];

            f_f_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[26];
            f_s_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[27];
        }

        public void GettingDetailsOfSecondMealInfo()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerDetails = db_obj.GetCustormerSecondMealDetails(NicNumber);

            s_f_breakfast_name_cmb.Text = RecivedCustormerDetails[0];
            s_s_breakfast_name_cmb.Text = RecivedCustormerDetails[1];

            s_f_breakfastType_cmb.Text = RecivedCustormerDetails[2];
            s_s_breakfastType_cmb.Text = RecivedCustormerDetails[3];

            s_f_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[6];
            s_s_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[7];

            s_f_lunchName_cmb.Text = RecivedCustormerDetails[10];
            s_s_lunch_name_cmb.Text = RecivedCustormerDetails[11];

            s_f_lunchType_cmb.Text = RecivedCustormerDetails[12];
            s_s_lunchType_cmb.Text = RecivedCustormerDetails[13];

            s_f_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[16];
            s_s_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[17];

            s_f_dinner_name_cmb.Text = RecivedCustormerDetails[20];
            s_s_dinner_name_cmb.Text = RecivedCustormerDetails[21];

            s_f_dinnerType_cmb.Text = RecivedCustormerDetails[22];
            s_s_dinnerType_cmb.Text = RecivedCustormerDetails[23];

            s_f_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[26];
            s_s_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[27];
        }

        private void GettingDetailsOfThirdMealInfo()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerDetails = db_obj.GetCustormerThirdMealDetails(NicNumber);

            t_f_breakfast_name_cmb.Text = RecivedCustormerDetails[0];
            t_s_breakfast_name_cmb.Text = RecivedCustormerDetails[1];

            t_f_breakfastType_cmb.Text = RecivedCustormerDetails[2];
            t_s_breakfastType_cmb.Text = RecivedCustormerDetails[3];

            t_f_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[6];
            t_s_breakfastOrderQuentity_txt.Text = RecivedCustormerDetails[7];

            t_f_lunch_name_cmb.Text = RecivedCustormerDetails[10];
            t_s_lunch_name_cmb.Text = RecivedCustormerDetails[11];

            t_f_lunchType_cmb.Text = RecivedCustormerDetails[12];
            t_s_lunchType_cmb.Text = RecivedCustormerDetails[13];

            t_f_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[16];
            t_s_lunchOrderQuentity_txt.Text = RecivedCustormerDetails[17];

            t_f_dinner_name_cmb.Text = RecivedCustormerDetails[20];
            t_s_dinner_name_cmb.Text = RecivedCustormerDetails[21];

            t_f_dinnerType_cmb.Text = RecivedCustormerDetails[22];
            t_s_dinnerType_cmb.Text = RecivedCustormerDetails[23];

            t_f_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[26];
            t_s_dinnerOrderQuentity_txt.Text = RecivedCustormerDetails[27];
        }

        //private void GettingDetailsOfTravellingInfoAndVehicleInfo()
        //{
        //    string NicNumber = nic_txt.Text;
        //    string[] RecivedCustormerDetails = db_obj.GetCustormerTravellingAndVehicleDetails(NicNumber);

        //    f_vehicleType_cmb.Text = RecivedCustormerDetails[0];
        //    s_vehicleType_cmb.Text = RecivedCustormerDetails[1];
        //    t_vehicleType_cmb.Text = RecivedCustormerDetails[2];

        //    f_vehicleNo_cmb.Text = RecivedCustormerDetails[3];
        //    s_vehicleNo_cmb.Text = RecivedCustormerDetails[4];
        //    t_vehicleNo_cmb.Text = RecivedCustormerDetails[5];

        //    f_DestinationName_cmb.Text = RecivedCustormerDetails[12];
        //    s_DestinationName_cmb.Text = RecivedCustormerDetails[13];
        //    t_DestinationName_cmb.Text = RecivedCustormerDetails[14];

        //    f_pathNo_cmb.Text = RecivedCustormerDetails[15];
        //    s_pathNo_cmb.Text = RecivedCustormerDetails[16];
        //    t_pathNo_cmb.Text = RecivedCustormerDetails[17];
        //}

        private void GettingBillPaymentStatus()
        {
            string NicNumber = nic_txt.Text;
            string[] RecivedCustormerBillPaymentStatus = db_obj.GetCustormerBillPaymentStatus(NicNumber);

            BillStatus_cmb.Text = RecivedCustormerBillPaymentStatus[0];
        }

        private void SearchCustormerDetails_btn_Click(object sender, EventArgs e)
        {
            if (GettingDetailsOfPersonalInfoAndReservationInfo() == true)
            {
                nic_txt.Enabled = false;
                MakeReservation_btn.Enabled = false;
                UpdateCustormerDetails_btn.Enabled = true;
                DeleteCustormerDetails_btn.Enabled = true;

                GettingDetailsOfLocationInfoAndDecorationInfo();
                GettingDetailsOfFirstMealInfo();
                GettingDetailsOfSecondMealInfo();
                GettingDetailsOfThirdMealInfo();
                //GettingDetailsOfTravellingInfoAndVehicleInfo();
                GettingBillPaymentStatus();
            }
            else
            {
                MessageBox.Show("There Is No Custormer For That NIC Number...", "Invalid NIC Number...");
            }
        }



        private bool UpdateCustormerPersonalInfoAndReservationInfo()
        {
            try
            {
                string NameTitle = nameini_cmb.Text;
                string NameWithInitials = nameini_txt.Text;
                string FullName = fullname_txt.Text;
                string Telephone_01 = tel1_txt.Text;
                string Telephone_02 = tel2_txt.Text;
                string EmailAddress = emailaddress_txt.Text;
                string NicNumber = nic_txt.Text;

                //Guest Quentity Informations
                int ChildGuestQuentity = ReplaceEmptyOrNullValues(childguest_txt.Text);
                int EldersGuestQuentity = ReplaceEmptyOrNullValues(elderguest_txt.Text);
                int TotalGuestQuentity = ReplaceEmptyOrNullValues(totalguest_txt.Text);

                //Reservation Details
                DateTime BookInDate = booking_dtpick.Value;
                DateTime CheckInDate = checkin_dtpick.Value;
                int No_Of_Days = ReplaceEmptyOrNullValues(days_txt.Text);
                DateTime CheckOutDate = checkout_dtpick.Value;
                string OfferAvailabilityStatus = offerstatus_cmb.Text;

                db_obj.UpdatingPersonalInfoAndReservationInfo(NameTitle, NameWithInitials, FullName, Telephone_01, Telephone_02, EmailAddress, NicNumber, ChildGuestQuentity, EldersGuestQuentity, TotalGuestQuentity, BookInDate, CheckInDate, No_Of_Days, CheckOutDate, OfferAvailabilityStatus);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool UpdateCustormerLocationDetails()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Location Categories 
                string FirstLocationCategory = f_Loc_category_cmb.Text;
                string SecondLocationCategory = s_Loc_category_cmb.Text;
                string ThirdLocationCategory = t_Loc_category_cmb.Text;

                //Location Types
                string FirstLocationType = f_Loc_type_cmb.Text;
                string SecondLocationType = s_Loc_type_cmb.Text;
                string ThirdLocationType = t_Loc_type_cmb.Text;

                //Location Numbers
                string FirstLocationNumber = f_Loc_no_cmb.Text;
                string SecondLocationNumber = s_Loc_no_cmb.Text;
                string ThirdLocationNumber = t_Loc_no_cmb.Text;

                //Number Of Max Guests In The Locations
                string FirstLocationGuestQuentity = f_Loc_guestquen_txt.Text;
                string SecondLocationGuestQuentity = s_Loc_guestquen_txt.Text;
                string ThirdLocationGuestQuentity = t_Loc_guestquen_txt.Text;

                //Location Prices
                string FirstLocationPrice = f_Loc_price_txt.Text;
                string SecondLocationPrice = s_Loc_price_txt.Text;
                string ThirdLocationPrice = t_Loc_price_txt.Text;

                //Total Location Price
                string TotalLocationPrice = TotalLocationPrice_txt.Text;

                db_obj.UpdatingLocationInfoAndEventInfo(FirstLocationCategory, SecondLocationCategory, ThirdLocationCategory, FirstLocationType, SecondLocationType, ThirdLocationType, FirstLocationNumber, SecondLocationNumber, ThirdLocationNumber, FirstLocationGuestQuentity, SecondLocationGuestQuentity, ThirdLocationGuestQuentity, FirstLocationPrice, SecondLocationPrice, ThirdLocationPrice, TotalLocationPrice, NicNumber);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool UpdateEventNamesAndDecorationTypes()
        {
            try
            {
                string NicNumber = nic_txt.Text;
                string EventName = eventname_cmb.Text;
                string EventNumber = eventno_cmb.Text;
                string EventPrice = eventprice_txt.Text;

                db_obj.UpdateEbentsNamesAndDecorationDetails(EventName, EventNumber, EventPrice, NicNumber);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool UpdateCustormerFirstDayMealDetails()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //First Day Breakfast Details
                string FirstBreakfastName = f_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = f_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = f_f_breakfastType_cmb.Text;
                string SecondBreakfastType = f_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = f_f_breakfast_price.Text;
                string SecondBreakfastPrice = f_s_breakfast_price.Text;
                string FirstBreakfastQuentity = f_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = f_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = f_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = f_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = f_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = f_s_breakfastTotalPrice_txt.Text;

                //First Day Lunch Details
                string FirstLunchName = f_f_lunch_name_cmb.Text;
                string SecondLunchName = f_s_lunch_name_cmb.Text;
                string FirstLunchType = f_f_lunchType_cmb.Text;
                string SecondLunchType = f_s_lunchType_cmb.Text;
                string FirstLunchPrice = f_f_lunch_price.Text;
                string SecondLunchPrice = f_s_lunch_price.Text;
                string FirstLunchQuentity = f_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = f_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = f_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = f_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = f_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = f_s_lunchTotalPrice_txt.Text;

                //First Day Dinner Details
                string FirstDinnerName = f_f_dinner_name_cmb.Text;
                string SecondDinnerName = f_s_dinner_name_cmb.Text;
                string FirstDinnerType = f_f_dinnerType_cmb.Text;
                string SecondDinnerType = f_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = f_f_dinner_price.Text;
                string SecondDinnerPrice = f_s_dinner_price.Text;
                string FirstDinnerQuentity = f_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = f_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = f_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = f_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = f_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = f_s_dinnerTotalPrice_txt.Text;

                string FirstDayTotalMealPrice = FirstDayMealPrice_txt.Text;

                db_obj.UpdatingFirstDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, FirstDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool UpdateCustormerSecondDayMealDetails()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Second Day Breakfast Details
                string FirstBreakfastName = s_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = s_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = s_f_breakfastType_cmb.Text;
                string SecondBreakfastType = s_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = s_f_breakfast_price.Text;
                string SecondBreakfastPrice = s_s_breakfast_price.Text;
                string FirstBreakfastQuentity = s_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = s_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = s_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = s_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = s_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = s_s_breakfastTotalPrice_txt.Text;

                //Second Day Lunch Details
                string FirstLunchName = s_f_lunchName_cmb.Text;
                string SecondLunchName = s_s_lunch_name_cmb.Text;
                string FirstLunchType = s_f_lunchType_cmb.Text;
                string SecondLunchType = s_s_lunchType_cmb.Text;
                string FirstLunchPrice = s_f_lunch_price.Text;
                string SecondLunchPrice = s_s_lunch_price.Text;
                string FirstLunchQuentity = s_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = s_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = s_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = s_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = s_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = s_s_lunchTotalPrice_txt.Text;

                //Second Day Dinner Details
                string FirstDinnerName = s_f_dinner_name_cmb.Text;
                string SecondDinnerName = s_s_dinner_name_cmb.Text;
                string FirstDinnerType = s_f_dinnerType_cmb.Text;
                string SecondDinnerType = s_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = s_f_dinner_price.Text;
                string SecondDinnerPrice = s_s_dinner_price.Text;
                string FirstDinnerQuentity = s_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = s_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = s_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = s_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = s_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = s_s_dinnerTotalPrice_txt.Text;

                string SecondDayTotalMealPrice = SecondDayMealPrice_txt.Text;

                db_obj.UpdateSecondDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, SecondDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool UpdateCustormerThirdMealDetails()
        {
            try
            {
                string NicNumber = nic_txt.Text;

                //Third Day Breakfast Details
                string FirstBreakfastName = t_f_breakfast_name_cmb.Text;
                string SecondBreakfastName = t_s_breakfast_name_cmb.Text;
                string FirstBreakfastType = t_f_breakfastType_cmb.Text;
                string SecondBreakfastType = t_s_breakfastType_cmb.Text;
                string FirstBreakfastPrice = t_f_breakfast_price.Text;
                string SecondBreakfastPrice = t_s_breakfast_price.Text;
                string FirstBreakfastQuentity = t_f_breakfastQuentity_txt.Text;
                string SecondBreakfastQuentity = t_s_breakfastQuentity_txt.Text;
                string FirstBreakfastOrederdQuentity = t_f_breakfastOrderQuentity_txt.Text;
                string SecondBreakfastOrederdQuentity = t_s_breakfastOrderQuentity_txt.Text;
                string FirstBreakfastTotalPrice = t_f_breakfastTotalPrice_txt.Text;
                string SecondBreakfastTotalPrice = t_s_breakfastTotalPrice_txt.Text;

                //Second Day Lunch Details
                string FirstLunchName = t_f_lunch_name_cmb.Text;
                string SecondLunchName = t_s_lunch_name_cmb.Text;
                string FirstLunchType = t_f_lunchType_cmb.Text;
                string SecondLunchType = t_s_lunchType_cmb.Text;
                string FirstLunchPrice = t_f_lunch_price.Text;
                string SecondLunchPrice = t_s_lunch_price.Text;
                string FirstLunchQuentity = t_f_lunchQuentity_txt.Text;
                string SecondLunchQuentity = t_s_lunchQuentity_txt.Text;
                string FirstLunchOrederdQuentity = t_f_lunchOrderQuentity_txt.Text;
                string SecondLunchOrederdQuentity = t_s_lunchOrderQuentity_txt.Text;
                string FirstLunchTotalPrice = t_f_lunchTotalPrice_txt.Text;
                string SecondLunchTotalPrice = t_s_lunchTotalPrice_txt.Text;

                //Second Day Dinner Details
                string FirstDinnerName = t_f_dinner_name_cmb.Text;
                string SecondDinnerName = t_s_dinner_name_cmb.Text;
                string FirstDinnerType = t_f_dinnerType_cmb.Text;
                string SecondDinnerType = t_s_dinnerType_cmb.Text;
                string FirstDinnerPrice = t_f_dinner_price.Text;
                string SecondDinnerPrice = t_s_dinner_price.Text;
                string FirstDinnerQuentity = t_f_dinnerQuentity_txt.Text;
                string SecondDinnerQuentity = t_s_dinnerQuentity_txt.Text;
                string FirstDinnerOrederdQuentity = t_f_dinnerOrderQuentity_txt.Text;
                string SecondDinnerOrederdQuentity = t_s_dinnerOrderQuentity_txt.Text;
                string FirstDinnerTotalPrice = t_f_dinnerTotalPrice_txt.Text;
                string SecondDinnerTotalPrice = t_s_dinnerTotalPrice_txt.Text;

                string ThirdDayTotalMealPrice = ThirdDayMealPrice_txt.Text;

                db_obj.UpdatingThirdDayMealInfo(NicNumber, FirstBreakfastName, SecondBreakfastName, FirstBreakfastType, SecondBreakfastType, FirstBreakfastQuentity, SecondBreakfastQuentity, FirstBreakfastPrice, SecondBreakfastPrice, FirstBreakfastOrederdQuentity, SecondBreakfastOrederdQuentity, FirstBreakfastTotalPrice, SecondBreakfastTotalPrice, FirstLunchName, SecondLunchName, FirstLunchType, SecondLunchType, FirstLunchQuentity, SecondLunchQuentity, FirstLunchPrice, SecondLunchPrice, FirstLunchOrederdQuentity, SecondLunchOrederdQuentity, FirstLunchTotalPrice, SecondLunchTotalPrice, FirstDinnerName, SecondDinnerName, FirstDinnerType, SecondDinnerType, FirstDinnerQuentity, SecondDinnerQuentity, FirstDinnerPrice, SecondDinnerPrice, FirstDinnerOrederdQuentity, SecondDinnerOrederdQuentity, FirstDinnerTotalPrice, SecondDinnerTotalPrice, ThirdDayTotalMealPrice);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //private bool UpdateCustormerTravellingAndVehicleDetails()
        //{
        //  /*  try
        //    {
        //        string NicNumber = nic_txt.Text;

        //        string FirstVehicleType = f_vehicleType_cmb.Text;
        //        string SecondVehicleType = s_vehicleType_cmb.Text;
        //        string ThirdVehicleType = t_vehicleType_cmb.Text;

        //        string FirstVehicleNumber = f_vehicleNo_cmb.Text;
        //        string SecondVehicleNumber = s_vehicleNo_cmb.Text;
        //        string ThirdVehicleNumber = t_vehicleNo_cmb.Text;

        //        string FirstVehiclePassengers = f_vehiclePassengers_txt.Text;
        //        string SecondVehiclePassengers = s_vehiclePassengers_txt.Text;
        //        string ThirdVehiclePassengers = t_vehiclePassengers_txt.Text;

        //        string FirstVehiclePrice = f_VehiclePrice_txt.Text;
        //        string SecondVehiclePrice = s_VehiclePrice_txt.Text;
        //        string ThirdVehiclePrice = t_VehiclePrice_txt.Text;

        //        string FirstDestinationName = f_DestinationName_cmb.Text;
        //        string SecondDestinationName = s_DestinationName_cmb.Text;
        //        string ThirdDestinationName = t_DestinationName_cmb.Text;

        //        string FirstDestinationPathNumber = f_pathNo_cmb.Text;
        //        string SecondDestinationPathNumber = s_pathNo_cmb.Text;
        //        string ThirdDestinationPathNumber = t_pathNo_cmb.Text;

        //        string FirstDestinationPrice = f_PathPrice_txt.Text;
        //        string SecondDestinationPrice = s_PathPrice_txt.Text;
        //        string ThirdDestinationPrice = t_PathPrice_txt.Text;

        //        string TotalTravelingPrice = TotalTravelingPrice_txt.Text;

        //        db_obj.UpdateTravelingInfoForReservation(NicNumber, FirstVehicleType, SecondVehicleType, ThirdVehicleType, FirstVehicleNumber, SecondVehicleNumber, ThirdVehicleNumber, FirstVehiclePassengers, SecondVehiclePassengers, ThirdVehiclePassengers, FirstVehiclePrice, SecondVehiclePrice, ThirdVehiclePrice, FirstDestinationName, SecondDestinationName, ThirdDestinationName, FirstDestinationPathNumber, SecondDestinationPathNumber, ThirdDestinationPathNumber, FirstDestinationPrice, SecondDestinationPrice, ThirdDestinationPrice, TotalTravelingPrice);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;*/
        //}

        private bool UpdateCustormerBillDetails()
        {
            try
            {
                string NicNumber = nic_txt.Text;
                string BillAmount = TotalBillAmount_txt.Text;
                string NetAmount = TotalNetAmount_txt.Text;
                string AdvanceAmountSts = "not complete";
                string FinalAmountSts = "not complete";
                string CompleteAmountSts = BillStatus_cmb.Text;
                string OfferValue = Convert.ToString(GetOfferValueForCalculateNetAmount());

                db_obj.UpdateBillDetailsForReservation(NicNumber, BillAmount, NetAmount, AdvanceAmountSts, FinalAmountSts, CompleteAmountSts, OfferValue);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void UpdateCustormerDetails_btn_Click(object sender, EventArgs e)
        {
            if (UpdateCustormerPersonalInfoAndReservationInfo() == true && UpdateCustormerLocationDetails() == true && UpdateEventNamesAndDecorationTypes() == true && UpdateCustormerFirstDayMealDetails() == true && UpdateCustormerSecondDayMealDetails() == true && UpdateCustormerThirdMealDetails() == true &&  UpdateCustormerBillDetails() == true)
            {
                MessageBox.Show("Custormer Details Update Sucessfully...", "Custormer Details Update......");
            }
            else
            {
                MessageBox.Show("There Is Some Error Occured While Updating Custormer Details...", "Database Or SQL Error..");
            }
        }

        private void DeleteCustormerDetailsOfReservationAndAllInfo()
        {
            string NicNumber = nic_txt.Text;

            DialogResult DeleteUser = MessageBox.Show("Are You Sure Want To Delete This Custormer Form The System ? ", "Custormer Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeleteUser == DialogResult.Yes)
            {
                db_obj.DeleteCustormerPersonalInfoAndReservationDetails(NicNumber);
            }
        }

        private void DeleteCustormerDetails_btn_Click(object sender, EventArgs e)
        {
            DeleteCustormerDetailsOfReservationAndAllInfo();
            GetDatabaseTableRecordCount();
        }

        private bool FirstDayMealReset()
        {
            try
            {
                f_f_breakfast_name_cmb.SelectedIndex = -1;
                f_s_breakfast_name_cmb.SelectedIndex = -1;

                f_f_breakfastType_cmb.SelectedIndex = -1;
                f_s_breakfastType_cmb.SelectedIndex = -1;

                f_f_breakfastOrderQuentity_txt.Text = "";
                f_s_breakfastOrderQuentity_txt.Text = "";

                f_f_lunch_name_cmb.SelectedIndex = -1;
                f_s_lunch_name_cmb.SelectedIndex = -1;

                f_f_lunchType_cmb.SelectedIndex = -1;
                f_s_lunchType_cmb.SelectedIndex = -1;

                f_f_lunchOrderQuentity_txt.Text = "";
                f_s_lunchOrderQuentity_txt.Text = "";

                f_f_dinner_name_cmb.SelectedIndex = -1;
                f_s_dinner_name_cmb.SelectedIndex = -1;

                f_f_dinnerType_cmb.SelectedIndex = -1;
                f_s_dinnerType_cmb.SelectedIndex = -1;

                f_f_dinnerOrderQuentity_txt.Text = "";
                f_s_dinnerOrderQuentity_txt.Text = "";
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool SecondDayMealReset()
        {
            try
            {
                s_f_breakfast_name_cmb.SelectedIndex = -1;
                s_s_breakfast_name_cmb.SelectedIndex = -1;

                s_f_breakfastType_cmb.SelectedIndex = -1;
                s_s_breakfastType_cmb.SelectedIndex = -1;

                s_f_breakfastOrderQuentity_txt.Text = "";
                s_s_breakfastOrderQuentity_txt.Text = "";

                s_f_lunch_name_cmb.SelectedIndex = -1;
                s_s_lunch_name_cmb.SelectedIndex = -1;

                s_f_lunchType_cmb.SelectedIndex = -1;
                s_s_lunchType_cmb.SelectedIndex = -1;

                s_f_lunchOrderQuentity_txt.Text = "";
                s_s_lunchOrderQuentity_txt.Text = "";

                s_f_dinner_name_cmb.SelectedIndex = -1;
                s_s_dinner_name_cmb.SelectedIndex = -1;

                s_f_dinnerType_cmb.SelectedIndex = -1;
                s_s_dinnerType_cmb.SelectedIndex = -1;

                s_f_dinnerOrderQuentity_txt.Text = "";
                s_s_dinnerOrderQuentity_txt.Text = "";
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool ThirdDayMealReset()
        {
            try
            {
                t_f_breakfast_name_cmb.SelectedIndex = -1;
                t_s_breakfast_name_cmb.SelectedIndex = -1;

                t_f_breakfastType_cmb.SelectedIndex = -1;
                t_s_breakfastType_cmb.SelectedIndex = -1;

                t_f_breakfastOrderQuentity_txt.Text = "";
                t_s_breakfastOrderQuentity_txt.Text = "";

                t_f_lunch_name_cmb.SelectedIndex = -1;
                t_s_lunch_name_cmb.SelectedIndex = -1;

                t_f_lunchType_cmb.SelectedIndex = -1;
                t_s_lunchType_cmb.SelectedIndex = -1;

                t_f_lunchOrderQuentity_txt.Text = "";
                t_s_lunchOrderQuentity_txt.Text = "";

                t_f_dinner_name_cmb.SelectedIndex = -1;
                t_s_dinner_name_cmb.SelectedIndex = -1;

                t_f_dinnerType_cmb.SelectedIndex = -1;
                t_s_dinnerType_cmb.SelectedIndex = -1;

                t_f_dinnerOrderQuentity_txt.Text = "";
                t_s_dinnerOrderQuentity_txt.Text = "";
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void ResetFeilds()
        {
            nameini_cmb.SelectedIndex = -1;
            nameini_txt.Text = "";
            fullname_txt.Text = "";
            tel1_txt.Text = "";
            tel2_txt.Text = "";
            emailaddress_txt.Text = "";
            childguest_txt.Text = "";
            elderguest_txt.Text = "";
            totalguest_txt.Text = "";
            booking_dtpick.Value = System.DateTime.Now;
            checkin_dtpick.Value = System.DateTime.Now;
            days_txt.Text = "";
            checkout_dtpick.Value = System.DateTime.Now;

            //second day meal reset

            s_f_breakfast_name_cmb.Text = null;
            s_s_breakfast_name_cmb.Text = null;

            s_f_breakfastType_cmb.Text = null;
            s_s_breakfastType_cmb.Text = null;

            s_f_breakfastOrderQuentity_txt.Text = "";
            s_s_breakfastOrderQuentity_txt.Text = "";

            s_f_lunch_name_cmb.Text = null;
            s_s_lunch_name_cmb.Text = null;

            s_f_lunchType_cmb.Text = null;
            s_s_lunchType_cmb.Text = null;

            s_f_lunchOrderQuentity_txt.Text = "";
            s_s_lunchOrderQuentity_txt.Text = "";

            s_f_dinner_name_cmb.Text = null;
            s_s_dinner_name_cmb.Text = null;

            s_f_dinnerType_cmb.Text = null;
            s_s_dinnerType_cmb.Text = null;

            s_f_dinnerOrderQuentity_txt.Text = "";
            s_s_dinnerOrderQuentity_txt.Text = "";

            //third meal reset

            t_f_breakfast_name_cmb.Text = null;
            t_s_breakfast_name_cmb.Text = null;

            t_f_breakfastType_cmb.Text = null;
            t_s_breakfastType_cmb.Text = null;

            t_f_breakfastOrderQuentity_txt.Text = "";
            t_s_breakfastOrderQuentity_txt.Text = "";

            t_f_lunch_name_cmb.Text = null;
            t_s_lunch_name_cmb.Text = null;

            t_f_lunchType_cmb.Text = null;
            t_s_lunchType_cmb.Text = null;

            t_f_lunchOrderQuentity_txt.Text = "";
            t_s_lunchOrderQuentity_txt.Text = "";

            t_f_dinner_name_cmb.Text = null;
            t_s_dinner_name_cmb.Text = null;

            t_f_dinnerType_cmb.Text = null;
            t_s_dinnerType_cmb.Text = null;

            t_f_dinnerOrderQuentity_txt.Text = "";
            t_s_dinnerOrderQuentity_txt.Text = "";

            //location details
            f_Loc_category_cmb.Text = null;
            s_Loc_category_cmb.Text = null;
            t_Loc_category_cmb.Text = null;

            f_Loc_type_cmb.SelectedIndex = -1;
            s_Loc_type_cmb.SelectedIndex = -1;
            t_Loc_type_cmb.SelectedIndex = -1;

            f_Loc_no_cmb.SelectedIndex = -1;
            s_Loc_no_cmb.SelectedIndex = -1;
            t_Loc_no_cmb.SelectedIndex = -1;

            eventname_cmb.SelectedIndex = -1;
            eventno_cmb.SelectedIndex = -1;

            //travelling details

            //f_vehicleType_cmb.SelectedIndex = -1;
            //s_vehicleType_cmb.SelectedIndex = -1;
            //t_vehicleType_cmb.SelectedIndex = -1;

            //f_vehicleNo_cmb.SelectedIndex = -1;
            //s_vehicleNo_cmb.SelectedIndex = -1;
            //t_vehicleNo_cmb.SelectedIndex = -1;

            //f_DestinationName_cmb.SelectedIndex = -1;
            //s_DestinationName_cmb.SelectedIndex = -1;
            //t_DestinationName_cmb.SelectedIndex = -1;

            //f_pathNo_cmb.SelectedIndex = -1;
            //s_pathNo_cmb.SelectedIndex = -1;
            //t_pathNo_cmb.SelectedIndex = -1;

            //first day meal

            f_f_breakfast_name_cmb.Text = null;
            f_s_breakfast_name_cmb.Text = null;

            f_f_breakfastType_cmb.Text = null;
            f_s_breakfastType_cmb.Text = null;

            f_f_breakfastOrderQuentity_txt.Text = "";
            f_s_breakfastOrderQuentity_txt.Text = "";

            f_f_lunch_name_cmb.Text = null;
            f_s_lunch_name_cmb.Text = null;

            f_f_lunchType_cmb.Text = null;
            f_s_lunchType_cmb.Text = null;

            f_f_lunchOrderQuentity_txt.Text = "";
            f_s_lunchOrderQuentity_txt.Text = "";

            f_f_dinner_name_cmb.Text = null;
            f_s_dinner_name_cmb.Text = null;

            f_f_dinnerType_cmb.Text = null;
            f_s_dinnerType_cmb.Text = null;

            f_f_dinnerOrderQuentity_txt.Text = "";
            f_s_dinnerOrderQuentity_txt.Text = "";
        }

        private void ResetFeilds_btn_Click(object sender, EventArgs e)
        {
            MakeReservation_btn.Enabled = true;
            UpdateCustormerDetails_btn.Enabled = false;
            DeleteCustormerDetails_btn.Enabled = false;
            nic_txt.Enabled = true;

            ResetFeilds();
        }
    }
}