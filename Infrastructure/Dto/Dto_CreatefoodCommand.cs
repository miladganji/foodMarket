using Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    public class Dto_CreatefoodCommand
    {
        public string FoodName { get; set; }
        public foodType FoodType { get; set; }
        public decimal Price { get; set; }
    }
}
