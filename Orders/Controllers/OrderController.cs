using Microsoft.AspNetCore.Mvc;
using Orders.BLL.Interfaces;
using Orders.Domain.DTO;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            try
            {
                return Ok(await _orderService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            try
            {
                return Ok(await _orderService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto value)
        {
            try
            {
                return Ok(await _orderService.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _orderService.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDto>> Delete(int id)
        {
            try
            {
                return Ok(await _orderService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
