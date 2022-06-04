using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamAPIMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessoryController : Controller
    {
        private readonly VendorServices _vendorServices;

        public AccessoryController(VendorServices vendorServices) =>
            _vendorServices = vendorServices;

        [HttpGet("{id}")]

        public async Task<ActionResult<Vendor>> Get(string id)
        {
            var vendor = await _vendorServices.GetAsync(id);
            
            if (vendor is null)
            {
                return NotFound();
            }

            return vendor;
        }


        
    }
   
   
};
