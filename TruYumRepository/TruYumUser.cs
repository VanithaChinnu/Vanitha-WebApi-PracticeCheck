using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    [Table("TruYumUser")]
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
    }
}
