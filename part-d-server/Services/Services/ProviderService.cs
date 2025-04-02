using AutoMapper;
using Newtonsoft.Json;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProviderService : IProviderSerivce
    {
        private readonly IRepository<Provider> _repository;
        private readonly IRepository<Product> _prodRepo;
        private readonly IMapper _mapper;

        public ProviderService(IRepository<Provider> repository, IMapper mapper, IRepository<Product> prodRepo)
        {
            this._repository = repository;
            this._prodRepo = prodRepo;
            this._mapper = mapper;
        }

        public ProviderDto AddItem(ProviderDto item)
        {
            return _mapper.Map<ProviderDto>(_repository.AddItem(_mapper.Map<Provider>(item)));
        }

        //public ProviderDto AddProvider(ProviderDto provider, List<ProductDto> products)
        //{
        //    string pwd = provider.Password;

        //    if (!CheckIfValidatePwd(pwd))
        //        throw new ArgumentException("Password must contain upper and lower case letters, numbers, and special characters.");

        //    // hashing
        //    string hashPwd = PasswordManagerService.HashPassword(pwd);
        //    provider.Password = hashPwd;

        //    // add product 
        //    if (products.Count == 0)
        //    {
        //        return null;
        //    }

        //    // add the provider
        //    ProviderDto newProvider = AddItem(provider);
        //    //add his products
        //    List<ProductDto> productsList = products;// JsonConvert.DeserializeObject<List<ProductDto>>(products);
        //    foreach (ProductDto p in productsList)
        //    {
        //        p.ProviderId = newProvider.Id;
        //        _prodRepo.AddItem(_mapper.Map<Product>(p));
        //    }            
        //    return newProvider;
        //}
        private bool CheckIfValidatePwd(string pwd)
        {
            if (pwd.Length < 8 || pwd.Length > 20)
                return false;

            bool foundUp = false, foundLow = false, foundChar = false, foundNum = false;
            for (int i = 0; i < pwd.Length && !(foundChar && foundLow && foundUp && foundNum); i++)
            {
                if (Char.IsUpper(pwd[i]))
                    foundUp = true;
                else if (Char.IsLower(pwd[i]))
                    foundLow = true;
                else if (Char.IsDigit(pwd[i]))
                    foundNum = true;
                else
                    foundChar = true;
            }
            return foundChar && foundLow && foundUp && foundNum;
        }


        public ProviderDto Get(int id)
        {
            return _mapper.Map<ProviderDto>(_repository.Get(id));
        }

        public List<ProviderDto> GetAll()
        {
            return _mapper.Map<List<ProviderDto>>(_repository.GetAll());
        }
    }
}