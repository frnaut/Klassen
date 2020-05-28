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
    public class AccountStudentsController : ControllerBase
    {
        private readonly UserStudentManager _manager;
        public AccountStudentsController(UserStudentManager manager)
        {
            this._manager = manager;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<TokenModel>> Login([FromBody] AccountRequest request)
        {
            try
            {
                var script = new scriptPass();
                var buildToken = new BuildToken();

                request.Password = script.script(request.Password);

                var model = await _manager.getByEmail(request.Email);
                if (model == null) BadRequest("Invalid  User");

                if(request.Email != model.Email || request.Password != model.Password)
                {
                    return BadRequest("Invalid Password");
                }

                return buildToken.UserToken(model.Email);

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UsersRequest request)
        {

            try
            {
                await _manager.postAsync(request);
                return Ok(); 

            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }

        }
    }
}