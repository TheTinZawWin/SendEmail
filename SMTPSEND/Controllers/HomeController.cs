using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SMTPSEND.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool SendEmail(string sendermail,string password,string receivermail)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string subject = string.Empty;
            string body = string.Empty;
           
                subject = " application have been approved";
                body = "<p>Dear xxxx,</p><p> Your  application has been approved.</p><p> Regards,<br/> xxxxxxx <br/> Sender </p> ";


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(sendermail);
                mail.To.Add(receivermail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
              
                //attached file
                mail.Attachments.Add(new Attachment("D:/Tin Zaw Win/deadlinechangequery.txt"));
            
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(sendermail, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
                return true;
            }
        }
    }
}