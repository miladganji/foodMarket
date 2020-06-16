using Application.Queries.food;
using Domain.Food;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandler.food
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, List<Food>>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GetFoodQueryHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<List<Food>> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var list =await applicationDbContext.tblFood.ToListAsync();
            return  list;
        }
    }
}
