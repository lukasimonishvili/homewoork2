using Mapster;
using DOMAIN;

namespace API.DtoMapper
{
    public static class MappingConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<RespodentAutheDTO, Respodent>
                .NewConfig();

            TypeAdapterConfig<Respodent, RespodentDTO>
                .NewConfig();
        }
    }
}
