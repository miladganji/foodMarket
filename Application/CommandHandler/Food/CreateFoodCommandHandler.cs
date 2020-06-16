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
            try
            {
                Domain.Food.Food food = new Domain.Food.Food(request.FoodName, request.FoodType, request.Price);
              await  applicationDbContext.tblFood.AddAsync(food);
                await applicationDbContext.SaveChangesAsync();

                return food.Id;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message) ;
            }
        }
    }
}
