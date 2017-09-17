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
    public partial class userHomePage : MetroFramework.Forms.MetroForm
    {
        public string LoggedUName;
        public int uRoll = 2;
        public string bloodGroup, reqType;
        public int bloodQuantity;
        DateTime date;
        DB_contextDataContext db = new DB_contextDataContext();
        BloodInventory bloodInventoryTable;
        //UserTempData userTempTable;


        public userHomePage()
        {
            InitializeComponent();
            this.txtBrowseFile.Visible = false;
            this.btnBrowse.Visible = false;
            this.optionVisibilityChange();
            this.btnSubmit.Enabled = false;

        }
        public void showLoggedUser(string uName)
        {
            this.lableDate.Text = DateTime.Now.ToString();
            UserAddr addressTable = db.UserAddrs.SingleOrDefault(x => x.userID == uName);
            if(addressTable!=null)
            {
                this.metroLabel1.Text = "Hello " + addressTable.firstName;
            }
            //this.metroLabel1.Text = "HELLO " + uName.ToUpper();
            this.LoggedUName = uName;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserLoginPage LoginPanal = new UserLoginPage();
            LoginPanal.DestroySession(2, this.LoggedUName);
            this.Hide();
            LoginPanal.Show();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            ChangePassword changePassForm = new ChangePassword();
            changePassForm.TrackUserSession(null, this);
            changePassForm.Show();
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm();
            userProfileForm.TrackUserSession(this); //Edit Profile will be avaiable only for users not admin
            userProfileForm.Show();
        }
        private void DonateBlood()
        {

        }

        private void BloodGroupIndexChanged(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = true;
            int index = this.comboBloodGroup.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        this.bloodGroup = "A+";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 1:
                    {
                        this.bloodGroup = "A-";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 2:
                    {
                        this.bloodGroup = "AB+";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 3:
                    {
                        this.bloodGroup = "AB-";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 4:
                    {
                        this.bloodGroup = "B+";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 5:
                    {
                        this.bloodGroup = "B-";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 6:
                    {
                        this.bloodGroup = "O+";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                case 7:
                    {
                        this.bloodGroup = "O-";
                        this.BagQuantityLable.Visible = true;
                        this.txtBloodQuantity.Visible = true;
                        this.checkBloodQuantity(index + 1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void RequestIndexChanged(object sender, EventArgs e)
        {
            int index = this.comboRequestType.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        this.reqType = "donate";
                        this.lastDonated();
                        this.optionVisibilityChange();

                        if (!this.checkLastGivenDate())
                        {
                            this.LableStatus.Text = "You can not donate blood before 3 months";
                            //this.btnSubmit.Enabled = false;
                        }
                        else
                        {
                            this.txtBrowseFile.Visible = true;
                            this.btnBrowse.Visible = true;
                        }
                        break;
                    }
                case 1:
                    {
                        this.reqType = "request";
                        this.BloodGroupLable.Visible = true;
                        this.comboBloodGroup.Visible = true;
                        this.txtBrowseFile.Visible = false;
                        this.btnBrowse.Visible = false;
                        //this.btnSubmit.Enabled = false;
                        this.LableStatus.Text = "";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void optionVisibilityChange()
        {
            this.comboBloodGroup.Visible = false;
            this.txtBloodQuantity.Visible = false;
            this.BloodGroupLable.Visible = false;
            this.BagQuantityLable.Visible = false;
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.reqType.Equals("donate"))
            {
                BloodData bloodDataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.LoggedUName);
                //UserDtail userDetailTable = db.UserDtails.SingleOrDefault(x => x.userID == this.LoggedUName);
                if (bloodDataTable != null)
                {
                    if (bloodDataTable.bloodReport == 1) //checking blood report pos or neg
                    {
                        this.bloodGroup = bloodDataTable.bloodGroup;
                        if (this.checkLastGivenDate())
                        {
                            this.addToTempTable();
                            //this.addToBloodInventory();
                        }
                        else
                        {
                            MessageBox.Show("U can not donate before 3 months");
                            this.LableStatus.Text = "Last Donated : " + bloodDataTable.date;
                            //
                        }
                    }
                    else
                    {
                        this.LableStatus.Text = "You Can Not Donate,Your Blood Report is negetive";
                    }
                }
            }
            else if (this.reqType.Equals("request"))
            {
                if (!string.IsNullOrEmpty(this.txtBloodQuantity.Text))
                {
                    int userRequested = int.Parse(this.txtBloodQuantity.Text);
                    if (userRequested >= 0 && userRequested <= this.bloodQuantity)
                    {

                        this.addToTempTable();
                        //this.updateBloodQuantity(userRequested);

                    }
                    else
                    {
                        MessageBox.Show("Blood Unavailable");
                    }
                    this.LableStatus.Text = this.bloodGroup + " : " + this.bloodQuantity;
                }
            }
            else
            {

            }
        }

        private void checkBloodQuantity(int id)
        {
            this.bloodInventoryTable = db.BloodInventories.SingleOrDefault(x => x.Id == id);
            if (this.bloodInventoryTable != null)
            {
                this.bloodQuantity = this.bloodInventoryTable.bloodquantity ?? default(int);
                this.LableStatus.Text = this.bloodGroup + " : " + this.bloodQuantity.ToString();
            }
        }
        private void updateBloodQuantity(int uReqQuantity) //only for request blood
        {
            BloodData bDataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.LoggedUName);
            BloodInventory bloodInvTable = db.BloodInventories.SingleOrDefault(x => x.bloodgroup == this.bloodGroup);
            if (bloodInvTable != null && bDataTable != null)
            {
                this.bloodQuantity -= uReqQuantity;
                //i was here
                bloodInvTable.bloodquantity = this.bloodQuantity;
                //db.SubmitChanges();
                bDataTable.requested += int.Parse(this.txtBloodQuantity.Text.ToString()); //it was not updating 
                db.SubmitChanges();
                this.addToHistory(uReqQuantity);
                MessageBox.Show("Request Accepted" + bDataTable.requested.ToString());
            }
            else
            {
                MessageBox.Show("DB not Updated");
            }
        }
        private void addToBloodInventory() //only for donation
        {
            BloodData bdataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.LoggedUName);
            BloodInventory bloodTable = db.BloodInventories.SingleOrDefault(x => x.bloodgroup == this.bloodGroup);
            if (bloodTable != null && bdataTable != null)
            {
                this.date = DateTime.Now;
                bloodTable.bloodquantity += 1;
                bdataTable.donated += 1;
                bdataTable.date = date.ToString();
                bdataTable.month = int.Parse(date.Month.ToString());
                db.SubmitChanges();
                this.addToHistory(1);
                this.LableStatus.Text = bloodTable.bloodgroup + " : Blood Donated " + bloodTable.bloodquantity.ToString();
            }
        }
        private void addToTempTable()
        {
            DB_contextDataContext db = new DB_contextDataContext();
            UserTempData uTempData=new UserTempData();
            uTempData.username = this.LoggedUName;
            if(this.reqType.Equals("donate"))
            {
                uTempData.quantity = 1;
                uTempData.requestType = "donate";
            }
            else
            {
                uTempData.quantity = int.Parse(this.txtBloodQuantity.Text.ToString());
                uTempData.requestType = "request";
            }
            db.UserTempDatas.InsertOnSubmit(uTempData);
            db.SubmitChanges();
            MessageBox.Show("Requested For");
        }
        private bool checkLastGivenDate()
        {
            BloodData bdataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.LoggedUName);
            if (bdataTable != null)
            {
                int Lastmonth = bdataTable.month ?? default(int);
                int currmonth = int.Parse(DateTime.Now.Month.ToString());
                int monthDuration = currmonth - Lastmonth;
                if (monthDuration >= 3)
                {
                    this.btnSubmit.Enabled = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void addToHistory(int uReqQuantity)
        {
            History historyTable = new History();
            historyTable.userID = LoggedUName;
            historyTable.date = this.date.ToString();
            historyTable.requestType = this.reqType;
            historyTable.quantity = uReqQuantity;
            db.Histories.InsertOnSubmit(historyTable);
            db.SubmitChanges();
        }
        private void lastDonated()
        {
            BloodData bdataTable = db.BloodDatas.SingleOrDefault(x => x.userID == this.LoggedUName);
            if (bdataTable != null)
            {
                if (bdataTable.date != null && bdataTable.donated > 0)
                {
                    this.LableStatus.Text = "Last Donated : " + bdataTable.date;
                }
                else
                {
                    this.LableStatus.Text = "Never Donated Before";
                }
            }
            else
            {
                MessageBox.Show("BloodData Table Error");
            }
        }
    }
}
