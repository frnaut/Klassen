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
    public class RolesController : ControllerBase
    {
        private readonly RoleManager _manager;

        public RolesController(RoleManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<List<Role>> getAllAsync() => await _manager.getAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> getByIdAsync(int id)
        {
            var model = await _manager.getById(id);
            if (model == null) return NotFound();

            return model;
        }

        [HttpPost]
        public async Task<ActionResult> postAsync([FromBody] RoleRequest request)
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
        public async Task<ActionResult> put(int id,[FromBody] RoleRequest request)
        {
            try
            {
                await _manager.Put(id, request);
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
            var model = await _manager.delete(id);
            if (model == null) return NotFound();

            return Ok(model);
        }
    }
}