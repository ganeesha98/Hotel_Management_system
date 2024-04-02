namespace Hotel_Management_System
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sqlCeConnection1 = new System.Data.SqlServerCe.SqlCeConnection();
            this.sqlCeCommand1 = new System.Data.SqlServerCe.SqlCeCommand();
            this.gunaGradientPanel1 = new Guna.UI.WinForms.GunaGradientPanel();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.search_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settings_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.paymentmgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.vrhiclemgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.travelingmgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.mealmgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.locationmgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.custormermgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.empmgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.dashboard_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.dashboard_form1 = new Hotel_Management_System.dashboard_form();
            this.searchSettings1 = new Hotel_Management_System.SearchSettings();
            this.vehicle_details1 = new Hotel_Management_System.vehicle_details();
            this.traveling_details1 = new Hotel_Management_System.traveling_details();
            this.settings_form1 = new Hotel_Management_System.settings_form();
            this.payment_details1 = new Hotel_Management_System.payment_details();
            this.meal_details1 = new Hotel_Management_System.meal_details();
            this.location_details1 = new Hotel_Management_System.location_details();
            this.employee_details1 = new Hotel_Management_System.employee_details();
            this.custormer_details1 = new Hotel_Management_System.custormer_details();
            this.gunaGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlCeCommand1
            // 
            this.sqlCeCommand1.CommandTimeout = 0;
            this.sqlCeCommand1.Connection = null;
            this.sqlCeCommand1.IndexName = null;
            this.sqlCeCommand1.Transaction = null;
            // 
            // gunaGradientPanel1
            // 
            this.gunaGradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gunaGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaGradientPanel1.BackgroundImage")));
            this.gunaGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaGradientPanel1.Controls.Add(this.gunaSeparator1);
            this.gunaGradientPanel1.Controls.Add(this.search_btn);
            this.gunaGradientPanel1.Controls.Add(this.panel1);
            this.gunaGradientPanel1.Controls.Add(this.settings_btn);
            this.gunaGradientPanel1.Controls.Add(this.paymentmgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.vrhiclemgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.travelingmgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.mealmgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.locationmgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.custormermgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.empmgmt_btn);
            this.gunaGradientPanel1.Controls.Add(this.dashboard_btn);
            this.gunaGradientPanel1.GradientColor1 = System.Drawing.Color.SteelBlue;
            this.gunaGradientPanel1.GradientColor2 = System.Drawing.Color.Navy;
            this.gunaGradientPanel1.GradientColor3 = System.Drawing.Color.DeepSkyBlue;
            this.gunaGradientPanel1.GradientColor4 = System.Drawing.Color.DarkSlateGray;
            this.gunaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradientPanel1.Name = "gunaGradientPanel1";
            this.gunaGradientPanel1.Size = new System.Drawing.Size(264, 740);
            this.gunaGradientPanel1.TabIndex = 7;
            this.gunaGradientPanel1.Text = "gunaGradientPanel1";
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(0, 634);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(264, 42);
            this.gunaSeparator1.TabIndex = 18;
            // 
            // search_btn
            // 
            this.search_btn.Animated = true;
            this.search_btn.AnimationHoverSpeed = 0.1F;
            this.search_btn.AnimationSpeed = 0.03F;
            this.search_btn.BackColor = System.Drawing.Color.Transparent;
            this.search_btn.BaseColor = System.Drawing.Color.Transparent;
            this.search_btn.BorderColor = System.Drawing.Color.Black;
            this.search_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.search_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.search_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.search_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("search_btn.CheckedImage")));
            this.search_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.search_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.search_btn.FocusedColor = System.Drawing.Color.Empty;
            this.search_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.Color.White;
            this.search_btn.Image = global::Hotel_Management_System.Properties.Resources.settings;
            this.search_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.search_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.search_btn.Location = new System.Drawing.Point(0, 678);
            this.search_btn.Name = "search_btn";
            this.search_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.search_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.search_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.search_btn.OnHoverImage = null;
            this.search_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.search_btn.OnPressedColor = System.Drawing.Color.Black;
            this.search_btn.Radius = 20;
            this.search_btn.Size = new System.Drawing.Size(317, 45);
            this.search_btn.TabIndex = 10;
            this.search_btn.Text = "     Search Sections";
            this.search_btn.Visible = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(40, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 112);
            this.panel1.TabIndex = 9;
            // 
            // settings_btn
            // 
            this.settings_btn.Animated = true;
            this.settings_btn.AnimationHoverSpeed = 0.1F;
            this.settings_btn.AnimationSpeed = 0.03F;
            this.settings_btn.BackColor = System.Drawing.Color.Transparent;
            this.settings_btn.BaseColor = System.Drawing.Color.Transparent;
            this.settings_btn.BorderColor = System.Drawing.Color.Black;
            this.settings_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.settings_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.settings_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.settings_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("settings_btn.CheckedImage")));
            this.settings_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.settings_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.settings_btn.FocusedColor = System.Drawing.Color.Empty;
            this.settings_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_btn.ForeColor = System.Drawing.Color.White;
            this.settings_btn.Image = global::Hotel_Management_System.Properties.Resources.settings;
            this.settings_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.settings_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.settings_btn.Location = new System.Drawing.Point(3, 424);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.settings_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.settings_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.settings_btn.OnHoverImage = null;
            this.settings_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.settings_btn.OnPressedColor = System.Drawing.Color.Black;
            this.settings_btn.Radius = 20;
            this.settings_btn.Size = new System.Drawing.Size(317, 45);
            this.settings_btn.TabIndex = 8;
            this.settings_btn.Text = "     Settings";
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // paymentmgmt_btn
            // 
            this.paymentmgmt_btn.Animated = true;
            this.paymentmgmt_btn.AnimationHoverSpeed = 0.1F;
            this.paymentmgmt_btn.AnimationSpeed = 0.03F;
            this.paymentmgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.paymentmgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.paymentmgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.paymentmgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.paymentmgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.paymentmgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.paymentmgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_paypal_144;
            this.paymentmgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.paymentmgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentmgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.paymentmgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.paymentmgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentmgmt_btn.ForeColor = System.Drawing.Color.White;
            this.paymentmgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_paypal_144;
            this.paymentmgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.paymentmgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.paymentmgmt_btn.Location = new System.Drawing.Point(3, 373);
            this.paymentmgmt_btn.Name = "paymentmgmt_btn";
            this.paymentmgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.paymentmgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.paymentmgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.paymentmgmt_btn.OnHoverImage = null;
            this.paymentmgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.paymentmgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.paymentmgmt_btn.Radius = 20;
            this.paymentmgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.paymentmgmt_btn.TabIndex = 7;
            this.paymentmgmt_btn.Text = "     Payment Mgt.";
            this.paymentmgmt_btn.Click += new System.EventHandler(this.paymentmgmt_btn_Click);
            // 
            // vrhiclemgmt_btn
            // 
            this.vrhiclemgmt_btn.Animated = true;
            this.vrhiclemgmt_btn.AnimationHoverSpeed = 0.1F;
            this.vrhiclemgmt_btn.AnimationSpeed = 0.03F;
            this.vrhiclemgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.vrhiclemgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.vrhiclemgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.vrhiclemgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.vrhiclemgmt_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.vrhiclemgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.vrhiclemgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_car_rental_96;
            this.vrhiclemgmt_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.vrhiclemgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vrhiclemgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.vrhiclemgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.vrhiclemgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrhiclemgmt_btn.ForeColor = System.Drawing.Color.White;
            this.vrhiclemgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_car_rental_96;
            this.vrhiclemgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.vrhiclemgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.vrhiclemgmt_btn.Location = new System.Drawing.Point(0, 475);
            this.vrhiclemgmt_btn.Name = "vrhiclemgmt_btn";
            this.vrhiclemgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.vrhiclemgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.vrhiclemgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.vrhiclemgmt_btn.OnHoverImage = null;
            this.vrhiclemgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.vrhiclemgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.vrhiclemgmt_btn.Radius = 20;
            this.vrhiclemgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.vrhiclemgmt_btn.TabIndex = 6;
            this.vrhiclemgmt_btn.Text = "     Vehicle Mgt.";
            this.vrhiclemgmt_btn.Visible = false;
            this.vrhiclemgmt_btn.Click += new System.EventHandler(this.vrhiclemgmt_btn_Click_1);
            // 
            // travelingmgmt_btn
            // 
            this.travelingmgmt_btn.Animated = true;
            this.travelingmgmt_btn.AnimationHoverSpeed = 0.1F;
            this.travelingmgmt_btn.AnimationSpeed = 0.03F;
            this.travelingmgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.travelingmgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.travelingmgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.travelingmgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.travelingmgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.travelingmgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.travelingmgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_place_marker_96;
            this.travelingmgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.travelingmgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.travelingmgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.travelingmgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.travelingmgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.travelingmgmt_btn.ForeColor = System.Drawing.Color.White;
            this.travelingmgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_place_marker_96;
            this.travelingmgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.travelingmgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.travelingmgmt_btn.Location = new System.Drawing.Point(0, 526);
            this.travelingmgmt_btn.Name = "travelingmgmt_btn";
            this.travelingmgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.travelingmgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.travelingmgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.travelingmgmt_btn.OnHoverImage = null;
            this.travelingmgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.travelingmgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.travelingmgmt_btn.Radius = 20;
            this.travelingmgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.travelingmgmt_btn.TabIndex = 5;
            this.travelingmgmt_btn.Text = "     Traveling Mgt.";
            this.travelingmgmt_btn.Visible = false;
            this.travelingmgmt_btn.Click += new System.EventHandler(this.travelingmgmt_btn_Click_1);
            // 
            // mealmgmt_btn
            // 
            this.mealmgmt_btn.Animated = true;
            this.mealmgmt_btn.AnimationHoverSpeed = 0.1F;
            this.mealmgmt_btn.AnimationSpeed = 0.03F;
            this.mealmgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.mealmgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.mealmgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.mealmgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.mealmgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.mealmgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.mealmgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_hamburger_96;
            this.mealmgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.mealmgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mealmgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.mealmgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.mealmgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mealmgmt_btn.ForeColor = System.Drawing.Color.White;
            this.mealmgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_hamburger_96;
            this.mealmgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.mealmgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.mealmgmt_btn.Location = new System.Drawing.Point(0, 322);
            this.mealmgmt_btn.Name = "mealmgmt_btn";
            this.mealmgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.mealmgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.mealmgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.mealmgmt_btn.OnHoverImage = null;
            this.mealmgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.mealmgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.mealmgmt_btn.Radius = 20;
            this.mealmgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.mealmgmt_btn.TabIndex = 4;
            this.mealmgmt_btn.Text = "     Meal Mgt.";
            this.mealmgmt_btn.Click += new System.EventHandler(this.mealmgmt_btn_Click_1);
            // 
            // locationmgmt_btn
            // 
            this.locationmgmt_btn.Animated = true;
            this.locationmgmt_btn.AnimationHoverSpeed = 0.1F;
            this.locationmgmt_btn.AnimationSpeed = 0.03F;
            this.locationmgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.locationmgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.locationmgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.locationmgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.locationmgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.locationmgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.locationmgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_room_96;
            this.locationmgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.locationmgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locationmgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.locationmgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.locationmgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationmgmt_btn.ForeColor = System.Drawing.Color.White;
            this.locationmgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_room_96;
            this.locationmgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.locationmgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.locationmgmt_btn.Location = new System.Drawing.Point(0, 271);
            this.locationmgmt_btn.Name = "locationmgmt_btn";
            this.locationmgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.locationmgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.locationmgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.locationmgmt_btn.OnHoverImage = null;
            this.locationmgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.locationmgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.locationmgmt_btn.Radius = 20;
            this.locationmgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.locationmgmt_btn.TabIndex = 3;
            this.locationmgmt_btn.Text = "     Location Mgt.";
            this.locationmgmt_btn.Click += new System.EventHandler(this.locationmgmt_btn_Click_1);
            // 
            // custormermgmt_btn
            // 
            this.custormermgmt_btn.Animated = true;
            this.custormermgmt_btn.AnimationHoverSpeed = 0.1F;
            this.custormermgmt_btn.AnimationSpeed = 0.03F;
            this.custormermgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.custormermgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.custormermgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.custormermgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.custormermgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.custormermgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.custormermgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_add_user_male_skin_type_7_961;
            this.custormermgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.custormermgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.custormermgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.custormermgmt_btn.FocusedColor = System.Drawing.Color.Transparent;
            this.custormermgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custormermgmt_btn.ForeColor = System.Drawing.Color.White;
            this.custormermgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_add_user_male_skin_type_7_961;
            this.custormermgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.custormermgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.custormermgmt_btn.Location = new System.Drawing.Point(0, 220);
            this.custormermgmt_btn.Name = "custormermgmt_btn";
            this.custormermgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.custormermgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.custormermgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.custormermgmt_btn.OnHoverImage = null;
            this.custormermgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.custormermgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.custormermgmt_btn.Radius = 20;
            this.custormermgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.custormermgmt_btn.TabIndex = 2;
            this.custormermgmt_btn.Text = "     Custormer Mgt.";
            this.custormermgmt_btn.Click += new System.EventHandler(this.custormermgmt_btn_Click_1);
            // 
            // empmgmt_btn
            // 
            this.empmgmt_btn.Animated = true;
            this.empmgmt_btn.AnimationHoverSpeed = 0.1F;
            this.empmgmt_btn.AnimationSpeed = 0.03F;
            this.empmgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.empmgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.empmgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.empmgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.empmgmt_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.empmgmt_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.empmgmt_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_user_groups_skin_type_7_96;
            this.empmgmt_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.empmgmt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.empmgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.empmgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.empmgmt_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empmgmt_btn.ForeColor = System.Drawing.Color.White;
            this.empmgmt_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_user_groups_skin_type_7_96;
            this.empmgmt_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.empmgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.empmgmt_btn.Location = new System.Drawing.Point(0, 169);
            this.empmgmt_btn.Name = "empmgmt_btn";
            this.empmgmt_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.empmgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.empmgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.empmgmt_btn.OnHoverImage = null;
            this.empmgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.empmgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.empmgmt_btn.Radius = 20;
            this.empmgmt_btn.Size = new System.Drawing.Size(317, 45);
            this.empmgmt_btn.TabIndex = 1;
            this.empmgmt_btn.Text = "     Employee Mgt.";
            this.empmgmt_btn.Click += new System.EventHandler(this.empmgmt_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.Animated = true;
            this.dashboard_btn.AnimationHoverSpeed = 0.1F;
            this.dashboard_btn.AnimationSpeed = 0.03F;
            this.dashboard_btn.BackColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.BaseColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.BorderColor = System.Drawing.Color.Black;
            this.dashboard_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.dashboard_btn.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.CheckedForeColor = System.Drawing.Color.Black;
            this.dashboard_btn.CheckedImage = global::Hotel_Management_System.Properties.Resources.icons8_combo_chart_96;
            this.dashboard_btn.CheckedLineColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dashboard_btn.FocusedColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Image = global::Hotel_Management_System.Properties.Resources.icons8_combo_chart_96;
            this.dashboard_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.dashboard_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.dashboard_btn.Location = new System.Drawing.Point(0, 118);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.OnHoverBaseColor = System.Drawing.Color.Gold;
            this.dashboard_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.dashboard_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.dashboard_btn.OnHoverImage = null;
            this.dashboard_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.dashboard_btn.OnPressedColor = System.Drawing.Color.Black;
            this.dashboard_btn.Radius = 20;
            this.dashboard_btn.Size = new System.Drawing.Size(317, 45);
            this.dashboard_btn.TabIndex = 0;
            this.dashboard_btn.Text = "     Dashboard";
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // dashboard_form1
            // 
            this.dashboard_form1.BackColor = System.Drawing.Color.White;
            this.dashboard_form1.Location = new System.Drawing.Point(265, 24);
            this.dashboard_form1.Name = "dashboard_form1";
            this.dashboard_form1.Size = new System.Drawing.Size(1125, 718);
            this.dashboard_form1.TabIndex = 17;
            // 
            // searchSettings1
            // 
            this.searchSettings1.BackColor = System.Drawing.Color.White;
            this.searchSettings1.Location = new System.Drawing.Point(266, 24);
            this.searchSettings1.Name = "searchSettings1";
            this.searchSettings1.Size = new System.Drawing.Size(1119, 716);
            this.searchSettings1.TabIndex = 16;
            // 
            // vehicle_details1
            // 
            this.vehicle_details1.BackColor = System.Drawing.Color.White;
            this.vehicle_details1.Location = new System.Drawing.Point(265, 24);
            this.vehicle_details1.Name = "vehicle_details1";
            this.vehicle_details1.Size = new System.Drawing.Size(1120, 716);
            this.vehicle_details1.TabIndex = 15;
            // 
            // traveling_details1
            // 
            this.traveling_details1.BackColor = System.Drawing.Color.White;
            this.traveling_details1.Location = new System.Drawing.Point(264, 24);
            this.traveling_details1.Name = "traveling_details1";
            this.traveling_details1.Size = new System.Drawing.Size(1121, 720);
            this.traveling_details1.TabIndex = 14;
            // 
            // settings_form1
            // 
            this.settings_form1.BackColor = System.Drawing.Color.White;
            this.settings_form1.Location = new System.Drawing.Point(264, 24);
            this.settings_form1.Name = "settings_form1";
            this.settings_form1.Size = new System.Drawing.Size(1126, 720);
            this.settings_form1.TabIndex = 13;
            // 
            // payment_details1
            // 
            this.payment_details1.BackColor = System.Drawing.Color.White;
            this.payment_details1.Location = new System.Drawing.Point(266, 24);
            this.payment_details1.Name = "payment_details1";
            this.payment_details1.Size = new System.Drawing.Size(1101, 768);
            this.payment_details1.TabIndex = 12;
            // 
            // meal_details1
            // 
            this.meal_details1.BackColor = System.Drawing.Color.White;
            this.meal_details1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.meal_details1.Location = new System.Drawing.Point(267, 24);
            this.meal_details1.Name = "meal_details1";
            this.meal_details1.Size = new System.Drawing.Size(1113, 718);
            this.meal_details1.TabIndex = 11;
            // 
            // location_details1
            // 
            this.location_details1.BackColor = System.Drawing.Color.White;
            this.location_details1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.location_details1.Location = new System.Drawing.Point(266, 24);
            this.location_details1.Name = "location_details1";
            this.location_details1.Size = new System.Drawing.Size(1148, 720);
            this.location_details1.TabIndex = 10;
            // 
            // employee_details1
            // 
            this.employee_details1.BackColor = System.Drawing.Color.White;
            this.employee_details1.Location = new System.Drawing.Point(266, 24);
            this.employee_details1.Name = "employee_details1";
            this.employee_details1.Size = new System.Drawing.Size(1135, 742);
            this.employee_details1.TabIndex = 9;
            // 
            // custormer_details1
            // 
            this.custormer_details1.BackColor = System.Drawing.Color.White;
            this.custormer_details1.Location = new System.Drawing.Point(266, 24);
            this.custormer_details1.Name = "custormer_details1";
            this.custormer_details1.Size = new System.Drawing.Size(1124, 731);
            this.custormer_details1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1386, 740);
            this.Controls.Add(this.dashboard_form1);
            this.Controls.Add(this.searchSettings1);
            this.Controls.Add(this.vehicle_details1);
            this.Controls.Add(this.traveling_details1);
            this.Controls.Add(this.settings_form1);
            this.Controls.Add(this.payment_details1);
            this.Controls.Add(this.meal_details1);
            this.Controls.Add(this.location_details1);
            this.Controls.Add(this.employee_details1);
            this.Controls.Add(this.custormer_details1);
            this.Controls.Add(this.gunaGradientPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gunaGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientPanel gunaGradientPanel1;
        private Guna.UI.WinForms.GunaAdvenceButton settings_btn;
        private Guna.UI.WinForms.GunaAdvenceButton paymentmgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton vrhiclemgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton travelingmgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton mealmgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton locationmgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton custormermgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton empmgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton dashboard_btn;
        private System.Data.SqlServerCe.SqlCeConnection sqlCeConnection1;
        private System.Data.SqlServerCe.SqlCeCommand sqlCeCommand1;
        private System.Windows.Forms.Panel panel1;
        private custormer_details custormer_details1;
        private employee_details employee_details1;
        private location_details location_details1;
        private meal_details meal_details1;
        private payment_details payment_details1;
        private settings_form settings_form1;
        private traveling_details traveling_details1;
        private vehicle_details vehicle_details1;
        private SearchSettings searchSettings1;
        private dashboard_form dashboard_form1;
        private Guna.UI.WinForms.GunaAdvenceButton search_btn;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
    }
}

