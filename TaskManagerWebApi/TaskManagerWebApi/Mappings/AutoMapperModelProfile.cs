using AutoMapper;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Mappings
{
    public class AutoMapperModelProfile : Profile
    {
        public AutoMapperModelProfile() : base(nameof(AutoMapperModelProfile))
        {
            CreateMap<User, User>()
                .ForMember(u => u.DateCreated, opt => opt.Ignore())
                .ForMember(u => u.DateUpdated, opt => opt.Ignore())
                .ForMember(u => u.IsDeleted, opt => opt.Ignore());

            CreateMap<Task, Task>()
                .ForMember(u => u.DateCreated, opt => opt.Ignore())
                .ForMember(u => u.DateUpdated, opt => opt.Ignore())
                .ForMember(u => u.IsDeleted, opt => opt.Ignore());

            CreateMap<Note, Note>()
                .ForMember(u => u.DateCreated, opt => opt.Ignore())
                .ForMember(u => u.DateUpdated, opt => opt.Ignore())
                .ForMember(u => u.IsDeleted, opt => opt.Ignore());
        }
    }
}