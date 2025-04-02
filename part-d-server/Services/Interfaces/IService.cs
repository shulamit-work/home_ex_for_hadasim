using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        T AddItem(T item);

    }

    public interface IProviderSerivce : IService<ProviderDto>
    {
        //ProviderDto AddProvider(ProviderDto provider, List<ProductDto> products);

    }
    public interface IOrderSerivce : IService<ProviderDto>
    {
        //ProviderDto AddProvider(ProviderDto provider, List<ProductDto> products);

    }
}
