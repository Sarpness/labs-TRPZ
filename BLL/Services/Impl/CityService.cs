using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using popCount.entities;
using popCount.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class CityService
        : ICityesService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public CityService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        // <exception cref="MethodAccessException"></exception>
        public IEnumerable<CityDTO> GetCityes(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Boss)
                && userType != typeof(Employer))
            {
                throw new MethodAccessException();
            }
            var cityID = user.CityID;
            var cityesEntities =
                _database
                    .citys
                    .Find(z => z.cityId == cityID, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<city, CityDTO>()
                    ).CreateMapper();
            var cityDto =
                mapper
                    .Map<IEnumerable<city>, List<CityDTO>>(
                        cityesEntities);
            return cityDto;
        }
    }
}
