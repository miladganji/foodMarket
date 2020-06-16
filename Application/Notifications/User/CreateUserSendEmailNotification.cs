using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Notifications.User
{
  public  class CreateUserSendEmailNotification:INotification
    {
        public Guid UserId { get; set; }
    }
}
