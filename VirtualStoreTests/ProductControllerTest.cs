using Moq;

using VirtualStoreBackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;
using VirtualStoreBackEnd.Data;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirtualStoreTests
{
    [TestClass]
    public class ProductControllerTest : IClassFixture<TestDatabaseFixture>
    {
        public ProductControllerTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }


        [Fact]
        [TestMethod]
        public void AddAsync()
        {
            using var context = Fixture.CreateContext();
            //var list = context.ProductModel.ToListAsync();
            //Console.WriteLine(list);
            Console.WriteLine("deu");
        }
        //    private readonly DbContextOptions _options = new DbContextOptionsBuilder<SQLServerContext>().UseSqlServer("Server=(localdb)mssqllocaldb;Database=VirtualStore").Options;

        //    [TestMethod("Test #1 Should be create a new product")]
        //    public void AddAsync()
        //    {
        //        //Arrange

        //        var mockSet = new Mock<DbSet<ProductModel>>();
        //        var mockContext = new Mock<SQLServerContext>(_options);
        //        mockContext.Setup(c => c.ProductModel).Returns(mockSet.Object);

        //        //act
        //        ProductModel model = new() { Id = Guid.NewGuid(), FullName = "ROTEADOR" };
        //        mockContext.Object.ProductModel.Add(model);
        //        mockContext.Object.SaveChanges();

        //        //Assert
        //        mockSet.Verify(m => m.Add(It.IsAny<ProductModel>()), Times.Once());
        //        mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //    }

        //[TestMethod("Test #2 Should be return 3 products")]
        //public void Index()
        //{
        //    //Arrange
        //    var data = new List<ProductModel>
        //    {
        //        new ProductModel {Id = Guid.NewGuid(), FullName = "Violão", Price = 333333.157M },
        //        new ProductModel {Id = Guid.NewGuid(), FullName = "Roteador", Price = 123456.157M},
        //        new ProductModel {Id = Guid.NewGuid(), FullName = "Modem", Price = 123456.157M}
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<ProductModel>>();
        //    mockSet.As<IQueryable<ProductModel>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<ProductModel>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<ProductModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<ProductModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<SQLServerContext>();
        //    mockContext.Setup(c => c.ProductModel).Returns(mockSet.Object);

        //    //Act
        //    var products = mockContext.Object.ProductModel.ToList();



        //    //Assert
        //    Assert.AreEqual(3, products.Count);
        //    Assert.AreEqual("Violão", products[0].FullName);
        //    Assert.AreEqual("Roteador", products[1].FullName);
        //    Assert.AreEqual("Modem", products[2].FullName);
        //}
    }
}