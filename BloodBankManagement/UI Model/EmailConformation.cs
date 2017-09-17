using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace BloodBankManagement
{
    public partial class EmailConformation : MetroFramework.Forms.MetroForm
    {
        public string LoggedUName;
        string code;
        UserLoginPage userLoginForm;

        public EmailConformation()
        {
            InitializeComponent();
            this.lableStatus.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //LoginPanal.DestroySession(2, this.LoggedUName);
            this.Hide();
            this.userLoginForm.reloadPage();
            this.userLoginForm.Show();
        }
        public void trackUser(string uName,UserLoginPage user)
        {
            this.LoggedUName = uName;
            this.userLoginForm = user;
        }
        private void checkVerificationCode()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            UserLoginData logindataTable = db.UserLoginDatas.SingleOrDefault(x=>x.username==this.LoggedUName);
            UserAddr userAddresTab = db.UserAddrs.SingleOrDefault(x=>x.userID==this.LoggedUName);
            UserDtail userDetailsTable = db.UserDtails.SingleOrDefault(x=>x.userID==this.LoggedUName);
            BloodData userBloodTable = db.BloodDatas.SingleOrDefault(x=>x.userID==this.LoggedUName);
            if(logindataTable!=null&&userAddresTab!=null&&userDetailsTable!=null&&userBloodTable!=null)
            {
                if(logindataTable.verfication==code)
                {
                    logindataTable.confirmVerification = this.txtConfirm.Text;
                    userAddresTab.accountstatus = "activated";
                    userDetailsTable.accountstatus = "activated";
                    userBloodTable.accountstatus = "activated";
                    db.SubmitChanges();
                    this.userLoginForm.isChecked = true;
                    this.lableStatus.Text = "Account Activating.....";
                    Thread.Sleep(4000);
                    userHomePage userForm = new userHomePage();
                    userForm.showLoggedUser(LoggedUName);
                    this.Hide();
                    userForm.Show();
                }
                else
                {
                    this.lableStatus.Text = "Invalid Code";
                    this.txtConfirm.Clear();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DB_contextDataContext db = new DB_contextDataContext();
            this.code = this.txtConfirm.Text;
            this.checkVerificationCode();

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            UserRegForm regForm = new UserRegForm();
            if (regForm.userCodeRequestSession(this))
            {
                lableStatus.Text = "Varification Code Send";
            }
            else
            {
                lableStatus.Text = "Code Sending Error";
            }

        }
    }
}
