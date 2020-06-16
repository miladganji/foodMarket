using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.User
{
   public interface IUserRepository
    {
       bool GetUser(string Mobile,string Password);
        Domain.User.Users GetUserByName(string Mobile);

    }
}
