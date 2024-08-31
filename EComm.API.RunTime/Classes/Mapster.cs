using EComm.API.BusinessDomain.DTOs;
using EComm.API.Infrastructure.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.RunTime.Classes
{
    public static class Mapster
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<ProductDTO, Product>
                .NewConfig();
            TypeAdapterConfig.GlobalSettings
            .NewConfig<CustomerDTO, Customer>()
            .IgnoreNonMapped(true);
        }
    }
}
//TypeAdapterConfig<ProductDTO, Product>
//               .NewConfig();
//var confiq = new TypeAdapterConfig();
//confiq
//.NewConfig<CustomerDTO, Customer>()
//.Ignore(dest => dest.PasswordSalt)
//.Ignore(dest => dest.UpdatedOn);