using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication8.Models
{
    public class ModelClass1
    {
        public string name="";
        public string pwd="";
        public string X_Username
        {
        get
        {
            return name;
        }
            set
            {
                name=value;
            }
        }
        public string X_paswrd
        {
            get
            {
                return pwd;
            }
            set
            {
                pwd=value;
            }
        }
        string msg;
        public string login()
        {
            try
            {
                ServiceReference2.Service1Client sc1 = new ServiceReference2.Service1Client();
                msg = sc1.login(X_Username, X_paswrd);
               // return msg;
            }
            catch (Exception ex)
            {
                errorloginfile.SendError(ex);
            }
            return msg;
        }
        public string fname = "";
        public string sname = "";
        public string email = "";
        public string pswrd = "";
        public string proflpic = "";
        public string dy = "";
        public string mnth = "";
        public string yer = "";
        public string gndr = "";
        public string X_frstname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string X_srname
        {
            get
            {
                return sname;
            }
            set
            {
                sname = value;
            }
        }
        public string X_emailadress
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string X_pawrd
        {
            get
            {
                return pswrd;
            }
            set
            {
                pswrd = value;
            }
        }
        public string proflepic
        {
            get
            {
                return proflpic;
            }
            set
            {
                proflpic = value;
            }
        }
        public string X_day
        {
            get
            {
                return dy;
            }
            set
            {
                dy = value;
            }
        }
        public string X_month
        {
            get
            {
                return mnth;
            }
            set
            {
                mnth = value;
            }
        }
        public string X_year
        {
            get
            {
                return yer;
            }
            set
            {
                yer = value;
            }
        }
        public string X_gendr
        {
            get
            {
                return gndr;
            }
            set
            {
                gndr = value;
            }
        }
        public string signup()
        {
            string msge;
            ServiceReference2.Service1Client sr=new ServiceReference2.Service1Client();
            DateTime DT_dob = Convert.ToDateTime(X_day + "/" + X_month + "/" + X_year);
            msge = sr.signupMethod(X_frstname, X_srname, X_emailadress, X_pawrd,proflepic,DT_dob, X_gendr);
            return msge;
        }

    }
}
