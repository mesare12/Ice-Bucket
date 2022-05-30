using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class IceCreamController : ControllerBase
    {
        private readonly IceCreamServices _iceCreamServices;

        public IceCreamController(IceCreamServices iceCreamServices) =>
            _iceCreamServices = iceCreamServices;

        [HttpGet]
        public async Task<List<IceCream>> Get() =>
            await _iceCreamServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<IceCream>> Get(string id)
        {
            var icecream = await _iceCreamServices.GetAsync(id);

            if (icecream is null)
            {
                return NotFound();
            }

            return icecream;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IceCream newIceCream)
        {
            await _iceCreamServices.CreateAsync(newIceCream);

            return CreatedAtAction(nameof(Get), new { id = newIceCream.Id }, newIceCream);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, IceCream updatedIceCream)
        {
            var icecream = await _iceCreamServices.GetAsync(id);

            if (icecream is null)
            {
                return NotFound();
            }

            updatedIceCream.Id = icecream.Id;

            await _iceCreamServices.UpdateAsync(id, updatedIceCream);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var icecream = await _iceCreamServices.GetAsync(id);

            if (icecream is null)
            {
                return NotFound();
            }

            await _iceCreamServices.DeleteAsync(id);

            return NoContent();
        }


    }
}
