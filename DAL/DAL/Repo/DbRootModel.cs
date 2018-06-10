using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    public class DbRootModel : IDbRootModel
    {
        [Key]
        public Int64 Id { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        [StringLength(1000, ErrorMessage = "Max 1000 characters")]
        public string HiddenInfo { get; set; }

        public bool IsSoftDeleted { get; set; }

        //[Column(TypeName = "DateTime2")]
        public DateTime DateTimeUtcCreated { get; set; }

        //[Column(TypeName = "DateTime2")]
        public DateTime DateTimeUtcLastUpdated { get; set; }

    }

    public interface IDbRootModel
    {
        Int64 Id { get; set; }
        //byte[] RowVersion { get; set; }
        string HiddenInfo { get; set; }
        bool IsSoftDeleted { get; set; }
        DateTime DateTimeUtcCreated { get; set; }
        DateTime DateTimeUtcLastUpdated { get; set; }
    }


}
