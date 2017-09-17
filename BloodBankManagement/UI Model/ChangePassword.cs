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
    public partial class ChangePassword : MetroFramework.Forms.MetroForm
    {
        DB_contextDataContext db = new DB_contextDataContext();
        //UserLoginData userLoginData = new UserLoginData();
        private UserLoginData newPassData;
        private string uName;
        private int uRoll;
        adminHomePage adminForm;
        userHomePage userForm;
        public ChangePassword()
        {
            InitializeComponent();
            this.LblStatus.Text = "";
            this.txtNewPassword.PasswordChar = '*';
            this.txtConfirmPassword.PasswordChar = '*';
        }
        public virtual void TrackUserSession(adminHomePage admin,userHomePage user)
        {
            if(admin!=null)
            {
                this.adminForm = admin;
                this.uName = this.adminForm.LoggedUName;
                this.uRoll = this.adminForm.uRoll;
                user = null;
            }
            else if(user!=null)
            {
                this.userForm = user;
                this.uName = this.userForm.LoggedUName;
                this.uRoll = this.userForm.uRoll;
                admin = null;
            }
            else
            {
                MessageBox.Show("NO REF PASSED");
            }
            MessageBox.Show(uName+" ROLL : "+this.uRoll);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtNewPassword.Text)|| !string.IsNullOrEmpty(this.txtConfirmPassword.Text))
            {
                if(this.txtNewPassword.Text.Equals(this.txtConfirmPassword.Text))
                {
                    this.newPassData = db.UserLoginDatas.SingleOrDefault(x => x.username == this.uName);
                    if(this.newPassData!=null && this.uRoll==newPassData.userroll)
                    {
                        if(this.txtConfirmPassword.Text.Equals(newPassData.password))
                        {
                            this.LblStatus.Text = "You Have The Same Password Allready";
                            this.txtNewPassword.Clear();
                            this.txtConfirmPassword.Clear();
                        }
                        else
                        {
                            //this.uRoll = newPassData.userroll;
                            //MessageBox.Show("ROLL : " + this.uRoll + " NAME : " + this.newPassData.username + " Pass : " + this.txtConfirmPassword.Text);
                            newPassData.password = this.txtConfirmPassword.Text;
                            db.SubmitChanges();
                            MessageBox.Show("Password Changed Successfully");
                        }
                        
                    }
                }
                else
                {
                    this.LblStatus.Text = "Password Doesn't Match";
                    this.txtConfirmPassword.Clear();
                }
            }
            else
            {
                this.LblStatus.Text = "Password Field can Not be Empty";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Hide();
            if(this.uRoll==1 && this.adminForm!=null)
            {
                this.newPassData = null;
                this.adminForm.Show();
            }
            else if(this.uRoll == 2 && this.userForm!=null)
            {
                this.newPassData = null;
                this.userForm.Show();
            }
            else
            {
                MessageBox.Show("INVALID USER ROLL OCCURED");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNewPassword.Clear();
            this.txtConfirmPassword.Clear();
        }
    }
}
