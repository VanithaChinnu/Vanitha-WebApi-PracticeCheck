using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumRepository
{
    [Table("MenuItem")]
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        public decimal Price { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Date of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }
        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        // Navigation property
        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public MenuItem()
        {
            Carts = new HashSet<Cart>();
        }
    }
}
