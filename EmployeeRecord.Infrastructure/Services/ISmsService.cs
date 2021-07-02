using System;
using System.Net.Mail;

namespace EmployeeRecord.Infrastructure
{
    public interface ISmsService
    {
        bool Send(string message);
    }
}
