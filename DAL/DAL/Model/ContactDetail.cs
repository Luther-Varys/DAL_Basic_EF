using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ContactDetail: DbRootModel
    {

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailContact { get; set; }

        [Url]
        public string UrlSocialFacebook { get; set; }

        [Url]
        public string UrlSocialTwitter { get; set; }

    }
}
