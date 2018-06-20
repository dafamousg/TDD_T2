using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDD_T2.Models;

namespace TDD_T2.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductApi")]
    public class ProductApiController : Controller
    {
        private readonly IApiRequest<Product> productRequest;

        public ProductApiController(IApiRequest<Product> request)
        {
            productRequest = request;
        }

        [HttpGet]
        public virtual IEnumerable<Product> GetAllProducts()
        {
            return productRequest.GetAllData();
        }

        [HttpPost]
        public virtual void AddProduct(Product product)
        {
            productRequest.AddEntity(product);
        }

        [HttpPost]
        public virtual void ModifyProduct(int id, Product product)
        {
            productRequest.ModifyEntity(id, product);
        }

        [HttpDelete]
        public virtual void DeleteProduct(Product product)
        {
            productRequest.DeleteEntity(product);
        }
    }
}