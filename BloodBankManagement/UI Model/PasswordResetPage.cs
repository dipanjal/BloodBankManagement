using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading;


namespace BloodBankManagement
{
    public partial class PasswordResetPage : MetroFramework.Forms.MetroForm
    {
        DB_contextDataContext db = new DB_contextDataContext();
        private string smtpHost = "revolutionofhackers@gmail.com"; //Mail SMTP SERVER That is a Gmail Account
        private string smtpPass = "cr4ck3dl00k"; //gmail password
        private char[] mainArr = "r00T".ToCharArray(); 
        string FinalPass;
        
        public PasswordResetPage()
        {
            InitializeComponent();
            UserLoginData userData = new UserLoginData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserLoginPage().Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            UserLoginData emailData = db.UserLoginDatas.SingleOrDefault(x=>x.email==this.emailBox.Text);
            if(emailData!=null)
            {
                this.generatePassword();
                this.sendEmail(emailData);
            }
            else
            {
                MessageBox.Show("INVALID EMAIL");
            }
        }
        private void sendEmail(UserLoginData updateData)
        {
            string generateTime = DateTime.Now.Millisecond.ToString();
            this.FinalPass = FinalPass + generateTime;
            string from = "bbmSystem@sys.com";
            string to = this.emailBox.Text;
            string subject = "BBM Password Reset";

            string body = "HI ! "+updateData.username+"\n"+"Your New Password Is : "+this.FinalPass;
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com"); //gmail's prtovided SMTP server for mailing
            client.Port = 587; //SMTP port
            client.Credentials = new NetworkCredential(this.smtpHost, this.smtpPass); //email authentication
            client.EnableSsl = true; //opening SSL port
            try
            {
                client.Send(mail);
                //
                updateData.password = this.FinalPass; //updating DB with the new generated password
                db.SubmitChanges();
                MessageBox.Show("Mail Send !");
            }
            catch (SmtpException exp)
            {
                MessageBox.Show("Sending Failure");
            }
        }
        private void generatePassword()
        {
            int[] keyList=new int[mainArr.Length];
            char[] passArr = new char[mainArr.Length];
            
            
            try
            {
                for (int i = 0; i < mainArr.Length; i++)
                {
                    int randA = this.RandI();
                    while(randA==this.RandI())
                    {
                        randA = this.RandI();
                    }
                    keyList[i] = randA;
                }
                try
                {
                    for(int i=0;i<mainArr.Length;i++)
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
    }
}




/*string from = "catroot_rootcat@yahoo.com";
                string to = this.emailBox.Text;
                msg = new MailMessage(from,to,"TEST EMAIL","NEW : 123456");
                login = new NetworkCredential("catroot_rootcat@yahoo.com","g00dpa$$w0rdyahoo");
                client = new SmtpClient("smtp.mail.yahoo.com");
                client.Port = 465;
                client.EnableSsl = true;
                client.Credentials = login;
                try
                {
                    client.Send(msg);
                }
                catch(SmtpException exp)
                {
                    MessageBox.Show(exp.StackTrace);
                */
