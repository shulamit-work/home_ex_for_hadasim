using AutoMapper;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MessageToProviderService : IMessageToProviderService
    {
        private readonly IMessageToProviderRepo _repository;
        private readonly IMapper _mapper;
        public MessageToProviderService(IMessageToProviderRepo repository , IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
        }

        public MessageToProviderDto AddItem(MessageToProviderDto item)
        {
            return _mapper.Map<MessageToProviderDto>(_repository.AddItem(_mapper.Map<MessageToProvider>(item)));
        }

        public MessageToProviderDto Get(int id)
        {
            throw new Exception();
        }

        public List<MessageToProviderDto> GetAll()
        {
            return _mapper.Map<List<MessageToProviderDto>>(_repository.GetAll());
        }

        public List<MessageToProviderDto> GetByProviderId(int providerId)
        {
            return _mapper.Map<List<MessageToProviderDto>>(_repository.GetByProviderId(providerId));
        }
    }
}
