using Application.Commands.Foods;
using AutoMapper;
using Domain.Food;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandler.Food
{
    public class CreateFoodCommandHandler : IRequestHandler<CreatefoodCommand, Guid>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CreateFoodCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Guid> Handle(CreatefoodCommand request, CancellationToken cancellationToken)
        {
            Domain.Food.Food food = new Domain.Food.Food("testganji", foodType.Irani, 1000);
            await applicationDbContext.AddAsync(food);
            await applicationDbContext.SaveChangesAsync();
               
              return  Guid.NewGuid() ;
        }
    }
}
