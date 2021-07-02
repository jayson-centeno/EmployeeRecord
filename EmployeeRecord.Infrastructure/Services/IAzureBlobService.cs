using System;
using System.Net.Mail;

namespace EmployeeRecord.Infrastructure
{
    public interface IAzureBlobService
    {
        string[] GetFiles();
    }
}
