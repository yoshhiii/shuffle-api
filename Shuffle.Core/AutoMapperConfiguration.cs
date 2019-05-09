using AutoMapper;

namespace Shuffle.Core
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AutoMapperConfiguration).Assembly));
            Mapper.AssertConfigurationIsValid();
        }
    }
}