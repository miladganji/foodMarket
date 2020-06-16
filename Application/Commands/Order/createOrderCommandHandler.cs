using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
  public  class createOrderCommandHandler:IRequest<Guid>
    {
        public int MyProperty { get; set; }
    }
}
