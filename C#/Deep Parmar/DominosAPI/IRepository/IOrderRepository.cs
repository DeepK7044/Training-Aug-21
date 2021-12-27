using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        void AddOrder(OrderDTO order);
        List<Vorder> GetOrder(int UserId);
        List<OrderDetailsDTO> GetOrderDetails(int OrderId);
    }
}
