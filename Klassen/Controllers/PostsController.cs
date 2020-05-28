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
    public class PostsController : ControllerBase
    {
        private readonly PostManager _manager;

        public PostsController(PostManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<List<Post>> getAllAsync() => await _manager.getAllAsync();

        [HttpGet("{id}")]
        public ActionResult<Post> getById(int id)
        {
            var model = _manager.getByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> postAsync(PostRequest request)
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
        public async Task<ActionResult> put(int id, PostRequest request)
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
        public async Task<ActionResult> deleteAsyc(int id)
        {
            var model = await _manager.delete(id);
            if (model == null) return NotFound();

            return Ok(model);
        }
    }
}