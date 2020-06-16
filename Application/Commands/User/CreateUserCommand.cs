using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
   public class CreateUserCommand:IRequest<Guid>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Mobile { get;  set; }


    }
}
