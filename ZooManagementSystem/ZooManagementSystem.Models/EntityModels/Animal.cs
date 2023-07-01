using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMS.Models.EntityModels
{
    public  class Animal
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Animal Name")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Animal Origin")]
        public string Origin { get; set; }
        [Required]
        [DisplayName("Animal Quantity")]
        public int Quantity { get; set; }

        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }


    }
}
