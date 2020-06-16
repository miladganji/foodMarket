using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PipeLine.EvenSourcing
{
    public class eventSourcingPipeline<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public eventSourcingPipeline(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public  Task<Tresponse> Handle(Trequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            //await _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            //add event sourcing with is not susscess
            Domain.Events.Event @event = new Domain.Events.Event(DateTime.Now) {
                actionName = typeof(Trequest).Name,
                EntityName = "",
                Issucces = false,
                jsonRequest = JsonConvert.SerializeObject(request),
                jsonResponse=null,
                
            };

            var rer1 = applicationDbContext.Add(@event);
            var rerdata1 = applicationDbContext.SaveChanges();

            var response =  next();
            //await _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            var myevent = applicationDbContext.events.FirstOrDefault(a=>a.Id==@event.Id);
            myevent.jsonResponse = response.Result.ToString();
            myevent.Issucces =true;

            applicationDbContext.Entry<Domain.Events.Event>(myevent).State = EntityState.Modified;
             applicationDbContext.SaveChanges();
            return response;
        }
    }
}
