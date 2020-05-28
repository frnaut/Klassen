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
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomManager _manager;
        private readonly UserTeacherManager _teacher;

        public ClassroomController(ClassroomManager manager, UserTeacherManager teacher)
        {
            this._manager = manager;
            this._teacher = teacher;
        }

        [HttpGet]
        public async Task<List<Classroom>> getAllAsync() => await _manager.getAllAsync();

        [HttpGet("{id}")]
        public ActionResult<Classroom> getById(int id)
        {
            try
            {
                var model =  _manager.getByIdAsync(id);
                if (model == null) return NotFound();

                return model;

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Classroom>> post([FromBody]  ClasroomRequest request)
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
        public async Task<ActionResult> put(int id, [FromBody] ClasroomRequest request)
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
        public async Task<ActionResult<Classroom>> delete(int id)
        {
            try
            {
                return await _manager.delete(id);
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return NotFound();
            }
        }
    }
}