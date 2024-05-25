using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.DOMAIN.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrdersService(IOrdersRepository ordersRepository, IOrderDetailRepository orderDetailRepository)
        {
            _ordersRepository = ordersRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrdersUserDTO?> GetById(int id)
        {
            var order = await _ordersRepository.GetById(id);
            return (order == null) ? null : new OrdersUserDTO
            {
                Id = id,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt,
                User = MapToUserDTO(order.User)
            };
        }

        public async Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId)
        {
            var orders = await _ordersRepository.GetAllByUserId(userId);
            if (orders.Count() == 0)
                return null;
            var ordersDTO = new List<OrdersDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new OrdersDTO()
                {
                    Id = order.Id,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount,
                };
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        public async Task<int> Insert(OrdersInsertDTO ordersDTO)
        {
            try
            {
                var dateTimeNow = DateTime.Now;
                var orders = new Orders()
                {
                    UserId = ordersDTO.UserId,
                    CreatedAt = dateTimeNow,
                    Status = "A",
                    TotalAmount = 0
                };

                var resultOrderId = await _ordersRepository.Insert(orders);

                //Insert order detail
                var orderDetailList = new List<OrderDetail>();
                foreach (var item in ordersDTO.OrderDetail)
                {
                    var orderDetail = new OrderDetail()
                    {
                        OrdersId = resultOrderId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        CreatedAt = dateTimeNow,
                        ProductId = item.ProductId
                    };
                    orderDetailList.Add(orderDetail);
                }

                await _orderDetailRepository.Insert(orderDetailList);

                orders.TotalAmount = orderDetailList.Sum(od => od.Quantity * od.Price);

                return resultOrderId;

            }
            catch (Exception ex)
            {

                // Handle the exception
                return 0;
            }
        }
        private UserByIdResponseDTO MapToUserDTO(User user)
        {
            return new UserByIdResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                Address = user.Address,
                Email = user.Email
            };
        }

        public async Task<bool> Delete(int id)
        {
            return await _ordersRepository.Delete(id);
        }
    }
}
