using EmployeeRecord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmployeeRecord.Domain.Services
{
    /// <summary>
    /// Use to send email
    /// </summary>
    public class EmailService : IEmailService
    {
        public bool Send(MailMessage message)
        {
            return true;
        }
    }
}
