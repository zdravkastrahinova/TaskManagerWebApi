using AutoMapper;

namespace TaskManagerWebApi.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(map =>
            {
                map.AddProfile<AutoMapperModelProfile>();
            });
        }
    }
}