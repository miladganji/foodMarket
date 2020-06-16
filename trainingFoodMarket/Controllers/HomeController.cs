using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Foods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace trainingFoodMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("Createfood")]
        [Authorize]
        public async Task< IActionResult> Createfood( [FromBody]CreatefoodCommand input)
        {
            var result =await mediator.Send(input);
            return Ok(result);
        }
    }
}