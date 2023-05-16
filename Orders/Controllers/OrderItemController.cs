using Microsoft.AspNetCore.Mvc;
using Orders.BLL.Interfaces;
using Orders.Domain.DTO;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> Get()
        {
            try
            {
                return Ok(await _orderItemService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> Get(int id)
        {
            try
            {
                return Ok(await _orderItemService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOne(int id)
        {
            try
            {
                return Ok(await _orderItemService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> Post([FromBody] OrderItemDto value)
        {
            try
            {
                return Ok(await _orderItemService.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItemDto>> Put(int id, [FromBody] OrderItemDto value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _orderItemService.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItemDto>> Delete(int id)
        {
            try
            {
                return Ok(await _orderItemService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
