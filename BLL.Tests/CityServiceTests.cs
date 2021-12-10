using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using Moq;
using popCount.entities;
using popCount.repositories.interfaces;
using popCount.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class CityServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetStreets_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ICityesService cityService = new CityService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => cityService.GetCityes(0));
        }

        [Fact]
        public void GetStreets_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Boss(1, "test", 1);
            SecurityContext.SetUser(user);
            var streetService = GetStreetService();

            // Act
            var actualStreetDto = streetService.GetCityes(0).First();
        
            // Assert
            Assert.True(
                actualStreetDto.cityId == 1
                && actualStreetDto.cityName == "testN"
                && actualStreetDto.count == 1000
            );
        }

        ICityesService GetStreetService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedCity = new city()
            {
                cityId = 1,
                cityName = "testN",
                count = 1000
            };
            var mockDbSet = new Mock<ICityRepository>();
            mockDbSet
              .Setup(z =>
                z.Find(
                    It.IsAny<Func<city, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                 .Returns(
                     new List<city>() { expectedCity }
                  );
            mockContext
                .Setup(context =>
                    context.citys)
                .Returns(mockDbSet.Object);

            ICityesService streetService = new CityService(mockContext.Object);

            return streetService;
        }
    }
}
