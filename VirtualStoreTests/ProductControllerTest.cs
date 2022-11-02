using Moq;
using VirtualStoreBackEnd.Context;
using VirtualStoreBackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;

namespace VirtualStoreTests
{
    [TestClass]
    public class ProductControllerTest
    {
        private readonly DbContextOptions _options = new DbContextOptionsBuilder<PostgresContext>().UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=fake").Options;

        [TestMethod("Test #1 Should be create a new product")]
        public void AddAsync()
        {
            //Arrange
                        
            var mockSet = new Mock<DbSet<ProductModel>>();
            var mockContext = new Mock<PostgresContext>(_options);
            mockContext.Setup(c => c.ProductModel).Returns(mockSet.Object);

            //act
            ProductModel model = new() { Id = Guid.NewGuid(), FullName = "ROTEADOR" };
            mockContext.Object.ProductModel.Add(model);
            mockContext.Object.SaveChanges();

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<ProductModel>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod("Test #2 Should be return 3 products")]
        public void Index()
        {
            //Arrange
            var data = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid(), FullName = "Violão"},
                new ProductModel {Id = Guid.NewGuid(), FullName = "Roteador"},
                new ProductModel {Id = Guid.NewGuid(), FullName = "Modem"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductModel>>();
            mockSet.As<IQueryable<ProductModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PostgresContext>(_options);
            mockContext.Setup(c => c.ProductModel).Returns(mockSet.Object);

            //Act
            var products  = mockContext.Object.ProductModel.ToList();
            


            //Assert
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("Violão", products[0].FullName);
            Assert.AreEqual("Roteador", products[1].FullName);
            Assert.AreEqual("Modem", products[2].FullName);
        }
    }
}