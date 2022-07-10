using AutoMapper;
using System;
using System.Collections.Generic;

namespace Hotel.Common.Helpers.Mappers
{
    public static class MapperGenericHelper<T,C>
    {
        public static C ToMapper(T model)
        {
            try
            {
                var config = new MapperConfiguration(mc => mc.CreateMap<T, C>());
                var mapper = new Mapper(config);

                return mapper.Map<T, C>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<C> ToMapperList(List<T> model)
        {
            try
            {
                List<C> list = new List<C>();

                model.ForEach(x => list.Add(ToMapper(x)));
                
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
