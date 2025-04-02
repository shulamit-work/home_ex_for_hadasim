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
    public class OwnerService : IService<OwnerDto>
    {
        private readonly IRepository<Owner> _repository;
        private readonly IMapper _mapper;

        public OwnerService(IRepository<Owner> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public OwnerDto AddItem(OwnerDto item)
        {
            return _mapper.Map<OwnerDto>(_repository.AddItem(_mapper.Map<Owner>(item)));
        }

        public OwnerDto Get(int id)
        {
            return _mapper.Map<OwnerDto>(_repository.Get(id));
        }

        public List<OwnerDto> GetAll()
        {
            return _mapper.Map<List<OwnerDto>>(_repository.GetAll());
        }
    }
}