using Common.Model;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class SmtpUtil : Smtp
    {
        public string ErrorMessage { get; set; }
        private static string HostAdd = ServiceConfiguration.GetAppSettingValue("Host");
        private static string FromEmailid = ServiceConfiguration.GetAppSettingValue("FromMail");
        private static string Pass = ServiceConfiguration.GetAppSettingValue("Password");

        public SmtpUtil()
        {
            ErrorMessage = string.Empty;
            using (DBHelper db = new DBHelper())
            {
                Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
                List<ms_system_parameter> colls = rep.GetAll("Where Category='Email' and SubCategory='SMTP Setting'");
                SetStmpValue(colls);
                rep = null;
            }
        }

        public SmtpUtil(string SqlConnectionstring)
        {
            using (DBHelper db = new DBHelper(SqlConnectionstring))
            {
                Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
                List<ms_system_parameter> colls = rep.GetAll("Where Category='Email' and SubCategory='SMTP Setting'");
                SetStmpValue(colls);
                rep = null;
            }
        }

        public SmtpUtil(DBHelper db)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
            List<ms_system_parameter> colls = rep.GetAll("Where Category='Email' and SubCategory='SMTP Setting'");
            SetStmpValue(colls);
            rep = null;
        }
        private void SetStmpValue(List<ms_system_parameter> colls)
        {
            this.SMTPServer = colls.Where(x => x.ParameterCode.ToLower().Equals("smtpserver")).SingleOrDefault().ParameterValue;
            this.EmailFrom = colls.Where(x => x.ParameterCode.ToLower().Equals("emailfrom")).SingleOrDefault().ParameterValue;
            this.SMTPUser = colls.Where(x => x.ParameterCode.ToLower().Equals("smtpuser")).SingleOrDefault().ParameterValue;
            this.SMTPPassword = colls.Where(x => x.ParameterCode.ToLower().Equals("smtppassword")).SingleOrDefault().ParameterValue;
            this.SMTPDefaultCredentials = Convert.ToBoolean(colls.Where(x => x.ParameterCode.ToLower().Equals("smtpdefaultcredentials")).SingleOrDefault().ParameterValue);
            this.SMTPSSL = Convert.ToBoolean(colls.Where(x => x.ParameterCode.ToLower().Equals("smtpssl")).SingleOrDefault().ParameterValue);
            this.SMTPPort = Convert.ToInt32(colls.Where(x => x.ParameterCode.ToLower().Equals("smtpport")).SingleOrDefault().ParameterValue);
        }

        private void ClientEmail (MailMessage msg)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTPServer);
            client.Port = Convert.ToInt32(SMTPPort);
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = Convert.ToBoolean(SMTPDefaultCredentials);

            // Create the credentials
            System.Net.NetworkCredential credentials = CredentialCache.DefaultNetworkCredentials;

            if (!string.IsNullOrEmpty(SMTPUser) && !string.IsNullOrEmpty(SMTPPassword))
            {
                credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
                client.Credentials = credentials;
            }

            if (Convert.ToBoolean(SMTPSSL))
                client.EnableSsl = Convert.ToBoolean(SMTPSSL);
          
            client.Send(msg);
        }

        public bool SendMail(string To, string Subject, string Body)
        {
            MailMessage msg = null;
            

            try
            {
                MailAddress from = new MailAddress(this.EmailFrom);

                msg = new MailMessage();
                msg.Priority = MailPriority.High;
                msg.From = from;

                string[] sTo = To.Split(';');

                foreach (string s in sTo)
                {
                    if (!string.IsNullOrEmpty(s.Trim()))
                    {
                        msg.To.Add(s.Trim());
                    }
                }

                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = true;

                ClientEmail(msg);

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
                return false;
            }
            finally
            {
                msg = null;
         
            }
        }

        public bool SendMail(string To, string Subject, string Body, List<Attachment> attach)
        {
            MailMessage msg = null;
         

            try
            {
                MailAddress from = new MailAddress(this.EmailFrom);

                msg = new MailMessage();
                msg.Priority = MailPriority.High;
                msg.From = from;

                string[] sTo = To.Split(';');

                foreach (string s in sTo)
                {
                    if (!string.IsNullOrEmpty(s.Trim()))
                    {
                        msg.To.Add(s.Trim());
                    }
                }
                               
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = true;
               
                if (attach.Count > 0)
                {
                    for (int i = 0; i < attach.Count; i++)
                    {
                        msg.Attachments.Add((Attachment)attach[i]);
                    }
                }

                ClientEmail(msg);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
                return false;
            }
            finally
            {
                msg = null;
             
            }
        }

        public static void SendEmail_With_Attachment(String ToEmail, String Subj, string Message, string sourcePath)
        {

            //creating the object of mailmessage
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new MailAddress(FromEmailid);
            mailMessage.Subject = Subj;
            mailMessage.Body = Message;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(ToEmail));
            FileStream fStream;
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            foreach (FileInfo files in dir.GetFiles("*.*"))
            {
                fStream = File.OpenRead(sourcePath + "\\" + files.Name);
                mailMessage.Attachments.Add(new System.Net.Mail.Attachment(fStream, files.Name));
                fStream.Close();
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostAdd;

            //network and security related credentia
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            NetworkCred.Password = Pass;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage);
        }
    }
}
