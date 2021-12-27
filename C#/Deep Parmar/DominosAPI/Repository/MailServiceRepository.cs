using DominosAPI.IRepository;
using DominosAPI.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class MailServiceRepository:IMailServiceRepository
    {
        private readonly MailSettings _mailSettings;

        public MailServiceRepository(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public void SendEmailAsync(MailRequest mailRequest)
        {
            MimeMessage Email = new MimeMessage();
            Email.Sender = MailboxAddress.Parse(_mailSettings.MailId);
            Email.From.Add(MailboxAddress.Parse(_mailSettings.MailId));

            Email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            Email.Subject = mailRequest.Subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            Email.Body = builder.ToMessageBody();

            using (SmtpClient smtp=new SmtpClient())
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, _mailSettings.UseSSL);
                smtp.Authenticate(_mailSettings.MailId, _mailSettings.Password);
                smtp.Send(Email);
                smtp.Disconnect(true);
            }
        }
    }
}
