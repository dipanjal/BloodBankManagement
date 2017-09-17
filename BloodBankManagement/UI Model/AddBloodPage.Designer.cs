namespace BloodBankManagement
{
    partial class AddBloodPage
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
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtBloodQuantity = new MetroFramework.Controls.MetroTextBox();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.lableStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "A+",
            "A-",
            "AB+",
            "AB-",
            "B+",
            "B-",
            "O+",
            "O-"});
            this.metroComboBox1.Location = new System.Drawing.Point(23, 130);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(154, 29);
            this.metroComboBox1.TabIndex = 0;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 108);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Blood Group";
            // 
            // txtBloodQuantity
            // 
            // 
            // 
            // 
            this.txtBloodQuantity.CustomButton.Image = null;
            this.txtBloodQuantity.CustomButton.Location = new System.Drawing.Point(130, 1);
            this.txtBloodQuantity.CustomButton.Name = "";
            this.txtBloodQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBloodQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBloodQuantity.CustomButton.TabIndex = 1;
            this.txtBloodQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBloodQuantity.CustomButton.UseSelectable = true;
            this.txtBloodQuantity.CustomButton.Visible = false;
            this.txtBloodQuantity.Lines = new string[0];
            this.txtBloodQuantity.Location = new System.Drawing.Point(197, 130);
            this.txtBloodQuantity.MaxLength = 32767;
            this.txtBloodQuantity.Name = "txtBloodQuantity";
            this.txtBloodQuantity.PasswordChar = '\0';
            this.txtBloodQuantity.PromptText = "Quantity";
            this.txtBloodQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBloodQuantity.SelectedText = "";
            this.txtBloodQuantity.SelectionLength = 0;
            this.txtBloodQuantity.SelectionStart = 0;
            this.txtBloodQuantity.ShortcutsEnabled = true;
            this.txtBloodQuantity.Size = new System.Drawing.Size(152, 23);
            this.txtBloodQuantity.TabIndex = 2;
            this.txtBloodQuantity.UseSelectable = true;
            this.txtBloodQuantity.WaterMark = "Quantity";
            this.txtBloodQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBloodQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(369, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(369, 204);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lableStatus
            // 
            this.lableStatus.AutoSize = true;
            this.lableStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lableStatus.Location = new System.Drawing.Point(23, 77);
            this.lableStatus.Name = "lableStatus";
            this.lableStatus.Size = new System.Drawing.Size(35, 13);
            this.lableStatus.TabIndex = 6;
            this.lableStatus.Text = "label1";
            // 
            // AddBloodPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 250);
            this.Controls.Add(this.lableStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBloodQuantity);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroComboBox1);
            this.Name = "AddBloodPage";
            this.Text = "Add Blood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtBloodQuantity;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnBack;
        private System.Windows.Forms.Label lableStatus;
    }
}