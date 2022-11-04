namespace VirtualStoreXunitTest
{
    public class UnitTest1 : IClassFixture<TestDatabaseFixture>
    {
        public UnitTest1(TestDatabaseFixture fixture)
        => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }
        [Fact]
        public void Test1()
        {
            using var context = Fixture.CreateContext();
            var tt = context.ProductModel.ToList();
            Console.Write("Vamos com�er com o p� direeito");
            Assert.Equal(2, tt.Count);
        }
    }
}