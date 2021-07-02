using EmployeeRecord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmployeeRecord.Domain.Services
{
    /// <summary>
    /// Use to send SMS
    /// </summary>
    public class SmsService : ISmsService
    {
        public bool Send(string message)
        {
            return true;
        }
    }
}
