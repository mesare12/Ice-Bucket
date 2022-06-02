using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamAPIMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToppingController : Controller
    {
        private readonly VendorServices _vendorServices;

        public ToppingController(VendorServices vendorServices) =>
            _vendorServices = vendorServices;

        [HttpGet]
        public async Task<List<Vendor>> Get() =>           
            await _vendorServices.GetAsync();

        [HttpGet("{toppings}")]
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


