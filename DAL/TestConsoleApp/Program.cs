using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uow = new UnitOfWork();
            var listres = uow.ReEmailSender.GetAll();

            Console.WriteLine($"There are {listres.Count} entities, the mail is {listres.First().EmailAddress}.");

            Console.ReadLine();
        }
    }
}
