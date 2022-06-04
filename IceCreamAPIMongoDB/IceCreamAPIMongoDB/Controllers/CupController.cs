using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamAPIMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupController : Controller
    {
        private readonly VendorServices _vendorServices;
        public CupController(VendorServices vendorServices) =>
         _vendorServices = vendorServices;

        [HttpGet]
        public async Task<List<Vendor>> Get() =>
            await _vendorServices.GetAsync();

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
}