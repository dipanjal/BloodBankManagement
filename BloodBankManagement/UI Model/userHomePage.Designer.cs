namespace BloodBankManagement
{
    partial class userHomePage
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnLogout = new MetroFramework.Controls.MetroButton();
            this.btnViewProfile = new MetroFramework.Controls.MetroButton();
            this.btnPasswordChange = new MetroFramework.Controls.MetroButton();
            this.comboRequestType = new MetroFramework.Controls.MetroComboBox();
            this.comboBloodGroup = new MetroFramework.Controls.MetroComboBox();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.BloodGroupLable = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.BagQuantityLable = new MetroFramework.Controls.MetroLabel();
            this.txtBloodQuantity = new MetroFramework.Controls.MetroTextBox();
            this.LableStatus = new MetroFramework.Controls.MetroLabel();
            this.lableDate = new MetroFramework.Controls.MetroLabel();
            this.txtBrowseFile = new MetroFramework.Controls.MetroTextBox();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 90);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(118, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "HELLO USER";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(212, 363);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(53, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseSelectable = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Location = new System.Drawing.Point(352, 146);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(102, 23);
            this.btnViewProfile.TabIndex = 3;
            this.btnViewProfile.Text = "View Profile";
            this.btnViewProfile.UseSelectable = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // btnPasswordChange
            // 
            this.btnPasswordChange.Location = new System.Drawing.Point(352, 363);
            this.btnPasswordChange.Name = "btnPasswordChange";
            this.btnPasswordChange.Size = new System.Drawing.Size(102, 23);
            this.btnPasswordChange.TabIndex = 2;
            this.btnPasswordChange.Text = "Change Password";
            this.btnPasswordChange.UseSelectable = true;
            this.btnPasswordChange.Click += new System.EventHandler(this.btnPasswordChange_Click);
            // 
            // comboRequestType
            // 
            this.comboRequestType.FormattingEnabled = true;
            this.comboRequestType.ItemHeight = 23;
            this.comboRequestType.Items.AddRange(new object[] {
            "Donate",
            "Request"});
            this.comboRequestType.Location = new System.Drawing.Point(108, 193);
            this.comboRequestType.Name = "comboRequestType";
            this.comboRequestType.Size = new System.Drawing.Size(157, 29);
            this.comboRequestType.TabIndex = 4;
            this.comboRequestType.UseSelectable = true;
            this.comboRequestType.SelectedIndexChanged += new System.EventHandler(this.RequestIndexChanged);
            // 
            // comboBloodGroup
            // 
            this.comboBloodGroup.FormattingEnabled = true;
            this.comboBloodGroup.ItemHeight = 23;
            this.comboBloodGroup.Items.AddRange(new object[] {
            "A+",
            "A-",
            "AB+",
            "AB-",
            "B+",
            "B-",
            "O+",
            "O-"});
            this.comboBloodGroup.Location = new System.Drawing.Point(108, 244);
            this.comboBloodGroup.Name = "comboBloodGroup";
            this.comboBloodGroup.Size = new System.Drawing.Size(157, 29);
            this.comboBloodGroup.TabIndex = 5;
            this.comboBloodGroup.UseSelectable = true;
            this.comboBloodGroup.SelectedIndexChanged += new System.EventHandler(this.BloodGroupIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(108, 363);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(53, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // BloodGroupLable
            // 
            this.BloodGroupLable.AutoSize = true;
            this.BloodGroupLable.Location = new System.Drawing.Point(19, 244);
            this.BloodGroupLable.Name = "BloodGroupLable";
            this.BloodGroupLable.Size = new System.Drawing.Size(85, 19);
            this.BloodGroupLable.TabIndex = 9;
            this.BloodGroupLable.Text = "Blood Group";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(19, 193);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(86, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Request Type";
            // 
            // BagQuantityLable
            // 
            this.BagQuantityLable.AutoSize = true;
            this.BagQuantityLable.Location = new System.Drawing.Point(19, 297);
            this.BagQuantityLable.Name = "BagQuantityLable";
            this.BagQuantityLable.Size = new System.Drawing.Size(85, 19);
            this.BagQuantityLable.TabIndex = 11;
            this.BagQuantityLable.Text = "Bag Quantity";
            // 
            // txtBloodQuantity
            // 
            // 
            // 
            // 
            this.txtBloodQuantity.CustomButton.Image = null;
            this.txtBloodQuantity.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.txtBloodQuantity.CustomButton.Name = "";
            this.txtBloodQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBloodQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBloodQuantity.CustomButton.TabIndex = 1;
            this.txtBloodQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBloodQuantity.CustomButton.UseSelectable = true;
            this.txtBloodQuantity.CustomButton.Visible = false;
            this.txtBloodQuantity.Lines = new string[0];
            this.txtBloodQuantity.Location = new System.Drawing.Point(108, 297);
            this.txtBloodQuantity.MaxLength = 32767;
            this.txtBloodQuantity.Name = "txtBloodQuantity";
            this.txtBloodQuantity.PasswordChar = '\0';
            this.txtBloodQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBloodQuantity.SelectedText = "";
            this.txtBloodQuantity.SelectionLength = 0;
            this.txtBloodQuantity.SelectionStart = 0;
            this.txtBloodQuantity.ShortcutsEnabled = true;
            this.txtBloodQuantity.Size = new System.Drawing.Size(157, 23);
            this.txtBloodQuantity.TabIndex = 12;
            this.txtBloodQuantity.UseSelectable = true;
            this.txtBloodQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBloodQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LableStatus
            // 
            this.LableStatus.AutoSize = true;
            this.LableStatus.Location = new System.Drawing.Point(19, 146);
            this.LableStatus.Name = "LableStatus";
            this.LableStatus.Size = new System.Drawing.Size(43, 19);
            this.LableStatus.TabIndex = 13;
            this.LableStatus.Text = "Status";
            // 
            // lableDate
            // 
            this.lableDate.AutoSize = true;
            this.lableDate.Location = new System.Drawing.Point(319, 90);
            this.lableDate.Name = "lableDate";
            this.lableDate.Size = new System.Drawing.Size(36, 19);
            this.lableDate.TabIndex = 14;
            this.lableDate.Text = "Date";
            // 
            // txtBrowseFile
            // 
            // 
            // 
            // 
            this.txtBrowseFile.CustomButton.Image = null;
            this.txtBrowseFile.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtBrowseFile.CustomButton.Name = "";
            this.txtBrowseFile.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrowseFile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrowseFile.CustomButton.TabIndex = 1;
            this.txtBrowseFile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrowseFile.CustomButton.UseSelectable = true;
            this.txtBrowseFile.CustomButton.Visible = false;
            this.txtBrowseFile.Lines = new string[0];
            this.txtBrowseFile.Location = new System.Drawing.Point(290, 199);
            this.txtBrowseFile.MaxLength = 32767;
            this.txtBrowseFile.Name = "txtBrowseFile";
            this.txtBrowseFile.PasswordChar = '\0';
            this.txtBrowseFile.PromptText = "Upload Blood Report";
            this.txtBrowseFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrowseFile.SelectedText = "";
            this.txtBrowseFile.SelectionLength = 0;
            this.txtBrowseFile.SelectionStart = 0;
            this.txtBrowseFile.ShortcutsEnabled = true;
            this.txtBrowseFile.Size = new System.Drawing.Size(138, 23);
            this.txtBrowseFile.TabIndex = 35;
            this.txtBrowseFile.UseSelectable = true;
            this.txtBrowseFile.WaterMark = "Upload Blood Report";
            this.txtBrowseFile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrowseFile.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(434, 199);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 34;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseSelectable = true;
            // 
            // userHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 409);
            this.Controls.Add(this.txtBrowseFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lableDate);
            this.Controls.Add(this.LableStatus);
            this.Controls.Add(this.txtBloodQuantity);
            this.Controls.Add(this.BagQuantityLable);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.BloodGroupLable);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.comboBloodGroup);
            this.Controls.Add(this.comboRequestType);
            this.Controls.Add(this.btnViewProfile);
            this.Controls.Add(this.btnPasswordChange);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.metroLabel1);
            this.Name = "userHomePage";
            this.Text = "USER HOME PAGE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnLogout;
        private MetroFramework.Controls.MetroButton btnViewProfile;
        private MetroFramework.Controls.MetroButton btnPasswordChange;
        private MetroFramework.Controls.MetroComboBox comboRequestType;
        private MetroFramework.Controls.MetroComboBox comboBloodGroup;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private MetroFramework.Controls.MetroLabel BloodGroupLable;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel BagQuantityLable;
        private MetroFramework.Controls.MetroTextBox txtBloodQuantity;
        private MetroFramework.Controls.MetroLabel LableStatus;
        private MetroFramework.Controls.MetroLabel lableDate;
        private MetroFramework.Controls.MetroTextBox txtBrowseFile;
        private MetroFramework.Controls.MetroButton btnBrowse;
    }
}