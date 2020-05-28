using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Managers;
using Core.Models;
using Core.Requests;
using Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klassen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTeachersController : ControllerBase
    {
        private readonly UserTeacherManager _manager;

        public AccountTeachersController(UserTeacherManager manager)
        {
            this._manager = manager;
        }

        [HttpPost("Login")]
        public async Task<TokenModel> Login([FromBody] AccountRequest request)
        {
            var script = new scriptPass();
            var buildToken = new BuildToken();
            request.Password = script.script(request.Password);

            var model = await _manager.getByEmail(request.Email);
            if (model == null) BadRequest("Invalid User");

            if (model.Email != request.Email || model.Password != request.Password) BadRequest("Invalid Password");

            return buildToken.UserToken(model.Email);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UsersRequest request)
        {
            try
            {
                await _manager.post(request);
                return Ok();

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }
    }
}