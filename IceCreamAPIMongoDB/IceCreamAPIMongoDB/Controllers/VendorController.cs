using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly VendorServices _vendorServices;

        public VendorController(VendorServices vendorServices) =>
            _vendorServices = vendorServices;

        [HttpGet]
        public async Task<List<Vendor>> Get() =>           
            await _vendorServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Vendor>> Get(string id)
        {
            var vendor = await _vendorServices.GetAsync(id);

            if (vendor is null)
            {
                return NotFound();
            }

            return vendor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vendor newVendor)
        {
            await _vendorServices.CreateAsync(newVendor);

            return CreatedAtAction(nameof(Get), new { id = newVendor.Id }, newVendor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Vendor updatedVendor)
        {
            var vendor = await _vendorServices.GetAsync(id);

            if (vendor is null)
            {
                return NotFound();
            }

            updatedVendor.Id = vendor.Id;

            await _vendorServices.UpdateAsync(id, updatedVendor);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var vendor = await _vendorServices.GetAsync(id);

            if (vendor is null)
            {
                return NotFound();
            }

            await _vendorServices.DeleteAsync(id);

            return NoContent();
        }


    }
}
