using popCount.EF;
using popCount.entities;
using popCount.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.repositories.impl
{
    internal class CityRepository
        : BaseRepository<city>, ICityRepository
    {
        internal CityRepository(cityContext context) : base(context)
        {
        }
    }
}
