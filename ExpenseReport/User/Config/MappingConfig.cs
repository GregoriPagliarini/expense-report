using User.Data.ValueObjects;
using User.Model;
using AutoMapper;

namespace User.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<UserModelValueObject, UserModel>();
                config.CreateMap<UserModel, UserModelValueObject>();
            });
            return mapperConfiguration;
        }
    }
}
