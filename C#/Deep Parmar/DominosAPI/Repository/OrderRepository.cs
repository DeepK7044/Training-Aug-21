using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(DominosDatabaseContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddOrder(OrderDTO order)
        {
            try
            {
                var json = JsonConvert.SerializeObject(order);
                var param = new SqlParameter("@Order",json);
                _context.Database.ExecuteSqlRaw($"Execute sp_OrderPizza @Order",param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Vorder> GetOrder(int UserId)
        {
            try
            {
                var order=_context.Vorders.Where(order=>order.UserId==UserId).ToList();
                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<OrderDetailsDTO> GetOrderDetails(int OrderId)
        {
            try
            {
                var orderDetails = _context.VpizzaOrderToppings.Where(order => order.OrderId == OrderId)
                                    .Select(order => new OrderDetailsDTO()
                                    { 
                                        OrderId=order.OrderId,
                                        PizzaId=order.PizzaId,
                                        PizzaName = order.PizzaName,
                                        Description=order.Description,
                                        PizzaTypeId=order.PizzaTypeId,
                                        Rating=order.Rating,
                                        ToppingId=order.ToppingId,
                                        ToppingName=order.ToppingName,
                                        ToppingCost=order.ToppingCost,
                                        UnitPrice=order.UnitPrice,
                                        Quantity=_context.OrderDetails.SingleOrDefault(quantity=>quantity.OrderId==OrderId && quantity.PizzaId==order.PizzaId).Quantity
                                    }).ToList();
                return orderDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(Order entity)
        {
            try
            {
                entity.OrderStatus = false;
                Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
