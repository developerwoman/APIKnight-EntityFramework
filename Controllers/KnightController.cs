using System.Threading.Tasks;
using APIKnight.Entities;
using APIKnight.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIKnight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnightController : ControllerBase
    {
        private readonly IKnightService _knightService;

        private readonly ILogger<KnightController> _logger;

        public KnightController(ILogger<KnightController> logger, IKnightService knightService)
        {
            _logger = logger;
            _knightService = knightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _knightService.GetAll().ConfigureAwait(false));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(int id)
        {
            var knight = await _knightService.GetById(id).ConfigureAwait(false);
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Knight knight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _knightService.Create(knight).ConfigureAwait(false);
            return Ok(knight.KnightId);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(int id, Knight knight)
        {
            var existKnight = await _knightService.GetById(id).ConfigureAwait(false);
            if (existKnight == null)
            {
                return NotFound();
            }
            await _knightService.Update(id, knight).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(int id, Knight knight)
        {
            var knightObj = await _knightService.GetById(id).ConfigureAwait(false);
            if (knightObj == null)
            {
                return NotFound();
            }
            _knightService.Delete(knight);
            return NoContent();
        }
    }
}
