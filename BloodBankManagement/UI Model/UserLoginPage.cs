using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BloodBankManagement
{
    public partial class UserLoginPage : MetroFramework.Forms.MetroForm
    {
        //DB_ContextDataContext db=new DB_ContextDataContext();
        DB_contextDataContext db = new DB_contextDataContext();
        private UserLoginData userlogin = new UserLoginData();
        private UserLoginData login, adminMode, userMode;
        public bool isChecked = false;
        public string uName;
        public UserLoginPage()
        {
            InitializeComponent();
            this.uName = this.userBox.Text;
            this.btnForget.Visible = false;
            this.passwordBox.PasswordChar = '*';  
        }
        private void callingBatFile()
        {
            if(File.Exists(@"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement\DB_Fix.bat"))
            {
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement\DB_Fix.bat";
                proc.StartInfo.WorkingDirectory = @"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement";
                proc.Start();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login = db.UserLoginDatas.SingleOrDefault(x=>x.username==this.userBox.Text && x.password==this.passwordBox.Text);
            this.adminMode = db.UserLoginDatas.SingleOrDefault(x=>x.username==this.userBox.Text&&x.userroll==1);
            this.userMode = db.UserLoginDatas.SingleOrDefault(x => x.username == this.userBox.Text && x.userroll == 2);
            if (login!=null)
            {
                if(adminMode!=null)
                {
                    adminHomePage adminForm = new adminHomePage();
                    adminForm.showLoggedUser(this.userBox.Text);
                    this.Hide();
                    adminForm.Show();
                }
                else if(userMode!=null)
                {
                    if(!isChecked)
                    {
                        this.checkVerification();
                    }
                    else
                    {
                        userHomePage userForm = new userHomePage();
                        userForm.showLoggedUser(this.userBox.Text);
                        this.Hide();
                        userForm.Show();
                    }

                }
            }
            else
            {
                MessageBox.Show("INVALID USERNAME or PASSWORD");
                this.userBox.Clear();
                this.passwordBox.Clear();
                this.btnForget.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserRegForm().Show();
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PasswordResetPage().Show();
        }
        public void DestroySession(int UserRoll,string uName)
        {
            if(UserRoll==1)
            {
                this.adminMode = null;
                MessageBox.Show(uName.ToUpper()+" LOGGED OUT");
                //MessageBox.Show("ADMIN LOGOUT");
            }
            else if(UserRoll==2)
            {
                this.userMode = null;
                MessageBox.Show(uName.ToUpper() + " LOGGED OUT");
            }
        }
        private void checkVerification()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            UserLoginData userTable = db.UserLoginDatas.SingleOrDefault(x => x.username == this.userBox.Text);
            if(userTable!=null)
            {
                EmailConformation confForm = new EmailConformation();
                if(userTable.confirmVerification==null)
                {
                    this.Hide();
                    confForm.trackUser(this.userBox.Text,this);
                    confForm.Show();
                }
                else
                {
                    this.isChecked = true;
                }
            }
        }
        public void reloadPage()
        {
            this.userBox.Clear();
            this.passwordBox.Clear();
        }
    }
}
