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
using System.Diagnostics;
using System.IO;

namespace BloodBankManagement
{
    public partial class adminHomePage : MetroFramework.Forms.MetroForm
    {
        DB_contextDataContext db = new DB_contextDataContext();
        public string LoggedUName;
        public int uRoll = 1;
        AddBloodPage AddBloodForm;
        public string uName;
        viewUserProfile viewProfile = new viewUserProfile();

        public adminHomePage()
        {
            InitializeComponent();
            UserLoginPage uLoginForm = new UserLoginPage();
            Thread.Sleep(1000);
            this.DataGrid.DataSource = db.BloodInventories;
            this.DataGrid.MultiSelect = false;
            this.LableStatus.Text = "";
        }
        public void showLoggedUser(string uName)
        {
            this.metroLabel1.Text = "HELLO " + uName.ToUpper();
            this.LoggedUName = uName;
            //MessageBox.Show(uName);
        }


        private void operationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void opComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LableStatus.Text = "";
            int index = this.opComboBox.SelectedIndex;
            switch(index)
            {
                case 0:
                    {
                        this.DataGrid.DataSource = db.UserDtails;
                        break;
                    }
                case 1:
                    {
                        this.DataGrid.DataSource = db.UserAddrs;
                        break;
                    }
                case 2:
                    {
                        this.DataGrid.DataSource = db.BloodDatas;
                        break;
                    }
                case 3:
                    {
                        this.DataGrid.DataSource = db.BloodInventories;
                        break;
                    }
                case 4:
                    {
                        this.DataGrid.DataSource = db.Histories;
                        break;
                    }
                case 5:
                    {
                        this.DataGrid.DataSource = db.UserTempDatas;
                        break;
                    }
                default :
                    {
                        break;
                    }
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            UserLoginPage LoginPanal = new UserLoginPage();
            LoginPanal.DestroySession(1, this.LoggedUName);
            this.Hide();
            LoginPanal.Show();
        }

        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            ChangePassword changePassForm = new ChangePassword();
            changePassForm.TrackUserSession(this, null);
            changePassForm.Show();
        }

        private void btnAddBlood_Click(object sender, EventArgs e)
        {
            this.AddBloodForm = new AddBloodPage();
            this.AddBloodForm.trackSession(this);
            this.Hide();
            this.AddBloodForm.Show();
        }

        public void reloadAdminPage()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            this.DataGrid.DataSource = db.BloodInventories;
            this.Show();
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement\DB_Fix.bat"))
            {
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement\DB_Fix.bat";
                proc.StartInfo.WorkingDirectory = @"F:\Programming\C#\C#Project\BloodBankManagement\BloodBankManagement";
                proc.Start();
            }
            else
            {
                MessageBox.Show("Missing BatFile");
                this.btnUpdateDB.Enabled = false;
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = (int)DataGrid.CurrentCell.RowIndex;
            this.uName = DataGrid[1, row].Value.ToString();
            this.LableStatus.Text = this.uName + " Selected ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.deleteUserLogin();
            this.deleteUserAddress();
            this.deleteUserDetails();
            this.deleteBloodData();
            db.SubmitChanges();
            this.relode();
            //this.reloadAdminPage();
            this.LableStatus.Text = this.uName + " Has Been Deleted";
        }
        private void deleteUserLogin()
        {
            UserLoginData userLoginTable = db.UserLoginDatas.SingleOrDefault(x=>x.username==this.uName);
            if(userLoginTable!=null)
            {
                db.UserLoginDatas.DeleteOnSubmit(userLoginTable);
                //db.SubmitChanges();
            }
        }
        private void deleteUserAddress()
        {
            UserAddr userAddressTable = db.UserAddrs.SingleOrDefault(x => x.userID == this.uName);
            if (userAddressTable != null)
            {
                db.UserAddrs.DeleteOnSubmit(userAddressTable);
               // db.SubmitChanges();
            }
        }
        private void deleteUserDetails()
        {
            UserDtail userDetailTable = db.UserDtails.SingleOrDefault(x=>x.userID==this.uName);
            if(userDetailTable!=null)
            {
                db.UserDtails.DeleteOnSubmit(userDetailTable);
                //db.SubmitChanges();
            }
        }
        private void deleteBloodData()
        {
            BloodData bloodDataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.uName);
            if(bloodDataTable!=null)
            {
                db.BloodDatas.DeleteOnSubmit(bloodDataTable);
                //db.SubmitChanges();
            }
        }
        private void relode()
        {
            this.db = null;
            this.db = new DB_contextDataContext();
            this.DataGrid.DataSource = this.db.UserDtails;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.delFromUserAddressTable();
            this.delFromUserDetailsTable();
            this.delFromUserLoginTable();
            this.delFromBloodDataTable();
            this.LableStatus.Text = "Pended Users Deleted";
            this.relode();
        }
        private void delFromUserLoginTable()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            //UserLoginData loginTable;
            var pendingUsers = from userLoginTab in db.UserLoginDatas
                               where userLoginTab.confirmVerification == null
                               select userLoginTab;
            db.UserLoginDatas.DeleteAllOnSubmit(pendingUsers);
            db.SubmitChanges();
        }
        private void delFromUserAddressTable()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            var pendinUsers = from userAddressTab in db.UserAddrs
                              where userAddressTab.accountstatus == "pending"
                              select userAddressTab;
            db.UserAddrs.DeleteAllOnSubmit(pendinUsers);
            db.SubmitChanges();
                            
        }
        private void delFromUserDetailsTable()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            var pendingUsers = from usersDetaisTab in db.UserDtails
                               where usersDetaisTab.accountstatus == "pending"
                               select usersDetaisTab;
            db.UserDtails.DeleteAllOnSubmit(pendingUsers);
            db.SubmitChanges();
        }
        private void delFromBloodDataTable()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            var pendingUsers = from userBloodTab in db.BloodDatas
                               where userBloodTab.accountstatus == "pending"
                               select userBloodTab;
            db.BloodDatas.DeleteAllOnSubmit(pendingUsers);
            db.SubmitChanges();
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {

            //viewProfile.trackUser(this);
            this.viewProfile.setFromDataBase(this);
            this.viewProfile.Show();
            //this.viewProfile = null;
        }
        public void destroySession()
        {
            //this.viewProfile = null;
        }
    }
}
