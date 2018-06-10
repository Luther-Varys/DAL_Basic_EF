using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class EmailSender: DbRootModel
    {

        [Required(ErrorMessage = "Inserire valore")]
        [EmailAddress]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
    }
}
