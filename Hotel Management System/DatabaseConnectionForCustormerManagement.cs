using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Hotel_Management_System
{
    class DatabaseConnectionForCustormerManagement
    {
        //public static string ProjPath = Path.GetFullPath(Environment.CurrentDirectory);
        //public static string DBName = "Hotel_Management_System.sdf;Password='root123'";
        //public static string FullPath = "Data Source=" + ProjPath + "\\" + DBName;
        //SqlCeConnection conn = new SqlCeConnection(FullPath);

        SqlCeConnection conn = new SqlCeConnection(@"Data Source=E:\HMS UPDATED NEW\Hotel Management System\Hotel Management System\Hotel_Management_System.sdf;Password='root123'");

        public string[] GetLocationCategoriesAndTypes()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] location_categories = new string[100];

            SqlCeCommand GetLocationCategory = new SqlCeCommand("select distinct category from location_details" ,conn);
            SqlCeDataReader LocationCategory = GetLocationCategory.ExecuteReader();

            int x = 0;
            while (LocationCategory.Read())
            {
                if (location_categories[x] == null)
                {
                    location_categories[x] = LocationCategory[0].ToString();
                }
                else
                {
                    location_categories[x + 1] = LocationCategory[0].ToString();
                    x++;
                }
            }

            GetLocationCategory.Dispose();
            return location_categories;
        }

        internal string[] GetDistinctLocationTypes(string GetLocationCategory)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] LocationTypes = new string[3];

            SqlCeCommand GetLocationTypes = new SqlCeCommand("select distinct category_type from location_details where category = '" + GetLocationCategory + "'" ,conn);
            SqlCeDataReader DistinctLocationTypes = GetLocationTypes.ExecuteReader();

            int x = 0;
            while (DistinctLocationTypes.Read())
            {
                if (LocationTypes[x] == null)
                {
                    LocationTypes[x] = DistinctLocationTypes[0].ToString();
                }
                else
                {
                    LocationTypes[x + 1] = DistinctLocationTypes[0].ToString();
                    x++;
                }
            }

            DistinctLocationTypes.Dispose();
            return LocationTypes;
        }

        internal string[] GetSuatbleLocationNumbers(string GetLocationCategory,string GetLocationType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] LocationNo = new string[50];
            SqlCeCommand GetLocationNumbers = new SqlCeCommand("select no from location_details where category = '" + GetLocationCategory + "' and category_type = '" + GetLocationType + "' and status = 'Active'" ,conn);
            SqlCeDataReader SelectedLocationNumbers = GetLocationNumbers.ExecuteReader();

            int x = 0;
            while(SelectedLocationNumbers.Read())
            {
                if (LocationNo[x] == null)
                {
                    LocationNo[x] = SelectedLocationNumbers[0].ToString();
                }
                else
                {
                    LocationNo[x + 1] = SelectedLocationNumbers[0].ToString();
                    x++;
                }
            }

            SelectedLocationNumbers.Dispose();
            return LocationNo;
        }

        internal string GetMaxPersonsOfLocation(string GetLocationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetMaxPersonsOfLocation = new SqlCeCommand("select max_per from location_details where no = '" + GetLocationNo + "'" ,conn);
            SqlCeDataReader SelectedQuentity = GetMaxPersonsOfLocation.ExecuteReader();

            string MaxPersons = "";

            while(SelectedQuentity.Read())
            {
                MaxPersons = SelectedQuentity[0].ToString();
            }


            return MaxPersons;
        }

        internal string GetLocationPrice(string GetLocationNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetMaxPersonsOfLocation = new SqlCeCommand("select price from location_details where no = '" + GetLocationNo + "'", conn);
            SqlCeDataReader SelectedQuentity = GetMaxPersonsOfLocation.ExecuteReader();

            string LocationPrice = "";

            while (SelectedQuentity.Read())
            {
                LocationPrice = SelectedQuentity[0].ToString();
            }

            SelectedQuentity.Dispose();
            return LocationPrice;
        }

        internal string[] GetEventNamesAndTypes()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] GetEventNamesAndTypes = new string[30];
            SqlCeCommand GetEventNames = new SqlCeCommand("select name from decoration_details" ,conn);
            SqlCeDataReader SelectedEventNames = GetEventNames.ExecuteReader();

            int x = 0;
            while (SelectedEventNames.Read())
            {
                if (GetEventNamesAndTypes[x] == null)
                {
                    GetEventNamesAndTypes[x] = SelectedEventNames[0].ToString();
                }
                else
                {
                    GetEventNamesAndTypes[x + 1] = SelectedEventNames[0].ToString();
                    x++;
                }
            }

            SelectedEventNames.Dispose();
            return GetEventNamesAndTypes;
        }

        internal string[] GetEventIDNumbers(string GetSelectedEventname)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] GetEventsIDNumbers = new string[30];
            SqlCeCommand GetEventNumbers = new SqlCeCommand("select decoration_no from decoration_details where name = '" + GetSelectedEventname + "'" ,conn);
            SqlCeDataReader GetSelectedEventIDNumbers = GetEventNumbers.ExecuteReader();

            int x = 0;
            while (GetSelectedEventIDNumbers.Read())
            {
                if (GetEventsIDNumbers[x] == null)
                {
                    GetEventsIDNumbers[x] = GetSelectedEventIDNumbers[0].ToString();
                }
                else
                {
                    GetEventsIDNumbers[x + 1] = GetSelectedEventIDNumbers[0].ToString();
                    x++;
                }
            }

            GetSelectedEventIDNumbers.Dispose();
            return GetEventsIDNumbers;
        }

        internal string GetSelectedEventPackagePrice(string SelectedEventIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetEventPackagePrice = new SqlCeCommand("select price from decoration_details where decoration_no = '" + SelectedEventIDNumber + "'" ,conn);
            SqlCeDataReader SelectedPackagePrice = GetEventPackagePrice.ExecuteReader();

            string EventPackagePrice = "";
            while (SelectedPackagePrice.Read())
            {
                EventPackagePrice = SelectedPackagePrice[0].ToString();
            }

            SelectedPackagePrice.Dispose();
            return EventPackagePrice;
        }

        internal string[] GetOfferStatusAvailability(DateTime CheckInDate, DateTime CheckOutDate)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] OfferAvailability = new string[2];
            SqlCeCommand GetOfferAvailability = new SqlCeCommand("select value,status from offer_details where (start_date < '" + CheckInDate + "' and end_date > '" + CheckInDate + "')",conn);
            SqlCeDataReader SelectedOfferAvailability = GetOfferAvailability.ExecuteReader();

            while (SelectedOfferAvailability.Read())
            {
                OfferAvailability[0] = SelectedOfferAvailability[0].ToString();
                OfferAvailability[1] = SelectedOfferAvailability[1].ToString();
            }

            SelectedOfferAvailability.Dispose();
            return OfferAvailability;
        }

        internal string[] GetAvailableMealNames()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableMealNames = new string[10];
            SqlCeCommand AccessAvailableMealNames = new SqlCeCommand("select distinct name from meal_details" ,conn);
            SqlCeDataReader SelectedMealNames = AccessAvailableMealNames.ExecuteReader();

            int x = 0;
            while (SelectedMealNames.Read())
            {
                if (AvailableMealNames[x] == null)
                {
                    AvailableMealNames[x] = SelectedMealNames[0].ToString();
                }
                else
                {
                    AvailableMealNames[x + 1] = SelectedMealNames[0].ToString();
                    x++;
                }
            }

            SelectedMealNames.Dispose();
            return AvailableMealNames;
        }

        internal string[] GetAvailableMealTypes(string SelectedMealName)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableMealTypes = new string[5];
            SqlCeCommand GetAvailableMealTypes = new SqlCeCommand("select distinct type from meal_details where name = '" + SelectedMealName + "'" ,conn);
            SqlCeDataReader SelectedMealTypes = GetAvailableMealTypes.ExecuteReader();

            int x = 0;
            while (SelectedMealTypes.Read())
            {
                if (AvailableMealTypes[x] == null)
                {
                    AvailableMealTypes[x] = SelectedMealTypes[0].ToString();
                }
                else
                {
                    AvailableMealTypes[x + 1] = SelectedMealTypes[0].ToString();
                }
            }

            SelectedMealTypes.Dispose();
            return AvailableMealTypes;
        }

        internal int GetAvailableMealPrice(string GetSelectedMealName,string GetSelectedMealType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetAvailableMealPrices = new SqlCeCommand("select price from meal_details where name = '" + GetSelectedMealName + "' and type = '" + GetSelectedMealType + "'" ,conn);
            SqlCeDataReader SelectedAvailableMealPrice = GetAvailableMealPrices.ExecuteReader();

            int SelectedMealPrice = 0;
            while (SelectedAvailableMealPrice.Read())
            {
                SelectedMealPrice = Convert.ToInt32(SelectedAvailableMealPrice[0]);
            }

            SelectedAvailableMealPrice.Dispose();
            return SelectedMealPrice;
        }

        internal string GetAvailableMealQuentity(string GetSelectedMealName, string GetSelectedMealType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetAvailableMealQuentity = new SqlCeCommand("select quentity from meal_details where name = '" + GetSelectedMealName + "' and type = '" + GetSelectedMealType + "'" ,conn);
            SqlCeDataReader SelectedAvailableMealQuentity = GetAvailableMealQuentity.ExecuteReader();

            string AvailableMealQuentity = "";
            while (SelectedAvailableMealQuentity.Read())
            {
                AvailableMealQuentity = SelectedAvailableMealQuentity[0].ToString();
            }

            SelectedAvailableMealQuentity.Dispose();
            return AvailableMealQuentity;
        }

        internal string[] GetAvailableVehicleCategories()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableVehicleCategories = new string[10];
            SqlCeCommand GetAvailableVehicleCategories = new SqlCeCommand("select distinct type from vehicle_details" ,conn);
            SqlCeDataReader SelectedAvailableVehicleCategories = GetAvailableVehicleCategories.ExecuteReader();

            int x = 0;
            while (SelectedAvailableVehicleCategories.Read())
            {
                if (AvailableVehicleCategories[x] == null)
                {
                    AvailableVehicleCategories[x] = SelectedAvailableVehicleCategories[0].ToString();
                }
                else
                {
                    AvailableVehicleCategories[x + 1] = SelectedAvailableVehicleCategories[0].ToString();
                    x++;
                }
            }

            SelectedAvailableVehicleCategories.Dispose();
            return AvailableVehicleCategories;
        }

        internal string[] GetSelectedVehicleNos(string GetSelectedVehicleType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableVehicleNumbers = new string[20];
            SqlCeCommand GetAvailableVehicleNumbers = new SqlCeCommand("select vec_no from vehicle_details where type = '" + GetSelectedVehicleType + "' and vec_status = 'Active'" ,conn);
            SqlCeDataReader SelectedAvailableVehicleNumbers = GetAvailableVehicleNumbers.ExecuteReader();

            int x = 0;
            while (SelectedAvailableVehicleNumbers.Read())
            {
                if (AvailableVehicleNumbers[x] == null)
                {
                    AvailableVehicleNumbers[x] = SelectedAvailableVehicleNumbers[0].ToString();
                }
                else
                {
                    AvailableVehicleNumbers[x + 1] = SelectedAvailableVehicleNumbers[0].ToString();
                    x++;
                }
            }

            SelectedAvailableVehicleNumbers.Dispose();
            return AvailableVehicleNumbers;
        }

        internal string[] GetAvailableNumberOfPassengers(string GetSelectedVehicleNo)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailablePassengersAndPrice = new string[3];
            SqlCeCommand GetAvailableNumberOfPassengers = new SqlCeCommand("select no_of_seats,price from vehicle_details where vec_no = '" + GetSelectedVehicleNo + "'" ,conn);
            SqlCeDataReader SelectedAvailablePassengers = GetAvailableNumberOfPassengers.ExecuteReader();

            while (SelectedAvailablePassengers.Read())
            {
                AvailablePassengersAndPrice[0] = SelectedAvailablePassengers[0].ToString();
                AvailablePassengersAndPrice[1] = SelectedAvailablePassengers[1].ToString();
            }

            SelectedAvailablePassengers.Dispose();
            return AvailablePassengersAndPrice;
        }

        internal string[] GetAvailableDestinationNames()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableDestinationNames = new string[30];
            SqlCeCommand GetAvailabledestinationnames = new SqlCeCommand("select destination_name from traveling_detials" ,conn);
            SqlCeDataReader SelectAvailableDestinationNames = GetAvailabledestinationnames.ExecuteReader();

            int x = 0;
            while(SelectAvailableDestinationNames.Read())
            {
                if (AvailableDestinationNames[x] == null)
                {
                    AvailableDestinationNames[x] = SelectAvailableDestinationNames[0].ToString();
                }
                else
                {
                    AvailableDestinationNames[x + 1] = SelectAvailableDestinationNames[0].ToString();
                    x++;
                }
            }

            SelectAvailableDestinationNames.Dispose();
            return AvailableDestinationNames;
        }

        internal string[] GetAvailableDestinationNo(string GetSelectedDestinationName)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailablePathNames = new string[4];
            SqlCeCommand GetAvailablePathNames = new SqlCeCommand("select path_1,path_2,path_3,price from traveling_detials where destination_name = '" + GetSelectedDestinationName + "'" ,conn);
            SqlCeDataReader SelectedAvailablePathNames = GetAvailablePathNames.ExecuteReader();

            while (SelectedAvailablePathNames.Read())
            {
                AvailablePathNames[0] = SelectedAvailablePathNames[0].ToString();
                AvailablePathNames[1] = SelectedAvailablePathNames[1].ToString();
                AvailablePathNames[2] = SelectedAvailablePathNames[2].ToString();
                AvailablePathNames[3] = SelectedAvailablePathNames[3].ToString();
            }

            SelectedAvailablePathNames.Dispose();
            return AvailablePathNames;
        }

        internal void InitializingPersonalInfoAndReservationInfo(string NameTitle,string NameWithInitials, string FullName, string Telephone_01, string Telephone_02, string EmailAddress, string NicNumber, int ChildGuestQuentity, int EldersGuestQuentity, int TotalGuestQuentity, DateTime BookInDate, DateTime CheckInDate, int No_Of_Days, DateTime CheckOutDate, string OfferAvailabilityStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertPersonalInfoAndReservationInfo = new SqlCeCommand("insert into cus_personalDetails (name_title,name_with_ini,full_name,tel_1,tel_2,email_addr,no_of_guest_child,no_of_guest_elders,total_guest,bookin_date,check_in,days,check_out,nic_no) values (@name_title,@name_with_ini,@full_name,@tel_1,@tel_2,@email_addr,@no_of_guest_child,@no_of_guest_elders,@total_guest,@bookin_date,@check_in,@days,@check_out,@nic_no)", conn);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@name_title", NameTitle);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@name_with_ini", NameWithInitials);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@full_name", FullName);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@tel_1", Telephone_01);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@tel_2", Telephone_02);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@email_addr", EmailAddress);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@no_of_guest_child", ChildGuestQuentity);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@no_of_guest_elders", EldersGuestQuentity);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@total_guest", TotalGuestQuentity);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@bookin_date", BookInDate);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@check_in", CheckInDate);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@days", No_Of_Days);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@check_out", CheckOutDate);
            InsertPersonalInfoAndReservationInfo.Parameters.Add("@nic_no", NicNumber);

            InsertPersonalInfoAndReservationInfo.ExecuteNonQuery();
            InsertPersonalInfoAndReservationInfo.Dispose();
        }

        internal void InitializeLocationInfoAndEventInfo(string FirstLocationCategory,string SecondLocationCategory,string ThirdLocationCategory,string FirstLocationType, string SecondLocationType, string ThirdLocationType, string FirstLocationNumber, string SecondLocationNumber, string ThirdLocationNumber, string FirstLocationGuestQuentity, string SecondLocationGuestQuentity, string ThirdLocationGuestQuentity, string FirstLocationPrice, string SecondLocationPrice, string ThirdLocationPrice, string EventName, string EventNumber, string EventPrice,string TotalLocationPrice ,string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertLocationDetailsAndEventDetails = new SqlCeCommand("insert into cus_location_details(f_cetegory,s_cetegory,t_cetegory,f_type,s_type,t_type,f_room_no,s_room_no,t_room_no,f_no_of_guest,s_no_of_guest,t_no_of_guest,f_room_price,s_room_price,t_room_price,event_name,event_no,decoration_price,total_loc_price,nic_no) values (@FirstLocationCategory,@SecondLocationCategory,@ThirdLocationCategory,@FirstLocationType,@SecondLocationType,@ThirdLocationType,@FirstLocationNumber,@SecondLocationNumber,@ThirdLocationNumber,@FirstLocationGuestQuentity,@SecondLocationGuestQuentity,@ThirdLocationGuestQuentity,@FirstLocationPrice,@SecondLocationPrice,@ThirdLocationPrice,@EventName,@EventNumber,@EventPrice,@TotalLocationPrice,@NicNumber)", conn);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@NicNumber" ,NicNumber);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@FirstLocationCategory", FirstLocationCategory);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@SecondLocationCategory", SecondLocationCategory);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@ThirdLocationCategory", ThirdLocationCategory);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@FirstLocationType" ,FirstLocationType);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@SecondLocationType", SecondLocationType);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@ThirdLocationType", ThirdLocationType);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@FirstLocationNumber" ,FirstLocationNumber);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@SecondLocationNumber", SecondLocationNumber);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@ThirdLocationNumber", ThirdLocationNumber);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@FirstLocationGuestQuentity" ,FirstLocationGuestQuentity);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@SecondLocationGuestQuentity", SecondLocationGuestQuentity);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@ThirdLocationGuestQuentity", ThirdLocationGuestQuentity);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@FirstLocationPrice" ,FirstLocationPrice);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@SecondLocationPrice", SecondLocationPrice);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@ThirdLocationPrice", ThirdLocationPrice);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@EventName" ,EventName);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@EventNumber", EventNumber);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@EventPrice", EventPrice);
            InsertLocationDetailsAndEventDetails.Parameters.Add("@TotalLocationPrice" ,TotalLocationPrice);

            InsertLocationDetailsAndEventDetails.ExecuteNonQuery();
            InsertLocationDetailsAndEventDetails.Dispose();
        }

        internal void InitializeFirstDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string FirstDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertFirstMealDetais = new SqlCeCommand("insert into cus_mealDetails_first (nic_no,f_f_breakfast_name,f_s_breakfast_name,f_f_breakfast_type,f_s_breakfast_type,f_f_breakfast_price,f_s_breakfast_price,f_f_breakfast_quentity,f_s_breakfast_quentity,f_f_breakfast_total_price,f_s_breakfast_total_price,f_f_lunch_name,f_s_lunch_name,f_f_lunch_type,f_s_lunch_type,f_f_lunch_price,f_s_lunch_price,f_f_lunch_quentity,f_s_lunch_quentity,f_f_lunch_total_price,f_s_lunch_total_price,f_f_dinner_name,f_s_dinner_name,f_f_dinner_type,f_s_dinner_type,f_f_dinner_price,f_s_dinner_price,f_f_dinner_quentity,f_s_dinner_quentity,f_f_dinner_total_price,f_s_dinner_total_price,f_total_price) values (@nic_no,@f_f_breakfast_name,@f_s_breakfast_name,@f_f_breakfast_type,@f_s_breakfast_type,@f_f_breakfast_price,@f_s_breakfast_price,@f_f_breakfast_quentity,@f_s_breakfast_quentity,@f_f_breakfast_total_price,@f_s_breakfast_total_price,@f_f_lunch_name,@f_s_lunch_name,@f_f_lunch_type,@f_s_lunch_type,@f_f_lunch_price,@f_s_lunch_price,@f_f_lunch_quentity,@f_s_lunch_quentity,@f_f_lunch_total_price,@f_s_lunch_total_price,@f_f_dinner_name,@f_s_dinner_name,@f_f_dinner_type,@f_s_dinner_type,@f_f_dinner_price,@f_s_dinner_price,@f_f_dinner_quentity,@f_s_dinner_quentity,@f_f_dinner_total_price,@f_s_dinner_total_price,@f_total_price)", conn);
            InsertFirstMealDetais.Parameters.Add("@nic_no", NicNumber);
            InsertFirstMealDetais.Parameters.Add("@f_f_breakfast_name", FirstBreakfastName);
            InsertFirstMealDetais.Parameters.Add("@f_s_breakfast_name", SecondBreakfastName);
            InsertFirstMealDetais.Parameters.Add("@f_f_breakfast_type", FirstBreakfastType);
            InsertFirstMealDetais.Parameters.Add("@f_s_breakfast_type", SecondBreakfastType);
            InsertFirstMealDetais.Parameters.Add("@f_f_breakfast_price", FirstBreakfastPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_breakfast_price", SecondBreakfastPrice);
            InsertFirstMealDetais.Parameters.Add("@f_f_breakfast_quentity", FirstBreakfastOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_s_breakfast_quentity", SecondBreakfastOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_f_breakfast_total_price", FirstBreakfastTotalPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_breakfast_total_price", SecondBreakfastTotalPrice);

            InsertFirstMealDetais.Parameters.Add("@f_f_lunch_name", FirstLunchName);
            InsertFirstMealDetais.Parameters.Add("@f_s_lunch_name", SecondLunchName);
            InsertFirstMealDetais.Parameters.Add("@f_f_lunch_type", FirstLunchType);
            InsertFirstMealDetais.Parameters.Add("@f_s_lunch_type", SecondLunchType);
            InsertFirstMealDetais.Parameters.Add("@f_f_lunch_price", FirstLunchPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_lunch_price", SecondLunchPrice);
            InsertFirstMealDetais.Parameters.Add("@f_f_lunch_quentity", FirstLunchOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_s_lunch_quentity", SecondLunchOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_f_lunch_total_price", FirstLunchTotalPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_lunch_total_price", SecondLunchTotalPrice);

            InsertFirstMealDetais.Parameters.Add("@f_f_dinner_name", FirstDinnerName);
            InsertFirstMealDetais.Parameters.Add("@f_s_dinner_name", SecondDinnerName);
            InsertFirstMealDetais.Parameters.Add("@f_f_dinner_type", FirstDinnerType);
            InsertFirstMealDetais.Parameters.Add("@f_s_dinner_type", SecondDinnerType);
            InsertFirstMealDetais.Parameters.Add("@f_f_dinner_price", FirstDinnerPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_dinner_price", SecondDinnerPrice);
            InsertFirstMealDetais.Parameters.Add("@f_f_dinner_quentity", FirstDinnerOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_s_dinner_quentity", SecondDinnerOrederdQuentity);
            InsertFirstMealDetais.Parameters.Add("@f_f_dinner_total_price", FirstDinnerTotalPrice);
            InsertFirstMealDetais.Parameters.Add("@f_s_dinner_total_price", SecondDinnerTotalPrice);

            InsertFirstMealDetais.Parameters.Add("@f_total_price", FirstDayTotalMealPrice);

            InsertFirstMealDetais.ExecuteNonQuery();
            InsertFirstMealDetais.Dispose();
        }

        internal void InitializeSecondDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string SecondDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertSecondMealDetais = new SqlCeCommand("insert into cus_mealDetails_second (nic_no,s_f_breakfast_name,s_s_breakfast_name,s_f_breakfast_type,s_s_breakfast_type,s_f_breakfast_price,s_s_breakfast_price,s_f_breakfast_quentity,s_s_breakfast_quentity,s_f_breakfast_total_price,s_s_breakfast_total_price,s_f_lunch_name,s_s_lunch_name,s_f_lunch_type,s_s_lunch_type,s_f_lunch_price,s_s_lunch_price,s_f_lunch_quentity,s_s_lunch_quentity,s_f_lunch_total_price,s_s_lunch_total_price,s_f_dinner_name,s_s_dinner_name,s_f_dinner_type,s_s_dinner_type,s_f_dinner_price,s_s_dinner_price,s_f_dinner_quentity,s_s_dinner_quentity,s_f_dinner_total_price,s_s_dinner_total_price,s_total_price) values (@nic_no,@s_f_breakfast_name,@s_s_breakfast_name,@s_f_breakfast_type,@s_s_breakfast_type,@s_f_breakfast_price,@s_s_breakfast_price,@s_f_breakfast_quentity,@s_s_breakfast_quentity,@s_f_breakfast_total_price,@s_s_breakfast_total_price,@s_f_lunch_name,@s_s_lunch_name,@s_f_lunch_type,@s_s_lunch_type,@s_f_lunch_price,@s_s_lunch_price,@s_f_lunch_quentity,@s_s_lunch_quentity,@s_f_lunch_total_price,@s_s_lunch_total_price,@s_f_dinner_name,@s_s_dinner_name,@s_f_dinner_type,@s_s_dinner_type,@s_f_dinner_price,@s_s_dinner_price,@s_f_dinner_quentity,@s_s_dinner_quentity,@s_f_dinner_total_price,@s_s_dinner_total_price,@s_total_price)", conn);
            InsertSecondMealDetais.Parameters.Add("@nic_no", NicNumber);
            InsertSecondMealDetais.Parameters.Add("@s_f_breakfast_name", FirstBreakfastName);
            InsertSecondMealDetais.Parameters.Add("@s_s_breakfast_name", SecondBreakfastName);
            InsertSecondMealDetais.Parameters.Add("@s_f_breakfast_type", FirstBreakfastType);
            InsertSecondMealDetais.Parameters.Add("@s_s_breakfast_type", SecondBreakfastType);
            InsertSecondMealDetais.Parameters.Add("@s_f_breakfast_price", FirstBreakfastPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_breakfast_price", SecondBreakfastPrice);
            InsertSecondMealDetais.Parameters.Add("@s_f_breakfast_quentity", FirstBreakfastOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_s_breakfast_quentity", SecondBreakfastOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_f_breakfast_total_price", FirstBreakfastTotalPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_breakfast_total_price", SecondBreakfastTotalPrice);

            InsertSecondMealDetais.Parameters.Add("@s_f_lunch_name", FirstLunchName);
            InsertSecondMealDetais.Parameters.Add("@s_s_lunch_name", SecondLunchName);
            InsertSecondMealDetais.Parameters.Add("@s_f_lunch_type", FirstLunchType);
            InsertSecondMealDetais.Parameters.Add("@s_s_lunch_type", SecondLunchType);
            InsertSecondMealDetais.Parameters.Add("@s_f_lunch_price", FirstLunchPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_lunch_price", SecondLunchPrice);
            InsertSecondMealDetais.Parameters.Add("@s_f_lunch_quentity", FirstLunchOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_s_lunch_quentity", SecondLunchOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_f_lunch_total_price", FirstLunchTotalPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_lunch_total_price", SecondLunchTotalPrice);

            InsertSecondMealDetais.Parameters.Add("@s_f_dinner_name", FirstDinnerName);
            InsertSecondMealDetais.Parameters.Add("@s_s_dinner_name", SecondDinnerName);
            InsertSecondMealDetais.Parameters.Add("@s_f_dinner_type", FirstDinnerType);
            InsertSecondMealDetais.Parameters.Add("@s_s_dinner_type", SecondDinnerType);
            InsertSecondMealDetais.Parameters.Add("@s_f_dinner_price", FirstDinnerPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_dinner_price", SecondDinnerPrice);
            InsertSecondMealDetais.Parameters.Add("@s_f_dinner_quentity", FirstDinnerOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_s_dinner_quentity", SecondDinnerOrederdQuentity);
            InsertSecondMealDetais.Parameters.Add("@s_f_dinner_total_price", FirstDinnerTotalPrice);
            InsertSecondMealDetais.Parameters.Add("@s_s_dinner_total_price", SecondDinnerTotalPrice);

            InsertSecondMealDetais.Parameters.Add("@s_total_price", SecondDayTotalMealPrice);

            InsertSecondMealDetais.ExecuteNonQuery();
            InsertSecondMealDetais.Dispose();
        }

        internal void InitializeThirdDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string ThirdDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertThirdMealDetais = new SqlCeCommand("insert into cus_mealDetails_trird (nic_no,t_f_breakfast_name,t_s_breakfast_name,t_f_breakfast_type,t_s_breakfast_type,t_f_breakfast_price,t_s_breakfast_price,t_f_breakfast_quentity,t_s_breakfast_quentity,t_f_breakfast_total_price,t_s_breakfast_total_price,t_f_lunch_name,t_s_lunch_name,t_f_lunch_type,t_s_lunch_type,t_f_lunch_price,t_s_lunch_price,t_f_lunch_quentity,t_s_lunch_quentity,t_f_lunch_total_price,t_s_lunch_total_price,t_f_dinner_name,t_s_dinner_name,t_f_dinner_type,t_s_dinner_type,t_f_dinner_price,t_s_dinner_price,t_f_dinner_quentity,t_s_dinner_quentity,t_f_dinner_total_price,t_s_dinner_total_price,t_total_price) values (@nic_no,@t_f_breakfast_name,@t_s_breakfast_name,@t_f_breakfast_type,@t_s_breakfast_type,@t_f_breakfast_price,@t_s_breakfast_price,@t_f_breakfast_quentity,@t_s_breakfast_quentity,@t_f_breakfast_total_price,@t_s_breakfast_total_price,@t_f_lunch_name,@t_s_lunch_name,@t_f_lunch_type,@t_s_lunch_type,@t_f_lunch_price,@t_s_lunch_price,@t_f_lunch_quentity,@t_s_lunch_quentity,@t_f_lunch_total_price,@t_s_lunch_total_price,@t_f_dinner_name,@t_s_dinner_name,@t_f_dinner_type,@t_s_dinner_type,@t_f_dinner_price,@t_s_dinner_price,@t_f_dinner_quentity,@t_s_dinner_quentity,@t_f_dinner_total_price,@t_s_dinner_total_price,@t_total_price)", conn);
            InsertThirdMealDetais.Parameters.Add("@nic_no", NicNumber);
            InsertThirdMealDetais.Parameters.Add("@t_f_breakfast_name", FirstBreakfastName);
            InsertThirdMealDetais.Parameters.Add("@t_s_breakfast_name", SecondBreakfastName);
            InsertThirdMealDetais.Parameters.Add("@t_f_breakfast_type", FirstBreakfastType);
            InsertThirdMealDetais.Parameters.Add("@t_s_breakfast_type", SecondBreakfastType);
            InsertThirdMealDetais.Parameters.Add("@t_f_breakfast_price", FirstBreakfastPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_breakfast_price", SecondBreakfastPrice);
            InsertThirdMealDetais.Parameters.Add("@t_f_breakfast_quentity", FirstBreakfastOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_s_breakfast_quentity", SecondBreakfastOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_f_breakfast_total_price", FirstBreakfastTotalPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_breakfast_total_price", SecondBreakfastTotalPrice);

            InsertThirdMealDetais.Parameters.Add("@t_f_lunch_name", FirstLunchName);
            InsertThirdMealDetais.Parameters.Add("@t_s_lunch_name", SecondLunchName);
            InsertThirdMealDetais.Parameters.Add("@t_f_lunch_type", FirstLunchType);
            InsertThirdMealDetais.Parameters.Add("@t_s_lunch_type", SecondLunchType);
            InsertThirdMealDetais.Parameters.Add("@t_f_lunch_price", FirstLunchPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_lunch_price", SecondLunchPrice);
            InsertThirdMealDetais.Parameters.Add("@t_f_lunch_quentity", FirstLunchOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_s_lunch_quentity", SecondLunchOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_f_lunch_total_price", FirstLunchTotalPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_lunch_total_price", SecondLunchTotalPrice);

            InsertThirdMealDetais.Parameters.Add("@t_f_dinner_name", FirstDinnerName);
            InsertThirdMealDetais.Parameters.Add("@t_s_dinner_name", SecondDinnerName);
            InsertThirdMealDetais.Parameters.Add("@t_f_dinner_type", FirstDinnerType);
            InsertThirdMealDetais.Parameters.Add("@t_s_dinner_type", SecondDinnerType);
            InsertThirdMealDetais.Parameters.Add("@t_f_dinner_price", FirstDinnerPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_dinner_price", SecondDinnerPrice);
            InsertThirdMealDetais.Parameters.Add("@t_f_dinner_quentity", FirstDinnerOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_s_dinner_quentity", SecondDinnerOrederdQuentity);
            InsertThirdMealDetais.Parameters.Add("@t_f_dinner_total_price", FirstDinnerTotalPrice);
            InsertThirdMealDetais.Parameters.Add("@t_s_dinner_total_price", SecondDinnerTotalPrice);

            InsertThirdMealDetais.Parameters.Add("@t_total_price", ThirdDayTotalMealPrice);

            InsertThirdMealDetais.ExecuteNonQuery();
            InsertThirdMealDetais.Dispose();
        }

        internal void InitializeTravelingInfoForReservation(string NicNumber,string FirstVehicleType, string SecondVehicleType, string ThirdVehicleType, string FirstVehicleNumber, string SecondVehicleNumber, string ThirdVehicleNumber, string FirstVehiclePassengers, string SecondVehiclePassengers, string ThirdVehiclePassengers, string FirstVehiclePrice, string SecondVehiclePrice, string ThirdVehiclePrice, string FirstDestinationName, string SecondDestinationName, string ThirdDestinationName, string FirstDestinationPathNumber, string SecondDestinationPathNumber, string ThirdDestinationPathNumber, string FirstDestinationPrice, string SecondDestinationPrice, string ThirdDestinationPrice, string TotalTravelingPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertTravelInformations = new SqlCeCommand("insert into cus_travelingDetails (nic_no,f_vehicle_type,s_vehicle_type,t_vehicle_type,f_vehicle_no,s_vehicle_no,t_vehicle_no,f_no_of_passengers,s_no_of_passengers,t_no_of_passengers,f_vehicle_price,s_vehicle_price,t_vehicle_price,f_path_type,s_path_type,t_path_type,f_path_no,s_path_no,t_path_no,f_path_price,s_path_price,t_path_price,t_traveling_price) values (@nic_no,@f_vehicle_type,@s_vehicle_type,@t_vehicle_type,@f_vehicle_no,@s_vehicle_no,@t_vehicle_no,@f_no_of_passengers,@s_no_of_passengers,@t_no_of_passengers,@f_vehicle_price,@s_vehicle_price,@t_vehicle_price,@f_path_type,@s_path_type,@t_path_type,@f_path_no,@s_path_no,@t_path_no,@f_path_price,@s_path_price,@t_path_price,@t_traveling_price) " ,conn);
            InsertTravelInformations.Parameters.Add("@nic_no", NicNumber);
            InsertTravelInformations.Parameters.Add("@f_vehicle_type", FirstVehicleType);
            InsertTravelInformations.Parameters.Add("@s_vehicle_type", SecondVehicleType);
            InsertTravelInformations.Parameters.Add("@t_vehicle_type", ThirdVehicleType);

            InsertTravelInformations.Parameters.Add("@f_vehicle_no", FirstVehicleNumber);
            InsertTravelInformations.Parameters.Add("@s_vehicle_no", SecondVehicleNumber);
            InsertTravelInformations.Parameters.Add("@t_vehicle_no", ThirdVehicleNumber);

            InsertTravelInformations.Parameters.Add("@f_no_of_passengers", FirstVehiclePassengers);
            InsertTravelInformations.Parameters.Add("@s_no_of_passengers", SecondVehiclePassengers);
            InsertTravelInformations.Parameters.Add("@t_no_of_passengers", ThirdVehiclePassengers);

            InsertTravelInformations.Parameters.Add("@f_vehicle_price", FirstVehiclePrice);
            InsertTravelInformations.Parameters.Add("@s_vehicle_price", SecondVehiclePrice);
            InsertTravelInformations.Parameters.Add("@t_vehicle_price", ThirdVehiclePrice);

            InsertTravelInformations.Parameters.Add("@f_path_type", FirstDestinationName);
            InsertTravelInformations.Parameters.Add("@s_path_type", SecondDestinationName);
            InsertTravelInformations.Parameters.Add("@t_path_type", ThirdDestinationName);

            InsertTravelInformations.Parameters.Add("@f_path_no", FirstDestinationPathNumber);
            InsertTravelInformations.Parameters.Add("@s_path_no", SecondDestinationPathNumber);
            InsertTravelInformations.Parameters.Add("@t_path_no", ThirdDestinationPathNumber);

            InsertTravelInformations.Parameters.Add("@f_path_price", FirstDestinationPrice);
            InsertTravelInformations.Parameters.Add("@s_path_price", SecondDestinationPrice);
            InsertTravelInformations.Parameters.Add("@t_path_price", ThirdDestinationPrice);

            InsertTravelInformations.Parameters.Add("@t_traveling_price", TotalTravelingPrice);

            
            InsertTravelInformations.ExecuteNonQuery();
            InsertTravelInformations.Dispose();
        }

        internal void InitializeBillDetailsForReservation(string BillNo, string NicNumber, string BillAmount, string NetAmount, string AdvanceAmountSts, string FinalAmountSts,string CompleteAmountSts, string OfferValue,DateTime AdvanceAmountDueDate,DateTime FinalAmountDueDate)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertBillDetails = new SqlCeCommand("insert into billDetails (nic_no,bill_amt,net_amt,advance_amt_sts,final_amt_sts,complete_sts,offer_value,advance_amt_due_date,final_amt_due_date,bill_no) values (@nic_no,@bill_amt,@net_amt,@advance_amt_sts,@final_amt_sts,@complete_sts,@offer_value,@advance_amt_due_date,@final_amt_due_date,@bill_no)", conn);
            InsertBillDetails.Parameters.Add("@nic_no", NicNumber);
            InsertBillDetails.Parameters.Add("@bill_amt", BillAmount);
            InsertBillDetails.Parameters.Add("@net_amt", NetAmount);
            InsertBillDetails.Parameters.Add("@advance_amt_sts", AdvanceAmountSts);
            InsertBillDetails.Parameters.Add("@final_amt_sts", FinalAmountSts);
            InsertBillDetails.Parameters.Add("@complete_sts", CompleteAmountSts);
            InsertBillDetails.Parameters.Add("@offer_value", OfferValue);
            InsertBillDetails.Parameters.Add("@advance_amt_due_date", AdvanceAmountDueDate);
            InsertBillDetails.Parameters.Add("@final_amt_due_date", FinalAmountDueDate);
            InsertBillDetails.Parameters.Add("@bill_no", BillNo);

            InsertBillDetails.ExecuteNonQuery();
            InsertBillDetails.Dispose();
        }

        internal string[] GetCustormerPersonalInfoAndReservationInfo(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] RecivedCustormerDetails = new string[20];
            SqlCeCommand GetCustormerPersonalInfoAndReservationDetails = new SqlCeCommand("select * from cus_personalDetails where nic_no = '" + NicNumber + "'" ,conn);
            SqlCeDataReader CustormerDetailsAndReservation = GetCustormerPersonalInfoAndReservationDetails.ExecuteReader();

            while (CustormerDetailsAndReservation.Read())
            {
                RecivedCustormerDetails[0] = CustormerDetailsAndReservation[1].ToString();
                RecivedCustormerDetails[1] = CustormerDetailsAndReservation[2].ToString();
                RecivedCustormerDetails[2] = CustormerDetailsAndReservation[3].ToString();
                RecivedCustormerDetails[3] = CustormerDetailsAndReservation[4].ToString();
                RecivedCustormerDetails[4] = CustormerDetailsAndReservation[5].ToString();
                RecivedCustormerDetails[5] = CustormerDetailsAndReservation[6].ToString();
                RecivedCustormerDetails[6] = CustormerDetailsAndReservation[7].ToString();
                RecivedCustormerDetails[7] = CustormerDetailsAndReservation[8].ToString();
                RecivedCustormerDetails[8] = CustormerDetailsAndReservation[9].ToString();
                RecivedCustormerDetails[9] = CustormerDetailsAndReservation[10].ToString();
                RecivedCustormerDetails[10] = CustormerDetailsAndReservation[11].ToString();
                RecivedCustormerDetails[11] = CustormerDetailsAndReservation[12].ToString();
                RecivedCustormerDetails[12] = CustormerDetailsAndReservation[13].ToString();
                RecivedCustormerDetails[13] = CustormerDetailsAndReservation[14].ToString();
            }

            CustormerDetailsAndReservation.Dispose();
            return RecivedCustormerDetails;
        }

        internal string[] GetCustormerLocationInfoAndDecorationInfo(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedLocationAndDecorationDetails = new string[20];
            SqlCeCommand GetCustormerLocationDetailsAndDecorationInfo = new SqlCeCommand("select * from cus_location_details where nic_no = '" + NicNumber + "'" ,conn);
            SqlCeDataReader CustormerLocationsAndDecorations = GetCustormerLocationDetailsAndDecorationInfo.ExecuteReader();

            while (CustormerLocationsAndDecorations.Read())
            {
                RecivedLocationAndDecorationDetails[1] = CustormerLocationsAndDecorations[1].ToString();
                RecivedLocationAndDecorationDetails[2] = CustormerLocationsAndDecorations[2].ToString();
                RecivedLocationAndDecorationDetails[3] = CustormerLocationsAndDecorations[3].ToString();
                RecivedLocationAndDecorationDetails[4] = CustormerLocationsAndDecorations[4].ToString();
                RecivedLocationAndDecorationDetails[5] = CustormerLocationsAndDecorations[5].ToString();
                RecivedLocationAndDecorationDetails[6] = CustormerLocationsAndDecorations[6].ToString();
                RecivedLocationAndDecorationDetails[7] = CustormerLocationsAndDecorations[7].ToString();
                RecivedLocationAndDecorationDetails[8] = CustormerLocationsAndDecorations[8].ToString();
                RecivedLocationAndDecorationDetails[9] = CustormerLocationsAndDecorations[9].ToString();
                RecivedLocationAndDecorationDetails[10] = CustormerLocationsAndDecorations[10].ToString();
                RecivedLocationAndDecorationDetails[11] = CustormerLocationsAndDecorations[11].ToString();
                RecivedLocationAndDecorationDetails[12] = CustormerLocationsAndDecorations[12].ToString();
                RecivedLocationAndDecorationDetails[13] = CustormerLocationsAndDecorations[13].ToString();
                RecivedLocationAndDecorationDetails[14] = CustormerLocationsAndDecorations[14].ToString();
                RecivedLocationAndDecorationDetails[15] = CustormerLocationsAndDecorations[15].ToString();
                RecivedLocationAndDecorationDetails[16] = CustormerLocationsAndDecorations[16].ToString();
                RecivedLocationAndDecorationDetails[17] = CustormerLocationsAndDecorations[17].ToString();
                RecivedLocationAndDecorationDetails[18] = CustormerLocationsAndDecorations[18].ToString();
                RecivedLocationAndDecorationDetails[19] = CustormerLocationsAndDecorations[19].ToString();
            }

            CustormerLocationsAndDecorations.Dispose();
            return RecivedLocationAndDecorationDetails;
        }

        internal string[] GetCustormerMealDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedCustormerMealDetails = new string[30];
            SqlCeCommand GetCustormerMealDetails = new SqlCeCommand("select * from cus_mealDetails_first where nic_no = '" + NicNumber + "'" ,conn);
            SqlCeDataReader CustormerMealDetails = GetCustormerMealDetails.ExecuteReader();

            while (CustormerMealDetails.Read())
            {
                RecivedCustormerMealDetails[0] = CustormerMealDetails[1].ToString();
                RecivedCustormerMealDetails[1] = CustormerMealDetails[2].ToString();
                RecivedCustormerMealDetails[2] = CustormerMealDetails[3].ToString();
                RecivedCustormerMealDetails[3] = CustormerMealDetails[4].ToString();
                RecivedCustormerMealDetails[4] = CustormerMealDetails[5].ToString();
                RecivedCustormerMealDetails[5] = CustormerMealDetails[6].ToString();
                RecivedCustormerMealDetails[6] = CustormerMealDetails[7].ToString();
                RecivedCustormerMealDetails[7] = CustormerMealDetails[8].ToString();
                RecivedCustormerMealDetails[8] = CustormerMealDetails[9].ToString();
                RecivedCustormerMealDetails[9] = CustormerMealDetails[10].ToString();
                RecivedCustormerMealDetails[10] = CustormerMealDetails[11].ToString();
                RecivedCustormerMealDetails[11] = CustormerMealDetails[12].ToString();
                RecivedCustormerMealDetails[12] = CustormerMealDetails[13].ToString();
                RecivedCustormerMealDetails[13] = CustormerMealDetails[14].ToString();
                RecivedCustormerMealDetails[14] = CustormerMealDetails[15].ToString();
                RecivedCustormerMealDetails[15] = CustormerMealDetails[16].ToString();
                RecivedCustormerMealDetails[16] = CustormerMealDetails[17].ToString();
                RecivedCustormerMealDetails[17] = CustormerMealDetails[18].ToString();
                RecivedCustormerMealDetails[18] = CustormerMealDetails[19].ToString();
                RecivedCustormerMealDetails[19] = CustormerMealDetails[20].ToString();
                RecivedCustormerMealDetails[20] = CustormerMealDetails[21].ToString();
                RecivedCustormerMealDetails[21] = CustormerMealDetails[22].ToString();
                RecivedCustormerMealDetails[22] = CustormerMealDetails[23].ToString();
                RecivedCustormerMealDetails[23] = CustormerMealDetails[24].ToString();
                RecivedCustormerMealDetails[24] = CustormerMealDetails[25].ToString();
                RecivedCustormerMealDetails[25] = CustormerMealDetails[26].ToString();
                RecivedCustormerMealDetails[26] = CustormerMealDetails[27].ToString();
                RecivedCustormerMealDetails[27] = CustormerMealDetails[28].ToString();
                RecivedCustormerMealDetails[28] = CustormerMealDetails[29].ToString();
            }

            CustormerMealDetails.Dispose();
            return RecivedCustormerMealDetails;
        }

        internal string[] GetCustormerSecondMealDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedCustormerMealDetails = new string[30];
            SqlCeCommand GetCustormerSecondDayMealDetails = new SqlCeCommand("select * from cus_mealDetails_second where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader CustormerSecondDayMealDetails = GetCustormerSecondDayMealDetails.ExecuteReader();

            while (CustormerSecondDayMealDetails.Read())
            {
                RecivedCustormerMealDetails[0] = CustormerSecondDayMealDetails[1].ToString();
                RecivedCustormerMealDetails[1] = CustormerSecondDayMealDetails[2].ToString();
                RecivedCustormerMealDetails[2] = CustormerSecondDayMealDetails[3].ToString();
                RecivedCustormerMealDetails[3] = CustormerSecondDayMealDetails[4].ToString();
                RecivedCustormerMealDetails[4] = CustormerSecondDayMealDetails[5].ToString();
                RecivedCustormerMealDetails[5] = CustormerSecondDayMealDetails[6].ToString();
                RecivedCustormerMealDetails[6] = CustormerSecondDayMealDetails[7].ToString();
                RecivedCustormerMealDetails[7] = CustormerSecondDayMealDetails[8].ToString();
                RecivedCustormerMealDetails[8] = CustormerSecondDayMealDetails[9].ToString();
                RecivedCustormerMealDetails[9] = CustormerSecondDayMealDetails[10].ToString();
                RecivedCustormerMealDetails[10] = CustormerSecondDayMealDetails[11].ToString();
                RecivedCustormerMealDetails[11] = CustormerSecondDayMealDetails[12].ToString();
                RecivedCustormerMealDetails[12] = CustormerSecondDayMealDetails[13].ToString();
                RecivedCustormerMealDetails[13] = CustormerSecondDayMealDetails[14].ToString();
                RecivedCustormerMealDetails[14] = CustormerSecondDayMealDetails[15].ToString();
                RecivedCustormerMealDetails[15] = CustormerSecondDayMealDetails[16].ToString();
                RecivedCustormerMealDetails[16] = CustormerSecondDayMealDetails[17].ToString();
                RecivedCustormerMealDetails[17] = CustormerSecondDayMealDetails[18].ToString();
                RecivedCustormerMealDetails[18] = CustormerSecondDayMealDetails[19].ToString();
                RecivedCustormerMealDetails[19] = CustormerSecondDayMealDetails[20].ToString();
                RecivedCustormerMealDetails[20] = CustormerSecondDayMealDetails[21].ToString();
                RecivedCustormerMealDetails[21] = CustormerSecondDayMealDetails[22].ToString();
                RecivedCustormerMealDetails[22] = CustormerSecondDayMealDetails[23].ToString();
                RecivedCustormerMealDetails[23] = CustormerSecondDayMealDetails[24].ToString();
                RecivedCustormerMealDetails[24] = CustormerSecondDayMealDetails[25].ToString();
                RecivedCustormerMealDetails[25] = CustormerSecondDayMealDetails[26].ToString();
                RecivedCustormerMealDetails[26] = CustormerSecondDayMealDetails[27].ToString();
                RecivedCustormerMealDetails[27] = CustormerSecondDayMealDetails[28].ToString();
                RecivedCustormerMealDetails[28] = CustormerSecondDayMealDetails[29].ToString();
            }

            return RecivedCustormerMealDetails;
        }

        internal string[] GetCustormerThirdMealDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedCustormerMealDetails = new string[30];
            SqlCeCommand GetCustormerThirdDayMealDetails = new SqlCeCommand("select * from cus_mealDetails_trird where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader CustormerThirdDayMealDetails = GetCustormerThirdDayMealDetails.ExecuteReader();

            while (CustormerThirdDayMealDetails.Read())
            {
                RecivedCustormerMealDetails[0] = CustormerThirdDayMealDetails[1].ToString();
                RecivedCustormerMealDetails[1] = CustormerThirdDayMealDetails[2].ToString();
                RecivedCustormerMealDetails[2] = CustormerThirdDayMealDetails[3].ToString();
                RecivedCustormerMealDetails[3] = CustormerThirdDayMealDetails[4].ToString();
                RecivedCustormerMealDetails[4] = CustormerThirdDayMealDetails[5].ToString();
                RecivedCustormerMealDetails[5] = CustormerThirdDayMealDetails[6].ToString();
                RecivedCustormerMealDetails[6] = CustormerThirdDayMealDetails[7].ToString();
                RecivedCustormerMealDetails[7] = CustormerThirdDayMealDetails[8].ToString();
                RecivedCustormerMealDetails[8] = CustormerThirdDayMealDetails[9].ToString();
                RecivedCustormerMealDetails[9] = CustormerThirdDayMealDetails[10].ToString();
                RecivedCustormerMealDetails[10] = CustormerThirdDayMealDetails[11].ToString();
                RecivedCustormerMealDetails[11] = CustormerThirdDayMealDetails[12].ToString();
                RecivedCustormerMealDetails[12] = CustormerThirdDayMealDetails[13].ToString();
                RecivedCustormerMealDetails[13] = CustormerThirdDayMealDetails[14].ToString();
                RecivedCustormerMealDetails[14] = CustormerThirdDayMealDetails[15].ToString();
                RecivedCustormerMealDetails[15] = CustormerThirdDayMealDetails[16].ToString();
                RecivedCustormerMealDetails[16] = CustormerThirdDayMealDetails[17].ToString();
                RecivedCustormerMealDetails[17] = CustormerThirdDayMealDetails[18].ToString();
                RecivedCustormerMealDetails[18] = CustormerThirdDayMealDetails[19].ToString();
                RecivedCustormerMealDetails[19] = CustormerThirdDayMealDetails[20].ToString();
                RecivedCustormerMealDetails[20] = CustormerThirdDayMealDetails[21].ToString();
                RecivedCustormerMealDetails[21] = CustormerThirdDayMealDetails[22].ToString();
                RecivedCustormerMealDetails[22] = CustormerThirdDayMealDetails[23].ToString();
                RecivedCustormerMealDetails[23] = CustormerThirdDayMealDetails[24].ToString();
                RecivedCustormerMealDetails[24] = CustormerThirdDayMealDetails[25].ToString();
                RecivedCustormerMealDetails[25] = CustormerThirdDayMealDetails[26].ToString();
                RecivedCustormerMealDetails[26] = CustormerThirdDayMealDetails[27].ToString();
                RecivedCustormerMealDetails[27] = CustormerThirdDayMealDetails[28].ToString();
                RecivedCustormerMealDetails[28] = CustormerThirdDayMealDetails[29].ToString();
            }

            CustormerThirdDayMealDetails.Dispose();
            return RecivedCustormerMealDetails;
        }

        internal string[] GetCustormerTravellingAndVehicleDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedCustormerLocationAndVehicleDetails = new string[30];
            SqlCeCommand GetCustormerLocationAndVehicleDetails = new SqlCeCommand("select * from cus_travelingDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader CustormerLocationAndVehicleDetails = GetCustormerLocationAndVehicleDetails.ExecuteReader();

            while (CustormerLocationAndVehicleDetails.Read())
            {
                RecivedCustormerLocationAndVehicleDetails[0] = CustormerLocationAndVehicleDetails[1].ToString();
                RecivedCustormerLocationAndVehicleDetails[1] = CustormerLocationAndVehicleDetails[2].ToString();
                RecivedCustormerLocationAndVehicleDetails[2] = CustormerLocationAndVehicleDetails[3].ToString();
                RecivedCustormerLocationAndVehicleDetails[3] = CustormerLocationAndVehicleDetails[4].ToString();
                RecivedCustormerLocationAndVehicleDetails[4] = CustormerLocationAndVehicleDetails[5].ToString();
                RecivedCustormerLocationAndVehicleDetails[5] = CustormerLocationAndVehicleDetails[6].ToString();
                RecivedCustormerLocationAndVehicleDetails[6] = CustormerLocationAndVehicleDetails[7].ToString();
                RecivedCustormerLocationAndVehicleDetails[7] = CustormerLocationAndVehicleDetails[8].ToString();
                RecivedCustormerLocationAndVehicleDetails[8] = CustormerLocationAndVehicleDetails[9].ToString();
                RecivedCustormerLocationAndVehicleDetails[9] = CustormerLocationAndVehicleDetails[10].ToString();
                RecivedCustormerLocationAndVehicleDetails[10] = CustormerLocationAndVehicleDetails[11].ToString();
                RecivedCustormerLocationAndVehicleDetails[11] = CustormerLocationAndVehicleDetails[12].ToString();
                RecivedCustormerLocationAndVehicleDetails[12] = CustormerLocationAndVehicleDetails[13].ToString();
                RecivedCustormerLocationAndVehicleDetails[13] = CustormerLocationAndVehicleDetails[14].ToString();
                RecivedCustormerLocationAndVehicleDetails[14] = CustormerLocationAndVehicleDetails[15].ToString();
                RecivedCustormerLocationAndVehicleDetails[15] = CustormerLocationAndVehicleDetails[16].ToString();
                RecivedCustormerLocationAndVehicleDetails[16] = CustormerLocationAndVehicleDetails[17].ToString();
                RecivedCustormerLocationAndVehicleDetails[17] = CustormerLocationAndVehicleDetails[18].ToString();
                RecivedCustormerLocationAndVehicleDetails[18] = CustormerLocationAndVehicleDetails[19].ToString();
                RecivedCustormerLocationAndVehicleDetails[19] = CustormerLocationAndVehicleDetails[20].ToString();
                RecivedCustormerLocationAndVehicleDetails[20] = CustormerLocationAndVehicleDetails[21].ToString();
                RecivedCustormerLocationAndVehicleDetails[21] = CustormerLocationAndVehicleDetails[22].ToString();
            }

            return RecivedCustormerLocationAndVehicleDetails;
        }

        internal string[] GetCustormerBillPaymentStatus(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string[] RecivedCustormerBillPaymentStatus = new string[1];
            SqlCeCommand GetCustormerBillPaymentDetails = new SqlCeCommand("select * from billDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader CustormerBillPaymentDetails = GetCustormerBillPaymentDetails.ExecuteReader();

            while (CustormerBillPaymentDetails.Read())
            {
                RecivedCustormerBillPaymentStatus[0] = CustormerBillPaymentDetails[5].ToString();
            }

            return RecivedCustormerBillPaymentStatus;
        }

        internal void UpdatingPersonalInfoAndReservationInfo(string NameTitle, string NameWithInitials, string FullName, string Telephone_01, string Telephone_02, string EmailAddress, string NicNumber, int ChildGuestQuentity, int EldersGuestQuentity, int TotalGuestQuentity, DateTime BookInDate, DateTime CheckInDate, int No_Of_Days, DateTime CheckOutDate, string OfferAvailabilityStatus)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdatePersonalInfoAndReservationInfo = new SqlCeCommand("update cus_personalDetails set name_title = '" + NameTitle + "' ,name_with_ini = '" + NameWithInitials + "',full_name = '" + FullName + "',tel_1 = '" + Telephone_01 + "',tel_2 = '" + Telephone_02 + "',email_addr = '" + EmailAddress + "',no_of_guest_child = '" + ChildGuestQuentity + "',no_of_guest_elders = '" + EldersGuestQuentity + "',total_guest = '" + TotalGuestQuentity + "',bookin_date = '" + BookInDate + "',check_in = '" + CheckInDate + "',days = '" + No_Of_Days + "',check_out = '" + CheckOutDate + "',nic_no = '" + NicNumber + "' where nic_no = '" + NicNumber + "'", conn);

            UpdatePersonalInfoAndReservationInfo.ExecuteNonQuery();
            UpdatePersonalInfoAndReservationInfo.Dispose();
        }

        internal void UpdatingLocationInfoAndEventInfo(string FirstLocationCategory, string SecondLocationCategory, string ThirdLocationCategory, string FirstLocationType, string SecondLocationType, string ThirdLocationType, string FirstLocationNumber, string SecondLocationNumber, string ThirdLocationNumber, string FirstLocationGuestQuentity, string SecondLocationGuestQuentity, string ThirdLocationGuestQuentity, string FirstLocationPrice, string SecondLocationPrice, string ThirdLocationPrice,string TotalLocationPrice, string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateLocationDetails = new SqlCeCommand("update cus_location_details set f_cetegory = '" + FirstLocationCategory + "',s_cetegory = '" + SecondLocationCategory + "',t_cetegory = '" + ThirdLocationCategory + "' ,f_type = '" + FirstLocationType + "',s_type = '" + SecondLocationType + "',t_type = '" + ThirdLocationType + "',f_room_no = '" + FirstLocationNumber + "',s_room_no = '" + SecondLocationNumber + "',t_room_no = '" + ThirdLocationNumber + "',f_no_of_guest = '" + FirstLocationGuestQuentity + "',s_no_of_guest = '" + SecondLocationGuestQuentity + "',t_no_of_guest = '" + ThirdLocationGuestQuentity + "',f_room_price = '" + FirstLocationPrice + "',s_room_price = '" + SecondLocationPrice + "',t_room_price = '" + ThirdLocationPrice + "',total_loc_price = '" + TotalLocationPrice + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateLocationDetails.ExecuteNonQuery();
            UpdateLocationDetails.Dispose();
        }

        internal void UpdateEbentsNamesAndDecorationDetails(string EventName, string EventNumber, string EventPrice, string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateEventNamesAndDecorationTypes = new SqlCeCommand("update cus_location_details set event_name = '" + EventName + "', event_no = '" + EventNumber + "' ,decoration_price = '" + EventPrice + "' where nic_no = '" + NicNumber + "'" ,conn);

            UpdateEventNamesAndDecorationTypes.ExecuteNonQuery();
            UpdateEventNamesAndDecorationTypes.Dispose();
        }

        internal void UpdatingFirstDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string FirstDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateFirstMealDetais = new SqlCeCommand("update cus_mealDetails_first set f_f_breakfast_name = '" + FirstBreakfastName + "',f_s_breakfast_name = '" + SecondBreakfastName + "',f_f_breakfast_type = '" + FirstBreakfastType + "',f_s_breakfast_type = '" + SecondBreakfastType + "',f_f_breakfast_price = '" + FirstBreakfastPrice + "',f_s_breakfast_price = '" + SecondBreakfastPrice + "',f_f_breakfast_quentity = '" + FirstBreakfastOrederdQuentity + "',f_s_breakfast_quentity = '" + SecondBreakfastOrederdQuentity + "',f_f_breakfast_total_price = '" + FirstBreakfastTotalPrice + "',f_s_breakfast_total_price = '" + SecondBreakfastTotalPrice + "',f_f_lunch_name = '" + FirstLunchName + "',f_s_lunch_name = '" + SecondLunchName + "',f_f_lunch_type = '" + FirstLunchType + "',f_s_lunch_type = '" + SecondLunchType + "',f_f_lunch_price = '" + FirstLunchPrice + "',f_s_lunch_price = '" + SecondLunchPrice + "',f_f_lunch_quentity = '" + FirstLunchOrederdQuentity + "',f_s_lunch_quentity = '" + SecondLunchOrederdQuentity + "',f_f_lunch_total_price = '" + FirstLunchTotalPrice + "',f_s_lunch_total_price = '" + SecondLunchTotalPrice + "',f_f_dinner_name = '" + FirstDinnerName + "',f_s_dinner_name = '" + SecondDinnerName + "',f_f_dinner_type = '" + FirstDinnerType + "',f_s_dinner_type = '" + SecondDinnerType + "',f_f_dinner_price = '" + FirstDinnerPrice + "',f_s_dinner_price = '" + SecondDinnerPrice + "',f_f_dinner_quentity = '" + FirstDinnerOrederdQuentity + "',f_s_dinner_quentity = '" + SecondDinnerOrederdQuentity + "',f_f_dinner_total_price = '" + FirstDinnerTotalPrice + "',f_s_dinner_total_price = '" + SecondDinnerTotalPrice + "',f_total_price = '" + FirstDayTotalMealPrice + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateFirstMealDetais.ExecuteNonQuery();
            UpdateFirstMealDetais.Dispose();
        }

        internal void UpdateSecondDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string SecondDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateSecondMealDetais = new SqlCeCommand("update cus_mealDetails_second set s_f_breakfast_name = '" + FirstBreakfastName + "',s_s_breakfast_name = '" + SecondBreakfastName + "',s_f_breakfast_type = '" + FirstBreakfastType + "',s_s_breakfast_type = '" + SecondBreakfastType + "',s_f_breakfast_price = '" + FirstBreakfastPrice + "',s_s_breakfast_price = '" + SecondBreakfastPrice + "',s_f_breakfast_quentity = '" + FirstBreakfastOrederdQuentity + "',s_s_breakfast_quentity = '" + SecondBreakfastOrederdQuentity + "',s_f_breakfast_total_price = '" + FirstBreakfastTotalPrice + "',s_s_breakfast_total_price = '" + SecondBreakfastTotalPrice + "',s_f_lunch_name = '" + FirstLunchName + "',s_s_lunch_name = '" + SecondLunchName + "',s_f_lunch_type = '" + FirstLunchType + "',s_s_lunch_type = '" + SecondLunchType + "',s_f_lunch_price = '" + FirstLunchPrice + "',s_s_lunch_price = '" + SecondLunchPrice + "',s_f_lunch_quentity = '" + FirstLunchOrederdQuentity + "',s_s_lunch_quentity = '" + SecondLunchOrederdQuentity + "',s_f_lunch_total_price = '" + FirstLunchTotalPrice + "',s_s_lunch_total_price = '" + SecondLunchTotalPrice + "',s_f_dinner_name =  '" + FirstDinnerName + "',s_s_dinner_name = '" + SecondDinnerName + "',s_f_dinner_type = '" + FirstDinnerType + "',s_s_dinner_type = '" + SecondDinnerType + "',s_f_dinner_price = '" + FirstDinnerPrice + "',s_s_dinner_price = '" + SecondDinnerPrice + "',s_f_dinner_quentity = '" + FirstDinnerOrederdQuentity + "',s_s_dinner_quentity = '" + SecondDinnerOrederdQuentity + "',s_f_dinner_total_price = '" + FirstDinnerTotalPrice + "',s_s_dinner_total_price = '" + SecondDinnerTotalPrice + "',s_total_price = '" + SecondDayTotalMealPrice + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateSecondMealDetais.ExecuteNonQuery();
            UpdateSecondMealDetais.Dispose();
        }

        internal void UpdatingThirdDayMealInfo(string NicNumber, string FirstBreakfastName, string SecondBreakfastName, string FirstBreakfastType, string SecondBreakfastType, string FirstBreakfastQuentity, string SecondBreakfastQuentity, string FirstBreakfastPrice, string SecondBreakfastPrice, string FirstBreakfastOrederdQuentity, string SecondBreakfastOrederdQuentity, string FirstBreakfastTotalPrice, string SecondBreakfastTotalPrice, string FirstLunchName, string SecondLunchName, string FirstLunchType, string SecondLunchType, string FirstLunchQuentity, string SecondLunchQuentity, string FirstLunchPrice, string SecondLunchPrice, string FirstLunchOrederdQuentity, string SecondLunchOrederdQuentity, string FirstLunchTotalPrice, string SecondLunchTotalPrice, string FirstDinnerName, string SecondDinnerName, string FirstDinnerType, string SecondDinnerType, string FirstDinnerQuentity, string SecondDinnerQuentity, string FirstDinnerPrice, string SecondDinnerPrice, string FirstDinnerOrederdQuentity, string SecondDinnerOrederdQuentity, string FirstDinnerTotalPrice, string SecondDinnerTotalPrice, string ThirdDayTotalMealPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateThirdMealDetais = new SqlCeCommand("update cus_mealDetails_trird set t_f_breakfast_name = '" + FirstBreakfastName + "',t_s_breakfast_name = '" + SecondBreakfastName + "',t_f_breakfast_type = '" + FirstBreakfastType + "',t_s_breakfast_type = '" + SecondBreakfastType + "',t_f_breakfast_price = '" + FirstBreakfastPrice + "',t_s_breakfast_price = '" + SecondBreakfastPrice + "',t_f_breakfast_quentity = '" + FirstBreakfastOrederdQuentity + "',t_s_breakfast_quentity = '" + SecondBreakfastOrederdQuentity + "',t_f_breakfast_total_price = '" + FirstBreakfastTotalPrice + "',t_s_breakfast_total_price = '" + SecondBreakfastTotalPrice + "',t_f_lunch_name = '" + FirstLunchName + "',t_s_lunch_name = '" + SecondLunchName + "',t_f_lunch_type = '" + FirstLunchType + "',t_s_lunch_type = '" + SecondLunchType + "',t_f_lunch_price = '" + FirstLunchPrice + "',t_s_lunch_price = '" + SecondLunchPrice + "',t_f_lunch_quentity = '" + FirstLunchOrederdQuentity + "',t_s_lunch_quentity = '" + SecondLunchOrederdQuentity + "',t_f_lunch_total_price = '" + FirstLunchTotalPrice + "',t_s_lunch_total_price = '" + SecondLunchTotalPrice + "',t_f_dinner_name = '" + FirstDinnerName + "',t_s_dinner_name = '" + SecondDinnerName + "',t_f_dinner_type = '" + FirstDinnerType + "',t_s_dinner_type = '" + SecondDinnerType + "',t_f_dinner_price = '" + FirstDinnerPrice + "',t_s_dinner_price = '" + SecondDinnerPrice + "',t_f_dinner_quentity = '" + FirstDinnerOrederdQuentity + "',t_s_dinner_quentity = '" + SecondDinnerOrederdQuentity + "',t_f_dinner_total_price = '" + FirstDinnerTotalPrice + "',t_s_dinner_total_price = '" + SecondDinnerTotalPrice + "',t_total_price = '" + ThirdDayTotalMealPrice + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateThirdMealDetais.ExecuteNonQuery();
            UpdateThirdMealDetais.Dispose();
        }

        internal void UpdateTravelingInfoForReservation(string NicNumber, string FirstVehicleType, string SecondVehicleType, string ThirdVehicleType, string FirstVehicleNumber, string SecondVehicleNumber, string ThirdVehicleNumber, string FirstVehiclePassengers, string SecondVehiclePassengers, string ThirdVehiclePassengers, string FirstVehiclePrice, string SecondVehiclePrice, string ThirdVehiclePrice, string FirstDestinationName, string SecondDestinationName, string ThirdDestinationName, string FirstDestinationPathNumber, string SecondDestinationPathNumber, string ThirdDestinationPathNumber, string FirstDestinationPrice, string SecondDestinationPrice, string ThirdDestinationPrice, string TotalTravelingPrice)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateTravelInformations = new SqlCeCommand("update cus_travelingDetails set f_vehicle_type = '" + FirstVehicleType + "',s_vehicle_type = '" + SecondVehicleType + "',t_vehicle_type = '" + ThirdVehicleType + "',f_vehicle_no = '" + FirstVehicleNumber + "',s_vehicle_no = '" + SecondVehicleNumber + "',t_vehicle_no = '" + ThirdVehicleNumber + "',f_no_of_passengers = '" + FirstVehiclePassengers + "',s_no_of_passengers = '" + SecondVehiclePassengers + "',t_no_of_passengers = '" + ThirdVehiclePassengers + "',f_vehicle_price = '" + FirstVehiclePrice + "',s_vehicle_price = '" + SecondVehiclePrice + "',t_vehicle_price = '" + ThirdVehiclePrice + "',f_path_type = '" + FirstDestinationName + "',s_path_type = '" + SecondDestinationName + "',t_path_type = '" + ThirdDestinationName + "',f_path_no = '" + FirstDestinationPathNumber + "',s_path_no = '" + SecondDestinationPathNumber + "',t_path_no = '" + ThirdDestinationPathNumber + "',f_path_price = '" + FirstDestinationPrice + "',s_path_price = '" + SecondDestinationPrice + "',t_path_price = '" + ThirdDestinationPrice + "',t_traveling_price = '" + TotalTravelingPrice + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateTravelInformations.ExecuteNonQuery();
            UpdateTravelInformations.Dispose();
        }

        internal void UpdateBillDetailsForReservation(string NicNumber, string BillAmount, string NetAmount, string AdvanceAmountSts, string FinalAmountSts, string CompleteAmountSts, string OfferValue)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateBillDetails = new SqlCeCommand("update billDetails set bill_amt = '" + BillAmount + "',net_amt = '" + NetAmount + "',advance_amt_sts = '" + AdvanceAmountSts + "',final_amt_sts = '" + FinalAmountSts + "',complete_sts = '" + CompleteAmountSts + "',offer_value = '" + OfferValue + "' where nic_no = '" + NicNumber + "'", conn);

            UpdateBillDetails.ExecuteNonQuery();
            UpdateBillDetails.Dispose();
        }

        internal void DeleteCustormerPersonalInfoAndReservationDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand DeletePersonalInfoAndReservationInfo = new SqlCeCommand("delete from cus_personalDetails where nic_no = '" + NicNumber + "'" ,conn);
            DeletePersonalInfoAndReservationInfo.ExecuteNonQuery();
            DeletePersonalInfoAndReservationInfo.Dispose();

            SqlCeCommand DeleteLocationDetailsAndEventsDetails = new SqlCeCommand("delete from cus_location_Details where nic_no = '" + NicNumber + "'", conn);
            DeleteLocationDetailsAndEventsDetails.ExecuteNonQuery();
            DeleteLocationDetailsAndEventsDetails.Dispose();

            SqlCeCommand DeleteCustormerFirstDayMealDetails= new SqlCeCommand("delete from cus_mealDetails_first where nic_no = '" + NicNumber + "'", conn);
            DeleteCustormerFirstDayMealDetails.ExecuteNonQuery();
            DeleteCustormerFirstDayMealDetails.Dispose();

            SqlCeCommand DeleteCustormerSecondDayMealDetails = new SqlCeCommand("delete from cus_mealDetails_second where nic_no = '" + NicNumber + "'", conn);
            DeleteCustormerSecondDayMealDetails.ExecuteNonQuery();
            DeleteCustormerSecondDayMealDetails.Dispose();

            SqlCeCommand DeleteCustormerThirdDayMealDetails = new SqlCeCommand("delete from cus_mealDetails_trird where nic_no = '" + NicNumber + "'", conn);
            DeleteCustormerThirdDayMealDetails.ExecuteNonQuery();
            DeleteCustormerThirdDayMealDetails.Dispose();

            SqlCeCommand DeleteCustormerTravellingDetails = new SqlCeCommand("delete from cus_travelingDetails where nic_no = '" + NicNumber + "'", conn);
            DeleteCustormerTravellingDetails.ExecuteNonQuery();
            DeleteCustormerTravellingDetails.Dispose();

            SqlCeCommand DeleteCustormerBillDetails = new SqlCeCommand("delete from billDetails where nic_no = '" + NicNumber + "'", conn);
            DeleteCustormerBillDetails.ExecuteNonQuery();
            DeleteCustormerBillDetails.Dispose();
        }

        internal int GetDatabaseTableRecordCount()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int RecordCount = 0;
            SqlCeCommand GetDatabaseTableRecordCount = new SqlCeCommand("select count(*) from cus_personalDetails" ,conn);
            SqlCeDataReader DatabaseTableRecordCount = GetDatabaseTableRecordCount.ExecuteReader();

            while (DatabaseTableRecordCount.Read())
            {
                RecordCount = Convert.ToInt32(DatabaseTableRecordCount[0].ToString());
            }

            return RecordCount;
        }
    }
}
