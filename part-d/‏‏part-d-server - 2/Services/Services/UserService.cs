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
    public class UserService : IProviderSerivce
    {
        private readonly IRepository<User> _repository;
        private readonly IRepository<Product> _prodRepo;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper, IRepository<Product> prodRepo)
        {
            this._repository = repository;
            this._prodRepo = prodRepo;
            this._mapper = mapper;
        }

        public UserDto AddItem(UserDto item)
        {
            Console.WriteLine(item.Password);
            return _mapper.Map<UserDto>(_repository.AddItem(_mapper.Map<User>(item)));
        }

        public UserDto AddProvider(UserDto provider, List<ProductDto> products)
        {
            string pwd = provider.Password;

            if (!CheckIfValidatePwd(pwd))
                throw new ArgumentException("Password must contain upper and lower case letters, numbers, and special characters.");

            // hashing
            string hashPwd = PasswordManagerService.HashPassword(pwd);
            provider.Password = hashPwd;

            // add product 
            if (products.Count == 0)
            {
                return null;
            }

            // add the provider
            UserDto newProvider = AddItem(provider);
            //add his products
            List<ProductDto> productsList = products;// JsonConvert.DeserializeObject<List<ProductDto>>(products);
            foreach (ProductDto p in productsList)
            {
                p.UserId = newProvider.Id;
                _prodRepo.AddItem(_mapper.Map<Product>(p));
            }            
            return newProvider;
        }
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


        public UserDto Get(int id)
        {
            return _mapper.Map<UserDto>(_repository.Get(id));
        }

        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_repository.GetAll());
        }
    }
}