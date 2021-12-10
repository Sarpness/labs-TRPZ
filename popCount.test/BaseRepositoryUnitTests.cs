using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using popCount.repositories.impl;
using popCount.entities;
using popCount.EF;

namespace popCount.test
{
    class TestCityRepository
        : BaseRepository<city>
    {
        public TestCityRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputCityInstance_CalledAddMethodOfDBSetWithCityInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<cityContext>()
                .Options;

            var mockContext = new Mock<cityContext>(opt);
            var mockDbSet = new Mock<DbSet<city>>();

            mockContext.Setup(
                context =>
                context.Set<city>()
                ).Returns(mockDbSet.Object);

            var repository = new TestCityRepository(mockContext.Object);
            city expectedCity = new Mock<city>().Object;

            repository.Create(expectedCity);

            mockDbSet.Verify(
                DbSet => DbSet.Add(expectedCity),
                Times.Once()
                );
                
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<cityContext>()
                .Options;
            var mockContext = new Mock<cityContext>(opt);
            var mockDbSet = new Mock<DbSet<city>>();
            mockContext
                .Setup(context =>
                    context.Set<city>(
                        ))
                .Returns(mockDbSet.Object);

            city expectedcity = new city() { cityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedcity.cityId))
                    .Returns(expectedcity);
            var repository = new TestCityRepository(mockContext.Object);

            //Act
            var actualcity = repository.Get(expectedcity.cityId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedcity.cityId
                    ), Times.Once());
            Assert.Equal(expectedcity, actualcity);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<cityContext>()
                .Options;
            var mockContext = new Mock<cityContext>(opt);
            var mockDbSet = new Mock<DbSet<city>>();
            mockContext
                .Setup(context =>
                    context.Set<city>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IcityRepository repository = uow.citys;
            var repository = new TestCityRepository(mockContext.Object);

            city expectedcity = new city() { cityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedcity.cityId)).Returns(expectedcity);

            //Act
            repository.Delete(expectedcity.cityId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedcity.cityId
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedcity
                    ), Times.Once());
        }

    }
}
