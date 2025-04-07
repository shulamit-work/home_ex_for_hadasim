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
    public class OrderProductService : IOrderProductsService
    {
        private readonly IOrderProductRepo _repository;
        private readonly IRepository<Product> _prodRepo;
        private readonly IMapper _mapper;

        public OrderProductService(IOrderProductRepo repository, IMapper mapper, IRepository<Product> prodRepo)
        {
            this._repository = repository;
            this._prodRepo = prodRepo;
            this._mapper = mapper;
        }

        public OrderProductDto AddItem(OrderProductDto item)
        {
            Product product = _prodRepo.Get(item.ProductId);
            if (product == null || product.MinCount > item.Count)
                return null;
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

        public List<OrderProductDto> GetByOrderId(int id)
        {
           return _mapper.Map<List<OrderProductDto>>(_repository.GetByOrderId(id));
        }
    }
}