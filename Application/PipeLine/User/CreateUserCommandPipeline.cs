using Application.Commands.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PipeLine.User
{
    public class CreateUserCommandPipeline<Trequest, Tresponse> : IPipelineBehavior<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<Guid> next)
        {
            //await _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            //await _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }
}
