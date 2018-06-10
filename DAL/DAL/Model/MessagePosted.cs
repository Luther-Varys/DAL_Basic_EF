using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MessagePosted: DbRootModel
    {
        [Required(ErrorMessage = "Inserire valore")]
        [EmailAddress]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Email")]
        public string EmailSender { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Cognome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Formato data non valido. esempio: 02/07/2010")]
        [Display(Name = "Data di Nascita")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Città")]
        public string City { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 100, ErrorMessage = "Lunghezza massima caratteri 100")]
        [Display(Name = "Provincia")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 30, ErrorMessage = "Lunghezza massima caratteri 30")]
        [Display(Name = "Numero di Telefono")]
        public string PhoneNumber { get; set; }

        //[AllowHtml]
        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 200, ErrorMessage = "Lunghezza massima caratteri 200")]
        [Display(Name = "Oggetto Messaggio")]
        public string MessageSubject { get; set; }

        //[AllowHtml]
        [Required(ErrorMessage = "Inserire valore")]
        [MaxLength(length: 1000, ErrorMessage = "Lunghezza massima caratteri 1000")]
        [Display(Name = "Messaggio")]
        public string MessageContent { get; set; }
    }
}
