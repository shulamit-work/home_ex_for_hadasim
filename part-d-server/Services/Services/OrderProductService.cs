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
    public class OrderProductService : IService<OrderProductDto>
    {
        private readonly IRepository<OrderProduct> _repository;
        private readonly IMapper _mapper;

        public OrderProductService(IRepository<OrderProduct> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public OrderProductDto AddItem(OrderProductDto item)
        {
            return _mapper.Map<OrderProductDto>(_repository.AddItem(_mapper.Map<OrderProduct>(item)));
        }

        public OrderProductDto Get(int id)
        {
            return _mapper.Map<OrderProductDto>(_repository.Get(id));
        }

        public List<OrderProductDto> GetAll()
        {
            return _mapper.Map<List<OrderProductDto>>(_repository.GetAll());
        }
    }
}