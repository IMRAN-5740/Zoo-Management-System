using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMS.Models.EntityModels;

namespace ZMS.Databases.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Animal>Animals { get; set; }
        public DbSet<Food> Foods {  get; set; }
        public DbSet<AnimalFood> AnimalFoods {  get; set; }
 
    }
}
