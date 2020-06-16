using Domain.Food;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Foods
{
    public class CreatefoodCommand:IRequest<Guid>
    {
        public string  FoodName { get; set; }
        public foodType FoodType{ get; set; }
        public decimal Price { get; set; }

    }
}
