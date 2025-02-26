using AutoMapper;
using ProjectManagementPlatform.Application.DTOs;
using ProjectManagementPlatform.Domain.Entities;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();

            CreateMap<Task, TaskDTO>();
            CreateMap<TaskDTO, Task>();
        }
    }
}