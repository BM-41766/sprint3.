using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MvcApplication8.Views.my
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string login(string X_username,string X_password);
        [OperationContract]
        string signupMethod(string X_firstname,string X_surname,string X_emailaddress,string X_password,string proflepic,DateTime DT_dob,string X_gender);
    }
  public class userlogin
  {
      public string firstname { get; set; }
      public string lastname { get; set; }
      public string profilepic { get; set; }
      public string username { get; set; }
      public int loginid { get; set; }
      public string X_loginid { get; set; }
      public string message { get; set; }
      public string password { get; set; }
  }
  public class signup
  {
      public string firstname { get; set; }
      public string surname { get; set; }
      public string emailadress { get; set; }
      public string password { get; set; }
      public string proflepic { get; set; }
      public DateTime DT_dob { get; set; }
      public string gender { get; set; }
  }
   
}
