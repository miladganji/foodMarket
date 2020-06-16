using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
  public  class OrderLine:Baseentity<Guid>
    {
        private OrderLine()
        {
        }

       
        public Food.Food Food { get;private set; }
        public int  Qty { get; private set; }
        public Guid OrderId { get; private set; }

        public void SetOrderId(Guid OrderId)
        {
            this.OrderId = OrderId;
        }
    }
}
