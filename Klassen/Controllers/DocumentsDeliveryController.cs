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
    public class DocumentsDeliveryController : ControllerBase
    {
        private readonly DocumentDeliveryManager _manager;

        public DocumentsDeliveryController(DocumentDeliveryManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<List<DocumentDelivery>> getAllAsync() => await _manager.getAll();

        [HttpGet("{id}")]
        public ActionResult<DocumentDelivery> getByIdAsync(int id)
        {
            var model = _manager.getById(id);
            if (model == null) return NotFound();

            return model;
        }

        [HttpPost]
        public async Task<ActionResult> postAsync([FromBody] DocumentDeliveryRequest request)
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
        public async Task<ActionResult> put(int id, [FromBody] DocumentDeliveryRequest request)
        {
            try
            {
                await _manager.put(id, request);
                return NoContent();

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}