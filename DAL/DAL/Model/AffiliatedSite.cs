using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AffiliatedSite: DbRootModel
    {
        //[Required]
        //public string AffiliatedSiteName { get; set; }
        public string HtmlCodeDescription { get; set; }
        //[Url]
        //public string Url { get; set; }
        //[Url]
        //public string EmailContact { get; set; }
    }
}
