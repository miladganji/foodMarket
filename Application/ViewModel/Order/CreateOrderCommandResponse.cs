using Domain.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Order
{
   public class CreateOrderCommandResponse
    {
        public OrderState  state{ get; set; }
        public string  Date { get; set; }
        public string  UserName { get; set; }
        public double TotalPrice { get; set; }
        public double TotalAmount { get; set; }
        public double Tax { get; set; }
        public List<OrderLine> orderLine { get; set; }

    }
}
