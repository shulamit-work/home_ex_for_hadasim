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

namespace Services.Services
{
    public class OrderService : IService<OrderDto>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public OrderDto AddItem(OrderDto item)
        {

            OrderDto newO= _mapper.Map<OrderDto>(_repository.AddItem(_mapper.Map<Order>(item)));

        }

        public OrderDto Get(int id)
        {
            return _mapper.Map<OrderDto>(_repository.Get(id));
        }

        public List<OrderDto> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetAll());
        }
    }
}