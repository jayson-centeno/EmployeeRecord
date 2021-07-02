using EmployeeRecord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace EmployeeRecord.Domain.Services
{
    /// <summary>
    /// Use to process azure blob
    /// </summary>
    public class AzureBlobService : IAzureBlobService
    {
        public string[] GetFiles()
        {
            return Enumerable.Repeat("photo", 1).ToArray();
        }
    }
}
