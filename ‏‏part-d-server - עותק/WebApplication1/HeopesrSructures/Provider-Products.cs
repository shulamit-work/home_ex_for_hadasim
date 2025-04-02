
using Services.Dtos;

namespace WebApi.HeopesrSructures
{
    public class Provider_Products
    {
        public ProviderDto Provider { get; set; }
        public List<ProductDto> Products { get; set; }
        public Provider_Products(List<ProductDto> products, ProviderDto provider)
        {
            Products = products;
            Provider= provider;
        }
        public Provider_Products()
        {

        }
    }
}
