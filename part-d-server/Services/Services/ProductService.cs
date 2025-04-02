//using AutoMapper;
//using Repositories.Entities;
//using Repositories.Interfaces;
//using Repositories.Repositories;
//using Services.Dtos;
//using Services.Interfaces;
//using Services.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Services.Services
//{
//    public class ProductService : IService<ProductDto>
//    {
//        private readonly IRepository<Product> _repository;
//        private readonly IMapper _mapper;

//        public ProductService(IRepository<Product> repository, IMapper mapper)
//        {
//            this._repository = repository;
//            this._mapper = mapper;
//        }

//        public ProductDto AddItem(ProductDto item)
//        {
//            return _mapper.Map<ProductDto>(_repository.AddItem(_mapper.Map<Product>(item)));
//        }

//        public ProductDto Get(int id)
//        {
//            return _mapper.Map<ProductDto>(_repository.Get(id));
//        }

//        public List<ProductDto> GetAll()
//        {
//            return _mapper.Map<List<ProductDto>>(_repository.GetAll());
//        }
//    }
//}