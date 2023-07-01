using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ZMS.Models.EntityModels
{
    public class AnimalFood
    {
        public int Id { get; set; }
        [ForeignKey("Animal")]
        [Required]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        [ForeignKey("Food")]
        [Required]
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
        [Required]
        [DisplayName("Animal Food Quantity")]
        public double Quantity { get; set; }
       
    }
}
