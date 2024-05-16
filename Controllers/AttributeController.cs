using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIKnight.Entities;
using APIKnight.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIKnight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttributeController : Controller
    {
        private readonly IAttributeService _service;

        public AttributeController(IAttributeService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll().ConfigureAwait(false));
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> Get(int id)
        {        
            var attr = await _service.GetById(id);
            if (attr == null)
            {
                return NotFound();
            }
            return Ok(attr);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Entities.Attribute attr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.Create(attr).ConfigureAwait(false);
             _service.SaveChanges();
            return Ok(attr.AttributeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Entities.Attribute attr)
        {
            var existAttr = await _service.GetById(id).ConfigureAwait(false);
            if (existAttr == null)
            {
                return NotFound();
            }
            await _service.Update(id, attr).ConfigureAwait(false);
            _service.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var existAttr = await _service.GetById(id).ConfigureAwait(false);
            if (existAttr == null)
            {
                return NotFound();
            }
            _service.Delete(existAttr);
            _service.SaveChanges();
            return NoContent();
        }

    }
}
