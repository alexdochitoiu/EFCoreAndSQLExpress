using Business;
using Data.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class CategoryRepositoryTest : BaseIntegrationTest
    {

        [TestMethod]
        public void Given_CategoryRepository_When_AddingACategory_Then_TheCategoryShouldBeProperlySaved()
        {
            RunOnDatabase(ctx => {
                //Arrange
                var repository = new CategoryRepository(ctx);
                var category = Category.Create("Category title", "Distributor name");

                //Act
                repository.Add(category);

                //Assert
                var categories = repository.GetAll();
                Assert.AreEqual(1, categories.Count);
            });
        }
    }
}
