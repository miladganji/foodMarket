using Application.Commands.User;
using Application.ViewModel.Order;
using Domain.Order;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandler.Order
{
    public class createOrderCommandHandler : IRequestHandler<createOrderCommand, string>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public createOrderCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<string> Handle(createOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Order.Order(request.user, request.orderLines);
            order.SetOrderId();
            
            //order.calculateTax();
            //order.CalculatetotalAmount();
            //order.CalculateTotalPrice();
            order.CreateDateMethod();
            var orderCreateResult = await applicationDbContext.tblOrder.AddAsync(order);
            applicationDbContext.SaveChanges();
            //foreach (var item in request.orderLines)
            //{
            //    OrderLine orderLine = new OrderLine(1);
            //    orderLine.Setqty(item.Qty);
            //    orderLine.Setfood(item.Food);

            //    order.AddOrderLine(orderLine);
            //}
            foreach (var item in request.orderLines)
            {
                OrderLine orderLine2 = new OrderLine(1);
                orderLine2.Setfood(item.Food);
                orderLine2.Setqty(item.Qty);
                orderLine2.SetOrderId(order.Id);
                var orderlineId =  applicationDbContext.tblOrderLine.Add(orderLine2);
                var orderlineCreateresult =  applicationDbContext.SaveChanges();
                order.AddOrderLine(orderLine2);
                applicationDbContext.Entry<Domain.Order.Order>(order).State = EntityState.Modified;
                await applicationDbContext.SaveChangesAsync();
            }
           


            order.CalculateTotalPrice();
            order.calculateTax();
            order.CalculatetotalAmount();
            applicationDbContext.Entry<Domain.Order.Order>(order).State = EntityState.Modified;
            await applicationDbContext.SaveChangesAsync();
            CreateOrderCommandResponse createOrderCommandResponse = new CreateOrderCommandResponse()
            {

                Date = order.CreateDate.ToString(),
                orderLine = order.OrderLine,
                state = OrderState.New,
                Tax = order.Tax,
                TotalAmount = order.totalAmount,
                TotalPrice = order.TotalPrice,
                UserName = order.User.Mobile

            };

            var res = JsonConvert.SerializeObject(createOrderCommandResponse);
            return res;
        }
    }
}
