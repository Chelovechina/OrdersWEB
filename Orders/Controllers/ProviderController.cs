using Microsoft.AspNetCore.Mvc;
using Orders.BLL.Interfaces;
using Orders.Domain.DTO;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderDto>>> Get()
        {
            try
            {
                return Ok(await _providerService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDto>> Get(int id)
        {
            try
            {
                return Ok(await _providerService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDto>> GetOne(int id)
        {
            try
            {
                return Ok(await _providerService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProviderDto>> Post([FromBody] ProviderDto value)
        {
            try
            {
                return Ok(await _providerService.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProviderDto>> Put(int id, [FromBody] ProviderDto value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _providerService.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProviderDto>> Delete(int id)
        {
            try
            {
                return Ok(await _providerService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
