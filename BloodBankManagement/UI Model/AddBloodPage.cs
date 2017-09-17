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
    public partial class AddBloodPage : MetroFramework.Forms.MetroForm
    {
        DB_contextDataContext db = new DB_contextDataContext();
        adminHomePage adminHomePageForm;
        private string bloodGroup;

        //private int quantity;
        public AddBloodPage()
        {
            InitializeComponent();
            this.txtBloodQuantity.Visible = false;
            this.btnAdd.Enabled = false;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtBloodQuantity.Visible = true;
            this.btnAdd.Enabled = true;
        }
        private bool checkValidation()
        {
            if(this.checkComboBox())
            {

                if (!string.IsNullOrEmpty(this.txtBloodQuantity.Text))
                {
                    return true;
                }
                else
                {
                    lableStatus.Text = "Blood Quantity can not be empty";
                    return false;
                }
            }
            else
            { 
                lableStatus.Text = "You Must Select A Blood Group";
                return false;
            }
        }
        private bool checkComboBox()
        {
            int index = this.metroComboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        this.bloodGroup = "A+";
                        return true;
                        break;
                    }
                case 1:
                    {
                        this.bloodGroup = "A-";
                        return true;
                        break;
                    }
                case 2:
                    {
                        this.bloodGroup = "AB+";
                        return true;
                        break;
                    }
                case 3:
                    {
                        this.bloodGroup = "AB-";
                        return true;
                        break;
                    }
                case 4:
                    {
                        this.bloodGroup = "B+";
                        return true;
                        break;
                    }
                case 5:
                    {
                        this.bloodGroup = "B-";
                        return true;
                        break;
                    }
                case 6:
                    {
                        this.bloodGroup = "O+";
                        return true;
                        break;
                    }
                case 7:
                    {
                        this.bloodGroup = "O-";
                        return true;
                        break;
                    }
                default:
                    {
                        this.lableStatus.Text = "You Must Select A Blood Group";
                        return false;
                        break;
                    }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.checkValidation())
            {
                BloodInventory bloodInvTab = db.BloodInventories.SingleOrDefault(x=>x.bloodgroup==this.bloodGroup);
                if(bloodInvTab!=null)
                {
                    int quantity = int.Parse(this.txtBloodQuantity.Text.ToString());
                    bloodInvTab.bloodquantity += quantity;
                    db.SubmitChanges();
                    this.lableStatus.Text = this.bloodGroup+" : "+bloodInvTab.bloodquantity.ToString()+"Total";
                }
            }
            else
            {
                lableStatus.Text = "Validation Error";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                this.adminHomePageForm.reloadAdminPage();
                //this.adminHomePageForm.Show();

            }
            catch (NullReferenceException exp)
            {
                MessageBox.Show("Null Ref Exp");
            }
            
        }
        public void trackSession(adminHomePage adminPg)
        {
            if(adminPg!=null)
            {
                this.adminHomePageForm = adminPg;
            }
            else
            {
                MessageBox.Show("NO Ref Passed");
            }
        }
    }
}
