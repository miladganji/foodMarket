using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
  public  class Order:Baseentity<Guid>
    {
        private Order()
        { 
           }
        public Order(User.Users user,List<OrderLine> orderLines)
        {
            this.User = user;
            //CalculateTotalPrice();
            //calculateTax();
            //CalculatetotalAmount();
        }
        public Guid  OrderNumber { get;private set; }
        public OrderState OrderState { get; private set; }
        public DateTime CreateDate { get; private set; }
        public double TotalPrice { get; private set; }
        public double totalAmount { get; private set; }
        public double Tax { get; private set; }
        public List<OrderLine> OrderLine { get; private set; }
        public User.Users User { get; private set; }

        public void SetOrderId()
        {
            OrderNumber = Guid.NewGuid();
        }
        public void CreateDateMethod()
        {
            CreateDate = DateTime.Now;
        }
        public void CancelOrder()
        {

            if (this.OrderState!=OrderState.New)
            {

                throw new Exception("Can Not to Cancel Order");
            }
            this.OrderState = OrderState.cancel;
           }
        public void AddOrderLine(OrderLine orderLine)
        {
            if (!orderLine.Food.IsExist)
            {
                throw new Exception("food is not found Or Food is Over");
            }
            orderLine.SetOrderId(this.Id);
            this.OrderLine.Add(orderLine);

        }
        public void CalculateTotalPrice()
        {
            double Sum = 0;
            foreach (var item in OrderLine)
            {
                Sum += Convert.ToDouble(item.Food.price.val * item.Qty);
            }
            TotalPrice = Sum;
           }
        public void calculateTax()
        {
            if (TotalPrice==0)
            {
                Tax = 0;
            }

            else {

                Tax = TotalPrice * 0.09;
               }
        }

        public void CalculatetotalAmount()
        {
            totalAmount = TotalPrice + Tax;
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            OrderLine.Remove(orderLine);
        }
    }

    

    public enum OrderState
    {
        New,
        Paied,
        cancel
    }
}
