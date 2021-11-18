using Day14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{
    public interface IOrderRepository
    {
        Orders AddOrder(int CustomerId, int TotalAmount);

        Toys GetToy(int Id);

        //void AddOrderItem(OrderItems orderData);
    }
}
