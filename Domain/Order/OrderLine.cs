using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
    public class OrderLine : Baseentity<Guid>
    {
        private OrderLine()
        {
        }

        public OrderLine(int i)
        {
        }

        public Food.Food Food { get;  set; }
        public int Qty { get; private set; }
        public Guid OrderId { get;  set; }

        public void SetOrderId(Guid OrderId)
        {
            this.OrderId = OrderId;
        }

        public void Setfood(Food.Food food)
        {
            this.Food = food;
        }

        public void Setqty(int qty)
        {
            this.Qty = qty;
        }

    }
}
