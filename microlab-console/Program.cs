using System;
using Microsoft.Extensions.Configuration;
using DataLayer;
using System.IO;
using System.Diagnostics;

namespace microlab_console
{
    class Program
    {
        // Microsoft.Extensions.Configuration
        private static IConfigurationRoot config;
        static void Main(string[] args)
        {
            Initialize();
            Console.WriteLine("Test zovi");
            Get_all_should_return_6_results();
        }

        static void Get_all_should_return_6_results()
        {
            var repository = CreateRepository();
            var contacts = repository.GetAll();

            Console.WriteLine($"Count: {contacts.Count}");
            Debug.Assert(contacts.Count == 6);
            contacts.Output();
        }

        private static void Initialize()
        {
            var dir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            config = builder.Build();

        }
        private static IContactRepository CreateRepository()
        {
            var t = new ContactRepostiory("server=(localdb)\\ProjectsV13;database=microlabdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            //var t = new ContactRepostiory(config.GetConnectionString("DefaultConnection"));
            return t;
        }
    }
}
