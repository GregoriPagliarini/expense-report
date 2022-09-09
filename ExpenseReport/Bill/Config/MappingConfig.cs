using Bill.Data.ValueObjects;
using Bill.Model;
using AutoMapper;

namespace Bill.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<BillModelValueObject, BillModel>();
                config.CreateMap<BillModel, BillModelValueObject>();
            });
            return mapperConfiguration;
        }
    }
}
