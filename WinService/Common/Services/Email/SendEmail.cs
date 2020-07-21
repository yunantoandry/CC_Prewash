using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;
using System.Configuration;
using HandlebarsDotNet;
using System.IO;
using Common.Model;
using Common.Repository;

namespace Common.Services.Email
{
   public class SendEmail : EmailCreator
    {
        private static string mFolderLocalDirectoryDumpOutput = string.Empty;
        public SendEmail()
        {

        }

        public void email_send()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("andry.yunanto0623@gmail.com");
            mail.To.Add("andry.yunanto0623@gmail.com");
            mail.Subject = "Reporting Risk";
            mail.Body = "Reporting Risk";

            //Attachment attachment;
            //attachment = new Attachment("c:/textfile.txt");
            //mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("andry.yunanto0623@gmail.com", "lupasekalisaya");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public void email_send2()
        {

            bool sts = false;
            SmtpUtil smtpUtil = null;
            smtpUtil = new SmtpUtil();
            var toAddressesAppSettingsName = "SendEmailsToAddresses";
            var toAddressesCsv = ConfigurationManager.AppSettings[toAddressesAppSettingsName];

        //    var bodyTemplate = GetEmbeddedEmailBodyTemplate("GeneralTemplate.html");
          //  var createBody = Handlebars.Compile(bodyTemplate);

           
           

            using (DBHelper db = new DBHelper())
            {
                Rep_ms_System_Parameter rep_ms_System_Parameter = new Rep_ms_System_Parameter(db);
                ms_system_parameter o = rep_ms_System_Parameter.Find("mFolderLocalDirectoryDumpOutput");
                mFolderLocalDirectoryDumpOutput = o != null ? o.ParameterValue : string.Empty;

                // Get all the files in the sourceDir
                string[] filePaths = Directory.GetFiles(mFolderLocalDirectoryDumpOutput);

                int fCount = Directory.GetFiles(mFolderLocalDirectoryDumpOutput, "*", SearchOption.AllDirectories).Length;
                // Attachment[] attachment = filePaths;

                // Get the files that their extension are either pdf of xls. 
                var files = filePaths.Where(x => Path.GetExtension(x).Contains(".txt") ||
                                                Path.GetExtension(x).Contains(".xls"));
                int count = filePaths.Length;
              //  Attachment[] attachment = fCount;


                // Loop through the files enumeration and attach each file in the mail.
                //foreach (string file in files)
                //{
                //    Console.WriteLine(file);
                //   // file;
                //    //  Attachments.Add(attachments);
                //}

                string to = toAddressesCsv;
                string subject = "test email";
                string body = "body email";
               // sts = smtpUtil.SendMail(to, subject, body, fCount);
            }
           // SendEmail_With_Attachment
        }
        //protected void SendMail(List<string> attachments)
        //{
        //    SmtpUtil Users = new SmtpUtil();
        //  //  Users.GetUserInformation();

        //    SmtpClient client = new SmtpClient(smtpse);
        //    MailMessage Message = new MailMessage();
        //    Message.From = new MailAddress(senderaddress);

        //    Message.To.Add(Users._CurUser_Destination_Email);
        //    Message.Subject = "Neue Umlagerung - " + cb_auflieger_limburg.SelectedItem.ToString();

        //    Message.Body = string.Format("Datum: {0}", DateTime.Now) + Environment.NewLine +
        //                                 "AufliegerNr.: " + cb_auflieger_limburg.SelectedItem.ToString() + Environment.NewLine +
        //                                 "Benutzer: " + Environment.UserName;

        //    client.UseDefaultCredentials = true;

        //    Attachment Attachment = null;

        //    try
        //    {
        //        foreach (string attachment in attachments)
        //        {
        //            Attachment = new Attachment(attachment);
        //            Message.Attachments.Add(Attachment);
        //        }

        //        client.Send(Message);
        //        Attachment.Dispose();
        //        Message.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        foreach (string attachment in attachments)
        //        {
        //            //Dateien nach Versendung löschen
        //            FileInfo fi = new FileInfo(attachment);
        //            if (fi.Exists)
        //            {
        //                fi.Delete();
        //            }
        //        }
        //    }
        //}


    }
}
