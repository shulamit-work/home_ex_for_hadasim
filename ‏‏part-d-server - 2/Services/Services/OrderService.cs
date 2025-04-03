using AutoMapper;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStatus = Repositories.Entities.OrderStatus;

namespace Services.Services
{
    public class OrderService : IOrderSerivce
    {
        private readonly IOrderRepo _repository;
        private readonly IService<MessageToProviderDto> _messageToProviderService;
        private readonly IService<OrderProductDto> _orderProdService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo repository, IMapper mapper, IService<OrderProductDto> orderProdServ, IService<MessageToProviderDto> messageToProviderServ)
        {
            this._repository = repository;
            this._orderProdService = orderProdServ;
            this._mapper = mapper;
            this._messageToProviderService = messageToProviderServ;
        }

        public OrderDto AddItem(OrderDto item)
        {
            Order o = _mapper.Map<Order>(item);
            Order newO = _repository.AddItem(o);
            return _mapper.Map<OrderDto>(newO);
        }

        public OrderDto AddOrder(OrderDto order, List<OrderProductDto> products)
        {
            if (products.Count == 0)
            {
                return null;
            }
            ///////////
            OrderDto newOrder = AddItem(order);
            if (newOrder == null)
            {
                return null;
            }

            List<OrderProductDto> newProducts = new List<OrderProductDto>();
            foreach (OrderProductDto op in products)
            {
                op.OrderId = newOrder.Id;
                newProducts.Add(_orderProdService.AddItem(op));
            }
            return newOrder;
        }

        public OrderDto ConfirmOrder(int id, bool isOwner)
        {
            OrderDto ret=null;
            Order o = _repository.Get(id);
            if (isOwner && (OrderStatus)o.Status == OrderStatus.PROCESSING)
            {
                ret = _mapper.Map<OrderDto>(_repository.ConfirmOrder(id, OrderStatus.DONE));
                MessageToProviderDto msg = new MessageToProviderDto(o.UserId, $"order number {o.Id} has confirmed right now");
                _messageToProviderService.AddItem(
                        msg
                    );
            }
            else if (!isOwner && (OrderStatus)o.Status == OrderStatus.NEW)
            {
                ret = _mapper.Map<OrderDto>(_repository.ConfirmOrder(id, OrderStatus.PROCESSING));
            }
            return ret;
        }

        public OrderDto Get(int id)
        {
            return _mapper.Map<OrderDto>(_repository.Get(id));
        }

        public List<OrderDto> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetAll());
        }

        public List<OrderDto> GetOrdersByProvderId(int providerId)
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetOrdersByProvderId(providerId));
        }
    }
}