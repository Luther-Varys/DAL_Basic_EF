using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{


    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            UnitOfWork uow = new UnitOfWork(db);

            var emailSender = new EmailSender();
            emailSender.EmailAddress = "bar@iol.it";
            uow.ReEmailSender.Add(emailSender);


            uow.SaveChanges();

            base.Seed(db);
        }
    }




}
