using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagement
{
    public partial class viewUserProfile : MetroFramework.Forms.MetroForm
    {
        private string userName;
        DB_contextDataContext db = new DB_contextDataContext();
        userHomePage userHomepageForm;
        UserAddr userAddressTable;
        BloodData userBloodDataTable;
        UserDtail userDetailTable;
        adminHomePage adminHome;
        public viewUserProfile()
        {
            InitializeComponent();
            this.setVisibilityChange(false);
        }
        public void setFromDataBase(adminHomePage admin)
        {
            
            this.adminHome = admin;
            this.userAddressTable = db.UserAddrs.SingleOrDefault(x => x.userID == admin.uName);
            this.userBloodDataTable = db.BloodDatas.SingleOrDefault(x => x.userID == admin.uName);
            this.userDetailTable = db.UserDtails.SingleOrDefault(x => x.userID == admin.uName);
            if (userAddressTable != null && userBloodDataTable != null && userDetailTable != null )
            {
                this.Text = userAddressTable.firstName + "'s Profile";
                this.txtFirstName.Text = userAddressTable.firstName;
                this.txtLastName.Text = userAddressTable.lastName;
                this.txtUserName.Text = userAddressTable.userID;
                this.txtPhone.Text = userAddressTable.mobileNo;
                this.txtEmail.Text = userAddressTable.email;
                this.txtDistrict.Text = userAddressTable.district;
                this.txtSubdistrict.Text = userAddressTable.subDistrict;
                this.txtPostal.Text = userAddressTable.postalCode;
                this.LableBlood.Text = userBloodDataTable.bloodGroup;
                try
                {
                    this.userPP.Image = Image.FromFile(userDetailTable.propicture);
                }
                catch (ArgumentNullException exp)
                {
                    this.userPP.Image = Image.FromFile(@"F:\Programming\C#\C# Project Updated\BloodBankManagement\BloodBankManagement\images\default.jpg");
                }

                //this.userPP.SizeMode = PictureBoxSizeMode.StretchImage;
                this.userPP.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                this.lableValidation.Text = "Problem To Load Database";
                //MessageBox.Show("Problem To Load Database");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.adminHome.destroySession();
            this.adminHome = null;
        }
        private void setVisibilityChange(bool op)
        {
            this.txtFirstName.Enabled = op;
            this.txtLastName.Enabled = op;
            this.txtUserName.Enabled = op;
            this.txtEmail.Enabled = op;
            this.txtPhone.Enabled = op;
            this.txtDistrict.Enabled = op;
            this.txtSubdistrict.Enabled = op;
            this.txtPostal.Enabled = op;
        }
    }
}
