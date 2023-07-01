﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMS.Databases.Data;
using ZMS.Models.EntityModels;
using ZMS.Services.Abstractions;
using ZMS.Services.Services.Base;

namespace ZMS.Services.Services
{
    public class AnimalService : Service<Animal>,IAnimalService
    {
        public AnimalService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
