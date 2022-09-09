//using Auth.Data.ValueObjects;
using Auth.Model;
using AutoMapper;

namespace Auth.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                //config.CreateMap<BillModelVO, BillModel>();
            });
            return mapperConfiguration;
        }
    }
}
