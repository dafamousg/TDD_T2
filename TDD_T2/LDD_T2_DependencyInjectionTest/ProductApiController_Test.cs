using System;
using Xunit;
using TDD_T2.Models;
using TDD_T2.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LDD_T2_DependencyInjectionTest
{
    public class ProductApiController_Test
    {
        private Mock<IApiRequest<Product>> mockRequest;
        private ProductApiController productController;
        private Product product;

        public Mock MockRequest()
        {
            return mockRequest = new Mock<IApiRequest<Product>>();
        }

        public ProductApiController CreateProductController()
        {
            return productController = new ProductApiController(mockRequest.Object);
        }

        public Product CreateProduct()
        {
            string name = "Audi A5";
            int price = 500000;
            int weight = 2000;
            int quantity = 30;

            return product = new Product(name, price, weight, quantity);
        }

        #region GetAllProducts_Test
        [Fact]
        public void GetAllProduct_Once()
        {
            MockRequest();
            CreateProductController();

            productController.GetAllProducts();

            mockRequest.Verify(m => m.GetAllData(), Times.Once());
        }
        #endregion

        #region AddProduct_Test
        [Fact]
        public void AddProduct_ShouldAddNewProduct()
        {
            MockRequest();
            CreateProductController();
            
            CreateProduct();

            productController.AddProduct(product);

            mockRequest.Verify(m => m.AddEntity(product), Times.Once());
        }
        #endregion

        #region ModifyProduct_Test
        [Fact]
        public void ModifyProduct_ShouldModify_And_UpdateProduct()
        {
            MockRequest();
            CreateProductController();
            CreateProduct();

            productController.ModifyProduct(product.Id, product);
            mockRequest.Verify(m => m.ModifyEntity(product.Id, It.Is<Product>(p => p.Id == product.Id)), Times.Once());

        }
        #endregion

        #region DeleteProduct_Test
        [Fact]
        public void DeleteProduct_ShouldDeleteProduct()
        {
            MockRequest();
            CreateProductController();
            CreateProduct();

            productController.DeleteProduct(product);

            mockRequest.Verify(m => m.DeleteEntity(product), Times.Once());
        }
        #endregion

    }
}
