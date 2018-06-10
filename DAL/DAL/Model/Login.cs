using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Login: DbRootModel
    {
        [Required(ErrorMessage = "Inserire username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Inserire password")]
        public string Password { get; set; }

        public bool Rememberme { get; set; }

    }
}
