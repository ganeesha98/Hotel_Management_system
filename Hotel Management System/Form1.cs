using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetUserControlForDisplay()
        {
            dashboard_btn.Checked = true;
            custormermgmt_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            search_btn.Checked = false;
            settings_btn.Checked = false;

            dashboard_form1.Show();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();
            searchSettings1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetUserControlForDisplay();
        }

        private void custormermgmt_btn_Click_1(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = true;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            search_btn.Checked = false;
            settings_btn.Checked = false;

            dashboard_form1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            custormer_details1.Show();
            custormer_details1.BringToFront();
        }

        private void locationmgmt_btn_Click_1(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            locationmgmt_btn.Checked = true;

            custormer_details1.Hide();
            dashboard_form1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            location_details1.Show();
            location_details1.BringToFront();
        }

        private void mealmgmt_btn_Click_1(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            mealmgmt_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            meal_details1.Show();
            meal_details1.BringToFront();
        }

        private void travelingmgmt_btn_Click_1(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            travelingmgmt_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            meal_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            traveling_details1.Show();
            traveling_details1.BringToFront();
        }

        private void vrhiclemgmt_btn_Click_1(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            vrhiclemgmt_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            vehicle_details1.Show();
            vehicle_details1.BringToFront();
        }

        private void empmgmt_btn_Click(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            empmgmt_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            employee_details1.Show();
            employee_details1.BringToFront();
            
        }

        private void paymentmgmt_btn_Click(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = false;
            paymentmgmt_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            settings_form1.Hide();

            payment_details1.Show();
            payment_details1.BringToFront();
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            custormermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            search_btn.Checked = false;
            settings_btn.Checked = true;

            dashboard_form1.Hide();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();

            settings_form1.Show();
            settings_form1.BringToFront();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            GetUserControlForDisplay();
            dashboard_form1.BringToFront();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            dashboard_btn.Checked = true;
            custormermgmt_btn.Checked = false;
            mealmgmt_btn.Checked = false;
            travelingmgmt_btn.Checked = false;
            locationmgmt_btn.Checked = false;
            empmgmt_btn.Checked = false;
            paymentmgmt_btn.Checked = false;
            vrhiclemgmt_btn.Checked = false;
            settings_btn.Checked = false;
            search_btn.Checked = true;

            dashboard_form1.Show();
            custormer_details1.Hide();
            meal_details1.Hide();
            traveling_details1.Hide();
            location_details1.Hide();
            vehicle_details1.Hide();
            employee_details1.Hide();
            payment_details1.Hide();
            settings_form1.Hide();

            searchSettings1.Show();
            searchSettings1.BringToFront();
        }

        
    }
}
