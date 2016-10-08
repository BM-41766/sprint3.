using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication8.Models;
using System.Web.UI.WebControls;
using System.IO;


namespace MvcApplication8.Controllers
{
    public class myController : Controller
    {
        //
        // GET: /my/
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index()
        {
            return View("Index");
        }
       [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(ModelClass1 mc, string cmd)
        {
           
           if (cmd == "Login")
           {
               string msg = mc.login();
               if(msg.Contains("Responce code:200"))
                {
                   return View("Homepage");
               }
               return Content("<script language='javascript'type='text/javascript'>alert('" + msg + "');</script>");
               //return View(mc);
               
           }


           if (cmd == "create an account")
           {

               //var today = new Date();
               int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());

               int year = Convert.ToInt32(mc.X_year);
               int age = currentYear - year;
               if (age >= 13)
               {
                   
                  FileUpload fld1 = new FileUpload();
                  string profpictr = "F:\\proflpict\\" + mc.proflepic;
                  fld1.SaveAs("F:\\proflpict\\" + mc.proflepic);
                   //long filesize = new FileInfo(profpictr).Length;
                   FileInfo fileInfo = new FileInfo("F:\\proflpict\\"+mc.proflepic);
                   double fileSizeKB = fileInfo.FullName.Length / 1024;
                   double fileSizeMB = fileInfo.FullName.Length / (1024 * 1024);
                  /* long fileSizeInBytes = fld1.FileContent.Length;
                   // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                   long fileSizeInKB = fileSizeInBytes / 1024;
                   // Convert the KB to MegaBytes (1 MB = 1024 KBytes)
                   long fileSizeInMB = fileSizeInKB / 1024;*/
                  // if (filesize < 5)
                   //{
                        string msgg = mc.signup();
                       // return Content("<script language='javascript'type='text/javascript'>alert('" + msgg + "');</script>");
                        return View("Vpage");
                   //}
               }
              /* else
               {
                   return null;
               }*/

               
              }
           return null;
           }
    }

 }
