using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Foods;
using Application.Commands.User;
using Application.Dto.order;
using Application.Services.User;
using Domain.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace trainingFoodMarket.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUserRepository userRepository;

        public HomeController(IMediator mediator,IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.userRepository = userRepository;
        }


        [HttpPost]
        //[Authorize]
        public async Task< IActionResult> Createfood( [FromBody]CreatefoodCommand input)
        {
            var result =await mediator.Send(input);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateOrder([FromBody] List<CreateOrderDto> input)
        {
            var MyUserclaims = User.Claims.ToList();
            createOrderCommand createOrderCommand = new createOrderCommand()
            {
               
                user = userRepository.GetUserByName(User.Identity.Name),

            };

            List<OrderLine> lstorder = new List<OrderLine>();
            foreach (var item in input)
            {

                Domain.Order.OrderLine orderLine = new Domain.Order.OrderLine(1);
                orderLine.Setfood(item.Food);
                orderLine.Setqty(item.Qty);

                lstorder.Add(orderLine);


            }
            createOrderCommand.orderLines = lstorder;


            var result = await mediator.Send(createOrderCommand);
            return Ok(result);
        }
    }
}