using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Service.Helpers.Mappers
{
    internal static class MapperGenericHelper<T,C>
    {
        public static C ToMapper(T model)
        {
            var config = new MapperConfiguration(mc => mc.CreateMap<T, C>());
            var mapper = new Mapper(config);

            return mapper.Map<T, C>(model);
        }
    }
}
