using Microsoft.EntityFrameworkCore;
using popCount.entities;
using popCount.repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.test
{
    internal class TestCityRepository
        : BaseRepository<city>
    {
        public TestCityRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
