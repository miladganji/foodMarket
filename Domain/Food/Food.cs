using Domain.Values.Price;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Food
{
    public class Food : Baseentity<Guid>
    {
        private Food()
        {

        }
        public Food(string _FoodName, foodType _foodType, decimal _price)
        {
            this.FoodName = _FoodName;
            this.foodType = _foodType;
            this.price = new Price().SetPrice(_price);
            this.IsExist = true;
            this.state = foodstate.active;
        }
        public string FoodName { get; private set; }
        public foodType foodType { get; private set; }
        public Price price { get; private set; }
        public bool IsExist { get; private set; }
        public foodstate state { get; private set; }



        public void ChangePrice(decimal Price)
        {
            if (this.state == foodstate.inactive)
            {
                throw new Exception("Food is not Active");
            }

            this.price = new Price().SetPrice(Price);
        }

        public void foodIsOver()
        {
            if (this.state == foodstate.inactive)
            {
                throw new Exception("Food is not Active");
            }
            this.IsExist = false;
        }

        public void Inactivefood()
        {
            if (this.state == foodstate.inactive)
            {
                throw new Exception("Food is not Active");
            }
            this.state = foodstate.inactive;
        }

        public void activefood()
        {
            if (this.state == foodstate.inactive)
            {
                throw new Exception("Food is not Active");
            }
            this.state = foodstate.inactive;
        }

    }



    public enum foodType
    {
        Drink,
        Irani,
        Cold,

    }

    public enum foodstate
    {
        active,
        inactive,


    }
}
