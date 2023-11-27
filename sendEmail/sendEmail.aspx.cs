using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace unSupervisorApp.demo
{
    public partial class sendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("appdev4y@gmail.com");
                msg.Subject = "Your Subject";
                msg.Body = "<h1>Hello user</h1> Email Body content";
                msg.IsBodyHtml = true;
                #region 
                //hard code
                //  msg.To.Add(new MailAddress("aalhussein63@gmail.com"));
                //List<string> files = new List<string>();
                //// loop file system to add files into  the list
                //files.Add("~/myPdf/aalhussein@gmail.com.pdf");
                //files.Add("~/myPdf/ahameed@kfmc.med.sa.pdf");
                //files.Add("~/myPdf/aalhussein@yahoo.com.pdf");
                /// List<string> files =(List <string>)GetUploadList();
                 #endregion
                /// 
                List<string> files =GetUploadList().Cast<string>().ToList();
                 foreach (string file in files)
                {
                   int index = file.IndexOf(".pdf");
                    string strTo = file.Substring(0,index);
                    msg.Subject = "Email Subject :    " +  strTo;
                    msg.To.Add(new MailAddress(strTo));
                    msg.Attachments.Add(new Attachment(Server.MapPath("~/Uploads/" + file))); // Attach Each file
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = msg.From.Address;
                    NetworkCred.Password = "aowhaqeyqiarghyr";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(msg);
                    msg.To.Clear();
                   msg.Attachments.Clear();
                }
            }
        }

        protected IEnumerable GetUploadList()
        {
            string folder = Server.MapPath("~/Uploads");// get uploaded folder
            string[] files = Directory.GetFiles(folder); // get all files in folder 
            Array.Sort(files);
            foreach (string file in files)
                yield return Path.GetFileName(file);  // return individual file
        }
    }
}