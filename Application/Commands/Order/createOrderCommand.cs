using Application.ViewModel.Order;
using Domain.Food;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
  public  class createOrderCommand:IRequest<string>
    {
        public Domain.User.Users user { get; set; }
        public List<Domain.Order.OrderLine>  orderLines{ get; set; }


    }
}
