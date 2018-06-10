using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public interface IApplicationDbContext
    {

    }


    // Code-Based Configuration and Dependency resolution  
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //Add your Dbsets here  
        public DbSet<AffiliatedSite> AffiliatedSites { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<EmailForward> EmailForwards { get; set; }
        public DbSet<EmailSender> EmailSenders { get; set; }
        public DbSet<LogException> LogExceptions { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<MessagePosted> MessagePosteds { get; set; }





        public ApplicationDbContext()
            //Reference the name of your connection string  
            //: base("Server=localhost,1433;Initial Catalog={initial catalog/database};Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            : base()
        {


            //http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            //Database.SetInitializer<ApplicationDbContext>(null);
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }





    }

}
