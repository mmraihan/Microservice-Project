using Catalog.Api.Interfaces.Manager;
using Catalog.Api.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    
    public class CatalogController : BaseController
    {
        private readonly IProductManager _productManager;
        public CatalogController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)] //Shows a template in swagger
        [ResponseCache(Duration = 20)]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productManager.GetAll();
                return CustomResult("Data loaded successfully", products);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)] //Shows a template in swagger
        [ResponseCache(Duration = 20)]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = _productManager.GetById(id);
                return CustomResult("Data loaded successfully", product);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)] //Shows a template in swagger
        [ResponseCache(Duration = 20)]
        public IActionResult GetByCategory(string category)
        {
            try
            {
                var products = _productManager.GetByCateory(category);
                return CustomResult("Data loaded successfully", products);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                product.Id = ObjectId.GenerateNewId().ToString();
                bool isSaved = _productManager.Add(product);
                if (isSaved)
                {
                    return CustomResult("Data created successfully", product, HttpStatusCode.Created);
                }
                return CustomResult("Couldn't save data", product, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return CustomResult("The requested resource couldn't be found", HttpStatusCode.NotFound);
                }
                bool isUpdated = _productManager.Update(product.Id, product);
                if (isUpdated)
                {
                    return CustomResult("Data updated successfully", product, HttpStatusCode.OK);
                }
                return CustomResult("Couldn't update data", product, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("The requested resource couldn't be found", HttpStatusCode.NotFound);
                }
                bool isDeleted = _productManager.Delete(id);
                if (isDeleted)
                {
                    return CustomResult("Data deleted successfully", HttpStatusCode.OK);
                }
                return CustomResult("Couldn't delete data.", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
