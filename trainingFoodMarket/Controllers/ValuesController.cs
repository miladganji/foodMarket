using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace trainingFoodMarket.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet()]
        [Authorize(Roles ="Admin")]
        public ActionResult<string> Get(int id)
        {
            var users = User.Claims.ToList();
            var Data = mediator.Send(new CreateUserCommand()
            {
                FirsName = "milad",
                LastName = "ganji",
                Mobile = "09305273238",
                Password = "123"

            });

            return "value";
        
        }

        [HttpPost]

        public IActionResult CreateToken()
        {
            //string SecurityKey = "MySecurityKeForMarketingJWTGanji";
            //string EncryptKey = "MySecurityKeForMarketingJWTGanjiEncrypt";

            //var SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            //var SigninCredential = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            //var encriptCredential = new EncryptingCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EncryptKey)), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            //var Myclaim = new List<Claim>();
            //Myclaim.Add(new Claim(ClaimTypes.Name, "milad ganji"));
            //Myclaim.Add(new Claim(ClaimTypes.Role, "Admin"));
            //Myclaim.Add(new Claim("ID", "100"));
            //var descriptor = new SecurityTokenDescriptor {
            //   Issuer= "milad ganji",
            //   Audience= "readers",
            //   EncryptingCredentials=encriptCredential,
            //   Expires=DateTime.Now.AddHours(1),
            //   IssuedAt=DateTime.Now,
            //   SigningCredentials=SigninCredential,
            //   Subject=new ClaimsIdentity(Myclaim),



            //};

            //var mysecurityToken = new JwtSecurityTokenHandler().CreateToken(descriptor);
            //var Securitytoken = new JwtSecurityTokenHandler().WriteToken(mysecurityToken);
            var secretKey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey"); // must be 16 character or longer
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey"); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, "milad"), //user.UserName
                   new Claim(ClaimTypes.NameIdentifier, "123"), //user.Id
                   new Claim(ClaimTypes.Role,"Admin")
                };

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "milad ganji",
                Audience = "readers",
                EncryptingCredentials = encryptingCredentials,
                Expires = DateTime.Now.AddHours(1),
                IssuedAt = DateTime.Now,
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims),

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            string encryptedJwt = tokenHandler.WriteToken(securityToken);
            return Ok(encryptedJwt);

        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
