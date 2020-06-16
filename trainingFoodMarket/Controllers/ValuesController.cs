using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dto.User;
using Application.Services.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trainingFoodMarket.securityTokenCreator;

namespace trainingFoodMarket.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUserRepository userRepository;

        public ValuesController(IMediator mediator,IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.userRepository = userRepository;
        }
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand input)
        {
            try
            {

                var Data = await mediator.Send(input);

                return Ok(Data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public IActionResult CreateToken([FromBody]LoginData input)
        {

            try
            {
                var Token = new CreateToken("LongerThan-16Char-SecretKey", "16CharEncryptKey",userRepository).Execute(input.Mobile,input.Password);



                return Ok(Token);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }



    }
}
