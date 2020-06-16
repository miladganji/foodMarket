using Domain.Food;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.food
{
  public  class GetFoodQuery:IRequest<List<Food>>
    {
    }
}
