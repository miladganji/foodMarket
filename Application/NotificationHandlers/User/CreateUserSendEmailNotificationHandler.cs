using Application.Notifications.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.User
{
    public class CreateUserSendEmailNotificationHandler : INotificationHandler<CreateUserSendEmailNotification>
    {
        public  Task Handle(CreateUserSendEmailNotification notification, CancellationToken cancellationToken)
        {
            //SendEmail to user for sign up to Application
             return  Task.CompletedTask;
        }
    }
}
