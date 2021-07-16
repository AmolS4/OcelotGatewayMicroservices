using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorService.Models;

namespace VendorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorAPIController : ControllerBase
    {
        VendorsDb vendors;

        public VendorAPIController()
        {
            vendors = new VendorsDb();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(vendors);
        }
    }
}
