using System.Net.Mail;

namespace AutDemo.Infraestrutura.Servicos
{
    public static class EmailService
    {
        static string _smtpServer = "smtp.sendgrid.net";
        static string _smtpUserLoginName = "";
        static string _smtpUserPassword = "";

        public static void Enviar(string emailPara, string assunto, string corpo)
        {
            EnviarInternal("no-reply@crescer.com.br", emailPara, assunto, corpo);
        }
        public static void Enviar(string emailDe, string emailPara, string assunto, string corpo)
        {
            EnviarInternal(emailDe, emailPara, assunto, corpo);
        }

        private static void EnviarInternal(string emailDe, string emailPara, string assunto, string corpo)
        {
            using (SmtpClient smtpClient = new SmtpClient(_smtpServer, 587))
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(_smtpUserLoginName, _smtpUserPassword);
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailDe);
                    mail.To.Add(new MailAddress(emailPara));
                    mail.Body = corpo;
                    smtpClient.Send(mail);
                }
            }
        }
    }
}
