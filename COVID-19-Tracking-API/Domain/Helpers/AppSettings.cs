using System;
namespace C19Tracking.API.Domain.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SubFolder { get; set; }
        public string MailSender { get; set; } 
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; } 
        public string MailSignature { get; set; }
        public string MailDefaultSubject { get; set; }
        public string MailDefaultContent { get; set; }

        

    }
}
