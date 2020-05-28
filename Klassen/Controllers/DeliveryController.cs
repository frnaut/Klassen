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
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryManager _manager;
       

        public DeliveryController(DeliveryManager manager)
        {
            this._manager = manager;
           
        }

        [HttpGet]
        public async Task<List<Delivery>> getAllAsync() => await _manager.getAllAsync();

        [HttpGet("{id}")]
        public ActionResult<Delivery> getByIdAsync(int id)
        {
            try
            {
                var model = _manager.getById(id);
                if (model == null) return NotFound();

                return model;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> postAsync([FromBody] DeliveryRequest request)
        {
            try
            {
                var model = await _manager.postAsync(request);
                return Ok(model);

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] DeliveryRequest request)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                var model = await _manager.delete(id);
                return Ok(model);

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}