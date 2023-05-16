using Microsoft.AspNetCore.Mvc;
using Orders.BLL.Interfaces;
using Orders.Domain.DTO;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
        {
            try
            {
                return Ok(await _itemService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            try
            {
                return Ok(await _itemService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetOne(int id)
        {
            try
            {
                return Ok(await _itemService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Post([FromBody] ItemDto value)
        {
            try
            {
                return Ok(await _itemService.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> Put(int id, [FromBody] ItemDto value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _itemService.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDto>> Delete(int id)
        {
            try
            {
                return Ok(await _itemService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
