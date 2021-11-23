using Day14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private ToyManufacturingCompanyContext _context;
        public OrderRepository(ToyManufacturingCompanyContext ToyContext)
        {
            _context = ToyContext;
        }
        public Orders AddOrder(int CustomerId,int TotalAmount)
        {
            _context.Database.ExecuteSqlRaw($"sp_order {CustomerId},{TotalAmount}");
            return _context.Orders.OrderBy(order=>order.OrdersId).LastOrDefault();
            
        }

        //public void AddOrderItem(OrderItems orderData)
        //{
        //    orderData.OrderId= _context.Orders.Count() + 1;            
        //    _context.OrderItems.Add(orderData);
        //}

        public Toys GetToy(int Id)
        {
            var Toy=_context.Toys.SingleOrDefault(Toys => Toys.ToysId == Id);
            return Toy;
        }
    }
}
