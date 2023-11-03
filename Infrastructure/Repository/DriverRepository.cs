using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository;
    public class DriverRepository : GenericRepository<Driver>, IDriver
    {
        public DriverRepository(DbFirstContext context) : base(context)
        {
        }
    }
