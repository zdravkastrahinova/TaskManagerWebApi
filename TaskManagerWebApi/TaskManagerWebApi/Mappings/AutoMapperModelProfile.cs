using AutoMapper;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Mappings
{
    public class AutoMapperModelProfile : Profile
    {
        public AutoMapperModelProfile() : base(nameof(AutoMapperModelProfile))
        {
            CreateMap<User, User>();
            CreateMap<Task, Task>();
            CreateMap<Note, Note>();
        }
    }
}