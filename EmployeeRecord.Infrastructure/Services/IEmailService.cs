using System;
using System.Net.Mail;

namespace EmployeeRecord.Infrastructure
{
    public interface IEmailService
    {
        bool Send(MailMessage message);
    }
}
