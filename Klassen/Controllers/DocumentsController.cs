using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Managers;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klassen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentManager _manager;

        public DocumentsController(DocumentManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<List<Document>> getAllAsync() => await _manager.getAllAsync();

        [HttpGet("{id}")]
        public ActionResult<Document> getByIdAsync(int id)
        {
            try
            {
                var model = _manager.getByIdAsync(id);
                if (model == null) return NotFound();

                return model;

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] DocumentRequest request)
        {
            try
            {

                var model = await _manager.post(request);
                return Ok(model);

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] DocumentRequest request)
        {
            try
            {
                await _manager.put(id, request);
                return NoContent();

            }catch(Exception ex)
            {
                ex.Message.ToLower();
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            var model = await _manager.delete(id);
            if (model == null) return NotFound();

            return Ok(model);
        }
    }
}