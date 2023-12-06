﻿using Catalog.Api.Interfaces.Manager;
using Catalog.Api.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetProducts()
        {
            var products = _productManager.GetAll();
            return CustomResult("Data loaded",products);
        }
    }
}
