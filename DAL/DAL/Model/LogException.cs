using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class LogException:DbRootModel
    {
        public string ExceptionMessage { get; set; }
    }
}
