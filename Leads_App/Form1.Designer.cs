namespace Leads_App
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
            this.cmb_Days = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkProcessLeads = new System.Windows.Forms.LinkLabel();
            this.lblAutoCA = new System.Windows.Forms.Label();
            this.cmbAutoCA = new System.Windows.Forms.ComboBox();
            this.txtZipCars = new System.Windows.Forms.TextBox();
            this.cmbStatesCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.CCityNames = new System.Windows.Forms.ComboBox();
            this.cboWebsite = new System.Windows.Forms.ComboBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txt_cityname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Del_History = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_Days
            // 
            this.cmb_Days.FormattingEnabled = true;
            this.cmb_Days.Items.AddRange(new object[] {
            "Last 1Day",
            "Last 2Days",
            "Last 3Days",
            "Last 4Days",
            "Last 5Days",
            "Last 6Days",
            "Last 7Days"});
            this.cmb_Days.Location = new System.Drawing.Point(81, 159);
            this.cmb_Days.Name = "cmb_Days";
            this.cmb_Days.Size = new System.Drawing.Size(121, 21);
            this.cmb_Days.TabIndex = 33;
            this.cmb_Days.Text = "Last 2Days";
            this.cmb_Days.SelectedIndexChanged += new System.EventHandler(this.cmb_Days_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "For Days :";
            // 
            // lnkProcessLeads
            // 
            this.lnkProcessLeads.AutoSize = true;
            this.lnkProcessLeads.Location = new System.Drawing.Point(209, 42);
            this.lnkProcessLeads.Name = "lnkProcessLeads";
            this.lnkProcessLeads.Size = new System.Drawing.Size(74, 13);
            this.lnkProcessLeads.TabIndex = 31;
            this.lnkProcessLeads.TabStop = true;
            this.lnkProcessLeads.Text = "ProcessLeads";
            this.lnkProcessLeads.Visible = false;
            // 
            // lblAutoCA
            // 
            this.lblAutoCA.AutoSize = true;
            this.lblAutoCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoCA.Location = new System.Drawing.Point(12, 89);
            this.lblAutoCA.Name = "lblAutoCA";
            this.lblAutoCA.Size = new System.Drawing.Size(41, 15);
            this.lblAutoCA.TabIndex = 30;
            this.lblAutoCA.Text = "State :";
            this.lblAutoCA.Visible = false;
            // 
            // cmbAutoCA
            // 
            this.cmbAutoCA.FormattingEnabled = true;
            this.cmbAutoCA.Items.AddRange(new object[] {
            "Select",
            "British Columbia",
            "Alberta",
            "Manitoba",
            "Ontario",
            "Yukon",
            "Saskatchewan"});
            this.cmbAutoCA.Location = new System.Drawing.Point(82, 79);
            this.cmbAutoCA.Name = "cmbAutoCA";
            this.cmbAutoCA.Size = new System.Drawing.Size(121, 21);
            this.cmbAutoCA.TabIndex = 29;
            this.cmbAutoCA.Text = "Select";
            this.cmbAutoCA.Visible = false;
            // 
            // txtZipCars
            // 
            this.txtZipCars.Location = new System.Drawing.Point(82, 127);
            this.txtZipCars.Name = "txtZipCars";
            this.txtZipCars.Size = new System.Drawing.Size(100, 20);
            this.txtZipCars.TabIndex = 28;
            this.txtZipCars.Visible = false;
            // 
            // cmbStatesCars
            // 
            this.cmbStatesCars.FormattingEnabled = true;
            this.cmbStatesCars.Items.AddRange(new object[] {
            "Select"});
            this.cmbStatesCars.Location = new System.Drawing.Point(82, 83);
            this.cmbStatesCars.Name = "cmbStatesCars";
            this.cmbStatesCars.Size = new System.Drawing.Size(121, 21);
            this.cmbStatesCars.TabIndex = 27;
            this.cmbStatesCars.Text = "Select";
            this.cmbStatesCars.Visible = false;
            this.cmbStatesCars.SelectedIndexChanged += new System.EventHandler(this.cmbStatesCars_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Count";
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "Select"});
            this.cmbState.Location = new System.Drawing.Point(81, 83);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.TabIndex = 24;
            this.cmbState.Text = "Select";
            this.cmbState.Visible = false;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(12, 85);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(41, 15);
            this.lblState.TabIndex = 23;
            this.lblState.Text = "State :";
            this.lblState.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(18, 126);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(32, 15);
            this.lblCity.TabIndex = 22;
            this.lblCity.Text = "City :";
            this.lblCity.Visible = false;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSite.Location = new System.Drawing.Point(18, 43);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(34, 15);
            this.lblSite.TabIndex = 21;
            this.lblSite.Text = "Site :";
            // 
            // CCityNames
            // 
            this.CCityNames.FormattingEnabled = true;
            this.CCityNames.Location = new System.Drawing.Point(82, 126);
            this.CCityNames.Name = "CCityNames";
            this.CCityNames.Size = new System.Drawing.Size(121, 21);
            this.CCityNames.TabIndex = 20;
            this.CCityNames.Text = "Select";
            this.CCityNames.Visible = false;
            // 
            // cboWebsite
            // 
            this.cboWebsite.FormattingEnabled = true;
            this.cboWebsite.Items.AddRange(new object[] {
            "AutoTrades",
            "Craigslist",
            "Cars.com",
            "AutoTradersCA",
            "CraigslistRVS",
            "CraigslistBikes",
            "CraigslistDealers",
            "CarPost",
            "ClassifiedsValley",
            "ClassifiedsCiti"});
            this.cboWebsite.Location = new System.Drawing.Point(82, 37);
            this.cboWebsite.Name = "cboWebsite";
            this.cboWebsite.Size = new System.Drawing.Size(121, 21);
            this.cboWebsite.TabIndex = 19;
            this.cboWebsite.Text = "Select";
            this.cboWebsite.SelectedIndexChanged += new System.EventHandler(this.cboWebsite_SelectedIndexChanged);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(145, 220);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 18;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(32, 220);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txt_cityname
            // 
            this.txt_cityname.Location = new System.Drawing.Point(81, 126);
            this.txt_cityname.Name = "txt_cityname";
            this.txt_cityname.Size = new System.Drawing.Size(121, 20);
            this.txt_cityname.TabIndex = 34;
            this.txt_cityname.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "City :";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 36;
            // 
            // Del_History
            // 
            this.Del_History.Location = new System.Drawing.Point(209, 37);
            this.Del_History.Name = "Del_History";
            this.Del_History.Size = new System.Drawing.Size(86, 23);
            this.Del_History.TabIndex = 37;
            this.Del_History.Text = "Del_History";
            this.Del_History.UseVisualStyleBackColor = true;
            this.Del_History.Click += new System.EventHandler(this.Del_History_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 262);
            this.Controls.Add(this.Del_History);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cityname);
            this.Controls.Add(this.cmb_Days);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkProcessLeads);
            this.Controls.Add(this.lblAutoCA);
            this.Controls.Add(this.cmbAutoCA);
            this.Controls.Add(this.txtZipCars);
            this.Controls.Add(this.cmbStatesCars);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.CCityNames);
            this.Controls.Add(this.cboWebsite);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Days;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkProcessLeads;
        private System.Windows.Forms.Label lblAutoCA;
        private System.Windows.Forms.ComboBox cmbAutoCA;
        private System.Windows.Forms.TextBox txtZipCars;
        private System.Windows.Forms.ComboBox cmbStatesCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox CCityNames;
        private System.Windows.Forms.ComboBox cboWebsite;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txt_cityname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Del_History;
    }
}

