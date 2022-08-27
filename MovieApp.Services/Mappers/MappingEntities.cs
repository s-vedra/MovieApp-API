using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Mappers
{
    public static class MappingEntities
    {
        public static TDestination Mapper<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = new Mapper(config);
            return mapper.Map<TDestination>(source);
        }
    }
}
