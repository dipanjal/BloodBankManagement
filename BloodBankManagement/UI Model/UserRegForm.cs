using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace BloodBankManagement
{
    public partial class UserRegForm : MetroFramework.Forms.MetroForm
    {
        private string bloodGroup;
        private bool bloodReportStatus;
        private bool chkboxStatus;
        private bool validation;
        private string filePath;
        DB_contextDataContext db = new DB_contextDataContext();
        UserAddr userAddressTable;
        UserDtail userDetailTable;
        UserLoginData userLoginTable;
        BloodData userBloodTable;
        UserTempData userTempTable;
        EmailConformation emailConf;

        private bool btnBrowseClicked;

        private string smtpHost = "revolutionofhackers@gmail.com"; //Mail SMTP SERVER That is a Gmail Account
        private string smtpPass = "cr4ck3dl00k"; //gmail password
        private char[] mainArr = "Sn1p3r-X".ToCharArray();
        private string userEmail;
        string FinalPass;


        public UserRegForm()
        {
            InitializeComponent();
            this.lableStatus.Text = "";
            this.lableStatus.ForeColor = Color.Red;
            this.userAddressTable = new UserAddr();
            this.txtboxPassword.PasswordChar = '*';
            this.txtboxConfirmPass.PasswordChar = '*';
            this.txtBrowseFile.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserLoginPage().Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.checkValidation();
            if(this.validation)
            {
                this.insertAddressTable();
                this.insertUserLoginTable();
                this.insertUserBloodDataTable();
                this.insertUserDetailsTable();
                //this.makeUserTempZero();
                
                MessageBox.Show("Regestration Seccessfull ! ");

                //MessageBox.Show("Blood Group"+this.bloodGroup+" Submission Status : "+this.bloodReportStatus);
            }
            else
            {
                MessageBox.Show("Regestration Faild ! ");
            }
        }
        private void checkValidation()
        {
            if (
                !string.IsNullOrEmpty(this.txtboxFirstName.Text) &&
                !string.IsNullOrEmpty(this.txtboxLastName.Text) &&
                !string.IsNullOrEmpty(this.txtboxUserName.Text) &&
                !string.IsNullOrEmpty(this.txtboxPassword.Text) &&
                !string.IsNullOrEmpty(this.txtboxConfirmPass.Text) &&
                !string.IsNullOrEmpty(this.txtboxMobile.Text) &&
                !string.IsNullOrEmpty(this.txtboxEmail.Text) &&
                !string.IsNullOrEmpty(this.txtboxDistrict.Text) &&
                !string.IsNullOrEmpty(this.txtboxSubDistrict.Text) &&
                !string.IsNullOrEmpty(this.txtboxPostal.Text))
            {
                if(this.checkUserNameAvailable()) // chkecking for available username
                {
                    if(this.checkEmailAvailable()) // checking for available email
                    {
                        if(this.checkMobileNumberAvailable()) // checking for available mobile number
                        {
                            if (this.chkPassword()) // checking for password match
                            {
                                if (this.checkComboBox()) // checking bloodgroup selection
                                {
                                    if (this.checkBoxStatus()) // cehcking for blood report selection
                                    {
                                        if(this.checkPhotoValidation())
                                        {
                                            this.validation = true;
                                        }
                                        else
                                        {
                                            this.validation = false;
                                        }
                                    }
                                    else
                                    {
                                        this.validation = false;
                                    }
                                }
                                else
                                {
                                    this.validation = false;
                                }
                            }
                            else
                            {
                                this.lableStatus.Text = "Password Doesn't Match";
                                this.txtboxConfirmPass.Clear();
                                this.validation = false;
                            }
                        }
                        else
                        {
                            this.txtboxMobile.Clear();
                            this.lableStatus.Text = "Mobile Number Allready exists";
                            this.validation = false;
                        }
                    }
                    else
                    {
                        this.txtboxEmail.Clear();
                        this.lableStatus.Text = "Email Allready Exists";
                        this.validation = false;
                    }
                }
                else
                {
                    this.txtboxUserName.Clear();
                    this.lableStatus.Text = "Username allready existes.Choose an unique username";
                    this.validation = false;
                }
            }
            else
            {
                this.lableStatus.Text = "YOU MUST FILL UP ALL THE FIELDS";
                this.validation = false;
            }
        }
        private bool checkComboBox()
        {
            int index = this.bloodGroupBox.SelectedIndex;
            switch(index)
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
        private bool checkBoxStatus()
        {
            if (this.chkBoxYes.Checked && !this.chkBoxNo.Checked)
            {
                this.lableStatus.Text = "Your Blood Report Is Positive";
                this.bloodReportStatus = true;
                return true;
            }
            else if (!this.chkBoxYes.Checked && this.chkBoxNo.Checked)
            {
                this.lableStatus.Text = "Your Blood Report Is Negative";
                this.bloodReportStatus = false;
                return true;
            }
            else
            {
                this.lableStatus.Text = "You Must Select Yes or No";
                return false;
            }
        }
        private bool chkPassword()
        {
            if(this.txtboxPassword.Text.Equals(this.txtboxConfirmPass.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void insertAddressTable()
        {

            try
            {
                this.userAddressTable.userID = this.txtboxUserName.Text;
                this.userAddressTable.firstName = this.txtboxFirstName.Text;
                this.userAddressTable.lastName = this.txtboxLastName.Text;
                this.userAddressTable.mobileNo = this.txtboxMobile.Text;
                this.userAddressTable.email = this.txtboxEmail.Text;
                this.userAddressTable.district = this.txtboxDistrict.Text;
                this.userAddressTable.subDistrict = this.txtboxSubDistrict.Text;
                this.userAddressTable.postalCode = this.txtboxPostal.Text;
                this.userAddressTable.accountstatus = "pending";

                db.UserAddrs.InsertOnSubmit(this.userAddressTable); //Adding In DB
                db.SubmitChanges();
            }catch(SqlException sqlEx)
            {
                MessageBox.Show("Address Not Inserted");
            }

        }
        private void insertUserLoginTable()
        {
            this.sendEmail();
            try
            {
                this.userLoginTable = new UserLoginData();
                this.userLoginTable.email = this.txtboxEmail.Text;
                this.userLoginTable.password = this.txtboxConfirmPass.Text;
                this.userLoginTable.username = this.txtboxUserName.Text;
                this.userLoginTable.userroll = 2;
                this.userLoginTable.verfication = this.FinalPass;
                this.userLoginTable.confirmVerification = null;
                db.UserLoginDatas.InsertOnSubmit(this.userLoginTable);
                db.SubmitChanges();
            }catch(SqlException sqlEx)
            {
                MessageBox.Show("UserLoginTable is not created");
            }

        }
        private void insertUserBloodDataTable()
        {
            if(this.userAddressTable!=null)
            {
                try
                {
                    this.userBloodTable = new BloodData();
                    this.userBloodTable.userID = this.txtboxUserName.Text;
                    this.userBloodTable.bloodGroup = this.bloodGroup;
                    this.userBloodTable.month = 0;
                    this.userBloodTable.date = null;
                    this.userBloodTable.donated = 0;
                    this.userBloodTable.requested = 0;
                    if (this.bloodReportStatus)
                    {
                        this.userBloodTable.bloodReport = 1;
                    }
                    else
                    {
                        this.userBloodTable.bloodReport = 0;
                    }
                    this.userBloodTable.accountstatus = "pending";
                    db.BloodDatas.InsertOnSubmit(this.userBloodTable);
                    db.SubmitChanges();
                }catch(SqlException ex)
                {
                    MessageBox.Show("BloodDataTable Not Created");
                }
            }
            else
            {
                MessageBox.Show("Address Table Is Must Be Created First");
            }
        }
        private void insertUserDetailsTable()
        {
            if(this.userAddressTable!=null && this.userBloodTable!=null && this.userLoginTable!=null)
            {
                try
                {
                    this.userDetailTable = new UserDtail();
                    this.userDetailTable.addressID = this.userAddressTable.addID;
                    this.userDetailTable.userID = this.txtboxUserName.Text;
                    this.userDetailTable.bloodID = this.userBloodTable.bloodID;
                    this.userDetailTable.bloodGroup = this.userBloodTable.bloodGroup;
                    this.userDetailTable.URoll = this.userLoginTable.userroll;
                    this.userDetailTable.accountstatus = "pending";
                    if(this.filePath!=null)
                    {
                        this.userDetailTable.propicture = this.filePath;
                    }
                    else
                    {
                        this.userDetailTable.propicture = null;
                    }
                    
                    db.UserDtails.InsertOnSubmit(this.userDetailTable);
                    db.SubmitChanges();
                }catch(SqlException ex)
                {
                    MessageBox.Show("UserDetailsTable Is Not Created");
                }
            }
        }
        /*private bool makeUserTempZero()
        {
            try
            {
                this.userTempTable = new UserTempData();
                try
                {
                    this.userTempTable.username = this.txtboxUserName.Text;
                    this.userTempTable.requestType = null;
                    this.userTempTable.requestStatus = null;
                    this.userTempTable.quantity = 0;
                    this.userTempTable.Date = null;
                    this.db.UserTempDatas.InsertOnSubmit(this.userTempTable);
                    this.db.SubmitChanges();
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("UserLoginTable is not created");
                    return false;
                }
                return true;
            }catch(NullReferenceException exp)
            {
                MessageBox.Show("Null Ref Exp");
                return false;
            }

        }*/
        private bool checkUserNameAvailable()
        {
            string name = this.txtboxUserName.Text;
            UserLoginData userLoginTable = db.UserLoginDatas.SingleOrDefault(x=>x.username==name);

            if(userLoginTable!=null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        private bool checkEmailAvailable()
        {
            string email = this.txtboxEmail.Text;
            UserLoginData userLoginTable = db.UserLoginDatas.SingleOrDefault(x=>x.email==email);
            if(userLoginTable!=null)
            {
                return false;
            }
            else
            {
                bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                {
                    this.lableStatus.Text = "";
                    return true;
                }
                else
                {
                    this.lableStatus.Text = "Invalid Email Format";
                    this.txtboxEmail.Clear();
                    this.txtboxEmail.WaterMark = "dipanjalmaitra@gmail.com";
                    return true;
                }
                
            }
        }
        private bool checkMobileNumberAvailable()
        { 
            string mobileNo = this.txtboxMobile.Text;
            UserAddr uAddrTab = db.UserAddrs.SingleOrDefault(x=>x.mobileNo==mobileNo);
            if(uAddrTab!=null)
            {
                return false;
            }
            else
            {
                bool isNumber = Regex.IsMatch(mobileNo, @"^(?:\+[8][8][\d]{11}$)");
                if(isNumber)
                {
                    this.lableStatus.Text = "";
                    return true;
                }
                else
                {
                    this.lableStatus.Text = "Invalid Mobile Number Ex: +8801717286919";
                    //this.txtboxMobile.Clear();
                    this.txtboxMobile.WaterMark = "+8801717286919";
                    return true;
                }
                
            }
        }

        private void txtboxPassword_Click(object sender, EventArgs e)
        {
            if (!this.checkUserNameAvailable())
            {
                this.txtboxUserName.Clear();
                this.lableStatus.Text = "Username allready existes";
            }
        }

        private void txtboxMobile_Click(object sender, EventArgs e)
        {
            if (!this.chkPassword())
            {
                this.lableStatus.Text = "Password Doesn't Match";
                this.txtboxConfirmPass.Clear();
            }
        }

        private void txtboxDistrict_Click(object sender, EventArgs e)
        {
            if(!this.checkEmailAvailable())
            {
                this.lableStatus.Text = "Email Allready Exists";
            }
        }

        private void txtboxEmail_Click(object sender, EventArgs e)
        {
            if(!this.checkMobileNumberAvailable())
            {

            }
        }
        private void generatePassword()
        {
            int[] keyList = new int[mainArr.Length];
            char[] passArr = new char[mainArr.Length];


            try
            {
                for (int i = 0; i < mainArr.Length; i++)
                {
                    int randA = this.RandI();
                    while (randA == this.RandI())
                    {
                        randA = this.RandI();
                    }
                    keyList[i] = randA;
                }
                try
                {
                    for (int i = 0; i < mainArr.Length; i++)
                    {
                        passArr[i] = this.mainArr[keyList[i]];
                    }
                    this.FinalPass = new string(passArr);
                }
                catch (IndexOutOfRangeException exp)
                {
                    MessageBox.Show("INDEX OUT'o Bound");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private int RandI()
        {
            int randIndex = new Random().Next(0, mainArr.Length);
            return randIndex;
        }

        private void sendEmail()
        {
            this.generatePassword();
            string generateTime = DateTime.Now.Millisecond.ToString();
            this.FinalPass = FinalPass + generateTime;
            string from = "bbmSystem@sys.com";
            string to = this.txtboxEmail.Text;
            string subject = "BBM Email Verification";

            string body = "HI ! " + this.txtboxFirstName.Text + "\n" + "Your Email Varification Code Is : " + this.FinalPass;
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com"); //gmail's prtovided SMTP server for mailing
            client.Port = 587; //SMTP port
            client.Credentials = new NetworkCredential(this.smtpHost, this.smtpPass); //email authentication
            client.EnableSsl = true; //opening SSL port
            try
            {
                client.Send(mail);
                //
                //updateData.password = this.FinalPass; //updating DB with the new generated password
                //db.SubmitChanges();
                //MessageBox.Show("Mail Send !");
                this.lableStatus.Text = "A Verification Code Has Been Send to your email";
            }
            catch (SmtpException exp)
            {
                MessageBox.Show("Sending Failure");
            }
        }
        private void sendEmail(string useremail)
        {
            this.generatePassword();
            string generateTime = DateTime.Now.Millisecond.ToString();
            this.FinalPass = FinalPass + generateTime;
            string from = "bbmSystem@sys.com";
            string to = useremail;
            string subject = "BBM Email Verification";

            string body = "HI ! " + this.txtboxFirstName.Text + "\n" + "Your Email Varification Code Is : " + this.FinalPass;
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com"); //gmail's prtovided SMTP server for mailing
            client.Port = 587; //SMTP port
            client.Credentials = new NetworkCredential(this.smtpHost, this.smtpPass); //email authentication
            client.EnableSsl = true; //opening SSL port
            try
            {
                client.Send(mail);
                //
                //updateData.password = this.FinalPass; //updating DB with the new generated password
                //db.SubmitChanges();
                //MessageBox.Show("Mail Send !");
                this.lableStatus.Text = "A Verification Code Has Been Send to your email";
            }
            catch (SmtpException exp)
            {
                MessageBox.Show("Sending Failure");
            }
        }
        public bool userCodeRequestSession(EmailConformation conf)
        {
            this.emailConf = conf;
            string userName = this.emailConf.LoggedUName;
            UserLoginData loginTable = db.UserLoginDatas.SingleOrDefault(x => x.username == userName);
            if(loginTable!=null)
            {
                this.sendEmail(loginTable.email);
                loginTable.verfication = this.FinalPass;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "*.jpg";
            //openFile.ShowDialog();
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                this.txtBrowseFile.Text = openFile.FileName;
                this.filePath = this.txtBrowseFile.Text;
                this.btnBrowseClicked = true;
            }
            else
            {
                this.btnBrowseClicked = false;
            }
        }
        private bool checkPhotoValidation()
        {
            if (this.btnBrowseClicked)
            {
                return true;
            }
            else
            {
                this.lableStatus.Text = "No Photo selected";
                return false;
            }
        }
    }
}






/*      
                               */
