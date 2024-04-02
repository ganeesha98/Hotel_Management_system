namespace Hotel_Management_System
{
    partial class SearchSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportVeiwer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LoadDetails_btn = new Guna.UI.WinForms.GunaButton();
            this.Sections_cmb = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Hotel_Management_System.Properties.Resources.edit2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.ReportVeiwer);
            this.panel1.Controls.Add(this.LoadDetails_btn);
            this.panel1.Controls.Add(this.Sections_cmb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 731);
            this.panel1.TabIndex = 0;
            // 
            // ReportVeiwer
            // 
            this.ReportVeiwer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReportVeiwer.Location = new System.Drawing.Point(20, 252);
            this.ReportVeiwer.Name = "ReportVeiwer";
            this.ReportVeiwer.Size = new System.Drawing.Size(1085, 447);
            this.ReportVeiwer.TabIndex = 3;
            // 
            // LoadDetails_btn
            // 
            this.LoadDetails_btn.AnimationHoverSpeed = 0.07F;
            this.LoadDetails_btn.AnimationSpeed = 0.03F;
            this.LoadDetails_btn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.LoadDetails_btn.BorderColor = System.Drawing.Color.Black;
            this.LoadDetails_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.LoadDetails_btn.FocusedColor = System.Drawing.Color.Empty;
            this.LoadDetails_btn.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDetails_btn.ForeColor = System.Drawing.Color.White;
            this.LoadDetails_btn.Image = ((System.Drawing.Image)(resources.GetObject("LoadDetails_btn.Image")));
            this.LoadDetails_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.LoadDetails_btn.Location = new System.Drawing.Point(391, 123);
            this.LoadDetails_btn.Name = "LoadDetails_btn";
            this.LoadDetails_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.LoadDetails_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.LoadDetails_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.LoadDetails_btn.OnHoverImage = null;
            this.LoadDetails_btn.OnPressedColor = System.Drawing.Color.Black;
            this.LoadDetails_btn.Size = new System.Drawing.Size(342, 42);
            this.LoadDetails_btn.TabIndex = 2;
            this.LoadDetails_btn.Text = "Load Details";
            this.LoadDetails_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoadDetails_btn.Click += new System.EventHandler(this.LoadDetails_btn_Click);
            // 
            // Sections_cmb
            // 
            this.Sections_cmb.BackColor = System.Drawing.Color.Transparent;
            this.Sections_cmb.BaseColor = System.Drawing.Color.White;
            this.Sections_cmb.BorderColor = System.Drawing.Color.Silver;
            this.Sections_cmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Sections_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sections_cmb.FocusedColor = System.Drawing.Color.Empty;
            this.Sections_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Sections_cmb.ForeColor = System.Drawing.Color.Black;
            this.Sections_cmb.FormattingEnabled = true;
            this.Sections_cmb.Items.AddRange(new object[] {
            "Employee Details",
            "Custormer Details",
            "Meal Details",
            "Location Details",
            "Travelling Details",
            "Vehicle Details",
            "Offers Details",
            "Decorations Details",
            "Maintain Details"});
            this.Sections_cmb.Location = new System.Drawing.Point(552, 55);
            this.Sections_cmb.Name = "Sections_cmb";
            this.Sections_cmb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Sections_cmb.OnHoverItemForeColor = System.Drawing.Color.White;
            this.Sections_cmb.Size = new System.Drawing.Size(181, 26);
            this.Sections_cmb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Sections :- ";
            // 
            // SearchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "SearchSettings";
            this.Size = new System.Drawing.Size(1124, 731);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaComboBox Sections_cmb;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton LoadDetails_btn;
        private Microsoft.Reporting.WinForms.ReportViewer ReportVeiwer;
    }
}
