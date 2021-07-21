using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        [Range(1, 99, ErrorMessage = "Qty must be 1 to 99")]
        public int Quantity { get; set; }
        // Navigation Property
        public virtual MenuItem MenuItem { get; set; }
    }
}
