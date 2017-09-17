using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BloodBankManagement
{
    public partial class UserProfileForm : MetroFramework.Forms.MetroForm
    {
        private string uName;
        private int uRoll;
        private bool isbtnBrowseClicked;
        private string filePath;
        DB_contextDataContext db = new DB_contextDataContext();
        userHomePage userHomepageForm;
        UserAddr userAddressTable;
        BloodData userBloodDataTable;

        int expType;

        public UserProfileForm()
        {
            InitializeComponent();
            this.ChangeTextBoxProperty(false);
            this.btnUpdate.Visible = false;
            this.lableValidation.Text = "";
        }
        public void TrackUserSession(userHomePage user)
        {
            if (user != null)
            {
                this.userHomepageForm = user;
                this.uName = this.userHomepageForm.LoggedUName;
                this.uRoll = this.userHomepageForm.uRoll;
                this.setFromDataBase();
            }
            else
            {
                MessageBox.Show("NO REF PASSED");
            }
            MessageBox.Show(uName + " ROLL : " + this.uRoll);
        }

        private void ChangeTextBoxProperty(bool op)
        {
            this.txtFirstName.Enabled = op;
            this.txtLastName.Enabled = op;
            this.txtUserName.Enabled = false;
            this.txtEmail.Enabled = op;
            this.txtPhone.Enabled = op;
            this.txtDistrict.Enabled = op;
            this.txtSubdistrict.Enabled = op;
            this.txtPostal.Enabled = op;
            this.txtBrowseFile.Visible = op;
            this.btnBrowse.Visible = op;
            this.txtBrowseFile.Enabled = false;
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            this.ChangeTextBoxProperty(true);
            this.btnUpdate.Visible = true;
        }
        private void setFromDataBase()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            UserDtail userDetailTable = new UserDtail();
            this.userAddressTable = db.UserAddrs.SingleOrDefault(x => x.userID == this.uName);
            this.userBloodDataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.uName);
            userDetailTable = db.UserDtails.SingleOrDefault(x=>x.userID==this.uName);
            if (this.userAddressTable != null && this.userBloodDataTable != null && userDetailTable!=null)
            {
                this.txtFirstName.Text = this.userAddressTable.firstName;
                this.txtLastName.Text = this.userAddressTable.lastName;
                this.txtUserName.Text = this.userAddressTable.userID;
                this.txtPhone.Text = this.userAddressTable.mobileNo;
                this.txtEmail.Text = this.userAddressTable.email;
                this.txtDistrict.Text = this.userAddressTable.district;
                this.txtSubdistrict.Text = this.userAddressTable.subDistrict;
                this.txtPostal.Text = this.userAddressTable.postalCode;
                this.LableBlood.Text = this.userBloodDataTable.bloodGroup;
                try
                {
                    this.userPP.Image = Image.FromFile(userDetailTable.propicture);
                }
                catch(ArgumentNullException exp)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.checkValidation())
            {
                if (this.expType == 0) 
                {
                    this.insertInDatabase();
                    this.setFromDataBase();
                }

                
            }
            else if(this.expType==1)
            {
                this.lableValidation.Text = "Email Already Exists";
            }
            else if(this.expType==2)
            {
                this.lableValidation.Text = "Invalid Email Format";
                this.txtEmail.Clear();
                this.txtEmail.WaterMark = "dipanjalmaitra@gmail.com";
            }
            else
            {
                this.lableValidation.Text="You Must Fillup All The Fields";
            }
        }
        private bool checkValidation()
        {
            if (
                !string.IsNullOrEmpty(this.txtFirstName.Text) &&
                !string.IsNullOrEmpty(this.txtLastName.Text) &&
                !string.IsNullOrEmpty(this.txtUserName.Text) &&
                !string.IsNullOrEmpty(this.txtPhone.Text) &&
                !string.IsNullOrEmpty(this.txtEmail.Text) &&
                !string.IsNullOrEmpty(this.txtDistrict.Text) &&
                !string.IsNullOrEmpty(this.txtSubdistrict.Text) &&
                !string.IsNullOrEmpty(this.txtPostal.Text))
            {
                if(!checkEmailValidate())
                {
                    this.lableValidation.Text = "Email Allready Exists";
                    return false;
                }
                else
                {
                    //this.txtEmail.Clear();
                    
                    return true;
                }
                
            }
            else
            {
                return false;
            }
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {

        }
        private void insertInDatabase()
        {
            if(this.updateAddress())
            {
                if(this.updateLogindata()) //username or primarykey is not updating 
                {
                    if(this.updateBloodData())
                    {
                        if(this.updateUserData())
                        {
                            MessageBox.Show("Profile Updated !");
                        }
                        else
                        {
                            lableValidation.Text = "UserData Data Is Not Updated";
                        }
                    }
                    else
                    {
                        lableValidation.Text = "Blood Data Is Not Updated";
                    }
                }
                else
                {
                    lableValidation.Text = "Login Data Is Not Updated";
                }
            }
            else
            {
                lableValidation.Text = "Address Data Is Not Updated";
            }

        }
        private bool updateAddress()
        {
            UserAddr addressData = db.UserAddrs.SingleOrDefault(x => x.userID == this.uName);
            if(addressData!=null)
            {
                addressData.firstName = this.txtFirstName.Text;
                addressData.lastName = this.txtLastName.Text;
                addressData.mobileNo = this.txtPhone.Text;
                addressData.district = this.txtDistrict.Text;
                addressData.subDistrict = this.txtSubdistrict.Text;
                addressData.postalCode = this.txtPostal.Text;
                addressData.email = this.txtEmail.Text;
                addressData.userID = this.txtUserName.Text;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool updateLogindata()
        {
            UserLoginData loginData = db.UserLoginDatas.SingleOrDefault(x => x.username == this.uName);
            if(loginData!=null)
            {
                loginData.email = this.txtEmail.Text;
                loginData.username = this.txtUserName.Text;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool updateUserData()
        {
            UserDtail userData = db.UserDtails.SingleOrDefault(x => x.userID == this.uName);
            if(userData!=null)
            {
                //userData.userID = this.txtUserName.Text;
                if(this.isbtnBrowseClicked)
                {
                    try
                    {
                        userData.propicture = this.txtBrowseFile.Text;
                        db.SubmitChanges();
                    }
                    catch(System.Data.SqlClient.SqlException exp)
                    {
                        MessageBox.Show("Invalid File Name");
                    }
                        
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool updateBloodData()
        {
            BloodData bloodData = db.BloodDatas.SingleOrDefault(x => x.userID == this.uName);
            if(bloodData!=null)
            {
                bloodData.userID = this.txtUserName.Text;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.userHomepageForm.showLoggedUser(this.uName);
            this.userHomepageForm.Show();

        }

        private void txtDistrict_Click(object sender, EventArgs e)
        {
            if(!this.checkEmailValidate())
            {
                this.txtEmail.Clear();
                this.lableValidation.Text = "Email Allready Exists";
            }
            //check email available here 
        }
        private bool checkEmailValidate()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            string requestedEmail = this.txtEmail.Text;
            string userName = this.txtUserName.Text;
            UserLoginData loginTab = db.UserLoginDatas.SingleOrDefault(x => x.email == requestedEmail && x.username!=userName);
            if (loginTab != null)
            {
                this.expType = 1;
                return false;
            }
            else
            {
                bool isEmail = Regex.IsMatch(requestedEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                {
                    this.lableValidation.Text = "";
                    return true;
                }
                else
                {
                    this.expType = 2;
                    this.lableValidation.Text = "Invalid Email Format";
                    this.txtEmail.Clear();
                    this.txtEmail.WaterMark = "dipanjalmaitra@gmail.com";
                    return true;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "*.jpg";
            //openFile.ShowDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseFile.Text = openFile.FileName;
                this.filePath = this.txtBrowseFile.Text;
                this.isbtnBrowseClicked = true;
            }
            else
            {
                this.isbtnBrowseClicked = false;
            }
        }
    }
}
