using DbUp;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace EmployeeRecord.Migration
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try {

                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var connectionString = configuration.GetConnectionString("Default");

                var upgrader =
                    DeployChanges.To
                        .SqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                        .LogToConsole()
                        .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.ResetColor();
#if DEBUG
                    Console.ReadLine();
#endif
                    return -1;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Migration Success!");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception e) {
            }

            return 0;
        }

    }
}
