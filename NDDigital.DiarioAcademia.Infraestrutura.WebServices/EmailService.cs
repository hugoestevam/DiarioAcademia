using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.WebServices
{
    internal class MailInfo
    {

        internal string Mails_Host_Server;
        internal string Sender_Mail;
        internal string Sender_Mail_Name;
        internal string Login_User;
        internal string Login_Pass;
        internal string DefaultReceiver;
        internal int SmtpServerPor;



    }
    public class EmailService : IIdentityMessageService
    {
        private MailInfo MailInfo;
        public EmailService()
        {
            MailInfo = new MailInfo
            {
                Login_User = "nddprint",
                Mails_Host_Server = "mail.nddigital.com.br",
                Sender_Mail = "nddprint@nddigital.com.br",
                Sender_Mail_Name = "Portal nddprint",
                Login_Pass = "vU72x@#oL",
                SmtpServerPor = 25,

                DefaultReceiver = "wesley.lemos@nddigital.com.br"
            };
        }


        public async Task<bool> Send(string to, string subject, string body, MemoryStream anexo = null)
        {
            bool ret = true;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    using (SmtpClient SmtpServer = new SmtpClient(MailInfo.Mails_Host_Server))
                    {
                        try
                        {
                            mail.From = new MailAddress(MailInfo.Sender_Mail, MailInfo.Sender_Mail_Name,
                                Encoding.Default);
                            mail.To.Add(to);
                            mail.Subject = subject;

                            mail.IsBodyHtml = true;
                            mail.Body = body;

                            if (anexo != null)
                            {
                                mail.Attachments.Add(new Attachment(anexo, subject + ".pdf"));

                            }

                            SmtpServer.Port = MailInfo.SmtpServerPor;
                            SmtpServer.Credentials = new System.Net.NetworkCredential(MailInfo.Login_User, MailInfo.Login_Pass);
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);
                        }
                        catch (Exception exe)
                        {
                            for (; exe.InnerException != null;)
                            {
                                exe = exe.InnerException;

                                Console.WriteLine(String.Format("Error: " + exe.Message));
                            }
                            ret = false;
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                for (; exe.InnerException != null;)
                {
                    exe = exe.InnerException;

                    Console.WriteLine(String.Format("Error: " + exe.Message));
                }
                ret = false;
            }

            return ret;
        }


        public Task SendAsync(IdentityMessage message)
        {
            return Send(message.Destination, MailInfo.Login_User, message.Body);
        }
    }
}