using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleWithDataAccess.Entities
{
    [Table("user")]
    public class User
    {
        [Column("row_num")]
        public int RowNum { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("user_password")]
        public string UserPassword { get; set; }

        [Column("user_token")]
        public string UserToken { get; set; }

        [Column("is_active")]
        public string IsActive { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
