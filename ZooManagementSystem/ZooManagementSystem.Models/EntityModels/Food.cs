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
    public class Food
    {
        public Food()
        {
            AnimalFoods=new List<AnimalFood>();
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Food Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Food Price")]
        public double Price { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }

        public static implicit operator Food(List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Food(List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> v)
        {
            throw new NotImplementedException();
        }
    }
}
