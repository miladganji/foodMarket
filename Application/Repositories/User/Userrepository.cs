using Application.Services.User;
using Domain.User;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Repositories.User
{
    public class Userrepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public Userrepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public bool GetUser(string Mobile, string Password)
        {
            if (applicationDbContext.tblUser.FirstOrDefault(a => a.Mobile == Mobile && a.Password == Password) != null)
            {
                return true;
            }

            else {
                return false;
            }
        }

        public Domain.User.Users GetUserByName(string Mobile)
        {
            return applicationDbContext.tblUser.FirstOrDefault(a => a.Mobile == Mobile);
        }
    }
}
