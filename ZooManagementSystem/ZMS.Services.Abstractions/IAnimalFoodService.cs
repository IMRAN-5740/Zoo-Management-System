using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions.Base;

namespace ZMS.Services.Abstractions
{
    public interface IAnimalFoodService:IService<AnimalFood>
    {
        ICollection<AnimalFood> GetAllResult(Expression<Func<AnimalFood, bool>> predicate = null);

    }
}
