using Microsoft.EntityFrameworkCore;
using book_store.Data;
using book_store.Repository;
using book_store.ViewModels;
using Xunit;
using System;
using System.Diagnostics;
using Moq;
using ProductModel;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Builder;
using Xunit.Abstractions;


namespace book_store.Tests
{

        public class ProductRepositoryTests
    {
        private readonly ITestOutputHelper output;

        public ProductRepositoryTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestCreateProduct()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            using (var realContext = new ApplicationDbContext(options))
            {
                var productRepository = new ProductRepository(realContext);

                var productDto = new ProductDto
                {
                    Id = 1,
                    Image = "image.jpg",
                    Title = "Test Book",
                    Author = "Test Author",
                    Category = "Test Category",
                    Description = "Test Description",
                    Price = 9.99
                };

                // Act
                var createdProduct = productRepository.CreateProduct(productDto);
                output.WriteLine("Product created: " + "\n" + createdProduct.Image + "\n" + createdProduct.Title + "\n"  + createdProduct.Author + "\n" + createdProduct.Description + "\n" + createdProduct.Price + "\n" + createdProduct.Category + "\n" + createdProduct.Id);
               
                // Assert
                Assert.NotNull(createdProduct);
                Assert.Equal(productDto.Id, createdProduct.Id);
                Assert.Equal(productDto.Image, createdProduct.Image);
                Assert.Equal(productDto.Title, createdProduct.Title);
                Assert.Equal(productDto.Author, createdProduct.Author);
                Assert.Equal(productDto.Category, createdProduct.Category);
                Assert.Equal(productDto.Description, createdProduct.Description);
                Assert.Equal(productDto.Price, createdProduct.Price);
            }

        }
        [Fact]
        public void TestDeleteProduct()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            using (var realContext = new ApplicationDbContext(options))
            {
                var productRepository = new ProductRepository(realContext);


                var product = new Product
                {
                    Id = 1,
                    Image = "image.jpg",
                    Title = "Test Book",
                    Author = "Test Author",
                    Category = "Test Category",
                    Description = "Test Description",
                    Price = 9.99
                };

                var deletedProduct = productRepository.DeleteProduct(product.Id);
                output.WriteLine("Product deleted: " + "\n" + deletedProduct.Image + "\n" + deletedProduct.Title + "\n" + deletedProduct.Author + "\n" + deletedProduct.Category + "\n" + deletedProduct.Description + "\n" + deletedProduct.Price + "\n" + deletedProduct.Id);

                Assert.NotNull(deletedProduct);
                Assert.Equal(product.Id, deletedProduct.Id);
        }
        }
    }
}