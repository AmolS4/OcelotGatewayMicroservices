using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductAPIController : ControllerBase
    {

        ProductsDb products;
        public ProductAPIController()
        {
            products = new ProductsDb();
        }
        
        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product prd)
        {
            products.Add(prd);
            return Ok(products);
        }


    }
}
