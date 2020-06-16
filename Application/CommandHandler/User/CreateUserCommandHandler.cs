using Application.Commands.User;
using Application.Notifications.User;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandler.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ApplicationDbContext db;
        private readonly IMediator mediator;

        public CreateUserCommandHandler(ApplicationDbContext db,IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.User.Users user = new Domain.User.Users(request.FirsName, request.LastName, request.Password, request.Mobile);
                var result =  db.Add(user);
                var s =  db.SaveChanges();

                await mediator.Publish(new CreateUserSendEmailNotification() { UserId = user.Id });

                return user.Id;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message) ;
            }
        }
    }
}
