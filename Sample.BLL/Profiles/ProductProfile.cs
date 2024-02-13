using AutoMapper;
using Sample.Common.Infrastructure.Models.Entities;
using Sample.Common.Infrastructure.Models.ViewModels;

namespace Sample.BLL.Profiles
{
    public class ProductProfile : Profile
    {

        /// <summary>
        /// Setting up mapping
        /// </summary>
        public ProductProfile()
        {
            CreateMap<Products, ProductsViewModel>();
        }
    }

}

