using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;



namespace MvcApplication8.Views.my
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        
        public void DoWork()
        {

        }
        public string login(string X_username,string X_password)
        {
            SqlConnection CON = new SqlConnection("Data Source=admin-pc;Initial Catalog=facebooklogin;Integrated Security=True");
           
            CON.Open();
            SqlCommand CMD = CON.CreateCommand();
            CMD.CommandText = "select * from userlogin";
            SqlDataReader sdr = CMD.ExecuteReader();
            userlogin login=new userlogin();
           login.username = X_username;
            login.password = X_password;
            try
            {
                while (sdr.Read())
                {
                    if ((login.username.Equals(sdr["username"].ToString())) && (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"loginid:\" " + login.X_loginid + "   \"username:\" " + login.username + "       \"firstname:\" " + login.firstname + "        \"surname:\" " + login.lastname + "        \"profilepic:\" " + login.profilepic + "    \"Responce code:200      Msg:Sucess\" ";
                        return str;

                    }
                    else if ((login.username.Equals(sdr["username"].ToString())) || (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"username:\" " + login.username + "   \"profilepic:\" " + login.profilepic + "    \"Responce code:500   Msg:password incorrect\" ";
                        return str;

                    }
                    else if (!(login.username.Equals(sdr["username"].ToString())) && (!(login.password.Equals(sdr["password"].ToString()))))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "    \"Responce code:404    Msg:Email id doesnot exit\" ";
                        return str;

                    }


                }
            }
            catch (Exception ex)
            {
                errorloginfile.SendError(ex);

            }
                

           // CON.Close();
           // CMD.Dispose();
           return null;
        }

        public string signupMethod(string X_firstname, string X_surname, string X_emailaddress, string X_password,string proflepic, DateTime DT_dob, string X_gender)
        {
     

            FileUpload FLD1 = new FileUpload();
            
            string profpictr = "E:\\profpic\\" + proflepic;
            FLD1.SaveAs(profpictr);


            SqlConnection CNN = new SqlConnection("Data Source=admin-pc;Initial Catalog=facebooklogin;Integrated Security=True");
            string STR;
            CNN.Open();
            signup sign = new signup();
            sign.firstname = X_firstname;
            sign.surname = X_surname;
            sign.emailadress = X_emailaddress;
            sign.password = X_password;
            sign.proflepic = profpictr;
            sign.DT_dob = DT_dob;
            sign.gender = X_gender;
            STR = "insert into userlogin(firstname,surname,profilepic,username,message,emailaddress,password,dob,gender) values('" + sign.firstname + "','" + sign.surname + "','"+sign.proflepic+"','"+""+"','"+""+"','"+ sign.emailadress + "','" + sign.password + "','" + sign.DT_dob + "','" + sign.gender + "')";
            SqlCommand COD = new SqlCommand(STR,CNN);
            int res=COD.ExecuteNonQuery();
            COD.Dispose();
            CNN.Close();
            if (res > 0)
            {
                mailservice();
                return "success";
            }
            else
            {
                return "false";
            }


        }
        public void mailservice()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("harishmahari1502@gmail.com");
            msg.To.Add("harishmahari1502@gmail.com");
            msg.Subject ="verification";
            msg.Body ="Welcome to facebook";
            msg.IsBodyHtml = true;
            //msg.Attachments.Add(new Attachment("C:\\Users\\ADMIN\\Desktop\\test.txt"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("harishmahari1502@gmail.com", "8301ha0882ri");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                
            }
            catch (Exception ex)
            {
              

            }
        }
    }

}
